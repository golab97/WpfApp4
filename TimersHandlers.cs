using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using SharpDX.DirectInput;
namespace WpfApp4
{
    partial class MainWindow
    {
        private void joyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (controller.IsJoystickAcqured())
            {
                // Dispatcher.Invoke(new Action(() => { RedLed.Background = Brushes.Red; }));
                JoystickState js = new JoystickState();
                js = controller.GetJoystickState();
                Dispatcher.Invoke(new Action(() => {

                    if (joyWinIsActive) joystickWindow.UpdateJoystickState(js);

                }));
            }  
        }
        private void uart1timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
