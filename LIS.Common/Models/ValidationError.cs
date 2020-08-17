namespace LIS.Common.Models
{
    public sealed class ValidationError
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }
    }
}