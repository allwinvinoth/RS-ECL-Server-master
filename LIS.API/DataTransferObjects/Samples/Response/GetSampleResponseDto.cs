using LIS.API.DataTransferObjects.ContainerTypes.Response;
using LIS.API.DataTransferObjects.SampleTypes.Response;

namespace LIS.API.DataTransferObjects.Samples.Response
{
    public class GetSampleResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AccessionId { get; set; }

        public int SampleTypeId { get; set; }

        public int ContainerTypeId { get; set; }

        public string Description { get; set; }

        public string Instruction { get; set; }

        public bool IsPrefix { get; set; }

        public SampleTypeResponseDto SampleType { get; set; }

        public ContainerTypeResponseDto ContainerType { get; set; }
    }
}
