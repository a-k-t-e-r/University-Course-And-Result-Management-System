using System.Collections.Generic;
using UCARMS.Gateway;
using UCARMS.Models;

namespace UCARMS.Manager
{
    public class CourseAssignManager
    {
        private CourseAssignGateway caGateway;

        public List<Teacher> GetTeacherDetails()
        {
            caGateway = new CourseAssignGateway();
            List<Teacher> teachers = caGateway.GetTeacherDetails();

            return teachers;
        }

        public List<Course> GetCourseDetails()
        {
            caGateway = new CourseAssignGateway();
            List<Course> courses = caGateway.GetCourseDetails();

            return courses;
        }
    }
}