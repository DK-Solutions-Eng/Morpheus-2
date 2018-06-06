using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using DAL;

namespace BLL
{
    public class CarregamentoBLL:BaseBLL<Carregamento>
    {
        public CarregamentoBLL(string table) : base(table)
        {

        }

        public Carregamento getCustomUltimo()
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT TOP 1 * FROM " + table + " ORDER BY ID DESC");
            if (dt.Rows.Count > 0)
            {
                return ConvertToClass(dt.Rows[0]);
            }
            return null;
        }

        public List<Carregamento> getAllCustom()
        {
            List<Carregamento> list = new List<Carregamento>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ConvertToClass(dt.Rows[i]));
            }

            return list;
        }

        public override Carregamento ConvertToClass(DataRow row)
        {
            Carregamento obj = new Carregamento();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.fornecedor = row["fornecedor"].ToString();
            obj.produto = row["produto"].ToString();
            obj.numero_nota = row["numero_nota"].ToString();
            obj.peso_nota_fiscal = Convert.ToInt32(row["peso_nota_fiscal"].ToString());
            obj.peso_real = Convert.ToInt32(row["peso_real"].ToString());
            obj.peso_diferenca = Convert.ToInt32(row["peso_diferenca"].ToString());
            obj.tara = Convert.ToInt32(row["tara"].ToString());
            obj.recebedor = row["recebedor"].ToString();
            obj.device = row["device"].ToString();
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
