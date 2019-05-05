using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class ProductAnalysis
    {
        [Key]
        public int paid { get; set; }
        [Display(Name = "Product")]
        public string Product_Name { get; set; }
        [Display(Name = "Items Sold")]
        public int Product_Quantity { get; set; }

        [Display(Name = "Revenue")]
        public decimal Product_Cost { get; set; }


        public ProductAnalysis()
        {
            Product_Name = "";
            Product_Quantity = 0;
            Product_Cost = 0;
        }


        public ApplicationDbContext db = new ApplicationDbContext();
        public void save(string name, int count, decimal unitPrice)
        {
            bool val = false;

            try
            {
                foreach (var prod in db.ProductAnalysis.ToList())
                {
                    if (prod.Product_Name == name)
                    {
                        val = true;
                        prod.Product_Quantity += count;
                        Product_Cost += (unitPrice * count);
                    }


                }

                if (val == false)
                {
                    db.ProductAnalysis.Add(new ProductAnalysis()
                    {
                        Product_Name = name,
                        Product_Quantity = count,
                        Product_Cost = unitPrice * count,

                    });
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            db.SaveChanges();


        }





        public ProductAnalysis HighestSellingProduct()
        {

            int high = 0;
            ProductAnalysis pa = new ProductAnalysis();


            foreach (var prod in db.ProductAnalysis.ToList())
            {
                if (prod.Product_Quantity > high)
                {
                    high = prod.Product_Quantity;
                    pa = prod;

                }
            }
            return pa;
        }
        public ProductAnalysis LowestSellingProduct()
        {

            int low = HighestSellingProduct().Product_Quantity;


            ProductAnalysis pa = new ProductAnalysis();

            foreach (var prod in db.ProductAnalysis.ToList())
            {
                if (prod.Product_Quantity < low)
                {
                    low = prod.Product_Quantity;
                    pa = prod;

                }
            }
            return pa;
        }


    }
}