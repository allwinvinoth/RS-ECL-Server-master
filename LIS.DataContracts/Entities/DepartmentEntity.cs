using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIS.DataContracts.Entities
{
    [Table("departments")]
    public sealed class DepartmentEntity : BaseEntity
    {
        [Key][Column("department_id")]public int Id { get; set; }

        [Column("branch_id")]public int BranchId { get; set; }
        
        [Column("name")]public string Name { get; set; }
    }
}