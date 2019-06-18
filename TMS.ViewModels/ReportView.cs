using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

namespace TMS.ViewModels
{
    public class ReportView:IViewBase
    {
        
        public int Id { get; set; }
        
        
        public int taskId { get; set; }
        
        public int engineerId { get; set; }
        
        public ActivityType activity { get; set; }

        //[DataMember]
        public ReportStatus status { get; set; }
        
        public DateTime start { get; set; }
        
        public DateTime end { get; set; }
        
        public string description { get; set; }

        //[DataMember]
        public double effort { get; set; }

        
        public ICollection<int> approveIds { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
