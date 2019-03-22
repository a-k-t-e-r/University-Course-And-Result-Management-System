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
    public class GradeLetterController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /GradeLetter/
        public ActionResult Index()
        {
            return View(db.GradeLetters.ToList());
        }

        // GET: /GradeLetter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLetter gradeletter = db.GradeLetters.Find(id);
            if (gradeletter == null)
            {
                return HttpNotFound();
            }
            return View(gradeletter);
        }

        // GET: /GradeLetter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GradeLetter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,GradeLetterName")] GradeLetter gradeletter)
        {
            if (ModelState.IsValid)
            {
                db.GradeLetters.Add(gradeletter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gradeletter);
        }

        // GET: /GradeLetter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLetter gradeletter = db.GradeLetters.Find(id);
            if (gradeletter == null)
            {
                return HttpNotFound();
            }
            return View(gradeletter);
        }

        // POST: /GradeLetter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,GradeLetterName")] GradeLetter gradeletter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradeletter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gradeletter);
        }

        // GET: /GradeLetter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLetter gradeletter = db.GradeLetters.Find(id);
            if (gradeletter == null)
            {
                return HttpNotFound();
            }
            return View(gradeletter);
        }

        // POST: /GradeLetter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradeLetter gradeletter = db.GradeLetters.Find(id);
            db.GradeLetters.Remove(gradeletter);
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
