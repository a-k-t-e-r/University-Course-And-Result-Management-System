using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UCARMS.Models;

namespace UCARMS.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Department> DepartmentDbSet { get; set; }
        public DbSet<Semester> SemesterDbSet { get; set; }
        public DbSet<Course> CourseDbSet { get; set; }
        public DbSet<Designation> DisignationDbSet { get; set; }
        public DbSet<Teacher> TeacherDbSet { get; set; }
        public DbSet<CourseAssign> CourseAssignDbSet { get; set; }
        public DbSet<ClassRoom> ClassRoomDbSet { get; set; }
        public DbSet<Day> DayDbSet { get; set; }
        public DbSet<ClassAllocation> ClassAllocationDbSet { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<StudentEnroll> StudentEnrolls { get; set; }
        public DbSet<GradeLetter> GradeLetters { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
    }
}