using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class LogisticAndServiceObject
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Clinic { get; set; }

        public string CalledBy { get; set; }

        public int DriverId { get; set; }

        public UserServiceObject Driver { get; set; }

        public int NoOfTRFs { get; set; }

        public string Temperature { get; set; }

        public bool Stat { get; set; }

        public string Remarks { get; set; }

        public string Signature { get; set; }

        public ICollection<LogisticAndLogisticTypeSeviceObject> LogisticAndLogisticTypes{ get; set; }

        public IEnumerable<LogisticAndSpecimenServiceObject> LogisticSpecimenTypes { get; set; }
    }
}
