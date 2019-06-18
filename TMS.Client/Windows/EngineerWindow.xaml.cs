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

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Context.CRUD.Execute(new CRUDModel()
            {
                operation = Operation.Get,
                type = typeof(ReportView)
            });
        }

        private void TabControl_Loaded(object sender, RoutedEventArgs e)
        {
            Context.CRUD.Execute(new CRUDModel()
            {
                operation = Operation.Get,
                type = typeof(ReportView)
            });
            Thread.Sleep(5000);
            Context.CRUD.Execute(new CRUDModel()
            {
                operation = Operation.Get,
                type = typeof(TaskView)
            });
        }
        
    }
}
