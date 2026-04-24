If the solution is being executed via Visual Studio, please ensure that both the FlowinglySDC.Web and FlowinglySDC.API project are set as startup projects in the FlowinglySDC solution file. Both the FlowinglySDC.Web and API projects are .NET 10.0 projects.

This is a no-code solution, everything was written entirely using GitHub CoPilot with the Claud Opus 4.6 AI model using Agent mode. The entire solution was written using 5 prompts to ensure no tokens are wasted (the prompts can be found below). Every line of code was thouroughly reviewed before acceptance. Certain aspects that would be implemented in a real-world solution was omitted from this challange. These include security concerns, more sleek and modern styling, and specific error messages (e.g. if the <total> tag has invalid data, like 35.2xx3, a general error message is displayed). These were standards where sacrificied to maintain readability of code. 


If the solution is being executed via Visual Studio, please ensure that both the FlowinglySDC.Web and FlowinglySDC.API project are set as startup projects in the FlowinglySDC solution file.

This is a no-code solution, everything was written entirely using GitHub CoPilot with the Claud Opus 4.6 AI model using Agent mode. The entire solution was written using 5 prompts (the prompts can be found below). Every line of code was thoroughly reviewed before acceptance. Certain aspects that would be implemented in a real-world solution was omitted from this challenge. These include security concerns, more sleek and modern styling, and specific error messages (e.g. if the <total> tag has invalid data, like 35.2xx3, a general error message is displayed). These standards were sacrificed to maintain readability of code.


AI Prompts:

Prompt 1: This sets up the project for me. Here I create everything as I would
without AI. The way this prompt is structured creates a coding pattern that is
easy read and also ensures best coding practices.
=

Overview:
We're going to create the foundation for an app which allows the user to paste text which contains XML. The text will be sent to an API which will perform calculations and provide a JSON response.

Main Components:
Frontend
API


API (Project Name - FlowinglySDC.API):
Create a config file for the API that has the following:
SalesTaxDescriptor
SalesTaxPercentage
SalesTaxCurrency

Create the following classes for the API:

SalesTaxConfig: This object should contain the values of the SalesTaxConfig settings and should be populated on API startup. The properties should follow the config settings (i.e. Descriptor, Percentage, Currency).

DataExtract: This object will hold the XML tags and daata extracted from the message. This object should have  properties called TagName and TagData, both of type string. It should also have a property called IsValid of type boolean (default false).

UserMessageValidationResult: This object will be used in other classes for operations. This object should have the following properties: IsValid (boolean, default FALSE), CostCentreDescription (string, default 'UNKNOWN'), TotalCost(decimal), a List of DataExtract. In the constructor of this class, set the defaults and construct the List property.

UserMessageValidator: This class should have a public function called Validate that accepts a string and should respond with a UserMessageValidationResult object. Extract the data from the string and ensure the following:
The string contains XML tags
- Each XML tag is valid (e.g. has an opening and closing tag or is self-closing, etc)
- That a <total> tag is present.
If these two conditions are true, populate IsValid with true and populate UserMessageValidationResult.TotalCost with the data inside the <total> tag. If the  data in the <total> tag is 0 or empty, default to 0 however, if the tag contains invalid decimal data, set IsValid to false and continue validating the rest of the data. Validate(string)'s final task will be to check if a <cost_centre> tag is present in the text. If it is, populate UserMessageValidationResult.CostCentreDescription with the data inside the <cost_centre> tag. While the data is being extracted and validated, if an XML tag is found, the tag and its data should be added to UserMessageValidationResult.DataExtract, the IsValid property of the DataExtract object needs to be set accordingly too. This is true for all XML tags found except for <cost_centre> and <total>. Break up the validations further into the following private functions - ValidateTotalTag, ValidateXMLTags, PopulateTotal, PopulateCostCentreDescription, PopulateDataExtract

UserMessageCalculationResult: This object will be used in other classes for operations. This object should have the following properties: SalesTaxValue (decimal), TotalExcludingSalesTax (decimal), SalesTaxDescriptor (string), SalesTaxPercentage (string), SalesTaxCurrency (string).

CostCalculator: This class should have a public function called CalculateCosts and accepts the UserMessageValidationResult object and returns UserMessageCalculationResult. Create a private function called CalculateSalesTax, this function will return the following calculation: what is SalesTaxConfig.Percentage of UserMessageValidationResult.TotalCost, this value should stored in UserMessageCalculationResult.SalesTaxValue. Another private function will be CalculateTotalExcludingSalesTax, this function will return the difference between UserMessageValidationResult.TotalCost and UserMessageCalculationResult.SalesTaxValue, this value should be stored in UserMessageCalculationResult.TotalExcludingSalesTax. The final private function will be PopulateSalesTaxConfigValues, this function simply populates the SalesTax properties on UserMessageCalculationResult with their appropriate values.

