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
    public class ClassAllocationController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /ClassAllocation/
        public ActionResult Index()
        {
            var classallocationdbset = db.ClassAllocationDbSet.Include(c => c.ClassRoom).Include(c => c.Course).Include(c => c.Day).Include(c => c.Department);
            return View(classallocationdbset.ToList());
        }

        // GET: /ClassAllocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAllocation classallocation = db.ClassAllocationDbSet.Find(id);
            if (classallocation == null)
            {
                return HttpNotFound();
            }
            return View(classallocation);
        }

        // GET: /ClassAllocation/Create
        public ActionResult Create()
        {
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomDbSet, "Id", "RoomNumber");
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name");
            ViewBag.DayId = new SelectList(db.DayDbSet, "Id", "DayName");
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name");
            return View();
        }

        // POST: /ClassAllocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DepartmentId,CourseId,ClassRoomId,DayId,FromDate,ToDate")] ClassAllocation classallocation)
        {
            if (ModelState.IsValid)
            {
                db.ClassAllocationDbSet.Add(classallocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassRoomId = new SelectList(db.ClassRoomDbSet, "Id", "RoomNumber", classallocation.ClassRoomId);
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", classallocation.CourseId);
            ViewBag.DayId = new SelectList(db.DayDbSet, "Id", "DayName", classallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", classallocation.DepartmentId);
            return View(classallocation);
        }

        // GET: /ClassAllocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAllocation classallocation = db.ClassAllocationDbSet.Find(id);
            if (classallocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomDbSet, "Id", "RoomNumber", classallocation.ClassRoomId);
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", classallocation.CourseId);
            ViewBag.DayId = new SelectList(db.DayDbSet, "Id", "DayName", classallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", classallocation.DepartmentId);
            return View(classallocation);
        }

        // POST: /ClassAllocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DepartmentId,CourseId,ClassRoomId,DayId,FromDate,ToDate")] ClassAllocation classallocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classallocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRoomDbSet, "Id", "RoomNumber", classallocation.ClassRoomId);
            ViewBag.CourseId = new SelectList(db.CourseDbSet, "Id", "Name", classallocation.CourseId);
            ViewBag.DayId = new SelectList(db.DayDbSet, "Id", "DayName", classallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "Id", "Name", classallocation.DepartmentId);
            return View(classallocation);
        }

        // GET: /ClassAllocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAllocation classallocation = db.ClassAllocationDbSet.Find(id);
            if (classallocation == null)
            {
                return HttpNotFound();
            }
            return View(classallocation);
        }

        // POST: /ClassAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassAllocation classallocation = db.ClassAllocationDbSet.Find(id);
            db.ClassAllocationDbSet.Remove(classallocation);
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
