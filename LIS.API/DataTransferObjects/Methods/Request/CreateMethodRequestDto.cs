using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Methods.Request
{
    public sealed class CreateMethodRequestDto
    {
            public string methodName { get; set; }
            public int departmentId { get; set; }
            public string active { get; set; }
    }
}
