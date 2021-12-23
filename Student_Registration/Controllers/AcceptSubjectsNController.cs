using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using Student_Registration.Models;

namespace Student_Registration.Controllers
{
    public class AcceptSubjectsNController : Controller
    {
        [HttpPost]
        public ActionResult AcceptSubjects(List<int> subjE, MultiLists ScId)
        {

            List<Subject> subs = new List<Subject>();
            int ects_cnt = 0;
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subject.sbj, subject.code, subject.name, subject.ects, semester.sname, semester.yr FROM subject " +
                    "INNER JOIN sem_sub ON subject.sbj = sem_sub.subject " +
                    "INNER JOIN semester ON sem_sub.semester = semester.semid;", con);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    foreach (var item in subjE)
                    {
                        if (item == Convert.ToInt32(reader[0]))
                        {
                            Subject sbjct = new Subject
                            {
                                Subj_Id = Convert.ToInt32(reader[0]),
                                SubjCode = reader[1].ToString(),
                                SubjName = reader[2].ToString(),
                                Ects = reader[3].ToString(),
                                Semester = reader[4].ToString(),
                                SemYear = reader[5].ToString()
                            };

                            subs.Add(sbjct);
                            ects_cnt += Convert.ToInt32(reader[3]);
                        }
                    }
                }
                reader.Close();
            }

            MultiLists ML = new MultiLists
            {
                Subject_List = subs,
                Sel_ECTS = ects_cnt,
                St_ScId = ScId.St_ScId
            };
            return View(ML);
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            return Redirect("~/Home/Index");
        }

        [HttpPost]
        public ActionResult ConfirmUpdate(List<int> sbe, MultiLists ScId)
        {
            List<Subject> excel_subjects = new List<Subject>();

            int ects_cnt = 0;
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subject.sbj, subject.name, subject.code, subject.ects, semester.sname, semester.yr, struct_group.name FROM subject " +
                    "INNER JOIN sbj_struct_group ON sbj_struct_group.subject = subject.sbj " +
                    "INNER JOIN struct_group ON sbj_struct_group.struct_group = struct_group.sgid " +
                    "INNER JOIN sem_sub ON subject.sbj = sem_sub.subject " +
                    "INNER JOIN semester ON sem_sub.semester = semester.semid; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foreach (var item in sbe)
                    {
                        if (item == Convert.ToInt32(reader[0]))
                        {
                            Subject rgsb = new Subject
                            {
                                StructName = reader[6].ToString(),
                                SubjName = reader[1].ToString(),
                                SubjCode = reader[2].ToString(),
                                Ects = reader[3].ToString(),
                                Semester = reader[4].ToString(),
                                SemYear = reader[5].ToString()
                            };

                            ects_cnt += Convert.ToInt32(reader[3]);
                            excel_subjects.Add(rgsb);
                        }
                    }
                }
                reader.Close();
            }

            Student st = new Student();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=student_registration;port=3306;password='';SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student.stid, student.name, student.surname, student.regNum, course.name FROM stud_course " +
                    "INNER JOIN student ON student.stid = stud_course.student " +
                    "INNER JOIN course ON stud_course.course = course.crid " +
                    "WHERE stud_course.scid = " + ScId.St_ScId + "; ", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    st.Name = reader[1].ToString();
                    st.Surname = reader[2].ToString();
                    st.RegNum = Convert.ToInt32(reader[3]);
                }

                reader.Close();
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("MultiList");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Student";
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Green;

                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Name";
                worksheet.Cell(currentRow, 2).Value = "Surname";
                worksheet.Cell(currentRow, 3).Value = "Reg. Number";
                //Colors
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.BlueGray;

                currentRow++;
                worksheet.Cell(currentRow, 1).Value = st.Name;
                worksheet.Cell(currentRow, 2).Value = st.Surname;
                worksheet.Cell(currentRow, 3).Value = st.RegNum;
                //Colors
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Subjects";
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Green;
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Type";
                worksheet.Cell(currentRow, 2).Value = "Code";
                worksheet.Cell(currentRow, 3).Value = "Name";
                worksheet.Cell(currentRow, 4).Value = "ECTS";
                worksheet.Cell(currentRow, 5).Value = "Semester";
                //Colors
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(currentRow, 4).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.BlueGray;
                foreach (var item in excel_subjects)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.StructName;
                    worksheet.Cell(currentRow, 2).Value = item.SubjCode;
                    worksheet.Cell(currentRow, 3).Value = item.SubjName;
                    worksheet.Cell(currentRow, 4).Value = item.Ects;
                    worksheet.Cell(currentRow, 5).Value = item.Semester + " " + item.SemYear;
                    //Colors
                    worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell(currentRow, 4).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                }
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Total ECTS: " + ects_cnt;
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Green;
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        st.Name + " " + st.Surname + " (" + st.RegNum + ").xlsx");
                }

            }
        }

    }
}