using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Lookup.Response
{
    public sealed class LookupResponseDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
