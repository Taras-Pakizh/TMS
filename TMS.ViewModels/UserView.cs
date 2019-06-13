using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

namespace TMS.ViewModels
{
    public class UserView:IViewBase
    {
        public int Id { get; set; }
        
        public string firstName { get; set; }
        
        public string lastName { get; set; }
        
        public string email { get; set; }
        
        public Role role { get; set; }
        
        public string login { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
