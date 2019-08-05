using GateBoysWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GateBoysWebApplication.Startup))]
namespace GateBoysWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
         
        }

        //public void CreateUserAndRoles()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        //create super admin role
        //        var role = new IdentityRole("Admin");
        //        roleManager.Create(role);

        //        //create default user
        //        var user = new ApplicationUser();
        //        user.UserName = "Admin@gateboys.com";
        //        user.Email = "Admin@gateboys.com";
        //        string pwd = "Password#1";

        //        var newuser = userManager.Create(user, pwd);
        //        if (newuser.Succeeded)
        //        {
        //            userManager.AddToRole(user.Id, "Admin");
        //        }

        //    }
        //}
    }
}
