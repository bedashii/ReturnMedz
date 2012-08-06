If you want to use this API in your *NON-COMMERCIAL* application, you MUST implement this method:

- public void processResult(int type, object result)
  In it you have to check the type value.
  If it's 0, then you must cast the result object to a IMDbTitle object and do whatever you want with it.
  If it's 1, then you must cast the result as a List<IMDbLink> object. 
  
  
To call the api, you have to add the reference to IMDBDLL and create an instance of IMDbManager.
After creating that instance, you must define some properties, like this:
  
  *global variable* IMDbManager manag;

  manag = new IMDbManager();
  manag.parentFunctionCaller = formFunctionCaller;
  
  manag.parentErrorCaller = formErrorCaller;
  manag.parentProgressUpdaterCaller = formProgressCaller;
  
then, you must call it like this: 

  manag.IMDbSearch(int searchMode, string text, int media, int nActors, int sSeas, int eSeas, bool[] fields);
  
where:
  - searchmode must be a 0 or a 1, to define if you want to query imdb by the title of the movie/TV serie or by an ID;
  - text is the query;
  - media is an integer 0 or 1, that defines if you want a movie or a tv serie;
  - nActors is an integer between -1 and 15, that defines how many actors you want to be parsed (-1 represents all);
  - sSeas is ant integer that defines the first season you want to start parsing to get episodes's info of a tv serie;
  - eSeas represents the last season you want to parse;
	- if sSeas or eSeas is equal to -1, than all the seasons are parsed;
  - fields is an array of bools, with 11 elements, each for a diferent field to be parsed.
	[0] - title;
	[1] - year;
	[2] - cover url;
	[3] - user rating;
	[4] - director/creator;
	[5] - seasons (episodes info of a tv serie);
	[6] - genres;
	[7] - tagline;
	[8] - plot;
	[9] - cast (info on actors);
	[10] - runtime;
	
If IMDb returns a search result list to the method processResul, you have to choose one of the items in that list and call
  manag.IMDbParse(*selected item url*);
If it finds only one title page, then it parses it automatically and returns an IMDbTitle object to the method processResul.
	
If you want to support this and future projects, don't forget to donate to my paypal account.
More info: 
	http://code.google.com/p/imdb-api/
	jpmassena@gmail.com
	