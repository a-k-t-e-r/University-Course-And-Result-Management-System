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
    public class CourseAssignController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /CourseAssign/
        public ActionResult Index()
        {
            var courseassigndbset = db.CourseAssignDbSet.Include(c => c.Course).Include(c => c.Department).Include(c => c.Teacher);
            return View(courseassigndbset.ToList());
        }

        // GET: /CourseAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssignDbSet.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // GET: /CourseAssign/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.TeacherDbSet, "Id", "Name");
            return View();
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DepartmentId,TeacherId,CreditTaken,CreditRemain,CourseId,CourseName,CourseCredit")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssignDbSet.Add(courseassign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.TeacherDbSet, "Id", "Name", courseassign.TeacherId);
            return View(courseassign);
        }

        public JsonResult GetTeacherDetails()
        {
            CourseAssignManager caManager = new CourseAssignManager();
            var teachers = caManager.GetTeacherDetails();

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseDetails()
        {
            CourseAssignManager caManager = new CourseAssignManager();
            var course = caManager.GetCourseDetails();

            return Json(course, JsonRequestBehavior.AllowGet);
        }

        // GET: /CourseAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssignDbSet.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.TeacherDbSet, "Id", "Name", courseassign.TeacherId);
            return View(courseassign);
        }

        // POST: /CourseAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DepartmentId,TeacherId,CreditTaken,CreditRemain,CourseId,CourseName,CourseCredit")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.TeacherDbSet, "Id", "Name", courseassign.TeacherId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssignDbSet.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // POST: /CourseAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseassign = db.CourseAssignDbSet.Find(id);
            db.CourseAssignDbSet.Remove(courseassign);
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
