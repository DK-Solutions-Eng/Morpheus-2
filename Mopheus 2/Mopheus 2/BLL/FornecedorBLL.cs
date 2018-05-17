using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAL;

namespace BLL
{
    public class FornecedorBLL : BaseBLL<Fornecedor>
    {
        public FornecedorBLL(string table) : base(table)
        {
        }

        public List<Fornecedor> getAllCustom()
        {
            List<Fornecedor> list = new List<Fornecedor>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ConvertToClass(dt.Rows[i]));
            }

            return list;
        }

        public override Fornecedor ConvertToClass(DataRow row)
        {
            Fornecedor obj = new Fornecedor();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.nome_completo = row["nome_completo"].ToString();
            obj.nome_resumido = row["nome_resumido"].ToString();
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
