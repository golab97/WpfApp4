using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    class PackageSizes
    {
        
        public PackageSizes() { }

        public enum PcArmCommands
        {
            GetLedStatus = 1,
            GetUcStatus = 2
        }

        public  byte[,] PcArmCommandsSizes =  {
//// package numver  ,  size 
            { 1, 1 },
            { 2, 1 },
            
        };

        public enum ArmPcResponse
        {
            GetLedStatus = 1,
            GetUcStatus = 2
        }

        public byte[,] ArmPcRespondSizes =   {
 //// package numver  ,  size 
            { Convert.ToByte(ArmPcResponse.GetLedStatus), 3 },
            { Convert.ToByte(ArmPcResponse.GetUcStatus), 1 },
        };

        public byte GetArmPcResponseSize(byte packageNumber)
        {
            int index = sizeof(ArmPcResponse) / 2;
            for(int i=0;i<index;i++)
            {
                if (ArmPcRespondSizes[i,0]==packageNumber)
                {
                    return ArmPcRespondSizes[i, 0];
                }
            }
            return 0;
        }

        public struct LedStatus
        {
            byte alarmLed;
            byte calibrationLed;
            byte workLed;
        }
    }

    




    

}
