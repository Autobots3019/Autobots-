using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class POrderDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemsID { get; set; }

        public int OrderID { get; set; }
        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal Rate { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual POrder POrder { get; set; }


    }
}