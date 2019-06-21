using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Client.Attributes;

namespace TMS.Client.ViewModels
{
    class ViewTask
    {
        [AutoGenerate(true, "Hours")]
        public double effort { get; set; }

        [AutoGenerate(true, "Project")]
        public string projectName { get; set; }

        [AutoGenerate(true, "Description")]
        public string taskName { get; set; }



        [AutoGenerate(false)]
        public int Id { get; set; }

        [AutoGenerate(false)]
        public int projectId { get; set; }

        [AutoGenerate(false)]
        public string description { get; set; }
    }
}
