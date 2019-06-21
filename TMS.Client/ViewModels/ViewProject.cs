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
        [AutoGenerate(true, "Name", 0)]
        public string name { get; set; }

        [AutoGenerate(true, "Abbreviation", 1)]
        public string abbreviation { get; set; }

        [AutoGenerate(true, "Hours", 2)]
        public double effort { get; set; }

        [AutoGenerate(true, "Begin date", 3)]
        public DateTime start { get; set; }

        [AutoGenerate(true, "End date", 4)]
        public DateTime end { get; set; }
        

        [AutoGenerate(false)]
        public int Id { get; set; }

        [AutoGenerate(false)]
        public string description { get; set; }

        [AutoGenerate(false)]
        public ICollection<int> taskIds { get; set; }
    }
}
