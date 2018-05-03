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
    public class NetworkBLL : BaseBLL<Network>
    {
        public NetworkBLL(string table) : base(table)
        {
        }

        public List<Network> getAllCustom()
        {
            List<Network> list = new List<Network>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ConvertToClass(dt.Rows[i]));
            }

            return list;
        }

        public override Network ConvertToClass(DataRow row)
        {
            Network obj = new Network();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.name = row["name"].ToString();
            obj.baud_rate = Convert.ToInt32(row["baud_rate"].ToString());
            obj.addr = Convert.ToInt32(row["addr"].ToString());
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
