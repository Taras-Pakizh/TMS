using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

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

        #region GOVNO

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public ReportStatus status { get; set; }
        public string projName { get; set; }
        public int approveId { get; set; }
        public int report_id { get; set; }
        public override string ToString()
        {
            return description;
        }

        #endregion
    }
}
