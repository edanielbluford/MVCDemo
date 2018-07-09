using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class ClassOnesController : Controller
    {
        private MVCDemoContext db = new MVCDemoContext();

        // GET: ClassOnes
        public ActionResult Index()
        {
            return View(db.ClassOnes.ToList());
        }

        // GET: ClassOnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOne classOne = db.ClassOnes.Find(id);
            if (classOne == null)
            {
                return HttpNotFound();
            }
            return View(classOne);
        }

        // GET: ClassOnes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,Name,MyAge")] ClassOne classOne)
        {
            if (ModelState.IsValid)
            {
                db.ClassOnes.Add(classOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classOne);
        }

        // GET: ClassOnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOne classOne = db.ClassOnes.Find(id);
            if (classOne == null)
            {
                return HttpNotFound();
            }
            return View(classOne);
        }

        // POST: ClassOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,Name,MyAge")] ClassOne classOne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classOne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classOne);
        }

        // GET: ClassOnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOne classOne = db.ClassOnes.Find(id);
            if (classOne == null)
            {
                return HttpNotFound();
            }
            return View(classOne);
        }

        // POST: ClassOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassOne classOne = db.ClassOnes.Find(id);
            db.ClassOnes.Remove(classOne);
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