JsonParser: This class will have a public function called ParseUserMessage and accepts 3 parameters, UserMessageValidationResult, UserMessageCalculationResult, OriginalMessage. The function should return a valid Json string. This Json object should have and be populated with the following properties:
SalesTaxValue (retrieved from UserMessageCalculationResult)
TotalExcludingSalesTax (retrieved from UserMessageCalculationResult)
CostCentreDescription (retrieved from UserMessageValidationResult)
OriginalMessageAsJson (populated with the OriginalMessage variable, however, the message should be escaped accordingly).

Create the following endpoints for the API:
ValidateUserMessage - This endpoint will accept a string, it will pass that string onto UserMessageValidator.Validate and return UserMessageValidationResult

CalculateUserMessageCosts - This endpoint will accept a string and pass that string onto UserMessageValidator.Validate. It will then pass on the result of Validate() to CostCalculator.CalculateCosts. It will then pass the results of Validate(), CalculateCosts() and the original incoming string parameter onto JsonParser.ParseUserMessage. Finally, the endpoint will return the json object resulting from ParseUserMessage.


Frontend:
The frontend needs to be written in React. It should contain a two text areas side by side with a margin in between. One that allows the user to paste the text and another read only text area that will display the result of the CalculateUserMessageCosts API call. There is no expected format for the text input however, any XML should be highlighted in the text area. Any valid XML (tags and data) should be highlighted in green. Below the input text box should be a button which allows the user to submit the data. The size of the combined text areas should be the width of the browser (leaving some area for a margin) and the height should be three quaters of the browser. The input text area should be a self-contained component, the logic for this component should be done in a TypeScript file. All API calls (ajax or http protocol) needs to be done via the view's controller and not via TypeScript.

When the user inputs data in the text area, after 3 seconds of inactivity (by the user), an asynchronous ajax call should be done to the API and the ValidateUserMessage endpoint should be called. The result of this API call will contain UserMessageValidationResult.DataExtract. This DataExtract list should be used to determine which XML tags to highlight for the text area.

When the submit button is clicked, the CalculateUserMessageCosts should be called. The result needs to be displayed as formatted json in the read only text area. When the user clicks on the read only text area, the text needs to be copied to the clipboard. When this action is performed, briefly highlight the text area and display a toast notification to the user that the text was copied. Add an IgnoreAntiforgeryToken attribute to the Index controller to ensure the WebApp can communicate with the API. Ensure there is sufficient margin and padding on both text areas.

Rules to follow:
Always remember and follow SOLID principles, seperate concerns accorrdingly. Do not place functional code in base classes (i.e. do not add endpoints to program.cs), instead create the relavent files. Readability should always be prefered over code reduction.




Prompt 2: The XML was not validating correctly. I identified that there was a
problem with the regex.
=
Something's wrong with the validation process, this is an example of the text being used:

Hi Patricia, Please create an expense claim for the below. Relevant details are marked up as requested... <expense><cost_centre>DEV632</cost_centre><total>35,000</total><payment_method>personal card</payment_method></expense>

The  expense and payment_method tags are being highlighted as invalid, however, they are valid.




Prompt 3: The regex was fixed but the overall validation process was not
accounting for isolated blocks of XML, this prompt fixed that issue.
=
The validation process needs to be updated. It currently handles entire blocks of XML fine, as with my previous example. However, if there are isolated pieces of XML, it does not seem to validate correctly, e.g:

From: William Steele Sent: Friday, 16 June 2022 10:32 AM To: Maria Washington Subject: test Hi Maria, Please create a reservation for 10 at the <vendor>Seaside Steakhouse</vendor> for our <description>development team’s project end celebration</description> on <date>27 April 2022</date> at 7.30pm. Regards, William


These tags are all valid however, the calculation bit as a whole is invalid because its missing the <total> tag.




Prompt 4: Here I addressed issues uncovered during testing
=
1.	When a message is submitted and the <cost> tag is missing, the Json should not be displayed. Instead a message (in the read only text area) should be displayed notifying the user of the error.

2.	When a message is submitted and the message contains an invalid tag, the Json should not be displayed. Instead a message (in the read only text area) should be displayed notifying the user of the error.

3.	When the submit button is clicked, first perform the OnPostValidateAsync before the OnPostCalculateAsync so that the text is highlighted before the json result (or error message) is displayed

4.	There seems to be overrlapping with the colours highlighting the text. Make sure that only the tags and its data is highlighted. Only highlight an area once, e.g.: <description><total_costs>3938</total_costs>The Descript</description> In the above example, total_costs and its data should only be highlighted once, despite being inside the description tag




Prompt 5: Testing and styling cleanup is always left for the end, this ensures
that the prompts before this complete faster (instead of updating tests and
styling for each change made)
=
1.	Create integration tests, one for each Action on the Controller of the web app. For each Action, create a test that handles the following:
•	Valid data
•	Data missing total tag (expected error message)
•	Data that has an invalid XML tag (expected error message)
•	Data where the cost centre is missing (expected CostCentreDescription in Json should be UNKNOWN


2.	Create unit tests for the API to ensure the primary functions of each service (CostCaluclator, JsonParser and UserMessageValidator) works correctly


3.	Move all of the styling in the Index view to css a file, hook up those CSS classes accordingly
