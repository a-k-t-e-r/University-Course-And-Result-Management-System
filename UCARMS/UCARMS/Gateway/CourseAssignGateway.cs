using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Owin.BuilderProperties;
using UCARMS.Models;

namespace UCARMS.Gateway
{
    public class CourseAssignGateway : BaseGateway
    {
        public List<Teacher> GetTeacherDetails()
        {
            string cmdText = "SELECT * FROM TEACHERS";
            Command = new SqlCommand(cmdText, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.Id = Convert.ToInt32(Reader["Id"]);
                aTeacher.Name = Reader["Name"].ToString();
                aTeacher.Address = Reader["Address"].ToString();
                aTeacher.Email = Reader["Email"].ToString();
                aTeacher.ContactNo = Reader["ContactNo"].ToString();
                aTeacher.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                aTeacher.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aTeacher.Credit = Convert.ToInt32(Reader["Credit"]);

                teachers.Add(aTeacher);
            }

            Reader.Close();
            Connection.Close();

            return teachers;
        }

        public List<Course> GetCourseDetails()
        {
            string cmdText = "SELECT * FROM COURSES";
            Command = new SqlCommand(cmdText, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = Convert.ToInt32(Reader["Id"]);
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Name = Reader["Name"].ToString();
                aCourse.Credit = Convert.ToDecimal(Reader["Credit"]);
                aCourse.Description = Reader["Description"].ToString();
                aCourse.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aCourse.SemesterId = Convert.ToInt32(Reader["SemesterId"]);

                courses.Add(aCourse);
            }

            Reader.Close();
            Connection.Close();

            return courses;
        }
    }
}