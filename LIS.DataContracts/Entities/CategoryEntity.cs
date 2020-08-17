using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("tests_category")]
    public sealed class CategoryEntity : BaseEntity
    {
        [Column("category_id")]
        public long Id { get; set; }

        [Column("category_name")]
        public string Name { get; set; }
        
    }
}