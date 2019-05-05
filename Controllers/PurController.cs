using Sprint0.ViewModels;
using Sprint0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace Sprint0.Controllers
{
    public class PurController : Controller
    {

        // GET: Pur
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ViewBag.Supplier = new SelectList(db.Suppliers, "SupplierName", "SupplierName");
            return View();
        }

        //Post action for Save data to database
        [HttpPost]
        public JsonResult SaveOrder(ViewModels.OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    POrder order = new POrder(O) { OrderNo = O.OrderNo, OrderDate = O.OrderDate, Description = O.Description };

                    dc.POrders.Add(order);
                    dc.SaveChanges();
                    order.SaveItems(order);
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}