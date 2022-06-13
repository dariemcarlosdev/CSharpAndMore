using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Models
{
    
    [Table("Employee_Tasks")]
    public class EmployeeTaskEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee{ get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task{ get; set; }
    }
}
