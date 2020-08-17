using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("sample_types")]
    public class SampleTypeEntity : BaseEntity
    {
        [Key][Column("sample_type_id")] public int Id { get; set; }

        [Column("sample_type_name")] public string Name { get; set; }        
    }
}
