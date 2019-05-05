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
using System.Collections;
using System.Web.Helpers;

namespace Sprint0.Controllers
{
    public class ProductAnalysis2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductAnalysis2
        public ActionResult Index()
        {
            return View(db.ProductAnalysis2.ToList());
        }
        public ActionResult ProfitLoss()
        {
            return View(db.ProductAnalysis2.ToList());
        }

        // GET: ProductAnalysis2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAnalysis2 productAnalysis2 = db.ProductAnalysis2.Find(id);
            if (productAnalysis2 == null)
            {
                return HttpNotFound();
            }
            return View(productAnalysis2);
        }

        // GET: ProductAnalysis2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductAnalysis2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paid,Product_Name,Product_Quantity")] ProductAnalysis2 productAnalysis2)
        {
            if (ModelState.IsValid)
            {
                db.ProductAnalysis2.Add(productAnalysis2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productAnalysis2);
        }

        // GET: ProductAnalysis2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAnalysis2 productAnalysis2 = db.ProductAnalysis2.Find(id);
            if (productAnalysis2 == null)
            {
                return HttpNotFound();
            }
            return View(productAnalysis2);
        }

        // POST: ProductAnalysis2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paid,Product_Name,Product_Quantity")] ProductAnalysis2 productAnalysis2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productAnalysis2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productAnalysis2);
        }

        // GET: ProductAnalysis2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAnalysis2 productAnalysis2 = db.ProductAnalysis2.Find(id);
            if (productAnalysis2 == null)
            {
                return HttpNotFound();
            }
            return View(productAnalysis2);
        }

        // POST: ProductAnalysis2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductAnalysis2 productAnalysis2 = db.ProductAnalysis2.Find(id);
            db.ProductAnalysis2.Remove(productAnalysis2);
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



