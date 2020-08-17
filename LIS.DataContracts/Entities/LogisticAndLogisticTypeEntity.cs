using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("logistic_with_logistictype_mapping")]
    public sealed class LogisticAndLogisticTypeEntity
    {
        [Key] [Column("logistic_with_logistictype_mapping_id")] public int Id { get; set; }

        [Column("logistic_id")] public int LogisticId { get; set; }

        [Column("logistic_type_id")] public int LogisticTypeId { get; set; }

        public LogisticEntity Logistic { get; set; }

        public LogisticTypeEntity LogisticType { get; set; }
    }
}
