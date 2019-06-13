using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ViewModels
{
    public class ApproveView:IViewBase
    {
        public int Id { get; set; }

        public bool isApproved { get; set; }

        public string rootCase { get; set; }

        public int reportId { get; set; }

        public int approveAuthorId { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
