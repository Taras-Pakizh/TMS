using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Client.Attributes
{
    class AutoGenerateAttribute:Attribute
    {
        public AutoGenerateAttribute(bool _IsVisible, string _Header = "Header")
        {
            IsVisible = _IsVisible;
            Header = _Header;
        }

        public bool IsVisible { get; set; }

        public string Header { get; set; }
    }
}
