namespace LIS.API.DataTransferObjects.Modules.Request
{
    public sealed class UpdateModuleRequestDto
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}