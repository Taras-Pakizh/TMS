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
            panel.Children.Add(dialogBox);
            services.Authorization("Pakizh_engineer", "Taras20.");
            Employees = services.Get<UserView>(1);
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                string temp = Microsoft.VisualBasic.Interaction.InputBox("Enter new e-mail:", "EDIT EMAIL", Employees.email);
                if (Employees.email != temp)
                {
                    services.Authorization("Pakizh_engineer", "Taras20.");
                    UserView userEdit = services.Get<UserView>(1);
                    userEdit.email = temp;
                    try
                    {
                        if (services.Update(userEdit))
                        {
                            MessageBox.Show("OK");
                            Employees = services.Get<UserView>(1);
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
