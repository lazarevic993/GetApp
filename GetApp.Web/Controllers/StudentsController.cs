using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetApp.Data.Services;
using GetApp.Data.Models;

namespace GetApp.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentData db;

        public StudentsController(IStudentData db)
        {
            this.db = db;
        }

   
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View (model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if(db.GetAllStudentIndexes().Contains(student.IndexNumber))
            {
                TempData["Message"] = "Student with that index number already exists!";

                return RedirectToAction("Create");
            }
            if(ModelState.IsValid)
            {
                db.Add(student);
                TempData["Message"] = "You have saved the student!";

                return RedirectToAction("Details", new { id = student.StudentId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (db.GetAllStudentIndexes().Contains(student.IndexNumber))
            {
                TempData["Message"] = "Student with that index number already exists!";

                return RedirectToAction("Edit");
            }
            if (ModelState.IsValid)
            {
                db.Update(student);
                TempData["Message"] = "You have saved the student!";

                return RedirectToAction("Details", new { id = student.StudentId });
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
