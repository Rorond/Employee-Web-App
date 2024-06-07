using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sertificate { get; set; }
        public int Year { get; set; }

        [ForeignKey(nameof(FkEmployeeId))]
        public Employee Employee { get; set; }
        public int FkEmployeeId { get; set; }
    }
}
