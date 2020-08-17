using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIS.DataContracts.Entities
{
    [Table("gender")]
    public sealed class GenderEntity : BaseEntity
    {
        [Column("gender_id")]
        public int Id { get; set; }

        [Column("gender_name")]
        public string Name { get; set; }
    }
}
