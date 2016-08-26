using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {

        public int Id { get; set; }
        [DisplayName("Course Code")]
        public string CourseCode { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        

        public decimal Credit { get; set; }

        public string Description { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        public Semesters Semester { get; set; }


        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeacher { get; set; } 
    }
}