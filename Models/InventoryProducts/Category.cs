using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sprint0.Models
{
    public class Category
    {
        [Key]

        public int categoryId { get; set; }

        [Display(Name = "Category")]
        public string categoryName { get; set; }

        [Display(Name = "Description")]
        public string categoryDescription { get; set; }




        public string Image { get; set; }

        //public ICollection<InventoryProduct> InventoryProduct { get; set; }
    }
}
