using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Client.Attributes;

namespace TMS.Client.ViewModels
{
    class ViewProject
    {
        [AutoGenerate(true, "Name")]
        public string name { get; set; }

        [AutoGenerate(true, "Abbreviation")]
        public string abbreviation { get; set; }

        [AutoGenerate(true, "Hours")]
        public double effort { get; set; }

        [AutoGenerate(true, "Begin date")]
        public DateTime start { get; set; }

        [AutoGenerate(true, "End date")]
        public DateTime end { get; set; }
        

        [AutoGenerate(false)]
        public int Id { get; set; }

        [AutoGenerate(false)]
        public string description { get; set; }

        [AutoGenerate(false)]
        public ICollection<int> taskIds { get; set; }
    }
}
