using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Entidades;
using BLL;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace Mopheus_2
{
    public partial class Form_MATERIA_PRIMA : Form
    {
        Materia_Prima mp = new Materia_Prima();
        Materia_PrimaBLL mpbll = new Materia_PrimaBLL("Materia_Prima");

        public Form_MATERIA_PRIMA()
        {
            InitializeComponent();
            atualiza_grid("");
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(textBox_descricao_full.Text!="" & textBox_descricao_half.Text!="" & textBox_codigo_sistema.Text!="")
            {
                mp.descricao_completa = textBox_descricao_full.Text;
                mp.descricao_resumida = textBox_descricao_half.Text;
                mp.codigo = textBox_codigo_sistema.Text;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                mp.dateinsert = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                mpbll.insert(mp);

                atualiza_grid("");
            }
            else
            {
                MessageBox.Show("Existem campos em branco!", "Atenção!");
            }

            textBox_codigo_sistema.Clear();
            textBox_descricao_full.Clear();
            textBox_descricao_half.Clear();
            
        }

        private void atualiza_grid(string filtro)
        {
            dataGridView_mp.DataSource = mpbll.getAll(filtro, "descricao_completa");

            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView_mp.CurrentRow != null)
            {
                primeiraLinha = dataGridView_mp.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView_mp.CurrentRow.Index;
                dataGridView_mp.Columns["id"].Visible = false;
                dataGridView_mp.Columns["descricao_completa"].Width = 280;
                dataGridView_mp.Columns["descricao_resumida"].Width = 120;
                dataGridView_mp.Columns["codigo"].Width = 120;
            }
            
            dataGridView_mp.Refresh();
            dataGridView_mp.ClearSelection();

            if (dataGridView_mp.RowCount != 0)
            {
                dataGridView_mp.Columns["id"].Visible = false;
                dataGridView_mp.Columns["descricao_completa"].Width = 280;
                dataGridView_mp.Columns["descricao_resumida"].Width = 120;
                dataGridView_mp.Columns["codigo"].Width = 120;
            }

        }
    }
}
