using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("samples")]
    public sealed class SampleEntity : BaseEntity
    {
        [Key] [Column("sample_id")] public int Id { get; set; }

        [Column("name")] public string Name { get; set; }

        [Column("accession_id")] public int AccessionId { get; set; }

        [Column("sample_type_id")] public int SampleTypeId { get; set; }

        [Column("container_type_id")] public int ContainerTypeId { get; set; }

        [Column("description")] public string Description { get; set; }

        [Column("instruction")] public string Instruction { get; set; }

        [Column("is_prefix")] public bool IsPrefix { get; set; }

        public SampleTypeEntity SampleType { get; set; }

        public ContainerTypeEntity ContainerType { get; set; }
    }
}
