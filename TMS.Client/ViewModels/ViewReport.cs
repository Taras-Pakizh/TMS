using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;
using TMS.Client.Attributes;

namespace TMS.Client.ViewModels
{
    class ViewReport
    {
        [AutoGenerate(true, "Task", 0)]
        public string taskName { get; set; }

        [AutoGenerate(true, "Activity", 1)]
        public ActivityType activity { get; set; }

        [AutoGenerate(true, "Status", 2)]
        public ReportStatus status { get; set; }

        [AutoGenerate(true, "Begin date", 3)]
        public DateTime start { get; set; }

        [AutoGenerate(true, "End date", 4)]
        public DateTime end { get; set; }

        [AutoGenerate(true, "Hours", 5)]
        public double effort { get; set; }


        [AutoGenerate(false)]
        public int Id { get; set; }

        [AutoGenerate(false)]
        public string description { get; set; }

        [AutoGenerate(false)]
        public int taskId { get; set; }

        [AutoGenerate(false)]
        public int engineerId { get; set; }
    }
}
