using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("users")]
    public sealed class UserEntity : BaseEntity
    {
        [Key] [Column("user_id")] public long Id { get; set; }

        [Required] [Column("name")] public string Name { get; set; }

        [Column("date_of_birth")] public DateTime? DateOfBirth { get; set; }

        [Column("primary_email")] public string PrimaryEmail { get; set; }

        [Column("secondary_email")] public string SecondaryEmail { get; set; }

        [Column("primary_contact_number")] public string PrimaryContactNumber { get; set; }

        [Column("secondary_contact_number")] public string SecondaryContactNumber { get; set; }

        [Column("comments")] public string Comments { get; set; }

        [Column("gender_id")] public int GenderId { get; set; }

        [Column("modified_by")] public long ModifiedBy { get; set; }
    }
}
