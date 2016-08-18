using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class DepartmentGateway
    {
        public string Connectionstring = WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public int SaveDepartment(Department Department)
        {
            SqlConnection connection=new SqlConnection(Connectionstring);

            string quary = "INSERT INTO Department (DepartmentCode,DepartmentName) VALUES('" + Department.DepartmentCode + "', '" +
                           Department.DepartmentName + "')";
            SqlCommand command=new SqlCommand(quary,connection);
            connection.Open();
            int rowAffectedColumn = command.ExecuteNonQuery();
            connection.Close();
            return rowAffectedColumn;


        }

        public bool IsCodeExist(Department department)
        {
            SqlConnection connection=new SqlConnection(Connectionstring);
            string quary = "Select DepartmentCode From Department Where DepartmentCode='" + department.DepartmentCode + "'";
            SqlCommand command=new SqlCommand(quary,connection);
            connection.Open();
           
            SqlDataReader reader=command.ExecuteReader();


            while(reader.HasRows)
                {

                    reader.Read();
                 Department dept=new Department();
                 dept.DepartmentCode = reader["DepartmentCode"].ToString();
                    reader.Close();

                    connection.Close();
                    return false;
                }
            return true;


        }

        public List<Department> GetAllDepartmentList()
        {
            SqlConnection connection=new SqlConnection(Connectionstring);
            string quary = "Select * from Department";
            connection.Open();
            List<Department> DepartmentList=new List<Department>();
            SqlCommand command=new SqlCommand(quary,connection);

            
            SqlDataReader reader=command.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                 Department department=new Department();
                    department.Id = Convert.ToInt32(reader["Id"].ToString());
                    department.DepartmentCode = reader["DepartmentCode"].ToString();
                    department.DepartmentName = reader["DepartmentName"].ToString();
                    DepartmentList.Add(department);
                }  
                reader.Close();

            }
            connection.Close();
            return DepartmentList;
        }


        public Department Departments()
        {
            SqlConnection connection = new SqlConnection(Connectionstring);
            string quary = "Select * from Department";
            connection.Open();
            Department dept=new Department();
            SqlCommand command = new SqlCommand(quary, connection);


            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();
                    department.Id = Convert.ToInt32(reader["Id"].ToString());
                    department.DepartmentCode = reader["DeaprtmentCode"].ToString();
                    department.DepartmentName = reader["DepartmentName"].ToString();
                    dept = department;
                }
                reader.Close();

            }
            connection.Close();
            return dept;
        } 

    }
}