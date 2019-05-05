using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sprint0.Models
{
    public class Category_
    {
        [Key]

        public int categoryId { get; set; }

        [Display(Name = "Category")]
        public string categoryName { get; set; }



        public ICollection<InventoryProduct> InventoryProducts { get; set; }
    }
}