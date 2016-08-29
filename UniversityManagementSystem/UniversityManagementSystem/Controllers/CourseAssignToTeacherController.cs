using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        private TeacherManager teacherManager = new TeacherManager();

        private CourseManager courseManager = new CourseManager();

        private DepartmentManager departmentManager = new DepartmentManager();
        // GET: /CourseAssignToTeacher/
        public ActionResult Index()
        {
            var courseassigntoteachers = db.CourseAssignToTeachers.Include(c => c.Course).Include(c => c.Departments).Include(c => c.Teacher);
            return View(courseassigntoteachers.ToList());
        }



        // GET: /CourseAssignToTeacher/Create
        public ActionResult Create()
        {

            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode");
            ViewBag.DepartmentId = departmentManager.GetAllDepartments();
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,CourseId,TeacherId,CourseAssign")] CourseAssignToTeacher courseassigntoteacher)
        {
            if (ModelState.IsValid)
            {


                db.CourseAssignToTeachers.Add(courseassigntoteacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode", courseassigntoteacher.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", courseassigntoteacher.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassigntoteacher.TeacherId);
            return View(courseassigntoteacher);
        }

        // GET: /CourseAssignToTeacher/Edit/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //public PartialViewResult TeacherCreadit(int Id)
        //{

        //    ViewBag.TeacherCredit = teacherManager.GetTeacherCredit(Id);
        //    return PartialView();
        //}

        public JsonResult GetTeacherByDepartmentId(int teacherId)
        {
            var teacherList = teacherManager.GetTeacherByDepartmentId(teacherId);
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCourseByCourseId(int courseId)
        {
            var courses = courseManager.GetCourseByCourseId(courseId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTeacherByTeacherId(int teacherId)
        {
            var teacher = teacherManager.GetTeacherByTeacherId(teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var course = courseManager.GetCourseByDepartmentId(departmentId);

            return Json(course, JsonRequestBehavior.AllowGet);
        }



        public Decimal CalculateCredit(int tId, int cId)
        {
            Teacher teacher = teacherManager.GetTeacherByTeacherId(tId);
            Course course = courseManager.GetCourseByCourseId(cId);
            decimal remaining = 0;
            remaining += teacher.CreditToBeTaken - course.Credit;
            return remaining;
        }

    }
}
