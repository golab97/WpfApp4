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
using System.Windows.Shapes;
using SharpDX.DirectInput;
namespace WpfApp4
{
    /// <summary>
    /// Logika interakcji dla klasy JoystickWindow.xaml
    /// </summary>
    public partial class JoystickWindow : Window
    {
        static List<Button> buttons = new List<Button>();
        
        
        JoystickState js;
        Button[] buttonss= new Button[] { };
        public JoystickWindow()
        {
            InitializeComponent();
            js = new JoystickState();
            
           
        }

        public void UpdateJoystickState(JoystickState joyState)
        {
            js = joyState;

            if (js.Buttons[0]) btn0Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[0]) btn0Image.Visibility = Visibility.Hidden;

            if (js.Buttons[1]) btn1Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[1]) btn1Image.Visibility = Visibility.Hidden;

            if (js.Buttons[2]) btn2Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[2]) btn2Image.Visibility = Visibility.Hidden;

            if (js.Buttons[3]) btn3Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[3]) btn3Image.Visibility = Visibility.Hidden;

            if (js.Buttons[4]) LeftUpTriggerBtn.Background = Brushes.Red;
            else if (!js.Buttons[4]) LeftUpTriggerBtn.Background = Brushes.Transparent;

            if (js.Buttons[5]) RightUpTriggerBtn.Background = Brushes.Red;
            else if (!js.Buttons[5]) RightUpTriggerBtn.Background = Brushes.Transparent;

            if (js.Buttons[6]) LeftDownTriggerBtn.Background = Brushes.Red;
            else if (!js.Buttons[6]) LeftDownTriggerBtn.Background = Brushes.Transparent;

            if (js.Buttons[7]) RighDownTriggerBtn.Background = Brushes.Red;
            else if (!js.Buttons[7]) RighDownTriggerBtn.Background = Brushes.Transparent;

            if (js.Buttons[8]) btn8Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[8]) btn8Image.Visibility = Visibility.Hidden;

            if (js.Buttons[9]) btn9Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[9]) btn9Image.Visibility = Visibility.Hidden;

            if (js.Buttons[10]) btn10Image.Visibility = Visibility.Visible;
            else if (!js.Buttons[10]) btn10Image.Visibility = Visibility.Hidden;

            if (js.Buttons[11])   btn11Image.Visibility = Visibility.Visible;            
            else if (!js.Buttons[11]) btn11Image.Visibility = Visibility.Hidden;

            switch (js.PointOfViewControllers[0])
            {
                case -1:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;
                case 0:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Red;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;
                case 4500:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Red;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Red;
                    break;
                case 9000:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Red;
                    break;
                case 13500:
                    DownArrowBtn.Background = Brushes.Red;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Red;
                    break;
                case 18000:
                    DownArrowBtn.Background = Brushes.Red;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;

                case 22500:
                    DownArrowBtn.Background = Brushes.Red;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Red;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;

                case 27000:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Red;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;

                case 31500:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Red;
                    LeftArrowBtn.Background = Brushes.Red;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;

                default:
                    DownArrowBtn.Background = Brushes.Transparent;
                    UpArrowBtn.Background = Brushes.Transparent;
                    LeftArrowBtn.Background = Brushes.Transparent;
                    RightArrowBtn.Background = Brushes.Transparent;
                    break;

            }


            HorizontalLeftJoy.Value = js.X;
            VerticalLeftJoy.Value = js.Y;
            HorizontalRightJoy.Value = js.Z;
            VerticalRightJoy.Value = js.RotationZ;

            valuebox.Clear();           
            
            valuebox.AppendText(js.ToString());

            
            

        } 
    }
}
