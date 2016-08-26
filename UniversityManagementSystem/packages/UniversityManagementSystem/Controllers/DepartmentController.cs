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
    public class DepartmentController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        DepartmentManager departmentManager=new DepartmentManager();
        // GET: /Department/
        public ActionResult Index()
        {
            
            return View(departmentManager.GetAllDepartments());
        }

        // GET: /Department/Details/5
      

        // GET: /Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DepartmentCode,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (departmentManager.SaveDepartment(department))
                {
                    ViewBag.SuccessMessage = "Save Successfully";
                    return View();
                }
                ViewBag.ErrorMessage = "Code already Exist";
                return View();



            }

            return View(department);
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
