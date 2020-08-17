using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("pages")]
    public sealed class PageEntity : BaseEntity
    {
        [Key] 
        [Column("page_id")] 
        public int Id { get; set; }

        [Column("name")] 
        public string Name { get; set; }

        [Column("organisation_id")] 
        public int OrganisationId { get; set; }
    }
}