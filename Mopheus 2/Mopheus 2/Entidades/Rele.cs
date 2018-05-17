using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Rele : Base
    {
        public string IO { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }
        public string device { get; set; }
        public string funcao { get; set; }
        public string parent { get; set; }
    }
}
