using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("logistics")]
    public sealed class LogisticEntity : BaseEntity
    {
        public LogisticEntity()
        {
            this.LogisticAndLogisticTypes = new List<LogisticAndLogisticTypeEntity>();
            this.LogisticSpecimenTypes = new List<LogisticAndSpecimenEntity>();
        }
        [Key] [Column("logistic_id")] public int Id { get; set; }

        [Column("date")] public DateTime Date { get; set; }

        [Column("clinic")] public string Clinic { get; set; }

        [Column("called_by")] public string CalledBy { get; set; }

        [Column("driver_id")] public long DriverId { get; set; }

        [Column("no_of_trfs")] public int NoOfTRFs { get; set; }

        [Column("temperature")] public string Temperature { get; set; }

        [Column("stat")] public bool Stat { get; set; }

        [Column("remarks")] public string Remarks { get; set; }

        [Column("signature")] public string Signature { get; set; }

        public UserEntity Driver { get; set; }

        public ICollection<LogisticAndLogisticTypeEntity> LogisticAndLogisticTypes { get; set; }

        public ICollection<LogisticAndSpecimenEntity> LogisticSpecimenTypes { get; set; }
    }
}
