using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Models;

namespace MANUAL.API.Domain.Models
{
    public class EmployeeTask
    {   
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Key, Column(Order = 2)]
        public int TaskId { get; set; }
        public API.Models.Task Task { get; set; }
    }
}
