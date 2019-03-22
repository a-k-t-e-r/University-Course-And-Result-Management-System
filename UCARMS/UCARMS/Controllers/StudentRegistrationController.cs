using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UCARMS.Models;
using UCARMS.Context;

namespace UCARMS.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /StudentRegistration/
        public ActionResult Index()
        {
            var studentregistrations = db.StudentRegistrations.Include(s => s.Department);
            return View(studentregistrations.ToList());
        }

        // GET: /StudentRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentregistration = db.StudentRegistrations.Find(id);
            if (studentregistration == null)
            {
                return HttpNotFound();
            }
            return View(studentregistration);
        }

        // GET: /StudentRegistration/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name");
            return View();
        }

        // POST: /StudentRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StuRegNo,StuName,Email,ContactNo,Date,Address,DepartmentId")] StudentRegistration studentregistration)
        {
            if (ModelState.IsValid)
            {
                db.StudentRegistrations.Add(studentregistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", studentregistration.DepartmentId);
            return View(studentregistration);
        }

        // GET: /StudentRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentregistration = db.StudentRegistrations.Find(id);
            if (studentregistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", studentregistration.DepartmentId);
            return View(studentregistration);
        }

        // POST: /StudentRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StuRegNo,StuName,Email,ContactNo,Date,Address,DepartmentId")] StudentRegistration studentregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentregistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", studentregistration.DepartmentId);
            return View(studentregistration);
        }

        // GET: /StudentRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentregistration = db.StudentRegistrations.Find(id);
            if (studentregistration == null)
            {
                return HttpNotFound();
            }
            return View(studentregistration);
        }

        // POST: /StudentRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentRegistration studentregistration = db.StudentRegistrations.Find(id);
            db.StudentRegistrations.Remove(studentregistration);
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
