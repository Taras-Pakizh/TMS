using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TMS.Client.ViewModels;
using TMS.Client.Windows;
using TMS.Data;

namespace TMS.Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ApplicationView _context;

        private Window _currentWindow;

        public App()
        {
            _currentWindow = new AuthorizationWindow();
            _context = new ApplicationView();
            _currentWindow.DataContext = _context;
            _currentWindow.Show();
        }

        public void FinishAuthorization()
        {
            switch (_context.Role)
            {
                case Role.Engineer: _currentWindow = new EngineerWindow();
                    break;
                case Role.ProjectManager: throw new NotImplementedException();
                    break;
                case Role.TeamLead: throw new NotImplementedException();
                    break;
            }
            _currentWindow.DataContext = _context;
            _currentWindow.Show();
        }
        
    }
}
