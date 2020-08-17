using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("modules_pages_mapping")]
    public sealed class ModulePageMappingEntity : BaseEntity
    {
        [Key] [Column("modules_pages_mapping_id")] public int Id { get; set; }

        [Column("module_id")] public int ModuleId { get; set; }

        [Column("page_id")] public int PageId { get; set; }
    }
}