using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ItensCarregamento:Base
    {
        public int id_carregamento { get; set; }
        public DateTime? data_inicial { get; set; }
        public double peso_inicial { get; set; }
        public DateTime? data_final { get; set; }
        public double peso_final { get; set; }
        
    }
}
