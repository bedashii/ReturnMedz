namespace FlowinglySDC.API.Models
{
    public class UserMessageCalculationResult
    {
        public decimal SalesTaxValue { get; set; }

        public decimal TotalExcludingSalesTax { get; set; }

        public string SalesTaxDescriptor { get; set; } = string.Empty;

        public string SalesTaxPercentage { get; set; } = string.Empty;

        public string SalesTaxCurrency { get; set; } = string.Empty;
    }
}
