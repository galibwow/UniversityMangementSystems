using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Semesters
    {

        public int Id { get; set; }

        public string SemesterName { get; set; }

        public virtual ICollection<Course> CourseList { get; set; } 
    }
}