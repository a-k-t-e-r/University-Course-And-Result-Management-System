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
    public class StudentEnrollController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /StudentEnroll/
        public ActionResult Index()
        {
            var studentenrolls = db.StudentEnrolls.Include(s => s.Course);
            return View(studentenrolls.ToList());
        }

        // GET: /StudentEnroll/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEnroll studentenroll = db.StudentEnrolls.Find(id);
            if (studentenroll == null)
            {
                return HttpNotFound();
            }
            return View(studentenroll);
        }

        // GET: /StudentEnroll/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name");
            return View();
        }

        // POST: /StudentEnroll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StudentRegistrationNo,StudentName,Email,Department,CourseId,Date")] StudentEnroll studentenroll)
        {
            if (ModelState.IsValid)
            {
                db.StudentEnrolls.Add(studentenroll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", studentenroll.CourseId);
            return View(studentenroll);
        }

        private StudentEnrollManager _seManager;

        public JsonResult GetStudentRegistrationDetails()
        {
            _seManager = new StudentEnrollManager();
            var studentDetails = _seManager.GetStudentRegistrationDetails();

            return Json(studentDetails, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentName(int id)
        {
            _seManager = new StudentEnrollManager();
            var departmentName = _seManager.GetDepartmentName(id);

            return Json(departmentName, JsonRequestBehavior.AllowGet);
        }

        // GET: /StudentEnroll/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEnroll studentenroll = db.StudentEnrolls.Find(id);
            if (studentenroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Code", studentenroll.CourseId);
            return View(studentenroll);
        }

        // POST: /StudentEnroll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StudentRegistrationNo,StudentName,Email,Department,CourseId,Date")] StudentEnroll studentenroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentenroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Code", studentenroll.CourseId);
            return View(studentenroll);
        }

        // GET: /StudentEnroll/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEnroll studentenroll = db.StudentEnrolls.Find(id);
            if (studentenroll == null)
            {
                return HttpNotFound();
            }
            return View(studentenroll);
        }

        // POST: /StudentEnroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            StudentEnroll studentenroll = db.StudentEnrolls.Find(id);
            db.StudentEnrolls.Remove(studentenroll);
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
