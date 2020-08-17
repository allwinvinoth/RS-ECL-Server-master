namespace LIS.API.DataTransferObjects.Tests.Response
{
    public sealed class GetTestResponseDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string TestCode { get; set; }

        public string ShortText { get; set; }

        public string IntegrationCode { get; set; }
        
        public string Description { get; set; }

        public bool IsAutoDispatch { get; set; }

        public bool IsBillOnlyTest { get; set; }

        public bool IsReportMasked { get; set; }

        public bool IsNABLTest { get; set; }

        public bool IsNA { get; set; }

        public bool IsPrintPriorityNA { get; set; }

        public bool IsOutSourceTest { get; set; }

        public bool IsDiscardDiscount { get; set; }

        public bool IsCAP { get; set; }

        public bool IsNoReportToPatient { get; set; }
        
        public decimal Price { get; set; }

        public decimal Price2 { get; set; }

        public decimal MinimumSellingPrice { get; set; }

        public decimal Cost { get; set; }
        
        public decimal RevenueCAP { get; set; }
        
        public int TargetTATDays { get; set; }
        
        public int TargetTATHours { get; set; }
        
        public int TargetTATMinutes { get; set; }
    }
}