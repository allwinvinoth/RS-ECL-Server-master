namespace LIS.API.DataTransferObjects.Samples.Request
{
    public class CreateSampleRequestDto
    {
        public string Name { get; set; }

        public int AccessionId { get; set; }

        public int SampleTypeId { get; set; }

        public int ContainerTypeId { get; set; }

        public string Description { get; set; }

        public string Instruction { get; set; }

        public bool IsPrefix { get; set; }
    }
}
