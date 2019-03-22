using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCARMS.Models;

namespace UCARMS.Gateway
{
    public class StudentEnrollGateway :BaseGateway
    {
        private string _cmdText;

        public List<StudentRegistration> GetStudentRegistrationDetails()
        {
            _cmdText = "SELECT * FROM StudentRegistrations";
            Command = new SqlCommand(_cmdText, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentRegistration> studentRegistrations = new List<StudentRegistration>();

            while (Reader.Read())
            {
                StudentRegistration aStudentRegistration = new StudentRegistration();
                aStudentRegistration.Id = Convert.ToInt32(Reader["Id"]);
                aStudentRegistration.StuRegNo = Reader["StuRegNo"].ToString();
                aStudentRegistration.StuName = Reader["StuName"].ToString();
                aStudentRegistration.Email = Reader["Email"].ToString();
                aStudentRegistration.ContactNo = Reader["ContactNo"].ToString();
                aStudentRegistration.Date = Convert.ToDateTime(Reader["Date"]);
                aStudentRegistration.Address = Reader["Address"].ToString();
                aStudentRegistration.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);

                studentRegistrations.Add(aStudentRegistration);
            }

            Reader.Close();
            Connection.Close();

            return studentRegistrations;
        }

        public string GetDepartmentName(int id)
        {
            _cmdText = "SELECT * FROM Department where id =" + id;
            Command = new SqlCommand(_cmdText, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string departmentName = null;

            while (Reader.Read())
            {
                departmentName = Reader["Name"].ToString();
            }

            Reader.Close();
            Connection.Close();

            return departmentName;
        }
    }
}