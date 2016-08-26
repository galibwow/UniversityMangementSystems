using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class TeacherGateway:CommonGateway
    {
        
        public Teacher GetTeacherCredit(int Id)
        {
        SqlConnection connectionString=new SqlConnection(ConnectionString);
        string quary = "Select CreditToBeTaken from Teacher Where Id='" + Id + "'";

        connectionString.Open();
            SqlCommand command=new SqlCommand(quary,connectionString);

            SqlDataReader reader = command.ExecuteReader();
            Teacher teachers=new Teacher();
            
            
            while (reader.Read())
            {
                teachers.CreditToBeTaken = Convert.ToDecimal(reader["CreditToBeTaken"]);
                reader.Close();

            }
            return teachers;

        }


        public List<Teacher> GetTeacherByDepartmentId(int Id)
        {
            SqlConnection connection=new SqlConnection(ConnectionString);

            string quary = "Select * from Teacher Where DepartmentId='" + Id + "'";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
    
           
           List<Teacher>teacherList=new List<Teacher>();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                { Teacher teachers=new Teacher();
                    
                    teachers.Id = Convert.ToInt32(reader["Id"].ToString());
                    teachers.TeacherName = reader["TeacherName"].ToString();
                    


                    
                    teacherList.Add(teachers);

                }
                reader.Close();
            }
            return teacherList;

        }
    }
}