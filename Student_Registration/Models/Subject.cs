using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Registration.Models
{
    public class Subject
    {
        public int Subj_Id { get; set; }
        public string SubjCourse { get; set; }
        public string SubjCode { get; set; }
        public string SubjName { get; set; }
        public string Ects { get; set; }
        public string Semester { get; set; }
        public string SemYear { get; set; }
        public string Passed { get; set; }
        public string Approved { get; set; }
        public string StructName { get; set; }
        public string Grade { get; set; }
    }
}
