using System.Text.Json;
using FlowinglySDC.API.Models;

namespace FlowinglySDC.API.Services
{
    public class JsonParser
    {
        public string ParseUserMessage(
            UserMessageValidationResult validationResult,
            UserMessageCalculationResult calculationResult,
            string originalMessage)
        {
            var resultObject = new
            {
                SalesTaxValue = calculationResult.SalesTaxValue,
                TotalExcludingSalesTax = calculationResult.TotalExcludingSalesTax,
                CostCentreDescription = validationResult.CostCentreDescription,
                OriginalMessageAsJson = originalMessage
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            return JsonSerializer.Serialize(resultObject, options);
        }
    }
}
