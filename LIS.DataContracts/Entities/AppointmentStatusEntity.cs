using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("appointment_status")]
    public sealed class AppointmentStatusEntity:BaseEntity
    {
        [Key][Column("appointment_status_id")] public int Id { get; set; }

        [Column("status")] public string Status { get; set; }
    }
}
