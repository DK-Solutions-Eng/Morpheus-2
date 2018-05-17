using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Network:Base
    {
        //private int ADDR;
        //private int BAUD_RATE;
        //private string MODEL;
        //private string NAME;
        //private int ID;


        public Network()
        {

        }

        public string model { get; set; }
        public string name { get; set; }
        public int addr { get; set; }
        public int baud_rate { get; set; }
        public string parent { get; set; }
        public string full_name { get; set; }
        public string type_model { get; set; }


    }
}
