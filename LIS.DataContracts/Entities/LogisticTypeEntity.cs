using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("logistic_types")]
    public sealed class LogisticTypeEntity : BaseEntity
    {
        [Key]
        [Column("logistic_type_id")]
        public int Id { get; set; }

        [Column("logistic_type")]
        public string LogisticType { get; set; }
    }
}
