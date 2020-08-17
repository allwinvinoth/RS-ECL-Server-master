using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class UserServiceObject
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PrimaryEmail { get; set; }

        public string SecondaryEmail { get; set; }

        public string PrimaryContactNumber { get; set; }

        public string SecondaryContactNumber { get; set; }

        public string Comments { get; set; }

        public int GenderId { get; set; }

        public long ModifiedBy { get; set; }
    }
}
