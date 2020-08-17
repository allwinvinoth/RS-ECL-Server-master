using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("organisations")]
    public sealed class OrganisationEntity : BaseEntity
    {
        [Key] [Column("organisation_id")] public int Id { get; set; }
        [Column("name")] public string Name { get; set; }
    }
}
