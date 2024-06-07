using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Models
{
    public class CareerHistory
    {
        public int Id { get; set; }
        public string Company_Name { get; set; }
        public string Last_Position { get; set; }
        public decimal Last_Salary { get; set; }
        public int Year { get; set;}

        [ForeignKey(nameof(FkEmployeeId))]
        public Employee? Employee { get; set; }
        public int FkEmployeeId { get; set; }
    }
}
