using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class Order
    {

        public Order()
        {
            this.OrderDate = DateTime.Now;
            this.OrderProgress = 0;


        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Display(Name = "OrderNo")]
        public string OrderNumber { get; set; }
        [Display(Name = "Status")]
        public string CurrentStatus { get; set; }

        public int OrderProgress { get; set; }
        [Display(Name = "Quantity")]
        public int OrderQuantity { get; set; }
        [Display(Name = "Total Cost")]
        public decimal TotalOrderCost { get; set; }
        [Display(Name = "Inspected?")]
        public bool Status { get; set; }
        public bool Confirmed { get; set; }
        public bool Paid { get; set; }
        public bool Delivered { get; set; }
        public bool Emailed { get; set; }
        public DateTime OrderDate { get; set; }
        [Display(Name = "Address")]
        public string DeliveryAddress { get; set; }
        public int Id { get; set; }
        public virtual ApplicationUser customer { get; set; }
        [Display(Name = "Customer")]
        public string username { get; set; }
        public string Cell { get; set; }
        [Display(Name = "Driver")]
        public string AssignedDriver { get; set; }




       

    }
}