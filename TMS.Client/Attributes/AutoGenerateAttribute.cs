using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Client.Attributes
{
    class AutoGenerateAttribute:Attribute
    {
        public AutoGenerateAttribute(bool _IsVisible, string _Header = "Header", int _index = -1)
        {
            IsVisible = _IsVisible;
            Header = _Header;
            Index = _index;
        }

        public bool IsVisible { get; set; }

        public string Header { get; set; }

        public int Index { get; set; }
    }
}
