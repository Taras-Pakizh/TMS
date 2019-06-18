using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Client.ViewModels
{
    class ViewProject
    {
        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Abbreviation")]
        public string abbreviation { get; set; }

        [DisplayName("Hours")]
        public double effort { get; set; }

        [DisplayName("Begin time")]
        public DateTime start { get; set; }

        [DisplayName("End time")]
        public DateTime end { get; set; }



        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public string description { get; set; }

        [Display(AutoGenerateField = false)]
        public ICollection<int> riskIds { get; set; }

        [Display(AutoGenerateField = false)]
        public ICollection<int> taskIds { get; set; }
    }
}
