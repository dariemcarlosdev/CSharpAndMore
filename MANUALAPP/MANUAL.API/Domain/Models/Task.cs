using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public string Jobs { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartedOn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CompletedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
