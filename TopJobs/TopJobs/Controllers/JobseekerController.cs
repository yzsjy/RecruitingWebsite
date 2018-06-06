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
    public class JobseekerController : Controller
    {
        private JobseekerContext db = new JobseekerContext();

        // GET: Jobseeker
        [Authorize]
        [MyAuth(Roles ="Jobseeker")]
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.Resumes.ToList());
        }

        // GET: Jobseeker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Create create = db.Resumes.Find(id);
            if (create == null)
            {
                return HttpNotFound();
            }
            return View(create);
        }

        // GET: Jobseeker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobseeker/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Education,nationality,Experience,PhoneNumber,Email")] Create create)
        {
            if (ModelState.IsValid)
            {
                db.Resumes.Add(create);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(create);
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
