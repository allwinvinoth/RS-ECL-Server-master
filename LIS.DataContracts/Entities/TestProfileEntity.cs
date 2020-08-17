using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("Test_Profiles")]
    public sealed class TestProfileEntity : BaseEntity
    {
        [Key]
        [Column("test_profile_id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("outsource_id")]
        public long OutsourceId { get; set; }


        [Column("integration_code")]
        public string IntegrationCode { get; set; }

        [Column("minimum_selling_price")]
        public decimal MinimumSellingPrice { get; set; }

        [Column("revenue_cap")]
        public decimal RevenueCap { get; set; }

        [Column("profile_price")]
        public decimal ProfilePrice { get; set; }
    }
}