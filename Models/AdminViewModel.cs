using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }

    //public class Driver
    //{
    //    [Required]
    //    [DataType(DataType.Text)]
    //    [Display(Name = "Driver Name")]
    //    public string driverName { get; set; }


    //    [Required]
    //    [DataType(DataType.PhoneNumber)]
    //    [Display(Name = "Contact Number")]
    //    public string dNumber { get; set; }


    //    [Required]
    //    [DataType(DataType.EmailAddress)]
    //    [Display(Name = "Email")]
    //    public string dEmail { get; set; }
    //}
}