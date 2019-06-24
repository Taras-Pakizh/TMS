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
using System.Windows.Shapes;

namespace TMS.Client.TeamLead.Views
{
    /// <summary>
    /// Interaction logic for MessageDecline.xaml
    /// </summary>
    public partial class MessageDecline : Window
    {
        public MessageDecline()
        {
            InitializeComponent();
        }
        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string Message
        {
            get { return messageBox.Text; }
        }
    }
}
