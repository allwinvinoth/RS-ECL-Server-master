using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("branches")]
    public sealed class BranchEntity:BaseEntity
    {
        [Key] [Column("branch_id")] public int Id { get; set; }

        [Column("name")] public string Name { get; set; }

        [Column("organisation_id")] public int OrganisationId { get; set; }
    }
}
