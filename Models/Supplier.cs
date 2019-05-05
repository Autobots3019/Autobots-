using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int supplierid { get; set; }

        //[ForeignKey("inventoryid")]
        //public Inventory Inventory { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Supplier Name")]
        public string supplierName { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string supplierNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string supplierEmail { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string supplierLocation { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Type Of Supply")]
        public string supplytype { get; set; }

        public ICollection<InventoryProduct> InventoryProducts { get; set; }


    }
}