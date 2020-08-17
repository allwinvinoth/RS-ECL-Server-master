using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    public abstract class BaseEntity
    {
        [Column("modified_on")] 
        public DateTime ModifiedOn { get; set; }
        
        [Column("is_active")] 
        public bool IsActive { get; set; }
    }
}