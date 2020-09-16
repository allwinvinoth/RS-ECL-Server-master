using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Departments.Response
{
    public sealed class GetDepartmentResponseDto
    {
        public int id { get; set; }

        public string departmentName { get; set; }
    }
}
