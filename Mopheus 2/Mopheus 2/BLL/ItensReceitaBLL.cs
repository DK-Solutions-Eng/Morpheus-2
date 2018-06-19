using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using DAL;

namespace BLL
{
    public class ItensReceitaBLL : BaseBLL<ItensReceita>
    {
        public ItensReceitaBLL(string table) : base(table)
        {
        }

        public ItensReceita getCustomUltimo()
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT TOP 1 * FROM " + table + " ORDER BY sequencia DESC");
            if (dt.Rows.Count > 0)
            {
                return ConvertToClass(dt.Rows[0]);
            }
            return null;
        }

        public void ordenaSequencia(int id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE ItensReceita"
                                        + " SET sequencia = x.teste"
                                        + " FROM("
                                              + " select ROW_NUMBER() OVER(ORDER BY id ASC) AS teste, id_receita, id from ItensReceita where id_receita = " + id_receita
                                              + " ) x"
                                        + " where ItensReceita.id_receita = x.id_receita"
                                        + " and ItensReceita.id = x.id");
        }

        public void deleteCustomReceita(int id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("DELETE FROM " + this.table + " WHERE ID_RECEITA = " + id_receita);
        }

        public void updateCustomMoveAcimaSequencia(int sequencia, int id)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET sequencia = " + sequencia + " WHERE sequencia = " + (sequencia + 1));
            daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET sequencia = " + (sequencia + 1) + " WHERE ID = " + id);
        }

        public void updateCustomMoveAbaixoSequencia(int sequencia, int id)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET sequencia = " + sequencia + " WHERE sequencia = " + (sequencia - 1));
            daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET sequencia = " + (sequencia - 1) + " WHERE ID = " + id);
        }

        public DataTable getCustomItensReceita(int? id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT* FROM " + this.table+ " WHERE id_receita = " + (id_receita == null ? 0 : id_receita) + " ORDER BY sequencia");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        //public DataTable getItensReceita(int? id_receita)
        //{
        //    DAOGeral daogeral = new DAOGeral();
        //    DataTable dt = daogeral.executaComRetorno("SELECT itens.*,rele.codigo as codigo_rele,rele.nome as nome_rele,tiporele.id as id_tiporele,tiporele.nome as nome_tiporele FROM " + table + " itens"
        //        + " LEFT JOIN Rele rele on itens.parametro2 = CAST(rele.id as varchar)"
        //        + " LEFT JOIN TipoRele tiporele on rele.tipo = TipoRele.id"
        //        + " WHERE ID_RECEITA = " + (id_receita == null ? 0 : id_receita) + " ORDER BY itens.sequencia");
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    return null;
        //}        
        public override ItensReceita ConvertToClass(DataRow row)
        {
            ItensReceita obj = new ItensReceita();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.id_receita = Convert.ToInt32(row["id_receita"].ToString());
            obj.etapa = row["etapa"].ToString();
            obj.processo = row["processo"].ToString();
            obj.produto = row["produto"].ToString();
            obj.rele = (row["rele"].ToString());
            obj.tipo_evento_anterior = row["tipo_evento_anterior"].ToString();
            obj.tempo_espera_evento_anterior = row["tempo_espera_evento_anterior"].ToString();
            obj.entrada_evento_anterior = row["entrada_evento_anterior"].ToString();
            obj.status_entrada_digital_evento_anterior = Convert.ToChar(row["status_entrada_digital_evento_anterior"].ToString());
            obj.setpoint_evento_anterior = Convert.ToInt32(row["setpoint_evento_anterior"].ToString());
            obj.tipo_evento_posterior = row["tipo_evento_posterior"].ToString();
            obj.pre_corte = Convert.ToInt32(row["pre_corte"].ToString());
            obj.corte = Convert.ToInt32(row["corte"].ToString());
            obj.tempo_on = Convert.ToInt32(row["tempo_on"].ToString());
            obj.tempo_off = Convert.ToInt32(row["tempo_off"].ToString());
            obj.limite_peso_seguranca_evento_posterior = Convert.ToInt32(row["limite_peso_seguranca_evento_posterior"].ToString());
            obj.entrada_evento_posterior = row["entrada_evento_posterior"].ToString();
            obj.status_entrada_digital_evento_posterior = Convert.ToChar(row["status_entrada_digital_evento_posterior"].ToString());
            obj.setpoint_evento_posterior = Convert.ToInt32(row["setpoint_evento_posterior"].ToString());
            obj.setpoint_limite_evento_posterior = Convert.ToInt32(row["setpoint_limite_evento_posterior"].ToString());
            obj.tempo_evento_posterior = (row["tempo_evento_posterior"].ToString());
            obj.tempo_limite_total = (row["tempo_limite_total"].ToString());
            obj.alerta_emergencia = Convert.ToChar(row["alerta_emergencia"].ToString());
            obj.pausar_receita = Convert.ToChar(row["pausar_receita"].ToString());
            obj.acionar_saida = Convert.ToChar(row["acionar_saida"].ToString());
            obj.saida_seguranca= row["saida_seguranca"].ToString();
            obj.sequencia = Convert.ToInt32(row["sequencia"].ToString());
            if (row["dateinsert"].ToString() == "")
            {
                obj.dateinsert = null;
            }
            else
            {
                obj.dateinsert = Convert.ToDateTime(row["dateinsert"].ToString());
            }
            if (row["dateupdate"].ToString() == "")
            {
                obj.dateupdate = null;
            }
            else
            {
                obj.dateupdate = Convert.ToDateTime(row["dateupdate"].ToString());
            }
            return obj;
        }
    }
}
