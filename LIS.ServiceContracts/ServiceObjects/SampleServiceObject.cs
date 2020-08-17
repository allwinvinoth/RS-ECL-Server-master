namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class SampleServiceObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AccessionId { get; set; }

        public int SampleTypeId { get; set; }

        public int ContainerTypeId { get; set; }

        public string Description { get; set; }

        public string Instruction { get; set; }

        public bool IsPrefix { get; set; }

        public SampleTypeServiceObject SampleType { get; set; }

        public ContainerTypeServiceObject ContainerType { get; set; }
    }
}
