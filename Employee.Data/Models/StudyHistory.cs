using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Models
{
    public class StudyHistory
    {
        public int Id { get; set; }
        public string Last_Study { get; set; }
        public string Intitude_Name { get; set; }
        public string Jurusan { get; set; }
        public int Tahun_Lulus { get; set; }
        public string Ipk { get; set;}

        [ForeignKey(nameof(FkEmployeeId))]
        public Employee Employee { get; set; }
        public int FkEmployeeId { get; set; }
    }
    
}
