using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class LookupServiceObject
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
