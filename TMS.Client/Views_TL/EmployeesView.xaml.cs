﻿using Caliburn.Micro;
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
using TMS.Client.TeamLead.ViewModels;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.TeamLead.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        static private WebApiServices services = new WebApiServices();

        public BindableCollection<UserView> Users { get; set; }

        EmployeePanelView panelView = new EmployeePanelView();

        public EmployeesView()
        {
            InitializeComponent();
        }

        public EmployeesViewModel Context
        {
            get { return (EmployeesViewModel)DataContext; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            services = Context.Client;
            var result = services.GetAll<UserView>().Where(x => x.team_id == Context.User.team_id);
            Users = new BindableCollection<UserView>(result);

            //Govno
            var team_info = services.Get<TeamView>(Context.User.team_id);
            txtTeamName.Text = team_info.name;

            panelView.Back.Click += BackButton;
            panelEmployees.ItemsSource = Users.ToList();
        }

        public List<UserView> GetUsers()
        {
            var users = (from dev in services.GetAll<UserView>()
                         join team in services.GetAll<TeamView>()
                         on dev.team_id equals team.Id
                         select new UserView
                         {
                             firstName = dev.firstName,
                             lastName = dev.lastName,
                             email = dev.email,
                             role = dev.role,
                             login = dev.login,
                             team_id = dev.team_id
                         }).ToList();
            return users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panelEmployees.Visibility = Visibility.Hidden;
            var btn = sender as Button;
            panelView.InitUser(Convert.ToInt32(btn.Uid));
            Panel.Children.Add(panelView);

        }
        private void BackButton(object sender, RoutedEventArgs e)
        {
            panelEmployees.Visibility = Visibility.Visible;
            Panel.Children.Remove(panelView);
        }
        
    }
}
