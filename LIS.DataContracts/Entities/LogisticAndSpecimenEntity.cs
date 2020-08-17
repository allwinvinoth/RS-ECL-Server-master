using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("logistic_specimen")]
    public sealed class LogisticAndSpecimenEntity
    {
        [Key] [Column("logistic_specimen_id")] public int Id { get; set; }

        [Column("logistic_id")] public int LogisticId { get; set; }

        [Column("container_type_id")] public int SpecimenTypeId { get; set; }

        [Column("specimen_count")] public int SpecimenCount { get; set; }

        public LogisticEntity Logistic { get; set; }

        public ContainerTypeEntity SpecimenType { get; set; }
    }
}
