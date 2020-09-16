using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using LIS.DataContracts.Entities;

namespace LIS.API.DataTransferObjects.TestMaster
{
    public sealed class IndividualTestResponseDto
    {
        public int Id { get; set; }
        public int TestCategoryId { get; set; }
        public int AccrediationSymbolId { get; set; }
        public bool Accrediation { get; set; }
        public string IndividualTestName { get; set; }
        public int EquipmentId { get; set; }
        public string ProcessingCentreId { get; set; }
        public string OutsourceVendorCode { get; set; }
        public int MethodId { get; set; }
        public int UnitId { get; set; }
        public string IntegrationCode { get; set; }
        public string CptAmount { get; set; }
        public int TatDays { get; set; }
        public int TatHours { get; set; }
        public int TatMinutes { get; set; }
        public MethodEntity Method { get; set; }
        public LookupEntity Lookup { get; set; }
        public bool IsActive { get; set; }
    }
}