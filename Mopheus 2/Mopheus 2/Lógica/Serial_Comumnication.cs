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

        public  static SerialPort serialPort = new SerialPort();

        public static SerialPort serial_port
        {
            get { return serialPort; }
            set { serialPort = value; }
        }
    }
}
