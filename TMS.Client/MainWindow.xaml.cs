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
using TMS.Data;
using TMS.Client.ViewModels;

namespace TMS.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static WebApiServices client = new WebApiServices();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            var report = new ReportView()
            {
                activity = ActivityType.Bug_fixing,
                description = "Delete_Soon",
                effort = 100,
                end = DateTime.Now, start = DateTime.Now,
                engineerId = 161, taskId = 5,
                status = ReportStatus.Open
            };

            var crud = new CRUDModel()
            {
                model = report,
                operation = Operation.Post,
                type = typeof(ReportView)
            };

            ((ApplicationView)DataContext).CRUD.Execute(crud);
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            ((ApplicationView)DataContext).CRUD.Execute(new CRUDModel()
            {
                model = new ReportView(),
                operation = Operation.Get,
                type = typeof(ReportView)
            });
        }
    }
}
