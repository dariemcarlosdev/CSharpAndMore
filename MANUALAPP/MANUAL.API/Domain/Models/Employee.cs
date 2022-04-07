using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        
        [Required]
        [MaxLength(7)]
        public int EmployeeNo { get; set; }
        [Required]
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public string LastName{ get; set; }
        public int TaskId  { get; set; }
        public Task Task { get; set; }

    }
}
