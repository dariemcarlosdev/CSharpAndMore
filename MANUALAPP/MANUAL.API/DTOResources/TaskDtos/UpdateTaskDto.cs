using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.DTOResources
{
    public class UpdateTaskDto
    {
        [Required]
        [RegularExpression(@"[a-zA-Z0-9._@+-]{2,150}", ErrorMessage = "The {0} must be 1 to 150 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Task Desciption")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Jobs asociated to this task are required")]
        public string Jobs { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Task Creation Date")]
        public DateTime DateOfTaskCreation { get; set; }

        [Required(ErrorMessage = "Task Start Date is required")]
        [Display(Name = "Task Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartedOn { get; set; }
        
        [Required(ErrorMessage = "Task Due Date is required")]
        [Display(Name = "Task Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Task Completed Date is required")]
        [Display(Name = "Task Completed Date")]
        [DataType(DataType.Date)]
        public DateTime CompletedDate { get; set; }

        [Display(Name = "Is it Completed?")]
        public bool? IsCompleted { get; set; }

        [Display(Name = "Is it Enable?")]
        public bool? IsEnable { get; set; }
    }
}
