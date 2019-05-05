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
using System.Web.Helpers;
using System.Collections;

namespace Sprint0.Controllers
{
    public class ProductAnalysisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductAnalysis
        public ActionResult Index()
        {
            return View(db.ProductAnalysis.ToList());
        }
        public ActionResult Profit()
        {
            return View(db.ProductAnalysis.ToList());
        }

        // GET: ProductAnalysis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAnalysis productAnalysis = db.ProductAnalysis.Find(id);
            if (productAnalysis == null)
            {
                return HttpNotFound();
            }
            return View(productAnalysis);
        }

        // GET: ProductAnalysis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductAnalysis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paid,Product_Name,Product_Quantity")] ProductAnalysis productAnalysis)
        {
            if (ModelState.IsValid)
            {
                db.ProductAnalysis.Add(productAnalysis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productAnalysis);
        }

        // GET: ProductAnalysis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAnalysis productAnalysis = db.ProductAnalysis.Find(id);
            if (productAnalysis == null)
            {
                return HttpNotFound();
            }
            return View(productAnalysis);
        }

        // POST: ProductAnalysis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paid,Product_Name,Product_Quantity")] ProductAnalysis productAnalysis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productAnalysis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productAnalysis);
        }

        // GET: ProductAnalysis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAnalysis productAnalysis = db.ProductAnalysis.Find(id);
            if (productAnalysis == null)
            {
                return HttpNotFound();
            }
            return View(productAnalysis);
        }

        // POST: ProductAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductAnalysis productAnalysis = db.ProductAnalysis.Find(id);
            db.ProductAnalysis.Remove(productAnalysis);
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

        public ActionResult HighestSellingProduct()
        {
            ProductAnalysis pa = new ProductAnalysis();

            return View(pa.HighestSellingProduct());


        }

        public ActionResult LowestSellingProduct()
        {
            ProductAnalysis pa = new ProductAnalysis();

            return View(pa.LowestSellingProduct());


        }

        public ActionResult Chart()

        {


            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = (from c in db.ProductAnalysis select c);
            results.ToList().ForEach(rs => xValue.Add(rs.Product_Name));
            results.ToList().ForEach(rs => yValue.Add(rs.Product_Quantity));


            new Chart(width: 800, height: 600, theme: ChartTheme.Blue)
                .AddTitle("Product Analysis").
                SetXAxis("Product Name")
                .SetYAxis("Number of Sales")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue).Write("png");



            return null;
        }


    }
}
