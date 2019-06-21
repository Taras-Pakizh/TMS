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

namespace TMS.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private ViewTask Context { get; set; }
        
        public TaskWindow(ViewTask task)
        {
            InitializeComponent();
            Context = task;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Label_Project.Content = "Project: " + Context.projectName;
            Label_Effort.Content = "Hours: " + Context.effort.ToString();
            TextBlock_Description.Text = Context.description;
        }
    }
}
