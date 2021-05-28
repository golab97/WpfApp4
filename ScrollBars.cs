using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    public partial class MainWindow
    {
        private void Axis1scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string aaa = String.Format("slider1value:{0} \n \r", Axis1scrollBar.Value);

        }
    }
}
