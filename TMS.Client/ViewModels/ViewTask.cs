using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Client.Attributes;

namespace TMS.Client.ViewModels
{
    public class ViewTask:IView
    {
        [AutoGenerate(true, "Hours", 0)]
        public double effort { get; set; }

        [AutoGenerate(true, "Project", 1)]
        public string projectName { get; set; }

        [AutoGenerate(true, "Description", 2)]
        public string taskName { get; set; }



        [AutoGenerate(false)]
        public int Id { get; set; }

        [AutoGenerate(false)]
        public int projectId { get; set; }

        [AutoGenerate(false)]
        public string description { get; set; }
    }
}
