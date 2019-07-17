using KWBlogg.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace KWBlogg.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<KWBlogg.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            #region Roles
            if (!context.Roles.Any(roles => roles.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!context.Roles.Any(roles => roles.Name == "Guest"))
            {
                roleManager.Create(new IdentityRole("Guest"));
            }

            if (!context.Roles.Any(roles => roles.Name == "Member"))
            {
                roleManager.Create(new IdentityRole("Member"));
            }
            #endregion

            #region Users
            if (!context.Users.Any(r => r.UserName == "admin@myblog.com"))
            {
                ApplicationUser adminUser = new ApplicationUser()
                {
                    UserName = "admin@myblog.Com",
                    Email = "admin@myblog.com",
                };

                userManager.Create(adminUser, "P@ssword");

            }

            if (!context.Users.Any(r => r.UserName == "guest@myblog.com"))
            {
                ApplicationUser guestUser = new ApplicationUser()
                {
                    UserName = "guest@myblog.Com",
                    Email = "guest@myblog.com",
                };

                userManager.Create(guestUser, "P@ssword");

            }

            if (!context.Users.Any(r => r.UserName == "member@myblog.com"))
            {
                ApplicationUser memberUser = new ApplicationUser()
                {
                    UserName = "member@myblog.Com",
                    Email = "admin@myblog.com",
                };

                userManager.Create(memberUser, "P@ssword");

            }
            #endregion

            #region AssignToRoles
            ApplicationUser admUser = context.Users.FirstOrDefault(r => r.Email == "admin@myblog.com");
            if (admUser != null)
            {
                userManager.AddToRole(admUser.Id, "Admin");
            }

            ApplicationUser gesUser = context.Users.FirstOrDefault(r => r.Email == "guest@myblog.com");
            if (gesUser != null)
            {
                userManager.AddToRole(gesUser.Id, "Guest");
            }

            ApplicationUser memUser = context.Users.FirstOrDefault(r => r.Email == "member@myblog.com");
            if (memUser != null)
            {
                userManager.AddToRole(memUser.Id, "Member");
            }
            #endregion

        }
    }
}



