using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();

        public bool SaveDepartment(Department department)
        {

            if (departmentGateway.IsCodeExist(department))
            {


                int isSaved = departmentGateway.SaveDepartment(department);
                if (isSaved > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartmentList();

        }

        public Department GetDepartment()
        {
            return departmentGateway.Departments();
        }


    }
}