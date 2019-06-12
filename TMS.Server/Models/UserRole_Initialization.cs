using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TMS.Server.Models
{
    public class UserRole_Initialization : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleList = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Engineer" },
                new IdentityRole { Name = "TeamLead" },
                new IdentityRole { Name = "ProjectManager" }
            };

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Email = "pakizht@gmail.com",
                    UserName = "Pakizh_engineer"
                },

                new ApplicationUser()
                {
                    Email = "pakizht@gmail.com",
                    UserName = "Pakizh_teamlead"
                },

                new ApplicationUser()
                {
                    Email = "pakizht@gmail.com",
                    UserName = "Pakizh_projectManager"
                }
            };

            string password = "Taras20.";
            
            foreach(var item in users.Zip(roleList, (_user, _role) => new { user = _user, role = _role }))
            {
                roleManager.Create(item.role);
                var result = userManager.Create(item.user, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(item.user.Id, item.role.Name);
                }
            }

            base.Seed(context);
        }
    }
}