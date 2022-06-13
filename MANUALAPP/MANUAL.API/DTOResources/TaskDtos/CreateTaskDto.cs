using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.DTOResources
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Task Description is required")]
        [RegularExpression(@"[a-zA-Z0-9._@+-]{2,150}", ErrorMessage = "The {0} must be 1 to 150 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "TaskDesciption")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Jobs asociated to this task must be passed")]
        public string Jobs { get; set; }
       
        [Required(ErrorMessage ="Task Creation Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Task Creation Date")]
        public DateTime DateOfTaskCreation { get; set; }
        
        [Required(ErrorMessage ="You must set a start Date")]
        [DataType(DataType.Date)]
        public DateTime StartedOn { get; set; }
        
        [Required(ErrorMessage = "Task Due Date is required")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime CompletedDate { get; set; }

        [Required()]
        [Display(Name = "Is it Completed?")]
        public bool? IsCompleted { get; set; }

        [Required()]
        [Display(Name = "Is it Enable?")]
        public bool? IsEnable { get; set; }
    }
}
