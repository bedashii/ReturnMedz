using FlowinglySDC.API.Configuration;
using FlowinglySDC.API.Models;
using FlowinglySDC.API.Services;
using Microsoft.Extensions.Options;

namespace FlowinglySDC.API.Tests.Services
{
    public class CostCalculatorTests
    {
        private readonly CostCalculator _calculator;
        private readonly SalesTaxConfig _taxConfig;

        public CostCalculatorTests()
        {
            _taxConfig = new SalesTaxConfig
            {
                Descriptor = "GST",
                Percentage = 15.0m,
                Currency = "NZD"
            };
            _calculator = new CostCalculator(Options.Create(_taxConfig));
        }

        [Fact]
        public void CalculateCosts_ValidTotal_CalculatesSalesTaxCorrectly()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                TotalCost = 1024.01m
            };

            var result = _calculator.CalculateCosts(validationResult);

            Assert.Equal(1024.01m * 0.15m, result.SalesTaxValue);
        }

        [Fact]
        public void CalculateCosts_ValidTotal_CalculatesTotalExcludingSalesTax()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                TotalCost = 1024.01m
            };

            var result = _calculator.CalculateCosts(validationResult);

            var expectedTax = 1024.01m * 0.15m;
            Assert.Equal(1024.01m - expectedTax, result.TotalExcludingSalesTax);
        }

        [Fact]
        public void CalculateCosts_ZeroTotal_ReturnsZeroValues()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                TotalCost = 0m
            };

            var result = _calculator.CalculateCosts(validationResult);

            Assert.Equal(0m, result.SalesTaxValue);
            Assert.Equal(0m, result.TotalExcludingSalesTax);
        }

        [Fact]
        public void CalculateCosts_PopulatesSalesTaxConfigValues()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                TotalCost = 100m
            };

            var result = _calculator.CalculateCosts(validationResult);

            Assert.Equal("GST", result.SalesTaxDescriptor);
            Assert.Equal("15.0", result.SalesTaxPercentage);
            Assert.Equal("NZD", result.SalesTaxCurrency);
        }

        [Fact]
        public void CalculateCosts_LargeTotal_CalculatesCorrectly()
        {
            var validationResult = new UserMessageValidationResult
            {
                IsValid = true,
                TotalCost = 35000m
            };

            var result = _calculator.CalculateCosts(validationResult);

            Assert.Equal(5250m, result.SalesTaxValue);
            Assert.Equal(29750m, result.TotalExcludingSalesTax);
        }
    }
}
