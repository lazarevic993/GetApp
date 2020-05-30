using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetApp.Data.Services;
using GetApp.Data.Models;

namespace GetApp.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectData db;

        public SubjectsController(ISubjectData db)
        {
            this.db = db;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
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
        public ActionResult Create(Subject subject)
        {

            if (ModelState.IsValid)
            {
                db.Add(subject);
                TempData["Message"] = "You have saved the subject!";

                return RedirectToAction("Details", new { id = subject.SubjectId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Update(subject);
                TempData["Message"] = "You have saved the subject!";

                return RedirectToAction("Details", new { id = subject.SubjectId });
            }

            return View(subject);
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
