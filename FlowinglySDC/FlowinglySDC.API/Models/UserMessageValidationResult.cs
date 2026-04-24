namespace FlowinglySDC.API.Models
{
    public class UserMessageValidationResult
    {
        public bool IsValid { get; set; }

        public string CostCentreDescription { get; set; }

        public decimal TotalCost { get; set; }

        public List<DataExtract> DataExtract { get; set; }

        public UserMessageValidationResult()
        {
            IsValid = false;
            CostCentreDescription = "UNKNOWN";
            TotalCost = 0;
            DataExtract = new List<DataExtract>();
        }
    }
}
