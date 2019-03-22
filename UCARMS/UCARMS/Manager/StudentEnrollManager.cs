using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCARMS.Gateway;
using UCARMS.Models;

namespace UCARMS.Manager
{
    public class StudentEnrollManager
    {
        private StudentEnrollGateway _seGateway;

        public List<StudentRegistration> GetStudentRegistrationDetails()
        {
            _seGateway = new StudentEnrollGateway();
            List<StudentRegistration> studentDetails = _seGateway.GetStudentRegistrationDetails();

            return studentDetails;
        }

        public string GetDepartmentName(int id)
        {
            _seGateway = new StudentEnrollGateway();
            var departmentName = _seGateway.GetDepartmentName(id);

            return departmentName;
        }
    }
}