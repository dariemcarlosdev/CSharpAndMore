using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Models
{
    [Table("Tasks")]
    public class TaskEntity
    {
        public TaskEntity()
        {
            DateOfTaskCreation = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            this.EmployeesTasks = new List<EmployeeTaskEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public string Jobs { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime DueDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartedOn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CompletedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTaskCreation { get; set; }

        
        public bool? IsCompleted { get; set; }
        
        public bool? IsEnable { get; set; }
        public ICollection<EmployeeTaskEntity> EmployeesTasks { get; set; }

        
    }
}
