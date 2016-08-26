using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssignToTeacher
    {

        public int Id { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
        [DisplayName("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [DisplayName("CourseAssign")]
        public int CourseAssign { get; set; }
    }
}
