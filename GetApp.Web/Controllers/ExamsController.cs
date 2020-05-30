using System.Web.Mvc;
using GetApp.Data.Services;
using GetApp.Data.Models;
using Microsoft.AspNet.SignalR;

namespace GetApp.Web
{
    public class ExamsController : Controller
    {
        private readonly IExamData db;

        public ExamsController(IExamData db)
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
            ViewBag.studentIndexes = new SelectList(db.GetAllStudentIndexes());
            ViewBag.subjectId = new SelectList(db.GetAllSubjetId());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exam exam)
        {

            if (ModelState.IsValid)
            {
                db.Add(exam);
                TempData["Message"] = "You have saved the exam!";


                return RedirectToAction("Details", new { id = exam.ExamId });
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
            ViewBag.studentIndexes = new SelectList(db.GetAllStudentIndexes());
            ViewBag.subjectId = new SelectList(db.GetAllSubjetId());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Update(exam);
                TempData["Message"] = "You have saved the exam!";
                return RedirectToAction("Details", new { id = exam.ExamId });
            }

            return View(exam);
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
