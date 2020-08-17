namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class ModulePageMappingServiceObject
    {
        public int Id { get; set; }

        public int ModuleId { get; set; }

        public int PageId { get; set; }

        public bool IsActive { get; set; }
    }
}