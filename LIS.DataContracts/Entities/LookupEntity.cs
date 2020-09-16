using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace LIS.DataContracts.Entities
{
    [Table("Lookup")]
    public sealed class LookupEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public string Param { get; set; }
    }
}