namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class ModuleServiceObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrganisationId { get; set; }

        public bool IsActive { get; set; }
    }
}