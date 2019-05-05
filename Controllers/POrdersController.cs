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
    public class POrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: POrders
        public ActionResult Index()
        {
            return View(db.POrders.ToList());
        }
        public ActionResult GetDetails(int OrderId)
        {


            return View(db.POrderDetails.Where(x => x.OrderID == OrderId).ToList());



        }
        // GET: POrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POrder pOrder = db.POrders.Find(id);
            if (pOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOrder);
        }

        // GET: POrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderNo,OrderDate,Description")] POrder pOrder)
        {
            if (ModelState.IsValid)
            {
                db.POrders.Add(pOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pOrder);
        }

        // GET: POrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POrder pOrder = db.POrders.Find(id);
            if (pOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOrder);
        }

        // POST: POrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderNo,OrderDate,Description")] POrder pOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOrder);
        }

        // GET: POrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POrder pOrder = db.POrders.Find(id);
            if (pOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOrder);
        }

        // POST: POrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POrder pOrder = db.POrders.Find(id);
            db.POrders.Remove(pOrder);
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