using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCARMS.Gateway;
using UCARMS.Models;

namespace UCARMS.Manager
{
    public class StudentResultManager
    {
        private StudentResultGateway _srGateway;

        public StudentRegistration GetStudentRegistrationDetails(string id)
        {
            _srGateway = new StudentResultGateway();
            StudentRegistration resultData = _srGateway.GetStudentRegistrationDetails(id);

            return resultData;
        }
    }
}