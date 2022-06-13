using MANUAL.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace MANUAL.API.DTOResources.EmployeeDtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        [Display(Name ="Employee Full Name")]
        public int FullName { get; set; }
        
        [Display(Name ="Employee No.")]
        public int EmployeeNo{ get; set; }

        
    }
}
