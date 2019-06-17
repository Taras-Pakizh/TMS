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
using TMS.Client.Validation;
using TMS.Client.ViewModels;

namespace TMS.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private ModelValidator validator = new ModelValidator();

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var model = new AuthorizationModel()
            {
                username = Login.Text,
                password = Password.Text
            };

            if (!validator.IsModelValid(model))
            {
                Error_list.Content = validator.ValidationResults;
                return;
            }

            Context.Authorization.Execute(model);

            if (Context.IsAuthorized)
            {
                ((App)Application.Current).FinishAuthorization();
                this.Close();
            }
            else
            {
                Error_list.Content = "Authorization has failed. Check if login and password had been inputed correctly";
            }
        }

        private ApplicationView Context
        {
            get { return (ApplicationView)DataContext; }
        }
    }
}
