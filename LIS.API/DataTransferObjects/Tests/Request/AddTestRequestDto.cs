namespace LIS.API.DataTransferObjects.Tests.Request
{
    public sealed class AddTestRequestDto
    {
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
        
        public float Price { get; set; }

        public float Price2 { get; set; }

        public float MinimumSellingPrice { get; set; }

        public float Cost { get; set; }
        
        public float RevenueCAP { get; set; }

        public long CategoryId { get; set; }

        public int DepartmentId { get; set; }

        public int TargetTATDays { get; set; }
        
        public int TargetTATHours { get; set; }
        
        public int TargetTATMinutes { get; set; }
    }
}