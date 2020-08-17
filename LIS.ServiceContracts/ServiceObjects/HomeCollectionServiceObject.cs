using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class HomeCollectionServiceObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GenderId { get; set; }

        public string Organization { get; set; }

        public long DoctorId { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Comment { get; set; }

        public GenderServiceObject Gender { get; set; }
    }
}
