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
    public class UsuarioBLL : BaseBLL<Usuario>
    {
        public UsuarioBLL(string table):base(table)
        {

        }
        public override Usuario ConvertToClass(DataRow row)
        {
            Usuario obj = new Usuario();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.login = row["login"].ToString();
            obj.senha = row["senha"].ToString();
            obj.Nome = row["Nome"].ToString();
            obj.acesso = row["acesso"].ToString();
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

        public List<Usuario> consultaUsuarios()
        {
            List<Usuario> listusuario = new List<Usuario>();

            DAOGeral daogeral = new DAOGeral();
            Usuario objusuario = new Usuario();
            DataTable dtusuario = daogeral.executaComRetorno("select * from " + table + " order by Nome");
            for (int i = 0; i < dtusuario.Rows.Count; i++)
            {
                listusuario.Add(ConvertToClass(dtusuario.Rows[i]));
            }
            return listusuario;
        }
    }
}
