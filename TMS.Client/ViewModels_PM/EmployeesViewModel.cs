using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Services;
using TMS.ViewModels;

namespace TMS.Client.Project_Manager.ViewModels
{
    public class EmployeesViewModel
    {
        public EmployeesViewModel() { }

        public UserView User { get; set; }

        public WebApiServices Client { get; set; }

        public EmployeesViewModel(UserView currentUser, WebApiServices client)
        {
            User = currentUser;
            Client = client;
        }
    }
}
