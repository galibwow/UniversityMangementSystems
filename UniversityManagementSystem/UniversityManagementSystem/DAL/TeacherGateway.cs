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
            SqlCommand command=new SqlCommand(quary,connectionString);
            connectionString.Open();
            SqlDataReader reader = command.ExecuteReader();
            Teacher teachers=new Teacher();
            
            while (reader.Read())
            {
                teachers.CreditToBeTaken = Convert.ToDecimal(reader["CreditToBeTaken"]);
                reader.Close();

            }
            return teachers;

        }


        public Teacher GetTeacherByDepartmentId(int Id)
        {
            SqlConnection connection=new SqlConnection(ConnectionString);

            string quary = "Select * from Teacher Where DepartmentId='" + Id + "'";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Teacher teachers = new Teacher();

            while (reader.Read())
            {
                teachers.Id = Convert.ToInt32(reader[Id]);
                teachers.TeacherName = reader["TeacherName"].ToString();
                
                
                reader.Close();

            }
            return teachers;
        }
    }
}