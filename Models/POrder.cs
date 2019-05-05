using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class POrder
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string OrderNo { get; set; }

        public DateTime OrderDate { get; set; }
        [Display(Name = "Supplier")]
        public string Description { get; set; }


        public ICollection<POrderDetail> POrderDetails { get; set; }

        public POrder() { }
        public POrder(ViewModels.OrderVM O)
        {
            OrderNo = O.OrderNo;
            OrderDate = O.OrderDate;
            Description = O.Description;

            POrderDetails = O.POrderDetails;

        }
        public void SaveItems(POrder pOrder)
        {


            foreach (var item in pOrder.POrderDetails)
            {
                //var orderdetails = new POrderDetail()
                //{

                //    OrderID = pOrder.OrderID,
                //    ItemName = item.ItemName,
                //    Quantity = item.Quantity,
                //    Rate = item.Rate,
                //    TotalAmount = item.TotalAmount,

                //};

                //db.POrderDetails.Add(orderdetails);
                //I HAD TO DO THIS BECAUSE IT WAS SAVING THE ITEMS TWICE
                //var remove = db.POrderDetails.First(x => x.OrderID == pOrder.OrderID);
                //db.POrderDetails.Remove(remove);


                ProductAnalysis2 pa = new ProductAnalysis2();
                pa.save(item.ItemName, item.Quantity, item.Rate);
                pa.updateStock(item.ItemName, item.Quantity, item.Rate, pOrder.Description);
            }
            db.SaveChanges();
        }
    }
}