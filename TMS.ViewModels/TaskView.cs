using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ViewModels
{
    public class TaskView:IViewBase
    {
        public int Id { get; set; }

        //[DataMember]
        public int projectId { get; set; }
        
        public string description { get; set; }

        //[DataMember]
        public double effort { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
