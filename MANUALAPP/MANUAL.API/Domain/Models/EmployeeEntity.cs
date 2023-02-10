using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Models
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
            this.EmployeesTasks = new List<EmployeeTaskEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Number is required")]
        [MaxLength(6,ErrorMessage = "Employee Number just can has 6 digits")]
        [Range(0, int.MaxValue, ErrorMessage ="Please, enter a valid integer number")]
        public int EmployeeNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName{ get; set; }
        public ICollection<EmployeeTaskEntity> EmployeesTasks;

        public string GetFullName()
        {
            return $"{this.Name}, {this.LastName}";
        }

    }
}
