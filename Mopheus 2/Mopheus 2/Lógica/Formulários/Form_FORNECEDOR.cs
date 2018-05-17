﻿using System;
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
    public partial class Form_FORNECEDOR : Form
    {
        Fornecedor fornecedor = new Fornecedor();
        FornecedorBLL fornecedorbll = new FornecedorBLL("Fornecedor");

        public Form_FORNECEDOR()
        {
            InitializeComponent();
            atualiza_grid("");
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(textBox_nome_completo.Text!=""|textBox_nome_resumido.Text!="")
            {
                fornecedor.nome_completo = textBox_nome_completo.Text;
                fornecedor.nome_resumido = textBox_nome_resumido.Text;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                fornecedor.dateinsert = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                fornecedorbll.insert(fornecedor);

                atualiza_grid("");
            }
            else
            {
                MessageBox.Show("Existem campos em branco!", "Atenção!");
            }

            textBox_nome_completo.Clear();
            textBox_nome_resumido.Clear();
            
        }
        private void atualiza_grid(string filtro)
        {
            dataGridView_fornecedor.DataSource = fornecedorbll.getAll(filtro, "nome_completo");

            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView_fornecedor.CurrentRow != null)
            {
                primeiraLinha = dataGridView_fornecedor.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView_fornecedor.CurrentRow.Index;
                dataGridView_fornecedor.Columns["id"].Visible = false;
                dataGridView_fornecedor.Columns["nome_completo"].Width = 280;
                dataGridView_fornecedor.Columns["nome_resumido"].Width = 120;
            }

            dataGridView_fornecedor.Refresh();
            dataGridView_fornecedor.ClearSelection();

            if (dataGridView_fornecedor.RowCount != 0)
            {
                dataGridView_fornecedor.Columns["id"].Visible = false;
                dataGridView_fornecedor.Columns["nome_completo"].Width = 280;
                dataGridView_fornecedor.Columns["nome_resumido"].Width = 120;
            }
        }
    }
}
