using MANUAL.API.Domain.Models;
using MANUAL.API.DTOResources.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.DTOResources
{
    public class TaskDto
    {
        

        public int TaskId { get; set; }
     
        [Display(Name = "Task Description")]
        public string Description { get; set; }
        
  
        [Display(Name = "Jobs for this Task")]
        public string Jobs { get; set; }
        
       
        [DataType(DataType.Date)]
        [Display(Name = "Task Start Date")]
        public DateTime StartedOn { get; set; }

       
        [DataType(DataType.Date)]
        [Display(Name = "Task Due Date")]
        public DateTime DueDate { get; set; }
        
        
        [DataType(DataType.Date)]
        [Display(Name ="Task Creation Date")]
        public DateTime DateOfTaskCreation { get; set; }

        [Display(Name = "Is it Completed?")]
        public bool? IsCompleted { get; set; }

        [Display(Name = "Is it Enable?")]
        public bool? IsEnable { get; set; }

        //Adding Collection of EmployeeDTO to TasKDTO

        public IList<string> Employees { get; set; }

    }
}
