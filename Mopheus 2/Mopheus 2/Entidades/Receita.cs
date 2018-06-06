using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Receita : Base
    {
        public string nome { get; set; }
        public string dispositivo { get; set; }
        public int endereco { get; set; }
        public string repeticao { get; set; }
        public int vezes { get; set; }
        public string intervalo { get; set; }
    }
}
