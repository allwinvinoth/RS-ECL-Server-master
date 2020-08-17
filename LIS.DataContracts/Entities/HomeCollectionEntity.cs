using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("home_collection")]
    public sealed class HomeCollectionEntity : BaseEntity
    {
        [Key] [Column("home_collection_id")] public int Id { get; set; }

        [Column("patient_name")] public string Name { get; set; }

        [Column("mobile_number")] public string MobileNumber { get; set; }

        [Column("phone_number")] public string PhoneNumber { get; set; }

        [Column("email")] public string Email { get; set; }

        [Column("date_of_birth")] public DateTime DateOfBirth { get; set; }

        [Column("gender_id")] public int GenderId { get; set; }

        [Column("referral_organization")] public string Organization { get; set; }

        [Column("referral_doctor_id")] public long DoctorId { get; set; }

        [Required] [Column("scheduled_date")] public DateTime ScheduledDate { get; set; }

        [Column("area")] public string Area { get; set; }

        [Column("city")] public string City { get; set; }

        [Column("postal_code")] public string PostalCode { get; set; }

        [Column("country")] public string Country { get; set; }

        [Column("comment")] public string Comment { get; set; }

        public GenderEntity Gender { get; set; }
    }
}
