using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ItensReceita : Base
    {
        public int sequencia { get; set; }
        public int id_receita { get; set; }
        public string etapa { get; set; }
        public string processo { get; set; }
        public string produto { get; set; }
        public string rele { get; set; }
        public string tipo_evento_anterior { get; set; }
        public string tempo_espera_evento_anterior { get; set; }
        public string entrada_evento_anterior { get; set; }
        public int status_entrada_digital_evento_anterior { get; set; }
        public int setpoint_evento_anterior { get; set; }
        public string tipo_evento_posterior { get; set; }
        public double pre_corte { get; set; }
        public double corte { get; set; }
        public int tempo_on { get; set; }
        public int tempo_off { get; set; }
        public int limite_peso_seguranca_evento_posterior { get; set; }
        public string entrada_evento_posterior { get; set; }
        public int status_entrada_digital_evento_posterior { get; set; }
        public int setpoint_evento_posterior { get; set; }
        public int setpoint_limite_evento_posterior { get; set; }
        public string tempo_evento_posterior { get; set; }
        public string tempo_limite_total { get; set; }
        public int alerta_emergencia { get; set; }
        public int pausar_receita { get; set; }
        public int acionar_saida { get; set; }
        public string saida_seguranca { get; set; }   
    }
}
