using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace WpfApp4
{
    class Timers
    {
        Timer tim1;
        public Timers(double interval, ElapsedEventHandler EventHandler)
        {
            tim1 = new Timer(interval);
            tim1.Elapsed += EventHandler;
            tim1.Start();
        }        

        public void StopTimer()
        {
            tim1.Stop();
        }
    }
}
