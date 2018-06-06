using AuthTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TopJobs.DatabaseContext;
using TopJobs.Models;

namespace TopJobs.Controllers
{
    public class EmployerController : Controller
    {
        private EmployerContext db = new EmployerContext();

        // GET: Employer
        [Authorize]
        [MyAuth(Roles ="Employer")]
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: Employer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Jobs.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Employer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employer/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,JobTitle,Category,Location,Requirement,Salary,Phone_Number,Email")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(post);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(post);
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
