using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data
{
    class Inizializator : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var list = new List<User>()
            {
                new User()
                {
                    firstName = "Taras",
                    lastName = "Pakizh",
                    email = "pakizht@gmail.com",
                    role = Role.Engineer,
                    login = "Pakizh_engineer"
                },
                new User()
                {
                    firstName = "Taras",
                    lastName = "Pakizh",
                    email = "pakizht@gmail.com",
                    role = Role.ProjectManager,
                    login = "Pakizh_projectManager"
                },
                new User()
                {
                    firstName = "Taras",
                    lastName = "Pakizh",
                    email = "pakizht@gmail.com",
                    role = Role.TeamLead,
                    login = "Pakizh_teamlead"
                }
            };

            var team = context.Teams.Add(new Team()
            {
                name = "Beast team"
            });

            foreach (var item in list)
            {
                var user = context.Users.Add(item);
                team.engineers.Add(user);
            }

            team.teamlead = team.engineers.Where(x => x.role == Role.TeamLead).Single();

            context.SaveChanges();
        }
    }
}
