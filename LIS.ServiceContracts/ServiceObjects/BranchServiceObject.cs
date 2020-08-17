using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class BranchServiceObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrganisationId { get; set; }

        public bool? IsActive { get; set; }
    }
}
