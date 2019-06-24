using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMS.Client.TeamLead.Views
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : UserControl
    {
        public DialogBox()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
        }
        public string val;
        public DialogBox(string title, string value)
        {
            InitializeComponent();
            Title.Text = title;
            Value.Text = value;
        }
        public bool GetDialog(string title, string value)
        {
            this.Visibility = Visibility.Visible;
            Title.Text = title;
            Value.Text = value;
            return true;
        }
    }
}
