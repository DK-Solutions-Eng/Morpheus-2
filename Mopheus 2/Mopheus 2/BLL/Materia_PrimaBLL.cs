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
    public class Materia_PrimaBLL : BaseBLL<Materia_Prima>
    {
        public Materia_PrimaBLL(string table) : base(table)
        {
        }

        public List<Materia_Prima> getAllCustom()
        {
            List<Materia_Prima> list = new List<Materia_Prima>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ConvertToClass(dt.Rows[i]));
            }

            return list;
        }

        public override Materia_Prima ConvertToClass(DataRow row)
        {
            Materia_Prima obj = new Materia_Prima();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.descricao_completa = row["descricao_completa"].ToString();
            obj.descricao_resumida = row["descricao_resumida"].ToString();
            obj.codigo = row["codigo"].ToString();
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
