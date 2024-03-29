using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Student_Registration.Models;

namespace Student_Registration.Controllers
{
    public class RegisterSubsController : Controller
    {
        public ActionResult RegisterSubjects(int stud)
        {
            MultiLists ML = new MultiLists();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=student_registration;port=3306;password='';SslMode=none;"))
            {
                int allECTS = 0;
                int TransfECTS = 0;
                int Last_Sem_Tot_ECTS = 0;
                double Last_Sem_GPA = 0.0;
                
                int Req_sum = 0;
                int Req_cnt = 0;

                int Tech_sum = 0;
                int Tech_cnt = 0;

                int Free_sum = 0;
                int Free_cnt = 0;
                con.Open();
                
                MySqlCommand cmd = new MySqlCommand("SELECT subject.ects, struct_group.name, stud_course_sbj.passed, semester.sname, " +
                    "semester.yr, stud_course_sbj.grade, stud_course.transfCreds FROM stud_course " + 
                    "INNER JOIN stud_course_sbj ON stud_course_sbj.stud_course = stud_course.scid " +
                    "INNER JOIN subject ON stud_course_sbj.subject = subject.sbj " +
                    "INNER JOIN semester ON stud_course_sbj.semester = semester.semid " +
                    "INNER JOIN sbj_struct_group ON subject.sbj = sbj_struct_group.subject " +
                    "INNER JOIN struct_group ON sbj_struct_group.struct_group = struct_group.sgid " +
                    "WHERE stud_course.scid = " + stud + "; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransfECTS = Convert.ToInt32(reader[6]);
                    if (reader[2].ToString() == "P")
                    {
                        allECTS += Convert.ToInt32(reader[0]);
                    }
                    
                    if (Convert.ToInt32(DateTime.Now.Month.ToString()) >= 1 && Convert.ToInt32(DateTime.Now.Month.ToString()) <= 5)
                    {
                        if (reader[3].ToString() == "Spring" && Convert.ToInt32(reader[4]) == Convert.ToInt32(DateTime.Now.Year.ToString()) - 1 && reader[2].ToString() == "P")
                        {
                            Last_Sem_Tot_ECTS += Convert.ToInt32(reader[0]);
                            
                            if (reader[5].ToString() == "A")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 10;
                            }
                            
                            if (reader[5].ToString() == "B")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 8;
                            }
                            
                            if (reader[5].ToString() == "C")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 7;
                            }
                            
                            if (reader[5].ToString() == "D")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 6;
                            }
                            
                            if (reader[5].ToString() == "E")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 5;
                            }
                        }

