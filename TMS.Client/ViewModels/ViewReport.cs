using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;

namespace TMS.Client.ViewModels
{
    class ViewReport
    {
        [DisplayName("Task")]
        public string taskName { get; set; }

        [DisplayName("Engineer")]
        public string engineerName { get; set; }

        [DisplayName("Activity")]
        public ActivityType activity { get; set; }

        [DisplayName("Status")]
        public ReportStatus status { get; set; }

        [DisplayName("Begin time")]
        public DateTime start { get; set; }

        [DisplayName("End time")]
        public DateTime end { get; set; }

        [DisplayName("Hours")]
        public double effort { get; set; }


        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public string description { get; set; }

        [Display(AutoGenerateField = false)]
        public int taskId { get; set; }

        [Display(AutoGenerateField = false)]
        public int engineerId { get; set; }
    }
}
