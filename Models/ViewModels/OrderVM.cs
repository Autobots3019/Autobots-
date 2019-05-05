using Sprint0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint0.ViewModels
{
    public class OrderVM
    {


        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        [Display(Name = "Supplier")]
        public string Description { get; set; }

        public List<POrderDetail> POrderDetails { get; set; }
    }
}