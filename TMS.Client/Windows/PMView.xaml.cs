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
using TMS.Client.Project_Manager.ViewModels;
using TMS.Client.ViewModels;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.Project_Manager
{
    /// <summary>
    /// Interaction logic for PMView.xaml
    /// </summary>
    public partial class PMView : Window
    {
        static private WebApiServices services = new WebApiServices();

        private UserView _currentUser;

        public PMView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _currentUser = ((ApplicationView)DataContext).CurrentUser;
            services = ((ApplicationView)DataContext).Proxy.Client;
            DataContext = null;
        }

        private void LoadAddProjectPage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddProjectViewModel();
            default_image.Visibility = Visibility.Collapsed;
        }

        private void LoadProjectsPage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProjectsViewModel();
            default_image.Visibility = Visibility.Collapsed;
            this.Width = 1200;
        }

        private void LoadEmployeesPage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeesViewModel(_currentUser, services);
            default_image.Visibility = Visibility.Collapsed;
        }

        private void LoadProfilePage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProfilePageViewModel(_currentUser, services);
            default_image.Visibility = Visibility.Collapsed;
        }
    }
}
