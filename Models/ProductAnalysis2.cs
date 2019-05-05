using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class ProductAnalysis2
    {
        [Key]
        public int paid { get; set; }
        [Display(Name = "Product")]
        public string Product_Name { get; set; }
        [Display(Name = "Items Purchased")]
        public int Product_Quantity { get; set; }
        [Display(Name = "Cost Price")]
        public decimal Product_Cost { get; set; }

        public ProductAnalysis2()
        {
            Product_Name = "";
            Product_Quantity = 0;


        }


        public ApplicationDbContext db = new ApplicationDbContext();
        public void save(string name, int count, decimal unitPrice)
        {
            bool val = false;

            try
            {
                foreach (var prod in db.ProductAnalysis2.ToList())
                {
                    if (prod.Product_Name == name)
                    {
                        val = true;
                        prod.Product_Quantity += count;
                        Product_Cost = Product_Cost + Convert.ToDecimal(unitPrice * count);

                        db.SaveChanges();
                    }


                }

                if (val == false)
                {

                    db.ProductAnalysis2.Add(new ProductAnalysis2()
                    {
                        Product_Name = name,
                        Product_Quantity = count,
                        Product_Cost = Convert.ToDecimal(unitPrice * count)

                    });


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            db.SaveChanges();


        }


        public void updateStock(string name, int count, decimal unitPrice, string supp)
        {
            bool val = false;
            foreach (var prod in db.Products.ToList())
            {
                if (prod.productName == name)
                {
                    val = true;
                    InventoryProduct inv = new InventoryProduct();

                    inv = db.Products.ToList().Find(x => x.productName == name);
                    inv.quantityOnHand = inv.quantityOnHand + count;
                    db.SaveChanges();
                }


            }
            if (val == false)
            {
                InventoryProduct add = new InventoryProduct();
                add.AddProduct(name, count, unitPrice, supp);
                db.SaveChanges();

            }
        }







      

    }
}