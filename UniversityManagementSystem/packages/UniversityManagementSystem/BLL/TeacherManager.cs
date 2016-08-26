using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {

        TeacherGateway teacherGateway=new TeacherGateway();

        public Teacher GetTeacherCredit(int Id)
        {
            return teacherGateway.GetTeacherCredit(Id);
        }

        public List<Teacher> GetTeacherByDepartmentId(int Id)
        {
            return teacherGateway.GetTeacherByDepartmentId(Id);
        }
    }
}