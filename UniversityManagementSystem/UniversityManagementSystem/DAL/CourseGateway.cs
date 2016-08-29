using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class CourseGateway : CommonGateway
    {

        public Course GetCourseByCourseId(int Id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string quary = "Select * from Course where Id='" + Id + "'";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            Course course = new Course();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    course.Id = Convert.ToInt32(reader["Id"]);
                    course.CourseName = reader["CourseName"].ToString();
                    course.CourseCode = reader["CourseCode"].ToString();
                    course.Credit = Convert.ToDecimal(reader["Credit"]);



                }
                reader.Close();
            }

            connection.Close();
            return course;
        }



        public List<Course> GetCourseByDepartmentId(int Id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string quary = "Select * from Course where DepartmentId='" + Id + "'";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();

            List<Course> CourseList = new List<Course>();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();
                    course.Id = Convert.ToInt32(reader["Id"]);
                    course.CourseName = reader["CourseName"].ToString();
                    course.CourseCode = reader["CourseCode"].ToString();
                    course.Credit = Convert.ToDecimal(reader["Credit"]);
                    course.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    CourseList.Add(course);
                }
                reader.Close();
            }

            connection.Close();
            return CourseList;
        }
    }
}