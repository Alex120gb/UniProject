using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using Student_Registration.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace Student_Registration.Controllers
{
    public class AcceptSubjectsNController : Controller
    {
        private string excelFilePath = "C:\\Users\\Alexis\\Desktop\\FinalYearProject\\ASP_ProjectFiles\\Test";
        private int rowNumber = 1; // define first row number to enter data in excel

        Excel.Application myExcelApplication;
        Excel.Workbook myExcelWorkbook;
        Excel.Worksheet myExcelWorkSheet;

        public string ExcelFilePath
        {
            get { return excelFilePath; }
            set { excelFilePath = value; }
        }

        public int Rownumber
        {
            get { return rowNumber; }
            set { rowNumber = value; }
        }

        public void openExcel()
        {
            myExcelApplication = null;

            myExcelApplication = new Excel.Application(); // create Excell App
            myExcelApplication.DisplayAlerts = false; // turn off alerts


            myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks._Open(excelFilePath, System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value)); // open the existing excel file

            int numberOfWorkbooks = myExcelApplication.Workbooks.Count; // get number of workbooks (optional)

            myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.Worksheets[1]; // define in which worksheet, do you want to add data
            //myExcelWorkSheet.Name = "WorkSheet 1"; // define a name for the worksheet (optinal)
            //while (myExcelWorkSheet.Row)
            //myExcelWorkSheet.UsedRange;
            int numberOfSheets = myExcelWorkbook.Worksheets.Count; // get number of worksheets (optional)
            int cnt = 0;
            for (int i = 1; i <= myExcelWorkSheet.Rows.Count; i++)
            {
                cnt++;
                string test = myExcelWorkSheet.Rows[i].Cells[1].value;
                if (test == null || test == "")
                {
                    rowNumber += cnt - 1;
                    break;
                }
            }
        }
        
        public void addDataToExcel(string Stname, string Stlastname, string RegNumb, string TransfECTS, string LastSemECTS, string TotalECTS, 
            string AfterAddition, string LeftECTS, string SubCodes, string Ects)
        {
            myExcelWorkSheet.Cells[rowNumber, "A"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "A"] = Stname;

            myExcelWorkSheet.Cells[rowNumber, "B"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "B"] = Stlastname;

            myExcelWorkSheet.Cells[rowNumber, "C"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "C"] = RegNumb;

            myExcelWorkSheet.Cells[rowNumber, "D"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "D"] = TransfECTS;

            myExcelWorkSheet.Cells[rowNumber, "E"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "E"] = LastSemECTS;

            myExcelWorkSheet.Cells[rowNumber, "F"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "F"] = TotalECTS;

            myExcelWorkSheet.Cells[rowNumber, "G"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "G"] = AfterAddition;

            myExcelWorkSheet.Cells[rowNumber, "H"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "H"] = LeftECTS;

            myExcelWorkSheet.Cells[rowNumber, "I"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "I"] = SubCodes;

            myExcelWorkSheet.Cells[rowNumber, "J"].Interior.Color = Excel.XlRgbColor.rgbAliceBlue;
            myExcelWorkSheet.Cells[rowNumber, "J"] = Ects;
            rowNumber++;  // if you put this method inside a loop, you should increase rownumber by one or wat ever is your logic

        }

        public void closeExcel()
        {
            try
            {
                myExcelWorkbook.SaveAs(excelFilePath, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value); // Save data in excel


                myExcelWorkbook.Close(true, excelFilePath, System.Reflection.Missing.Value); // close the worksheet


            }
            finally
            {
                if (myExcelApplication != null)
                {
                    myExcelApplication.Quit(); // close the excel application
                }
            }

        }

        [HttpPost]
        public ActionResult AcceptSubjects(List<int> subjE, MultiLists ScId, MultiLists LastSemECTS)
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
                St_ScId = ScId.St_ScId,
                LastSem_ECTS = LastSemECTS.LastSem_ECTS
            };
            return View(ML);
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            return Redirect("~/Home/Index");
        }

        [HttpPost]
        public ActionResult ConfirmUpdate(List<int> sbe, MultiLists ScId, MultiLists LastSemECTS)
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
                MySqlCommand cmd = new MySqlCommand("SELECT student.stid, student.name, student.surname, student.regNum, " +
                    "stud_course.transfCreds, SUM(subject.ects) FROM stud_course " +
                    "INNER JOIN student ON student.stid = stud_course.student " +
                    "INNER JOIN stud_course_sbj ON stud_course.scid = stud_course_sbj.stud_course " +
                    "INNER JOIN subject ON stud_course_sbj.subject = subject.sbj " +
                    "INNER JOIN course ON stud_course.course = course.crid " +
                    "WHERE stud_course.scid = " + ScId.St_ScId + " AND stud_course_sbj.passed = 'P'; ", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    st.Name = reader[1].ToString();
                    st.Surname = reader[2].ToString();
                    st.RegNum = Convert.ToInt32(reader[3]);
                    st.TransfECTS = Convert.ToInt32(reader[4]);
                    st.TotEcts = Convert.ToInt32(reader[5]);
                }

                reader.Close();
            }
            this.openExcel();
            string subCodes = "";
            int TotSubEcts = 0;
            int cnt = excel_subjects.Count;
            int i = 0;
            foreach (var item in excel_subjects)
            {
                i++;
                TotSubEcts += Convert.ToInt32(item.Ects);
                if (i == cnt)
                {
                    subCodes += item.SubjCode;
                }
                else
                {
                    subCodes += item.SubjCode + ", ";
                }
            }
            int AfterAdd = st.TotEcts + TotSubEcts + st.TransfECTS;
            int LeftECTS = 240 - AfterAdd;
            this.addDataToExcel(st.Name, st.Surname, Convert.ToString(st.RegNum), Convert.ToString(st.TransfECTS), Convert.ToString(st.TotEcts),
            Convert.ToString(LastSemECTS.LastSem_ECTS), Convert.ToString(AfterAdd), Convert.ToString(LeftECTS), subCodes, Convert.ToString(TotSubEcts));
            this.closeExcel();

            return new HttpStatusCodeResult(204);
        }
    }
}

