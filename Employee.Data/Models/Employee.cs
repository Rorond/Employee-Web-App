using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Nik { get; set; }
        public string Place_Of_Birth {  get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Blood_Group { get; set; }
        public string Status { get; set; }
        public string Address_Ktp { get; set; }
        public string Address_Life { get; set; }
        public string Email { get; set; }
        public string Tlp { get; set; }
        public string Relatives { get; set; }
        public string Skill { get; set; }
        public bool Readdy_To_Be_Placed { get; set; }
        public decimal Expected_Sallary { get; set; }
    }

}
