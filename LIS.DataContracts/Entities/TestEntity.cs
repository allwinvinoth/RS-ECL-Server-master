using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("tests")]
    public sealed class TestEntity : BaseEntity
    {
        [Key]
        [Column("test_id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("test_code")]
        public string TestCode { get; set; }

        [Column("short_text")]
        public string ShortText { get; set; }

        [Column("integration_code")]
        public string IntegrationCode { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_auto_dispatch")]
        public bool IsAutoDispatch { get; set; }

        [Column("is_billonly_test")]
        public bool IsBillOnlyTest { get; set; }

        [Column("is_report_masked")]
        public bool IsReportMasked { get; set; }

        [Column("is_nabl_test")]
        public bool IsNABLTest { get; set; }

        [Column("is_na")]
        public bool IsNA { get; set; }

        [Column("is_print_priority_na")]
        public bool IsPrintPriorityNA { get; set; }

        [Column("is_outsource_test")]
        public bool IsOutSourceTest { get; set; }

        [Column("is_discard_discount")]
        public bool IsDiscardDiscount { get; set; }

        [Column("is_cap")]
        public bool IsCAP { get; set; }

        [Column("is_no_report_to_patient")]
        public bool IsNoReportToPatient { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("price2")]
        public decimal Price2 { get; set; }

        [Column("minimum_selling_price")]
        public decimal MinimumSellingPrice { get; set; }

        [Column("cost")]
        public decimal Cost { get; set; }

        [Column("revenue_cap")]
        public decimal RevenueCAP { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("target_tat_days")]
        public int TargetTATDays { get; set; }

        [Column("target_tat_hours")]
        public int TargetTATHours { get; set; }

        [Column("target_tat_minute")]
        public int TargetTATMinutes { get; set; }

        [Column("department_id")]
        public int DepartmentId { get; set; }
    }
}