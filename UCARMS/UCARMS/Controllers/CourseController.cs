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
    public class CourseController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /Course/
        public ActionResult Index()
        {
            var coursedbset = db.CourseDbSet.Include(c => c.Department).Include(c => c.Semester);
            return View(coursedbset.ToList());
        }

        // GET: /Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: /Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name");
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "Id", "Name");
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Code,Name,Credit,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.CourseDbSet.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "Id", "Name", course.SemesterId);
            return View(course);
        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "Id", "Name", course.SemesterId);
            return View(course);
        }

        // POST: /Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Code,Name,Credit,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "Id", "Name", course.SemesterId);
            return View(course);
        }

        // GET: /Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.CourseDbSet.Find(id);
            db.CourseDbSet.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ViewCourseStatics()
        {
            ViewBag.vcsDepartments = db.DepartmentDbSet;
            return View();
        }

        public JsonResult GetCourseDetails()
        {
            List<Course> courses = db.CourseDbSet.ToList();

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSemesterDetails()
        {
            var semesters = db.SemesterDbSet.ToList();

            return Json(semesters, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseAssignDetails()
        {
            var AssignCourses = db.CourseAssignDbSet.ToList();

            return Json(AssignCourses, JsonRequestBehavior.AllowGet);
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
