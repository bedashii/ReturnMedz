using FlowinglySDC.API.Models;
using FlowinglySDC.API.Services;
using System.Text.Json;

namespace FlowinglySDC.API.Tests.Services
{
    public class JsonParserTests
    {
        private readonly JsonParser _parser = new();

        [Fact]
        public void ParseUserMessage_ValidInput_ContainsSalesTaxValue()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                CostCentreDescription = "DEV632",
                TotalCost = 1024.01m
            };
            var calculationResult = new UserMessageCalculationResult
            {
                SalesTaxValue = 153.6015m,
                TotalExcludingSalesTax = 870.4085m
            };
            var originalMessage = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total></expense>";

            var json = _parser.ParseUserMessage(validationResult, calculationResult, originalMessage);
            var doc = JsonDocument.Parse(json);

            Assert.Equal(153.6015m, doc.RootElement.GetProperty("SalesTaxValue").GetDecimal());
        }

        [Fact]
        public void ParseUserMessage_ValidInput_ContainsTotalExcludingSalesTax()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                CostCentreDescription = "DEV632",
                TotalCost = 1024.01m
            };
            var calculationResult = new UserMessageCalculationResult
            {
                SalesTaxValue = 153.6015m,
                TotalExcludingSalesTax = 870.4085m
            };
            var originalMessage = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total></expense>";

            var json = _parser.ParseUserMessage(validationResult, calculationResult, originalMessage);
            var doc = JsonDocument.Parse(json);

            Assert.Equal(870.4085m, doc.RootElement.GetProperty("TotalExcludingSalesTax").GetDecimal());
        }

        [Fact]
        public void ParseUserMessage_ValidInput_ContainsCostCentreDescription()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                CostCentreDescription = "DEV632",
                TotalCost = 1024.01m
            };
            var calculationResult = new UserMessageCalculationResult
            {
                SalesTaxValue = 153.6015m,
                TotalExcludingSalesTax = 870.4085m
            };
            var originalMessage = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total></expense>";

            var json = _parser.ParseUserMessage(validationResult, calculationResult, originalMessage);
            var doc = JsonDocument.Parse(json);

            Assert.Equal("DEV632", doc.RootElement.GetProperty("CostCentreDescription").GetString());
        }

        [Fact]
        public void ParseUserMessage_ValidInput_ContainsOriginalMessage()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                CostCentreDescription = "DEV632",
                TotalCost = 1024.01m
            };
            var calculationResult = new UserMessageCalculationResult
            {
                SalesTaxValue = 153.6015m,
                TotalExcludingSalesTax = 870.4085m
            };
            var originalMessage = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total></expense>";

            var json = _parser.ParseUserMessage(validationResult, calculationResult, originalMessage);
            var doc = JsonDocument.Parse(json);

            Assert.Equal(originalMessage, doc.RootElement.GetProperty("OriginalMessageAsJson").GetString());
        }

        [Fact]
        public void ParseUserMessage_MissingCostCentre_ContainsUnknown()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                CostCentreDescription = "UNKNOWN",
                TotalCost = 500m
            };
            var calculationResult = new UserMessageCalculationResult
            {
                SalesTaxValue = 75m,
                TotalExcludingSalesTax = 425m
            };
            var originalMessage = "<expense><total>500</total></expense>";

            var json = _parser.ParseUserMessage(validationResult, calculationResult, originalMessage);
            var doc = JsonDocument.Parse(json);

            Assert.Equal("UNKNOWN", doc.RootElement.GetProperty("CostCentreDescription").GetString());
        }

        [Fact]
        public void ParseUserMessage_ReturnsValidJson()
        {
            var validationResult = new UserMessageValidationResult();
            var calculationResult = new UserMessageCalculationResult();
            var originalMessage = "test";

            var json = _parser.ParseUserMessage(validationResult, calculationResult, originalMessage);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
            var doc = JsonDocument.Parse(json);
            Assert.NotNull(doc);
        }
    }
}
