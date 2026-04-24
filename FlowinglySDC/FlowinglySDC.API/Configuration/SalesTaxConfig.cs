namespace FlowinglySDC.API.Configuration
{
    public class SalesTaxConfig
    {
        public string Descriptor { get; set; } = string.Empty;

        public decimal Percentage { get; set; }

        public string Currency { get; set; } = string.Empty;
    }
}
