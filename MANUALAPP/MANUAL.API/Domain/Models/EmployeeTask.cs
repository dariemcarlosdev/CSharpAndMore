using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

;

namespace MANUAL.API.Domain.Models
{
    public class EmployeeTask
    {
        //he primary key for the join table is a composite key comprising both of the foreign key values.
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Key, Column(Order = 2)]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
