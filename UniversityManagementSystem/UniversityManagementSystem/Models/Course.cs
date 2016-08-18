using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {

        public int Id { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }


        public decimal Credit { get; set; }

        public string Description { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int SemesterId { get; set; }

        public Semesters Semester { get; set; }
    }
}