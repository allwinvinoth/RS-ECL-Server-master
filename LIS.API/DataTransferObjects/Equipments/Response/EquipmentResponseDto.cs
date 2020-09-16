using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.Equipments.Response
{
    public sealed class EquipmentResponseDto
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; }
        public int EquipmentId { get; set; }
        public int Brand { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int InterfaceType { get; set; }
        public int Analysed { get; set; }
        public string Manufacturer { get; set; }
        public string Serial { get; set; }
        public string Supplier { get; set; }
        public string Condition { get; set; }
        public string Warranty { get; set; }
        public string Depreciation { get; set; }
        public string Value { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
