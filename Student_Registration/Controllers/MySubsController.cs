using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Student_Registration.Models;

namespace Student_Registration.Controllers
{
    public class MySubsController : Controller
    {
        public ActionResult MySubjects(int stud)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=student_registration;port=3306;password='';SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student.stid, student.name, student.surname, student.regNum, stud_course.scid, course.name, stud_course.scid " +
                    "FROM stud_course " +
                    "INNER JOIN student ON stud_course.student = student.stid " +
                    "INNER JOIN course ON stud_course.course = course.crid " +
                    "WHERE stud_course.scid = " + stud + "; ", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Session["st_name"] = reader[1].ToString();
                    Session["st_surname"] = reader[2].ToString();
                    Session["st_regNum"] = reader[3].ToString();
                    Session["st_id"] = Convert.ToInt32(reader[0]);
                    Session["course"] = reader[5].ToString();
                    Session["st_ScId"] = Convert.ToInt32(reader[6]);
                }

                reader.Close();
            }

            List<Subject> mysub = new List<Subject>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=student_registration;port=3306;password='';SslMode=none;"))
            {
                int My_ECTS_Req = 0;
                int My_ECTS_Tech = 0;
                int My_ECTS_Free = 0;
                int All_ECTS = 0;
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT subject.name, subject.code, subject.ects, semester.sname, semester.yr, stud_course_sbj.passed, " +
                    "stud_course_sbj.approved, struct_group.name FROM stud_course " +
                    "INNER JOIN stud_course_sbj ON " + stud + " = stud_course_sbj.stud_course " +
                    "INNER JOIN semester ON stud_course_sbj.semester = semester.semid " +
                    "INNER JOIN subject ON stud_course_sbj.subject = subject.sbj " +
                    "INNER JOIN sbj_struct_group ON sbj_struct_group.subject = subject.sbj " +
                    "INNER JOIN struct_group ON struct_group.sgid = sbj_struct_group.struct_group; ", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Subject sb = new Subject
                    {
                        SubjName = reader[0].ToString(),
                        SubjCode = reader[1].ToString(),
                        Ects = reader[2].ToString(),
                        Semester = reader[3].ToString(),
                        SemYear = reader[4].ToString(),
                        Passed = reader[5].ToString(),
                        Approved = reader[6].ToString(),
                        StructName = reader[7].ToString()
                    };

                    if (reader[7].ToString() == "Required")
                    {
                        My_ECTS_Req += Convert.ToInt32(reader[2]);
                    }

                    if (reader[7].ToString() == "Technical Electives")
                    {
                        My_ECTS_Tech += Convert.ToInt32(reader[2]);
                    }
                    if (reader[7].ToString() == "Free Electives")
                    {
                        My_ECTS_Free += Convert.ToInt32(reader[2]);
                    }
                    mysub.Add(sb);
                }

                Session["My_ECTS_Req"] = My_ECTS_Req;
                Session["My_ECTS_Tech"] = My_ECTS_Tech;
                Session["My_ECTS_Free"] = My_ECTS_Free;
                All_ECTS = My_ECTS_Req + My_ECTS_Tech + My_ECTS_Free;
                Session["My_All_ECTS"] = All_ECTS;

                reader.Close();
            }
            MultiLists ML = new MultiLists
            {
                Subject_List = mysub
            };
            return View(ML);
        }
    }
}