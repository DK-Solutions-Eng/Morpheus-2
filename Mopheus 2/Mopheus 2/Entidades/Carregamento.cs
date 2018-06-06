using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Carregamento:Base
    {
        public string fornecedor { get; set; }
        public string produto { get; set; }
        public string numero_nota { get; set; }
        public int peso_nota_fiscal { get; set; }
        public int peso_real { get; set; }
        public int peso_diferenca { get; set; }
        public int tara { get; set; }
        public string recebedor { get; set; }
        public string device { get; set; }
    }
}
