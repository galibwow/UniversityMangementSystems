using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Department
    {

        public int Id { get; set; }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [DisplayName("Department Code")]
        public string DepartmentCode { get; set; }

        public virtual ICollection<Course> CoursesList { get; set; }

        public virtual ICollection<Teacher> TeacherList { get; set; }

        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeacher { get; set; } 
    }
}