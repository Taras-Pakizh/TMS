using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.TeamLead.ViewModels
{
    public class ProfilePageViewModel
    {
        static private WebApiServices services = new WebApiServices();
        //public BindableCollection<UserView> Employees { get; set; }
        public UserView User { get; set; }
        public string Days { get; set; }
        public string Projects { get; set; }
        public string ApproveCount { get; set; }
        public string TeamName { get; set; }

        public ProfilePageViewModel()
        {
            var res = services.Authorization("Pakizh_engineer", "Taras20.");
            User = services.Get<UserView>(1);
            var report = services.GetAll<ReportView>().Where(x => x.engineerId == 1).ToList();
            int day = 0;
            foreach (var i in report)
            {
                day += i.end.Day - i.start.Day;
            }
            Days = "Загальна кількість днів\n" + "роботи над проектами: " + day;

            var approve = services.GetAll<ApproveView>().Where(x => x.approveAuthorId == 3).Count();
            ApproveCount = "Загальна кількість\n" + "підтверджених звітів: " + approve;
            var t = services.Get<UserView>(1);
            var team = services.Get<TeamView>(1);
            TeamName = "Team name: " + team.name;

        }
    }
}
