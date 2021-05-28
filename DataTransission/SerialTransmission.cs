using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace WpfApp4
{
    class SerialTransmission
    {
        SerialPort serial;

        public SerialTransmission(int baudrate,string comPort,SerialDataReceivedEventHandler eventHandler)
        {
            serial = new SerialPort();
            serial.BaudRate = baudrate;
            serial.PortName = comPort;
            serial.DataReceived += eventHandler;
            serial.ReceivedBytesThreshold = 1;
        }

        public  void SetThresholdbytes (int thresholdBytes)
        {
            serial.ReceivedBytesThreshold = thresholdBytes;
        }

        public bool IsOpen()
        {
            return serial.IsOpen;
        }
        public string Open()
        {
            try
            {
                serial.Open();
            }
            catch (Exception ex)
            {
                return ex.ToString();   // błąd transmisji
            }

            return "Connected";   //transmisja pomyślna 
        }
        public void Close(){    serial.Close();    }

        public void SendMessage(Byte []data, int dataSize)
        {
            serial.Write(data, 0, dataSize);
        }

        public char ReadByte()
        {
            return Convert.ToChar(serial.ReadByte());    
        }

        public byte[] ReadBytes(int howManyBytes)
        {
            byte[] d = new byte[30];
            serial.Read(d, 0, howManyBytes);
            return d;
        }

        public string[] GetComPorts()
        {
            string[] availablePorts;
            availablePorts = SerialPort.GetPortNames();   
            
            return availablePorts;
        }

        public void WriteString(string s)
        {
            serial.Write(s);
        }

        public int GetBufferSize()
        {
            return serial.ReadBufferSize;
        }

        public void ClearBuffer()
        {
            serial.DiscardInBuffer();
        }

    }
}
