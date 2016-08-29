using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {

        public int Id { get; set; }
        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }

        

        public string Address { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        [DisplayName("Disignationn")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        [DisplayName("Credit To Be Taken")]
        public decimal CreditToBeTaken { get; set; }

        public decimal RemainingCredit { get; set; }
        public virtual ICollection<CourseAssignToTeacher> CourseAssignToTeacher { get; set; } 
    }
}