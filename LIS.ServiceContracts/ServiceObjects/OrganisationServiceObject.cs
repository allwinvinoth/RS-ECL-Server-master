using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class OrganisationServiceObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
