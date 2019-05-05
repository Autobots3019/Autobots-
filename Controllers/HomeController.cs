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
using System.Globalization;

using System.Net.Mail;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using System.Security.Claims;
using System.Threading.Tasks;

using Sprint0.Controllers;
using System.Web.Mvc.Html;
using Microsoft.AspNet.Identity.EntityFramework;


namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var cat = db.Category_.ToList();
            ViewBag.Categories = cat;


            var result = db.Products.Include(s => s.Categories).ToList();
            return View(result);
        }
       

        //[Authorize(Users="Admin")]
        public ActionResult Dashboard()
        {
            return View();
        }
      

        public ActionResult Stock()
        {
            var products = db.Products.ToList();
            ViewBag.products = products;

            var lowstock = products.Where(x => x.quantityOnHand < 10).ToList();
            ViewBag.lowstock = lowstock;

            var suppliers = db.Suppliers.ToList();
            ViewBag.supliers = suppliers;

            var porders = db.POrders.ToList();
            ViewBag.purchase = porders;

            return View();
        }

        public ActionResult Users()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);

            return View(product);
        }


        //public ActionResult Index2()
        //{
        //    var categ = db.Categories.ToList();

        //    return View(categ);
        //}

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }

        public ActionResult Browse(string categorypar)
        {
            var cat_model = db.Category_.Include("InventoryProducts").Single(g => g.categoryName == categorypar);
            return View(cat_model);
        }

        public new string Profile()
        {

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var name = currentUser.FirstName;


            return name;

        }

        public string LastName()
        {

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var lname = currentUser.LastName;


            return lname;

        }

        public string Cell()
        {

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var cell = currentUser.Cell;


            return cell;

        }
        public string Address()
        {

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var address = currentUser.Address;


            return address;

        }


        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult Route()
        {
            return View();
        }

       

    }
}