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
    public class ResumeController : Controller
    {
        private ResumeContext db = new ResumeContext();

        // GET: Resume
        [Authorize]
        [MyAuth(Roles ="Employer")]
        public ActionResult Index()
        {
            return View(db.SubmitResume.ToList());
        }

        // GET: Resume/Details/5
        [Authorize]
        [MyAuth(Roles = "Employer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit submit = db.SubmitResume.Find(id);
            if (submit == null)
            {
                return HttpNotFound();
            }
            return View(submit);
        }

        // GET: Resume/Create
        [Authorize]
        [MyAuth(Roles = "Jobseeker")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resume/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Education,nationality,Experience,PhoneNumber,Email")] Submit submit)
        {
            if (ModelState.IsValid)
            {
                db.SubmitResume.Add(submit);
                db.SaveChanges();
                return RedirectToAction("Home", "Jobseeker");
            }

            return View(submit);
        }


        // GET: Resume/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit submit = db.SubmitResume.Find(id);
            if (submit == null)
            {
                return HttpNotFound();
            }
            return View(submit);
        }

        // POST: Resume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Submit submit = db.SubmitResume.Find(id);
            db.SubmitResume.Remove(submit);
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
    }
}
