﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Registration.Models
{
    public class Failed_NotActive
    {
        public int Subj_Id { get; set; }
        public string SubjCode { get; set; }
        public string SubjName { get; set; }
        public string Ects { get; set; }
        public string Semester { get; set; }
        public string SemYear { get; set; }
        public string Passed { get; set; }
        public string StructName { get; set; }
    }
}