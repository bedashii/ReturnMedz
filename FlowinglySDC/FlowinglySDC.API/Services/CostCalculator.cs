using FlowinglySDC.API.Configuration;
using FlowinglySDC.API.Models;
using Microsoft.Extensions.Options;

namespace FlowinglySDC.API.Services
{
    public class CostCalculator
    {
        private readonly SalesTaxConfig _salesTaxConfig;

        public CostCalculator(IOptions<SalesTaxConfig> salesTaxConfig)
        {
            _salesTaxConfig = salesTaxConfig.Value;
        }

        public UserMessageCalculationResult CalculateCosts(UserMessageValidationResult validationResult)
        {
            var calculationResult = new UserMessageCalculationResult();

            calculationResult.SalesTaxValue = CalculateSalesTax(validationResult.TotalCost);
            calculationResult.TotalExcludingSalesTax = CalculateTotalExcludingSalesTax(validationResult.TotalCost, calculationResult.SalesTaxValue);
            PopulateSalesTaxConfigValues(calculationResult);

            return calculationResult;
        }

        private decimal CalculateSalesTax(decimal totalCost)
        {
            return totalCost * (_salesTaxConfig.Percentage / 100m);
        }

        private decimal CalculateTotalExcludingSalesTax(decimal totalCost, decimal salesTaxValue)
        {
            return totalCost - salesTaxValue;
        }

        private void PopulateSalesTaxConfigValues(UserMessageCalculationResult calculationResult)
        {
            calculationResult.SalesTaxDescriptor = _salesTaxConfig.Descriptor;
            calculationResult.SalesTaxPercentage = _salesTaxConfig.Percentage.ToString();
            calculationResult.SalesTaxCurrency = _salesTaxConfig.Currency;
        }
    }
}
