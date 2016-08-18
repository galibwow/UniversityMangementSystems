using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CoursesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /Courses/
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester);
            return View(courses.ToList());
        }

      
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.SemesterId = new SelectList(db.Semesterses, "Id", "SemesterName");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CourseCode,CourseName,Credit,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesterses, "Id", "SemesterName", course.SemesterId);
            return View(course);
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
