using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ViewModels
{
    public class ProjectView:IViewBase
    {
        public int Id { get; set; }
        
        public string name { get; set; }

        public string abbreviation { get; set; }

        public string description { get; set; }

        public double effort { get; set; }
        
        public DateTime start { get; set; }
        
        public DateTime end { get; set; }

        public ICollection<int> riskIds { get; set; }

        public ICollection<int> taskIds { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
