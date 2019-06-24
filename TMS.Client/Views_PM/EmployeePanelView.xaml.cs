using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.Project_Manager.Views
{
    /// <summary>
    /// Interaction logic for EmployeePanelView.xaml
    /// </summary>
    public partial class EmployeePanelView : UserControl
    {
        private int UserID;
        private UserView User;
        static private WebApiServices services = new WebApiServices();
        private IEnumerable<ReportView> report;
        public EmployeePanelView()
        {
            InitializeComponent();
            services.Authorization("Pakizh_engineer", "Taras20.");
        }
        /// <summary>
        /// Ініціалізація нового юзера
        /// </summary>
        /// <param name="id">ід юзера</param>
        public void InitUser(int id)
        {
            UserID = id;
            User = services.Get<UserView>(UserID);
            report = services.GetAll<ReportView>().Where(x => x.engineerId == UserID);
            BackEnd_Developing.Text = "BackEnd Developing: " + report.Where(x => x.activity == TMS.Data.ActivityType.BackEnd_Developing).Sum(x => x.effort) + " h";
            FrontEnd_Developing.Text = "FrontEnd Developing: " + report.Where(x => x.activity == TMS.Data.ActivityType.FrontEnd_Developing).Sum(x => x.effort) + " h";
            Testing.Text = "Testing: " + report.Where(x => x.activity == TMS.Data.ActivityType.Testing).Sum(x => x.effort) + " h";
            UI_Designing.Text = "UI Designing: " + report.Where(x => x.activity == TMS.Data.ActivityType.UI_Designing).Sum(x => x.effort) + " h";
            DB_Designing.Text = "DB Designing: " + report.Where(x => x.activity == TMS.Data.ActivityType.DB_Designing).Sum(x => x.effort) + " h";
            Bug_fixing.Text = "Bug fixing: " + report.Where(x => x.activity == TMS.Data.ActivityType.Bug_fixing).Sum(x => x.effort) + " h";

            Reports.ItemsSource = report;
            Name.Text = User.FullName;
            Email.Text = User.email;
            Role.Text = User.role.ToString();



        }

        private void Approve_Checked(object sender, RoutedEventArgs e)
        {
            if (Approve.IsChecked == true)
            {
                var approveReport = report.Where(x => x.status == TMS.Data.ReportStatus.Approved);
                Reports.ItemsSource = approveReport;
            }
            if (Approve.IsChecked == false)
            {
                Reports.ItemsSource = report;
            }
        }
    }
}
