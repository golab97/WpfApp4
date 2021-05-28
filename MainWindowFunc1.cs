using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace WpfApp4
{
    public partial class MainWindow
    {
        public List<string> AvailableComPorts()
        {
            List<string> comPorts = new List<string>();
            comPorts.AddRange(SerialPort.GetPortNames());
            return comPorts;
        }

        
    }




}

