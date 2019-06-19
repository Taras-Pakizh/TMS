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
using TMS.Client.ViewModels;
using TMS.ViewModels;
using TMS.Client;
using System.Threading;
using TMS.Services;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TMS.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для EngineerWindow.xaml
    /// </summary>
    public partial class EngineerWindow : Window
    {
        private ApplicationView Context
        {
            get { return (ApplicationView)DataContext; }
        }

        public EngineerWindow()
        {
            InitializeComponent();
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Context.GetAll<ReportView>();
            await Context.GetAll<TaskView>();
            await Context.GetAll<ProjectView>();
        }
    }
}
