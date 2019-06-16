using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TMS.Client.ViewModels;

namespace TMS.Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindow window = new MainWindow();
            window.DataContext = new ApplicationView();
            window.Show();
        }
    }
}
