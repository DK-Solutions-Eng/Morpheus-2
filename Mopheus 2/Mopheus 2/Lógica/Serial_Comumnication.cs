using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Mopheus_2
{
    public static class Serial_Comumnication
    {
        public static SerialPort serialPort = new SerialPort();

        public static int bytes_to_read;

        public static byte crch;
        public static byte crcl;

        public static byte crcl_received;
        public static byte crch_received;

        


        //public static SerialPort serialPort
        //{
        //    get { return serialPort; }
        //    set { serialPort = value; }
        //}



    }
}
