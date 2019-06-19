using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Client.ViewModels
{
    class ViewTask
    {
        [DisplayName("Hours")]
        public double effort { get; set; }

        [DisplayName("Project")]
        public string projectName { get; set; }
        
        [DisplayName("Name")]
        public string taskName { get; set; }



        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public int projectId { get; set; }

        [Display(AutoGenerateField = false)]
        public string description { get; set; }
    }
}
