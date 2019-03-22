using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCARMS.Models;

namespace UCARMS.Gateway
{
    public class StudentResultGateway : BaseGateway
    {
        private string _cmdText;

        public StudentRegistration GetStudentRegistrationDetails(string id)
        {
            _cmdText = "SELECT * FROM StudentRegistrations where StuRegNo = '" + id+"'";
            Command = new SqlCommand(_cmdText, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            StudentRegistration aStudentRegistration = null;

            while (Reader.Read())
            {
                aStudentRegistration = new StudentRegistration();

                aStudentRegistration.Id = Convert.ToInt32(Reader["Id"]);
                aStudentRegistration.StuRegNo = Reader["StuRegNo"].ToString();
                aStudentRegistration.StuName = Reader["StuName"].ToString();
                aStudentRegistration.Email = Reader["Email"].ToString();
                aStudentRegistration.ContactNo = Reader["ContactNo"].ToString();
                aStudentRegistration.Date = Convert.ToDateTime(Reader["Date"]);
                aStudentRegistration.Address = Reader["Address"].ToString();
                aStudentRegistration.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);

            }

            Reader.Close();
            Connection.Close();

            return aStudentRegistration;
        }
    }
}