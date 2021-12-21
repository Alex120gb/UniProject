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

    }
}