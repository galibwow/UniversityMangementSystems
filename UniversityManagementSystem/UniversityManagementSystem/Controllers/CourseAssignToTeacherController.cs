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
        private TeacherManager teacherManager=new TeacherManager();
        // GET: /CourseAssignToTeacher/
        public ActionResult Index()
        {
            var courseassigntoteachers = db.CourseAssignToTeachers.Include(c => c.Course).Include(c => c.Departments).Include(c => c.Teacher);
            return View(courseassigntoteachers.ToList());
        }

        // GET: /CourseAssignToTeacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssignToTeacher courseassigntoteacher = db.CourseAssignToTeachers.Find(id);
            if (courseassigntoteacher == null)
            {
                return HttpNotFound();
            }
            return View(courseassigntoteacher);
        }

        // GET: /CourseAssignToTeacher/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName");
            return View();
        }

        // POST: /CourseAssignToTeacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DepartmentId,CourseId,TeacherId,CourseAssign")] CourseAssignToTeacher courseassigntoteacher)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssignToTeacher courseassigntoteacher = db.CourseAssignToTeachers.Find(id);
            if (courseassigntoteacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode", courseassigntoteacher.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", courseassigntoteacher.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassigntoteacher.TeacherId);
            return View(courseassigntoteacher);
        }

        // POST: /CourseAssignToTeacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DepartmentId,CourseId,TeacherId,CourseAssign")] CourseAssignToTeacher courseassigntoteacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassigntoteacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode", courseassigntoteacher.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", courseassigntoteacher.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassigntoteacher.TeacherId);
            return View(courseassigntoteacher);
        }

        // GET: /CourseAssignToTeacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssignToTeacher courseassigntoteacher = db.CourseAssignToTeachers.Find(id);
            if (courseassigntoteacher == null)
            {
                return HttpNotFound();
            }
            return View(courseassigntoteacher);
        }

        // POST: /CourseAssignToTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssignToTeacher courseassigntoteacher = db.CourseAssignToTeachers.Find(id);
            db.CourseAssignToTeachers.Remove(courseassigntoteacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public PartialViewResult TeacherCreadit(int Id)
        {

            ViewBag.TeacherCredit = teacherManager.GetTeacherCredit(Id);
            return PartialView();
        }
    }
}
