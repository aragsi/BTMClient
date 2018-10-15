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

namespace BTMClient.Pages
{
    /// <summary>
    /// Interaction logic for SeccondPage.xaml
    /// </summary>
    public partial class SeccondPage : UserControl
    {
        public SeccondPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string MessageText { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Business.Helpers.Navigate(new WelcomePage());
        }
    }
}
