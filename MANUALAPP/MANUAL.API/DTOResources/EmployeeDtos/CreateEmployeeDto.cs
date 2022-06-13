using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.DTOResources.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Employee Full Name must be passed.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "It can contain just letter")]
        [Display(Name = "Employee Full Name")]
        public int FullName { get; set; }

        [Required(ErrorMessage = "Employee No. must be passed.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be numeric.")]
        [MaxLength(6, ErrorMessage = "Max. length value accepted is 6 digits.")]
        [MinLength(6, ErrorMessage = "Min. length value accepted is 6 digits.")]
        [Display(Name = "Employee No.")]
        public int EmployeeNo { get; set; }


    }
}
