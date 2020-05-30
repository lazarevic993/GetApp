using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GetApp.Data.Services;

namespace GetApp.Web.Controllers
{
    public class HomeController : Controller
    {
        IStudentData dbStudent;
        IExamData dbExam;

        public HomeController(IStudentData dbStudent,IExamData dbExam)
        {
            this.dbStudent = dbStudent;
            this.dbExam = dbExam;
        }

        public ActionResult Index()
        {
            Hashtable ht = new Hashtable();
            ht.Add("students", dbStudent.GetAll());
            ht.Add("exams", dbExam.GetAll());

            return View(ht);
        }
    }
}
