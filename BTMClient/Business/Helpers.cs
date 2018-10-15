using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BTMClient.Business
{
    public static class Helpers
    {
        public static void Navigate(UserControl to)
        {        
            var Window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            var g = Window.Content as Grid;
            var gg = g.Children[0] as Grid;
            gg.Children.Clear();
            gg.Children.Add(to);
        }
    }
}
