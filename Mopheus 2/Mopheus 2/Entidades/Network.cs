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
        //public int addr
        //{
        //    get { return ADDR; }
        //    set { ADDR = value; }
        //}

        //public int baud_rate
        //{
        //    get { return BAUD_RATE; }
        //    set { BAUD_RATE = value; }
        //}

        //public string model
        //{
        //    get { return MODEL; }
        //    set { MODEL = value; }
        //}

        //public string name
        //{
        //    get { return NAME; }
        //    set { NAME = value; }
        //}

        //public int id
        //{
        //    get { return ID; }
        //    set { ID = value; }
        //}

        //public int id { get; set; }
        public string model { get; set; }

        public string name { get; set; }

        public int addr { get; set; }
        
        public int baud_rate { get; set; }


    }
}
