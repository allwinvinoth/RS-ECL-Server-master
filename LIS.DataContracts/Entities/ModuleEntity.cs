using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("modules")]
    public sealed class ModuleEntity : BaseEntity
    {

        [Key] [Column("module_id")] 
        public int Id { get; set; }

        [Column("name")] 
        public string Name { get; set; }

        [Column("organisation_id")] 
        public int OrganisationId { get; set; }
    }
}