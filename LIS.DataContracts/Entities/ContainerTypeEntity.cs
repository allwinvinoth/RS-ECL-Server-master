using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("container_types")]
    public class ContainerTypeEntity : BaseEntity
    {
        [Key] [Column("container_type_id")] public int Id { get; set; }

        [Column("container_type_name")] public string Name { get; set; }
    }
}
