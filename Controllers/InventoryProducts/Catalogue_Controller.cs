using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Sprint0.Models;

namespace Sprint0.Controllers
{
    public class Catalogue_Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catalogue_
        public ActionResult Index()
        {
            return View(db.Catalogue_.ToList());
        }

        // GET: Catalogue_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue_ catalogue_ = db.Catalogue_.Find(id);
            if (catalogue_ == null)
            {
                return HttpNotFound();
            }
            return View(catalogue_);
        }

        // GET: Catalogue_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogue_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "catalogueId,catalogueName")] Catalogue_ catalogue_)
        {
            if (ModelState.IsValid)
            {
                db.Catalogue_.Add(catalogue_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogue_);
        }

        // GET: Catalogue_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue_ catalogue_ = db.Catalogue_.Find(id);
            if (catalogue_ == null)
            {
                return HttpNotFound();
            }
            return View(catalogue_);
        }

        // POST: Catalogue_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "catalogueId,catalogueName")] Catalogue_ catalogue_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogue_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogue_);
        }

        // GET: Catalogue_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue_ catalogue_ = db.Catalogue_.Find(id);
            if (catalogue_ == null)
            {
                return HttpNotFound();
            }
            return View(catalogue_);
        }

        // POST: Catalogue_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalogue_ catalogue_ = db.Catalogue_.Find(id);
            db.Catalogue_.Remove(catalogue_);
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

