using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.ViewModel
{
    public class CourseStatics
    {

        public int Id { get; set; }

        
        public CourseAssignToTeacher CourseAssignToTeacher { get; set; }


        public string CourseCode
        {
            get
            {
                return CourseAssignToTeacher.Course.CourseCode;
                
            }
            set { CourseAssignToTeacher.Course.CourseCode = value; }
        }


        public string CourseName
        {
            get { return CourseAssignToTeacher.Course.CourseName; }
            set { CourseAssignToTeacher.Course.CourseName= value; }

           
        }

        public string SemesterName
        {
            get { return CourseAssignToTeacher.Course.Semester.SemesterName; }
            set { CourseAssignToTeacher.Course.Semester.SemesterName = value; }
        }

        public string AssisgnTo
        {
            get { return CourseAssignToTeacher.Teacher.TeacherName; }
            set { CourseAssignToTeacher.Teacher.TeacherName = value; }
        }


    }
}