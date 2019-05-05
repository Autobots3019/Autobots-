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

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;




using System.Text;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Collections;

namespace Sprint0.Controllers
{
    public class InventoryProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InventoryProducts
        public ActionResult Index(string productCategory, string search)
        {
            var categs = from g in db.Products
                         select g;

            if (!string.IsNullOrEmpty(search))
            {
                categs = categs.Where(g => g.productName.StartsWith(search));
            }
            return View(categs.ToList());
        }
        // GET: InventoryProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryProduct inventoryProduct = db.Products.Find(id);
            if (inventoryProduct == null)
            {
                return HttpNotFound();
            }
            return View(inventoryProduct);
        }

        // GET: InventoryProducts/Create
        public ActionResult Create()
        {
            ViewBag.catalogueId = new SelectList(db.Catalogue_, "catalogueId", "catalogueName");
            ViewBag.categoryId = new SelectList(db.Category_, "categoryId", "categoryName");
            ViewBag.supplierid = new SelectList(db.Suppliers, "supplierid", "supplierName");
            return View();
        }

        // POST: InventoryProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productId,brandName,productName,productDescription,Image,ImageType,categoryId,catalogueId,SupplierId,quantityOnHand,quantityForQuote,unitPrice,totalPrice")] InventoryProduct inventoryProduct, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                inventoryProduct.ImageType = Path.GetExtension(file.FileName);
                inventoryProduct.Image = ConvertToBytes(file);
            }

            if (ModelState.IsValid)
            {
                inventoryProduct.DiscountPrice = inventoryProduct.unitPrice;
                db.Products.Add(inventoryProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.catalogueId = new SelectList(db.Catalogue_, "catalogueId", "catalogueName", inventoryProduct.catalogueId);
            ViewBag.categoryId = new SelectList(db.Category_, "categoryId", "categoryName", inventoryProduct.categoryId);
            ViewBag.supplierid = new SelectList(db.Suppliers, "supplierid", "supplierName", inventoryProduct.SupplierId);
            return View(inventoryProduct);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            BinaryReader reader = new BinaryReader(file.InputStream);
            return reader.ReadBytes((int)file.ContentLength);
        }

        // Display File
        public FileStreamResult RenderImage(int id)
        {
            MemoryStream ms = null;

            var item = db.Products.FirstOrDefault(x => x.productId == id);
            //if (item.Image != null)
            {
                ms = new MemoryStream(item.Image);

            }



            return new FileStreamResult(ms, item.ImageType);
        }
        public ActionResult Quote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryProduct inventoryProduct = db.Products.Find(id);
            if (inventoryProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.catalogueId = new SelectList(db.Catalogue_, "catalogueId", "catalogueName", inventoryProduct.catalogueId);
            ViewBag.categoryId = new SelectList(db.Category_, "categoryId", "categoryName", inventoryProduct.categoryId);
            ViewBag.supplierid = new SelectList(db.Suppliers, "supplierid", "supplierName", inventoryProduct.SupplierId);
            return View(inventoryProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quote([Bind(Include = "productId,brandName,productName,productDescription,Image,ImageType,categoryId,catalogueId,quantityOnHand,quantityForQuote,unitPrice,DiscountPrice,totalPrice,supplierid,onPromotion")] InventoryProduct inventoryProduct, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    inventoryProduct.ImageType = Path.GetExtension(file.FileName);
                    inventoryProduct.Image = ConvertToBytes(file);
                }
                db.Entry(inventoryProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LowStock");
            }
            ViewBag.catalogueId = new SelectList(db.Catalogue_, "catalogueId", "catalogueName", inventoryProduct.catalogueId);
            ViewBag.categoryId = new SelectList(db.Category_, "categoryId", "categoryName", inventoryProduct.categoryId);
            ViewBag.supplierid = new SelectList(db.Suppliers, "supplierid", "supplierName", inventoryProduct.SupplierId);
            return View(inventoryProduct);
        }
        // GET: InventoryProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryProduct inventoryProduct = db.Products.Find(id);
            if (inventoryProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.catalogueId = new SelectList(db.Catalogue_, "catalogueId", "catalogueName", inventoryProduct.catalogueId);
            ViewBag.categoryId = new SelectList(db.Category_, "categoryId", "categoryName", inventoryProduct.categoryId);
            ViewBag.supplierid = new SelectList(db.Suppliers, "supplierid", "supplierName", inventoryProduct.SupplierId);
            return View(inventoryProduct);
        }

        // POST: InventoryProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,brandName,productName,productDescription,Image,ImageType,categoryId,catalogueId,quantityOnHand,quantityForQuote,unitPrice,DiscountPrice,totalPrice,supplierid,onPromotion")] InventoryProduct inventoryProduct, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    inventoryProduct.ImageType = Path.GetExtension(file.FileName);
                    inventoryProduct.Image = ConvertToBytes(file);
                }
                inventoryProduct.DiscountPrice = inventoryProduct.unitPrice;
                db.Entry(inventoryProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catalogueId = new SelectList(db.Catalogue_, "catalogueId", "catalogueName", inventoryProduct.catalogueId);
            ViewBag.categoryId = new SelectList(db.Category_, "categoryId", "categoryName", inventoryProduct.categoryId);
            ViewBag.supplierid = new SelectList(db.Suppliers, "supplierid", "supplierName", inventoryProduct.SupplierId);
            return View(inventoryProduct);
        }

        // GET: InventoryProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryProduct inventoryProduct = db.Products.Find(id);
            if (inventoryProduct == null)
            {
                return HttpNotFound();
            }
            return View(inventoryProduct);
        }

        // POST: InventoryProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryProduct inventoryProduct = db.Products.Find(id);
            db.Products.Remove(inventoryProduct);
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
        public ActionResult LowStock()
        {


            return View(db.Products.Where(x => x.quantityOnHand <= 5).ToList());



        }




        public async Task<ActionResult> Invoice(int? id)
        {

            //if (ModelState.IsValid)
            //{
            //    if (id == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            //    inventoryProduct = db.Products.Find(id);
            //    if (inventoryProduct == null)
            //    {
            //        return HttpNotFound();
            //    }
            List<InventoryProduct> items = db.Products.Where(x => x.quantityOnHand <= 5).ToList();

            StringBuilder sbName = new StringBuilder();
            StringBuilder sbBrand = new StringBuilder();
            StringBuilder sbQuantity = new StringBuilder();


            foreach (var prod in items)
            {
                sbName.AppendFormat("{0}<br>", prod.productName);
            }

            foreach (var prod in items)
            {
                sbBrand.AppendFormat("{0}<br>", prod.brandName);
            }
            foreach (var prod in items)
            {
                sbQuantity.AppendFormat("{0}<br>", prod.quantityForQuote);
            }


            var body = "<p>To: {0} ({1})</p><p>Request:</p><p>{2}</p>";
            //body += "<table align ='Left'>";

            //body += "<tr>";
            //body += "<td>  </td>";
            //body += "<td >" + "Dear Sir/Madam" + "</td>";
            //body += "</tr>";




            //body += "</table>" + "</br>";


            body += "<p>";

            body += "Kindy Provide A Quotation for the Following Items with respective quanitites:";
            body += "</p>";




            body += "</br>";


            body += "<table align = 'Left'";
            body += "<th>" + sbBrand + "</th>";
            body += "</table>";

            body += "<table align = 'Center'";
            body += "<th>" + sbName + "&nbsp;" + sbQuantity + "</th>";
            body += "</table>";

            //body += "<table align = 'Right'";
            //body += "<th align = Left >"+sbQuantity + "</th>";
            //body += "</table>";









            var message = new MailMessage();


            ArrayList arEmails = new ArrayList();

            foreach (var supp in items)
            {

                //arEmails.Add(supp.Suppliers.supplierEmail.ToString());
                message.To.Add(supp.Suppliers.supplierEmail);

            }


            //string strEmails = string.Join(", ", arEmails);

            /*   message.To.Add(strEmails);*/  // replace with valid value 
            message.From = new MailAddress("trunesh1996@gmail.com");  // replace with valid value
            message.Subject = "PETSWORLD QUOTE REQUEST";
            message.Body = string.Format(body, message.From, "Petsworld", " ");
            message.IsBodyHtml = true;

            //message.Attachments.Add(new Attachment("Index.cshtml"));

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "trunesh1996@gmail.com",  // replace with valid value
                    Password = "Bukkake01"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

            }





            return RedirectToAction("InvoiceSent");




            //return View("LowStock");
        }

        public ActionResult InvoiceSent()
        {
            return View();
        }

    }
}

