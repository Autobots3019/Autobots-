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
using System.IO;

namespace Sprint0.Controllers
{
    public class CataloguesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catalogues
        public ActionResult Index()
        {
            return View(db.Catalogues.ToList());
        }

        // GET: Catalogues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue catalogue = db.Catalogues.Find(id);
            if (catalogue == null)
            {
                return HttpNotFound();
            }
            return View(catalogue);
        }

        // GET: Catalogues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "catalogueId,catalogueName,catalogueDescription,Image")] Catalogue catalogue, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string str = file.FileName.Substring(file.FileName.Length - 3);
                    string path = string.Empty;
                    path = Server.MapPath("~/Content/Images/");
                    file.SaveAs(path + file.FileName);

                    using (db)
                    {
                        catalogue.Image = file.FileName;

                        db.Catalogues.Add(catalogue);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }

            return View(catalogue);
        }

        // GET: Catalogues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue catalogue = db.Catalogues.Find(id);
            if (catalogue == null)
            {
                return HttpNotFound();
            }
            return View(catalogue);
        }

        // POST: Catalogues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "catalogueId,catalogueName,catalogueDescription,Image")] Catalogue catalogue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogue);
        }

        // GET: Catalogues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue catalogue = db.Catalogues.Find(id);
            if (catalogue == null)
            {
                return HttpNotFound();
            }
            return View(catalogue);
        }

        // POST: Catalogues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalogue catalogue = db.Catalogues.Find(id);
            db.Catalogues.Remove(catalogue);
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
