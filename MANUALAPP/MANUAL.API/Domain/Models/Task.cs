using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Models
{
    [Table("Tasks", Schema ="Employee")]
    public class Task
    {   
        [Key]
        public int TaskId{ get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime?  StartedOn { get; set; }
        public DateTime? CompletedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public ICollection<Job> JobsRelated { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
