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
using System.Windows.Shapes;
using TMS.Client.TeamLead.ViewModels;
using TMS.Services;

namespace TMS.Client.TeamLead
{
    /// <summary>
    /// Interaction logic for TeamLeadView.xaml
    /// </summary>
    public partial class TeamLeadView : Window
    {
        static private WebApiServices services = new WebApiServices();
        public TeamLeadView()
        {
            InitializeComponent();
            var res = services.Authorization("Pakizh_engineer", "Taras20.");
        }

        private void LoadProjectsPage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProjectsViewModel();
            default_image.Visibility = Visibility.Collapsed;
        }

        private void LoadEmployeesPage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeesViewModel();
            default_image.Visibility = Visibility.Collapsed;
        }

        private void LoadProfilePage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProfilePageViewModel();
            default_image.Visibility = Visibility.Collapsed;
        }
    }
}
