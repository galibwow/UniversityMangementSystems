using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Department
    {

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }

        public virtual ICollection<Course> CoursesList { get; set; }

        public virtual ICollection<Teacher> TeacherList { get; set; } 
    }
}