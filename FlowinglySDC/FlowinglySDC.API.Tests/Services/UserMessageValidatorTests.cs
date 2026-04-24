using FlowinglySDC.API.Services;

namespace FlowinglySDC.API.Tests.Services
{
    public class UserMessageValidatorTests
    {
        private readonly UserMessageValidator _validator = new();

        [Fact]
        public void Validate_ValidMessageWithAllTags_ReturnsIsValidTrue()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var result = _validator.Validate(message);

            Assert.True(result.IsValid);
            Assert.Equal("DEV632", result.CostCentreDescription);
            Assert.Equal(1024.01m, result.TotalCost);
        }

        [Fact]
        public void Validate_MissingTotalTag_ReturnsIsValidFalse()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><payment_method>personal card</payment_method></expense>";

            var result = _validator.Validate(message);

            Assert.False(result.IsValid);
            Assert.Equal(0m, result.TotalCost);
        }

        [Fact]
        public void Validate_InvalidXmlUnclosedTag_ReturnsIsValidFalse()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</expense>";

            var result = _validator.Validate(message);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_MissingCostCentre_ReturnsCostCentreAsUnknown()
        {
            var message = "<expense><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var result = _validator.Validate(message);

            Assert.True(result.IsValid);
            Assert.Equal("UNKNOWN", result.CostCentreDescription);
        }

        [Fact]
        public void Validate_NoXmlTags_ReturnsIsValidFalse()
        {
            var message = "This is a plain text message with no tags.";

            var result = _validator.Validate(message);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_TotalTagWithZero_ReturnsTotalCostZero()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>0</total></expense>";

            var result = _validator.Validate(message);

            Assert.True(result.IsValid);
            Assert.Equal(0m, result.TotalCost);
        }

        [Fact]
        public void Validate_IslandXmlTags_ExtractsDataCorrectly()
        {
            var message = "Please book at <vendor>Seaside Steakhouse</vendor> for <description>team celebration</description> on <date>27 April 2022</date>.";

            var result = _validator.Validate(message);

            Assert.False(result.IsValid);
            Assert.Equal(3, result.DataExtract.Count);
            Assert.Contains(result.DataExtract, d => d.TagName == "vendor" && d.TagData == "Seaside Steakhouse");
            Assert.Contains(result.DataExtract, d => d.TagName == "description" && d.TagData == "team celebration");
            Assert.Contains(result.DataExtract, d => d.TagName == "date" && d.TagData == "27 April 2022");
        }

        [Fact]
        public void Validate_ValidMessage_PopulatesDataExtract()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var result = _validator.Validate(message);

            Assert.Contains(result.DataExtract, d => d.TagName == "payment_method" && d.TagData == "personal card");
            Assert.DoesNotContain(result.DataExtract, d => d.TagName == "cost_centre");
            Assert.DoesNotContain(result.DataExtract, d => d.TagName == "total");
        }
    }
}
