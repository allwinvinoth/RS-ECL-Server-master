using LIS.DataContracts.Entities;

namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class MethodServiceObject
    {
        public int id { get; set; }
        
        public int departmentId { get; set; }
        
        public string methodName { get; set; }

        public string active { get; set; }
        public DepartmentEntity department { get; set; }
    }
}