namespace LIS.ServiceContracts.ServiceObjects
{
    public sealed class TestProfileServiceObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OutsourceId { get; set; }
        public string IntegrationCode { get; set; }
        public decimal MinimumSellingPrice { get; set; }
        public decimal RevenueCap { get; set; }
        public decimal ProfilePrice { get; set; }
    }
}