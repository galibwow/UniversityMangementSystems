using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class UniversityDbContext:DbContext
    {
       public DbSet<Department> Departments { get; set; }
       public DbSet<Course> Courses { get; set; }

      public  DbSet<Teacher> Teachers { get; set; }
      //public DbSet<Enroll> Enrolls { get; set; }
      public DbSet<Semesters> Semesterses { get; set; }

      public DbSet<CourseAssignToTeacher> CourseAssignToTeachers { get; set; } 
      public UniversityDbContext() : base("name=UniversityDbContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Designation> Designations { get; set; }

        
    }
}