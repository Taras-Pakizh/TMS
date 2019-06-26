using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

namespace TMS.Client.ViewModels
{
    public class ViewUser:BaseView
    {
        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        private Role _role;
        public Role role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(role));
            }
        }

        private string _login;
        public string login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                _teamName = value;
                OnPropertyChanged(nameof(TeamName));
            }
        }

        private int _reportsCount;
        public int ReportsCount
        {
            get { return _reportsCount; }
            set
            {
                _reportsCount = value;
                OnPropertyChanged(nameof(ReportsCount));
            }
        }
    }
}
