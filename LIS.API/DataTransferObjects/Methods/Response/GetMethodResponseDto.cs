using LIS.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Methods.Response
{
    public sealed class GetMethodResponseDto
    {
        public int Id { get; set; }

        public string methodName { get; set; }

        public string departmentId { get; set; }

        public string active { get; set; }
        public DepartmentEntity department { get; set; }
    }
}
