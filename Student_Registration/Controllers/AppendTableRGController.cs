using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Student_Registration.Models;

namespace Student_Registration.Controllers
{
    public class AppendTableRGController : Controller
    {
        [HttpPost]
        public ActionResult AppendTable(int subj)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=student_registration; port=3306;password=''; SslMode=none;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subject.sbj, subject.code, subject.name, subject.ects, semester.sname, semester.yr, struct_group.name FROM subject " +
                    "INNER JOIN sem_sub ON subject.sbj = sem_sub.subject " +
                    "INNER JOIN semester ON sem_sub.semester = semester.semid " +
                    "INNER JOIN sbj_struct_group ON subject.sbj = sbj_struct_group.subject " +
                    "INNER JOIN struct_group ON  sbj_struct_group.struct_group = struct_group.sgid; ", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (subj == Convert.ToInt32(reader["sbj"]))
                    {
                        Session["ects_cnt"] = Convert.ToInt32(reader[3]) + Convert.ToInt32(Session["ects_cnt"]);
                        sb.Append("<tr> " +
                        "<td style='display:none' > <input type='text' id='strct_name' value='" + reader[6].ToString() + "'> </td>" +
                        "<td style='display:none' > <input type='text' name='subjE' id='gback' value='" + Convert.ToInt32(reader[0]) + "'> </td>" +
                        "<td class='sbj_cd' >" + reader[1].ToString() + "</td>" +
                        "<td class='sbj_name' >" + reader[2].ToString() + "</td>" +
                        "<td class='ects_cnt'>" + reader[3].ToString() + "</td>" +
                        "<td>" + reader[4].ToString() + " " + reader[5].ToString() +"</td>" +
                        "<td> <button  id='rm_row'  class='btn btn-danger' onclick='removeRow()'> Remove </button></td> </tr>");
                        int ect = Convert.ToInt32(reader[3]);
                        return Content(sb.ToString(), ect.ToString());
                    }
                }

                reader.Close();
            }

            return View();
        }
    }
}