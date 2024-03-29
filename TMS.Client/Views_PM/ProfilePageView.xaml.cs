﻿using System;
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
using TMS.Client.Project_Manager.ViewModels;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.Project_Manager.Views
{
    /// <summary>
    /// Interaction logic for ProfilePageView.xaml
    /// </summary>
    public partial class ProfilePageView : UserControl
    {
        static private WebApiServices services = new WebApiServices();

        public UserView Employees { get; set; }

        DialogBox dialogBox = new DialogBox();

        public ProfilePageView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            services = ((ProfilePageViewModel)DataContext).GetClient;
            panel.Children.Add(dialogBox);
            Employees = ((ProfilePageViewModel)DataContext).User;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                string temp = Microsoft.VisualBasic.Interaction.InputBox("Enter new e-mail:", "EDIT EMAIL", Employees.email);
                if (Employees.email != temp)
                {
                    UserView userEdit = services.Get<UserView>(Employees.Id);
                    userEdit.email = temp;
                    try
                    {
                        if (services.Update(userEdit))
                        {
                            MessageBox.Show("OK");
                            Employees = services.Get<UserView>(Employees.Id);
                            email.Text = temp;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
