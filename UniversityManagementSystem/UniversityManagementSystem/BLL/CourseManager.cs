using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Controllers;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {

        CourseGateway courseGateway = new CourseGateway();


        public Course GetCourseByCourseId(int Id)
        {
            return courseGateway.GetCourseByCourseId(Id);
        }

        public List<Course> GetCourseByDepartmentId(int Id)
        {
            return courseGateway.GetCourseByDepartmentId(Id);
        }
    }
}