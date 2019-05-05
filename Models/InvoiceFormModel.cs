using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sprint0.Models
{
    public class InvoiceFormModel
    {
        [Display(Name = "Your name")]
        public string FromName { get; set; }
        [Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        public string Message { get; set; }
    }
}