using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("methods")]
    public sealed class MethodEntity : BaseEntity
    {
        [Key][Column("method_id")]public int Id { get; set; }

        [ForeignKey("department")]
        [Column("department_id")]public int departmentId { get; set; }
        
        [Column("name")]public string methodName { get; set; }

        public DepartmentEntity department { get; set; }
    }
}