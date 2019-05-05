using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class Customer
    {
        [Key]
        public string customerID { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}