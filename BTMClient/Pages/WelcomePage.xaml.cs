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
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var r = Rulles.IsChecked ?? false;
            if (r) Business.Helpers.Navigate(new SeccondPage()
            { MessageText = $"forwarded from {nameof(WelcomePage)}" });
            else MessageBox.Show("لطفا متن فوق را مطالعه کرده و مربع مربوطه را علامت بزنید"
                , "مطالعه قوانین"
                , MessageBoxButton.OK
                , MessageBoxImage.Error
                , MessageBoxResult.OK
                , MessageBoxOptions.ServiceNotification);
        }
    }
}
