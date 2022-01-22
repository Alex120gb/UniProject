using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Student_Registration.Models;

namespace Student_Registration.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(string courses)
        {
            List<Student> stud = new List<Student>();
            MultiLists ml = new MultiLists();
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student.stid, student.name, student.surname, student.regNum, stud_course.scid, course.name, stud_course.scid " +
                    "FROM stud_course " +
                    "INNER JOIN student ON stud_course.student = student.stid " +
                    "INNER JOIN course ON stud_course.course = course.crid; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (courses != null)
                    {
                        ml.Crs_name = courses;
                        if (courses == reader[5].ToString())
                        {
                            Student st = new Student
                            {
                                ScId = Convert.ToInt32(reader[6]),
                                StId = Convert.ToInt32(reader[0]),
                                Name = reader[1].ToString(),
                                Surname = reader[2].ToString(),
                                RegNum = Convert.ToInt32(reader[3]),
                                Course = reader[5].ToString()
                            };
                            stud.Add(st);
                        }

                        if (courses == "All")
                        {
                            Student st = new Student
                            {
                                ScId = Convert.ToInt32(reader[6]),
                                StId = Convert.ToInt32(reader[0]),
                                Name = reader[1].ToString(),
                                Surname = reader[2].ToString(),
                                RegNum = Convert.ToInt32(reader[3]),
                                Course = reader[5].ToString()
                            };
                            stud.Add(st);
                        }
                    }
                }
            }

            List<Courses> crs = new List<Courses>();
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT course.name, structure.str_name FROM course; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Courses cr = new Courses
                    {
                        course_name = reader[0].ToString()
                    };

                    crs.Add(cr);
                }
            }
            
            ml.Courses = crs;
            ml.Studs = stud;

            return View(ml);
        }

        public ActionResult Index()
        {
            List<Student> stud = new List<Student>();
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student.stid, student.name, student.surname, student.regNum, stud_course.scid, course.name, stud_course.scid " +
                    "FROM stud_course " +
                    "INNER JOIN student ON stud_course.student = student.stid " +
                    "INNER JOIN course ON stud_course.course = course.crid; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student st = new Student
                    {
                        ScId = Convert.ToInt32(reader[6]),
                        StId = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        RegNum = Convert.ToInt32(reader[3]),
                        Course = reader[5].ToString()
                    };

                    stud.Add(st);

                }
            }

            List<Courses> crs = new List<Courses>();
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT course.name FROM course; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Courses cr = new Courses
                    {
                        course_name = reader[0].ToString()
                    };

                    crs.Add(cr);
                }
            }
            MultiLists ML = new MultiLists
            {
                Courses = crs,
                Studs = stud
            };

            return View(ML);
        }



    }
}