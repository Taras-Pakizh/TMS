using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

namespace TMS.ViewModels
{
    public class RiskView:IViewBase
    {
        public int Id { get; set; }
        
        public virtual RiskStatus status { get; set; }
        
        public virtual Impact impact { get; set; }

        //[DataMember]
        public int projectId { get; set; }
        
        public string description { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
