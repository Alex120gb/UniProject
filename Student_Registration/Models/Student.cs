using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Registration.Models
{
    public class Student
    {
        public int ScId { get; set; }
        public int StId { get; set; }
        public string Course { get; set; }
        public string Struct { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RegNum { get; set; }
        public int TotEcts { get; set; }
        public int TransfECTS { get; set; }

    }
}
