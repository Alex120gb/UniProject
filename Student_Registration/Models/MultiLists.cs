using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Registration.Models
{
    public class MultiLists
    {
        public List<Student> Studs { get; set; }
        public List<Courses> Courses { get; set; }
        public List<Subject> Subject_List { get; set; }
        public List<Failed_NotActive> Failed_NotActive { get; set; }
        public int ReqECTS { get; set; }
        public int ReqECTSleft { get; set; }
        public int ReqIncomplete { get; set; }
        public int TechECTS { get; set; }
        public int TechECTSleft { get; set; }
        public int TechIncomplete { get; set; }
        public int FreeECTS { get; set; }
        public int FreeECTSleft { get; set; }
        public int FreeIncomplete { get; set; }
        public int LastSem_ECTS { get; set; }
        public double LastSem_GPA { get; set; }
        public string St_Fullname { get; set; }
        public string St_regNum { get; set; }
        public string Course { get; set; }
        public int Sel_ECTS { get; set; }
        public int St_ScId { get; set; }
        public string Crs_name { get; set; }
    }
}