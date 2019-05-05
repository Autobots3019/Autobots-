using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sprint0.Models
{
    public class Catalogue
    {
        [Key]

        public int catalogueId { get; set; }

        [Display(Name = "Catalogue")]
        public string catalogueName { get; set; }


        [Display(Name = "Description")]
        public string catalogueDescription { get; set; }

        public string Image { get; set; }

        //        public ICollection<InventoryProduct> InventoryProduct { get; set; }
    }
}