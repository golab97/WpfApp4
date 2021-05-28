using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public partial class MainWindow
    {
        void EnableScrollBars()
        {
            Axis1scrollBar.IsEnabled = true;
            Axis2scrollBar.IsEnabled = true;
            Axis3scrollBar.IsEnabled = true;
            Axis4scrollBar.IsEnabled = true;
            Axis5scrollBar.IsEnabled = true;
            Axis6scrollBar.IsEnabled = true;
        }

        void DisableScrollBars()
        {
            Axis1scrollBar.IsEnabled = false;
            Axis2scrollBar.IsEnabled = false;
            Axis3scrollBar.IsEnabled = false;
            Axis4scrollBar.IsEnabled = false;
            Axis5scrollBar.IsEnabled = false;
            Axis6scrollBar.IsEnabled = false;
        }



    }
}
