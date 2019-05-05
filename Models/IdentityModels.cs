using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Sprint0.Models;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cell { get; set; }
        public string Address { get; set; }
        [Display(Name = "Rating Aspect")]
        public string City { get; set; }
        public string Role { get; set; }


        public int dogCount { get; set; }
        public int catCount { get; set; }
        public int fishCount { get; set; }
        public int birdCount { get; set; }

        public int otherCount { get; set; }






        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //public virtual UserProfile UserProfile { get; set; }

        public object FindByName(string p)
        {
            throw new System.NotImplementedException();
        }

    }

    public abstract class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public string Address { get; set; }

        public byte[] AddPhoto { get; set; }

    }


    public class Employee : UserProfile
    {
        public string Role { get; set; }


        public object GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
    public class Administrator : UserProfile
    {
        public string UserId { get; set; }
    }

    public class Customer : UserProfile
    {
        public string userId { get; set; }
        public int DeliveryAddressId { get; set; }
     //   public virtual DeliveryAddress deliveryAddress { get; set; }
        public int OrderId { get; set; }
     //   public virtual Order order { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Sprint0.Models.InventoryProduct> Products { get; set; }


        public System.Data.Entity.DbSet<Sprint0.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Sprint0.Models.Catalogue> Catalogues { get; set; }

        public System.Data.Entity.DbSet<Sprint0.Models.Catalogue_> Catalogue_ { get; set; }

        public System.Data.Entity.DbSet<Sprint0.Models.Category_> Category_ { get; set; }

        public System.Data.Entity.DbSet<Sprint0.Models.Order> Orders { get; set; }



        public System.Data.Entity.DbSet<Sprint0.Models.Customer> Customers { get; set; }
        

        internal static object Open(string v)
        {
            throw new NotImplementedException();
        }
        


        public System.Data.Entity.DbSet<IdentitySample.Models.RoleViewModel> RoleViewModels { get; set; }


        

        public System.Data.Entity.DbSet<Sprint0.Models.ProductAnalysis> ProductAnalysis { get; set; }
        public System.Data.Entity.DbSet<Sprint0.Models.ProductAnalysis2> ProductAnalysis2 { get; set; }
        

        public System.Data.Entity.DbSet<Sprint0.Models.Supplier> Suppliers { get; set; }

        

        public System.Data.Entity.DbSet<Sprint0.Models.POrder> POrders { get; set; }
        public System.Data.Entity.DbSet<Sprint0.Models.POrderDetail> POrderDetails { get; set; }

        //public System.Data.Entity.DbSet<PETSWORLD.ViewModels.OrderVM> OrderVMs { get; set; }


    }
}