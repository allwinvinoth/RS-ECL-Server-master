using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("appointments")]
    public sealed class AppointmentEntity : BaseEntity
    {
        [Column("appointment_id")] public long Id { get; set; }

        [Column("appointment_date_from")] public DateTime From { get; set; }

        [Column("appointment_date_to")] public DateTime To { get; set; }

        [Column("comment")] public string Comment { get; set; }

        [Required] [Column("name")] public string Name { get; set; }

        [Column("email")] public string Email { get; set; }

        [Column("date_of_birth")] public DateTime? DateOfBirth { get; set; }

        [Column("primary_phone_number")] public string PrimaryPhoneNumber { get; set; }

        [Column("secondary_phone_number")] public string SecondaryPhoneNumber { get; set; }

        [Column("appointment_status_id")] public int AppointmentStatusId { get; set; }

        public AppointmentStatusEntity AppointmentStatus { get; set; }
    }
}
