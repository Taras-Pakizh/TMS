using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ViewModels;

namespace TMS.Client.ViewModels
{
    class CRUDModel
    {
        public IViewBase model { get; set; }

        public Operation operation { get; set; }

        public Type type { get; set; }
    }

    enum Operation
    {
        Post,
        Put,
        Delete,
        Get
    }
}
