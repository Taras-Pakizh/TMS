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
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using TMS.Client.Attributes;

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
            await Context.MapToUI();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var attributes = ((PropertyDescriptor)e.PropertyDescriptor).Attributes.OfType<AutoGenerateAttribute>();
            
            if (attributes == null)
                e.Column.Visibility = Visibility.Collapsed;
            else
            {
                var attribute = attributes.Single();
                if (attribute.IsVisible)
                {
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Header = attribute.Header;
                }
                else e.Column.Visibility = Visibility.Hidden;
            }
        }
        
    }
}
