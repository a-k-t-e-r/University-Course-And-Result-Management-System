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
using UCARMS.Manager;

namespace UCARMS.Controllers
{
    public class StudentResultController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /StudentResult/
        public ActionResult Index()
        {
            var studentresults = db.StudentResults.Include(s => s.Course).Include(s => s.GradeLetter);
            return View(studentresults.ToList());
        }

        // GET: /StudentResult/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResult studentresult = db.StudentResults.Find(id);
            if (studentresult == null)
            {
                return HttpNotFound();
            }
            return View(studentresult);
        }

        // GET: /StudentResult/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name");
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "Id", "GradeLetterName");
            return View();
        }

        // POST: /StudentResult/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StudentRegistrationNum,StudentName,Email,Department,CourseId,GradeLetterId")] StudentResult studentresult)
        {
            if (ModelState.IsValid)
            {
                db.StudentResults.Add(studentresult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", studentresult.CourseId);
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "Id", "GradeLetterName", studentresult.GradeLetterId);
            return View(studentresult);
        }

        private StudentResultManager _srManager;

        public JsonResult GetStudentRegistrationDetails(string id)
        {
            _srManager = new StudentResultManager();
            StudentRegistration resultData = _srManager.GetStudentRegistrationDetails(id);

            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

        private StudentEnrollManager _seManager;

        public JsonResult GetDepartmentName(int id)
        {
            _seManager = new StudentEnrollManager();
            var departmentName = _seManager.GetDepartmentName(id);

            return Json(departmentName, JsonRequestBehavior.AllowGet);
        }

        // GET: /StudentResult/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResult studentresult = db.StudentResults.Find(id);
            if (studentresult == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Code", studentresult.CourseId);
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "Id", "GradeLetterName", studentresult.GradeLetterId);
            return View(studentresult);
        }

        // POST: /StudentResult/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StudentRegistrationNum,StudentName,Email,Department,CourseId,GradeLetterId")] StudentResult studentresult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentresult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Code", studentresult.CourseId);
            ViewBag.GradeLetterId = new SelectList(db.GradeLetters, "Id", "GradeLetterName", studentresult.GradeLetterId);
            return View(studentresult);
        }

        // GET: /StudentResult/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResult studentresult = db.StudentResults.Find(id);
            if (studentresult == null)
            {
                return HttpNotFound();
            }
            return View(studentresult);
        }

        // POST: /StudentResult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentResult studentresult = db.StudentResults.Find(id);
            db.StudentResults.Remove(studentresult);
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