                        if (reader[3].ToString() == "Spring" && Convert.ToInt32(reader[4]) == Convert.ToInt32(DateTime.Now.Year.ToString()) - 1 && reader[2].ToString() == "F")
                        {
                            Last_Sem_Tot_ECTS += Convert.ToInt32(reader[0]);
                        }
                    }
                    
                    if (Convert.ToInt32(DateTime.Now.Month.ToString()) >= 6 && Convert.ToInt32(DateTime.Now.Month.ToString()) <= 12)
                    {
                        if (reader[3].ToString() == "Spring" && Convert.ToInt32(reader[4]) == Convert.ToInt32(DateTime.Now.Year.ToString()) && reader[2].ToString() == "P")
                        {
                            Last_Sem_Tot_ECTS += Convert.ToInt32(reader[0]);
                            
                            if (reader[5].ToString() == "A")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 10;
                            }
                            
                            if (reader[5].ToString() == "B")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 8;
                            }
                            
                            if (reader[5].ToString() == "C")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 7;
                            }
                            
                            if (reader[5].ToString() == "D")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 6;
                            }
                            
                            if (reader[5].ToString() == "E")
                            {
                                Last_Sem_GPA += Convert.ToInt32(reader[0]) * 5;
                            }
                        }

                        if (reader[3].ToString() == "Spring" && Convert.ToInt32(reader[4]) == Convert.ToInt32(DateTime.Now.Year.ToString()) && reader[2].ToString() == "F")
                        {
                            Last_Sem_Tot_ECTS += Convert.ToInt32(reader[0]);
                        }
                    }

                    if (reader[2].ToString() == "P")
                    {
                        if (reader[1].ToString() == "Required")
                        {
                            Req_sum += Convert.ToInt32(reader[0]);
                        }

                        if (reader[1].ToString() == "Technical Electives")
                        {
                            Tech_sum += Convert.ToInt32(reader[0]);
                        }

                        if (reader[1].ToString() == "Free Electives")
                        {
                            Free_sum += Convert.ToInt32(reader[0]);
                        }
                    }

                    if (reader[2].ToString() == "I")
                    {
                        if (reader[1].ToString() == "Required")
                        {
                            Req_cnt++;
                        }

                        if (reader[1].ToString() == "Technical Electives")
                        {
                            Tech_cnt++;
                        }

                        if (reader[1].ToString() == "Free Electives")
                        {
                            Free_cnt++;
                        }
                    }
                }

                ML.AllECTS = allECTS + TransfECTS;
                ML.ReqECTS = Req_sum;
                ML.ReqECTSleft = 177 - Req_sum;
                ML.ReqIncomplete = Req_cnt;

                ML.TechECTS = Tech_sum;
                ML.TechECTSleft = 48 - Tech_sum;
                ML.TechIncomplete = Tech_cnt;

                ML.FreeECTS = Free_sum;
                ML.FreeECTSleft = 15 - Free_sum;
                ML.FreeIncomplete = Free_cnt;

                ML.LastSem_ECTS = Last_Sem_Tot_ECTS;
                double round = Math.Round(Last_Sem_GPA / Last_Sem_Tot_ECTS, 2);
                ML.LastSem_GPA = round;
                
                reader.Close();
            }

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
                    ML.St_Fullname = reader[1].ToString() + " " + reader[2].ToString();
                    ML.St_regNum = reader[3].ToString();
                    ML.Course = reader[5].ToString();
                    ML.St_ScId = Convert.ToInt32(reader[6]);
                }

                reader.Close();
            }

            List<Failed_NotActive> Failed_NActive = new List<Failed_NotActive>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=student_registration;port=3306;password='';SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT struct_group.name, subject.name, subject.code, subject.ects, " +
                    "semester.sname, semester.yr, subject.sbj, stud_course_sbj.passed FROM stud_course " +
                    "INNER JOIN stud_course_sbj ON stud_course.scid = stud_course_sbj.stud_course " +
                    "INNER JOIN subject ON stud_course_sbj.subject = subject.sbj " +
                    "INNER JOIN sem_sub ON subject.sbj = sem_sub.subject " +
                    "INNER JOIN semester ON sem_sub.semester = semester.semid " +
                    "INNER JOIN sbj_struct_group ON subject.sbj = sbj_struct_group.subject " +
                    "INNER JOIN struct_group ON sbj_struct_group.struct_group = struct_group.sgid " +
                    "INNER JOIN structure ON struct_group.structure = structure.stid " +
                    "WHERE stud_course.scid = " + stud + " AND (stud_course_sbj.passed = 'F'" +
                    "OR stud_course_sbj.passed = '' AND stud_course_sbj.grade = ''); ", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[7].ToString() == "F")
                    {
                        Failed_NotActive g = new Failed_NotActive
                        {
                            StructName = reader[0].ToString(),
                            SubjName = reader[1].ToString(),
                            SubjCode = reader[2].ToString(),
                            Ects = reader[3].ToString(),
                            Semester = reader[4].ToString(),
                            SemYear = reader[5].ToString(),
                            Subj_Id = Convert.ToInt32(reader[6]),
                            Passed = "F"
                        };

                        Failed_NActive.Add(g);
                    }

                    else
                    {
                        Failed_NotActive g = new Failed_NotActive
                        {
                            StructName = reader[0].ToString(),
                            SubjName = reader[1].ToString(),
                            SubjCode = reader[2].ToString(),
                            Ects = reader[3].ToString(),
                            Semester = reader[4].ToString(),
                            SemYear = reader[5].ToString(),
                            Subj_Id = Convert.ToInt32(reader[6]),
                            Passed = "N/A"
                        };

                        Failed_NActive.Add(g);
                    }
                }

                reader.Close();
            }

            // Add to a list any subject that are not passed or not already registered in or incomplete
            List<Subject> myRegsub = new List<Subject>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=student_registration;port=3306;password='';SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT struct_group.name, subject.name, subject.code, subject.ects, " +
                    "semester.sname, semester.yr, subject.sbj FROM stud_course " +
                    "INNER JOIN course ON stud_course.course = course.crid " +
                    "INNER JOIN structure ON course.crid = structure.pos " +
                    "INNER JOIN struct_group ON structure.stid = struct_group.structure " +
                    "INNER JOIN sbj_struct_group ON struct_group.sgid = sbj_struct_group.struct_group " +
                    "INNER JOIN subject ON sbj_struct_group.subject = subject.sbj " +
                    "INNER JOIN sem_sub ON subject.sbj = sem_sub.subject " +
                    "INNER JOIN semester ON sem_sub.semester = semester.semid " +
                    "WHERE stud_course.scid = " + stud + " AND stud_course.structure_id = structure.stid " + 
                    "AND NOT subject.sbj = ANY (SELECT DISTINCT subject.sbj FROM stud_course " +
                    "INNER JOIN stud_course_sbj ON stud_course.scid = stud_course_sbj.stud_course " +
                    "INNER JOIN subject ON stud_course_sbj.subject = subject.sbj " +
                    "WHERE stud_course.scid = " + stud + " AND stud_course_sbj.passed = 'P' OR stud_course_sbj.grade = 'N/A' OR stud_course_sbj.passed = 'I'); ", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                //string month;

                while (reader.Read())
                {
                    if (Convert.ToInt32(DateTime.Now.Month.ToString()) >= 1 && Convert.ToInt32(DateTime.Now.Month.ToString()) <= 5)
                    {
                        if (reader[4].ToString() == "Spring" && Convert.ToInt32(reader[5]) == Convert.ToInt32(DateTime.Now.Year.ToString()))
                        {
                            Subject rgsb = new Subject
                            {
                                StructName = reader[0].ToString(),
                                SubjName = reader[1].ToString(),
                                SubjCode = reader[2].ToString(),
                                Ects = reader[3].ToString(),
                                Semester = reader[4].ToString(),
                                SemYear = reader[5].ToString(),
                                Subj_Id = Convert.ToInt32(reader[6])
                            };

                            myRegsub.Add(rgsb);
                        }
                    }

                    else if (Convert.ToInt32(DateTime.Now.Month.ToString()) <= 6 || Convert.ToInt32(DateTime.Now.Month.ToString()) >= 12)
                    {
                        if (reader[4].ToString() == "Fall" && Convert.ToInt32(reader[5]) == Convert.ToInt32(DateTime.Now.Year.ToString()))
                        {
                            Subject rgsb = new Subject
                            {
                                StructName = reader[0].ToString(),
                                SubjName = reader[1].ToString(),
                                SubjCode = reader[2].ToString(),
                                Ects = reader[3].ToString(),
                                Semester = reader[4].ToString(),
                                SemYear = reader[5].ToString(),
                                Subj_Id = Convert.ToInt32(reader[6])
                            };

                            myRegsub.Add(rgsb);
                        }
                    }
                }

                reader.Close();
            }

            ML.Subject_List = myRegsub;
            ML.Failed_NotActive = Failed_NActive;

            return View(ML);
        }
    }
}