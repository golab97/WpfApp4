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
using System.IO.Ports;
using SharpDX.DirectInput;
using System.Timers;
namespace WpfApp4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        
        SerialTransmission serial;
        Controller controller;
        Timers joyTimer;
        Timers uart1timer;
        JoystickWindow joystickWindow;
        PackageSizes packageSizes;
        bool joyWinIsActive;

        uint uart1RxState;
        public MainWindow()
        {
            InitializeComponent();
            InitializeUserThings();
        }

        private void SerialReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            char[] a = new char[10];  
           

            switch (uart1RxState)
            {
                case 0:
                    a[0] = serial.ReadByte();
                    if (a[0] == ':')
                    {
                        uart1RxState = 1;                        
                    }
                    else uart1RxState = 0;
                    break;

                case 1:
                    a[0] = serial.ReadByte();
                    serial.SetThresholdbytes(5);
                    uart1RxState = 2;
                    
                    break;
                case 2:
                    byte []dat = new byte[10];
                    dat=serial.ReadBytes(5);
                    Dispatcher.Invoke(new Action(() => {
                        uart1RxState = 0;
                        if (dat[0] == 1) RedLed.Background = Brushes.Red;
                        else RedLed.Background = Brushes.Transparent;
                        if (dat[1] == 1) YellowLed.Background = Brushes.Yellow;
                        else YellowLed.Background = Brushes.Transparent;
                        if (dat[2] == 1) WhieLed.Background = Brushes.White;
                        else WhieLed.Background = Brushes.Transparent;

                    }));
                    
                    break;

                 default:
                    uart1RxState = 0;
                    break;
            }
           // ConsoleBox.AppendText("\nUart1state:" + uart1RxState.ToString());

            Dispatcher.Invoke(new Action(() => { MessageBox.AppendText("\nUart1state:" + uart1RxState.ToString()); }));    
        }

       

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            controller.JoystickUnaquire();           
        }
        void InitializeUserThings()
        {
            RefreshBtn_Click(RefreshBtn, new RoutedEventArgs());
            RefreshDevBtn_Click(RefreshDevBtn, new RoutedEventArgs());
            
            joyWinIsActive = false;
            uart1RxState = new uint(); uart1RxState = 0;
            packageSizes = new PackageSizes();

        }
    }
}
