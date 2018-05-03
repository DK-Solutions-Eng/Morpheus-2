using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ItensReceita : Base
    {
        public int id_receita { get; set; }
        public string etapa { get; set; }
        public string processo { get; set; }
        public string produto { get; set; }
        public int rele { get; set; }
        public string tipo_evento_anterior { get; set; }
        public int tempo_espera_evento_anterior { get; set; }
        public string entrada_evento_anterior { get; set; }
        public bool status_entrada_digital_evento_anterior { get; set; }
        public int temperatura_evento_anterior { get; set; }
        public string tipo_evento_posterior { get; set; }
        public double pre_corte { get; set; }
        public double corte { get; set; }
        public int tempo_on { get; set; }
        public int tempo_off { get; set; }
        public int limite_seguranca_evento_posterior { get; set; }
        public string entrada_evento_posterior { get; set; }
        public bool status_entrada_digital_evento_posterior { get; set; }
        public int temperatura_evento_posterior { get; set; }
        public int seguranca_temperatura_evento_posterior { get; set; }
        public int tempo_evento_posterior { get; set; }
        public int tempo_limite_evento_posterior { get; set; }
        public int tempo_limite_total { get; set; }
        public bool alerta_emergencia { get; set; }
        public bool pausar_receita { get; set; }
        public bool acionar_saida { get; set; }
        public string saida_seguranca { get; set; }



        public string valor { get; set; }
        public string acao { get; set; }
        public string parametro1 { get; set; }
        public string parametro2 { get; set; }
        public string tipo_limite { get; set; }
        public string valor_limite { get; set; }
        public int sequencia { get; set; }
    }
}
