using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using SharpDX.DirectInput;
namespace WpfApp4
{
    public partial class MainWindow
    {
        //public  RoutedEventHandler RefreshBtnClick => RefreshBtn_Click;
        private  void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PortBox.Items.Clear();
            foreach (string c in AvailableComPorts())
            {
                PortBox.Items.Add(c);
            }

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            serial.WriteString(MessageBox.Text);
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectBtn.Content.ToString() == "CONNECT")
            {
                serial = new SerialTransmission(Convert.ToInt32(BaudRateBox.Text), PortBox.Text, SerialReceivedEventHandler);
                ConsoleBox.AppendText(serial.Open());
                ConnectBtn.Content = "CONNECTED";
                EnableScrollBars();
                SendBtn.IsEnabled = true;
                uart1timer = new Timers(1, uart1timer_Elapsed);
            }
            else if (ConnectBtn.Content.ToString() == "CONNECTED")
            {
                serial.Close();
                ConnectBtn.Content = "CONNECT";
                DisableScrollBars();
                SendBtn.IsEnabled = false;
                uart1timer = new Timers(1,uart1timer_Elapsed);
                uart1timer.StopTimer();
            }

        }

        

        private void RefreshDevBtn_Click(object sender, RoutedEventArgs e)
        {
            controller = new Controller();
            DeviceBox.Items.Clear();
            foreach (var c in controller.GetAvailableDevices())
            {
                switch(c.Type)
                {
                    case DeviceType.Joystick:
                        if ((DevTypeBox.Text == "GAMEPAD"))
                        {
                          DeviceBox.Items.Add(c.InstanceGuid);
                        }
                        break;
                    case DeviceType.Keyboard:
                        if ((DevTypeBox.Text == "KEYBOARD"))
                        {
                            DeviceBox.Items.Add(c.InstanceGuid); 
                        }
                        break;
                }
                DeviceBox.SelectedIndex = 0;
                //ConsoleBox.AppendText(String.Format("{0} \r", c.Type));
                
            }
        }

        private void ConnectDevBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DevTypeBox.Text=="GAMEPAD" && DeviceBox.Text!="")
            {
                foreach (var c in controller.GetAvailableDevices())
                {
                    if(c.InstanceGuid.ToString()==DeviceBox.Text)
                    {
                        if (controller.GetAcessToJoystick(c)) TestBtn.IsEnabled = true;
                        joyTimer = new Timers(1, joyTimer_Elapsed);
                    }
                }                    
            }
        }

        private void TestBtnClick(object sender, RoutedEventArgs e)
        {
            
            joyWinIsActive = new bool();            
            joystickWindow = new JoystickWindow();
            joystickWindow.Show();
            joyWinIsActive = true;
            
        }
    }

}
