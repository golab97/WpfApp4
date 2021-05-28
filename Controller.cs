using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
namespace WpfApp4
{
    public class Controller
    {

        DirectInput di;
        Joystick joystick;
        bool isJoystickAcquired;

        public Controller()
        {
            di = new DirectInput();
        }

        public List<DeviceInstance> GetAvailableDevices()
        {
            List<DeviceInstance> list = new List<DeviceInstance>(di.GetDevices());
            return list;
        }

        public bool GetAcessToJoystick(DeviceInstance devins)
        {
            joystick = new Joystick(di, devins.InstanceGuid);
            joystick.Acquire();
            isJoystickAcquired = new bool();
            isJoystickAcquired = true;
            return isJoystickAcquired;
        }

        public JoystickState GetJoystickState() {
            if (isJoystickAcquired)
            {
                joystick.Poll();
                try
                {
                    return joystick.GetCurrentState();
                }
                catch (Exception e)
                {
                    return new JoystickState();
                }
            }
            return new JoystickState();
        }

        public bool IsJoystickAcqured()
        {
            return isJoystickAcquired;
        }

        public void JoystickUnaquire()
        {
            //joystick.Unacquire();
            //isJoystickAcquired = false;
        }

    }
}
