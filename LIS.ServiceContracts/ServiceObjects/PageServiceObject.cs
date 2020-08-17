namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class PageServiceObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrganisationId { get; set; }

        public bool IsActive { get; set; }
    }
}