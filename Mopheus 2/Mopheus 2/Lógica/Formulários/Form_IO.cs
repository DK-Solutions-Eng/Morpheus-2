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
    public partial class Form_IO : Form
    {
        NetworkBLL bll = new NetworkBLL("Network");
        Network device = new Network();

        ReleBLL relebll = new ReleBLL("Rele");
        Rele rele = new Rele();

        Materia_Prima mp = new Materia_Prima();
        Materia_PrimaBLL mpbll= new Materia_PrimaBLL("Materia_Prima");


        public Form_IO()
        {
            InitializeComponent();
            //load_comboBox_device();
            load_comboBox_funcao();

            atualiza_grid("");

            comboBox_produto.Visible = false;

            load_comboBox_produto();
        }
        private void load_comboBox_funcao()
        {
            comboBox_funcao.Items.Clear();
            comboBox_funcao.Items.Add("Produto");
            comboBox_funcao.Items.Add("Acionamento/Sensoriamento");
        }

        private void load_comboBox_device()
        {
            comboBox_device.Items.Clear();
            List<Network> list = bll.getAllCustom();

            if (comboBox_funcao.SelectedIndex == 0)
            {
                if (list != null)
                {
                    foreach (Network item in list)
                    {
                        if (item.model == "ControlMix" || item.type_model != "4-TC" || item.type_model != "4-AI")
                        {
                            if(item.model == "Indicador")
                            {

                            }
                            else
                            {
                                comboBox_device.Items.Add(item.full_name);
                            }
                                
                        }
                    }
                }
            }
            if(comboBox_funcao.SelectedIndex == 1)
            {
                if (list != null)
                {
                    foreach (Network item in list)
                    {
                        if (item.model == "ControlMix" || item.model == "Expansão" )
                        {
                            comboBox_device.Items.Add(item.full_name);
                            
                        }
                    }
                }
            }
        }

        private void comboBox_device_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_IO.Items.Clear();
            comboBox_IO.Text = "";
            comboBox_tipo.Items.Clear();
            comboBox_tipo.Text = "";
            textBox_description.Clear();

            DataTable dt = bll.getAll(comboBox_device.Text, "full_name");
            if (dt == null)
            {
                //bll.insert(device);
                //dt = bll.getAll(treeView_rede.SelectedNode.Text, "name");
                return;
            }
            device = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

            switch(device.type_model)
            {
                case "5-DI/12-RO":
                    comboBox_tipo.Items.Clear();
                    if (comboBox_funcao.Text != "Produto")
                    {
                        comboBox_tipo.Items.Add("Entrada Digital");
                    }
                    else
                    {
                        comboBox_tipo.Items.Add("Saída a Relé");
                    }
                    break;
                case "0-DI/12-RO":
                    comboBox_tipo.Items.Clear();
                    //comboBox_tipo.Items.Add("Entrada Digital");
                    comboBox_tipo.Items.Add("Saída a Relé");
                    break;
                case "8-DI/9-RO":
                    comboBox_tipo.Items.Clear();
                    if (comboBox_funcao.Text != "Produto")
                    {
                        comboBox_tipo.Items.Add("Entrada Digital");
                    }
                    else
                    {
                        comboBox_tipo.Items.Add("Saída a Relé");
                    }
                    break;
                case "4-TC":
                    comboBox_tipo.Items.Clear();
                    //comboBox_tipo.Items.Add("Entrada Digital");
                    //comboBox_tipo.Items.Add("Saída a Relé");
                    if (comboBox_funcao.Text != "Produto")
                    {
                        comboBox_tipo.Items.Add("Termopar-K");
                        comboBox_tipo.Items.Add("Termopar-J");
                        comboBox_tipo.Items.Add("Termopar-T");
                        comboBox_tipo.Items.Add("Termopar-N");
                        comboBox_tipo.Items.Add("Termopar-S");
                        comboBox_tipo.Items.Add("Termopar-E");
                        comboBox_tipo.Items.Add("Termopar-B");
                        comboBox_tipo.Items.Add("Termopar-R");
                    }
                    break;
                case "4-AI":
                    comboBox_tipo.Items.Clear();
                    //comboBox_tipo.Items.Add("Entrada Digital");
                    //comboBox_tipo.Items.Add("Saída a Relé");
                    if (comboBox_funcao.Text != "Produto")
                    {
                        comboBox_tipo.Items.Add("AI-Tensão");
                        comboBox_tipo.Items.Add("AI-Corrente");
                    }
                    break;
                default:
                    comboBox_tipo.Items.Clear();
                    if (comboBox_funcao.Text != "Produto")
                    {
                        comboBox_tipo.Items.Add("Entrada Digital");
                        comboBox_tipo.Items.Add("Entrada Analógica");
                    }
                    else
                    {
                        comboBox_tipo.Items.Add("Saída a Relé");
                    }              
                    break;
            }
        }

        private void comboBox_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_IO.Items.Clear();
            comboBox_IO.Text = "";
            textBox_description.Clear();
            switch (comboBox_tipo.Text)
            {
                case "Entrada Digital":
                    switch(device.type_model)
                    {
                        case "5-DI/12-RO":
                            comboBox_IO.Items.Clear();
                            comboBox_IO.Items.Add("I1");
                            comboBox_IO.Items.Add("I2");
                            comboBox_IO.Items.Add("I3");
                            comboBox_IO.Items.Add("I4");
                            comboBox_IO.Items.Add("I5");
                            break;
                        case "8-DI/9-RO":
                            comboBox_IO.Items.Clear();
                            comboBox_IO.Items.Add("I1");
                            comboBox_IO.Items.Add("I2");
                            comboBox_IO.Items.Add("I3");
                            comboBox_IO.Items.Add("I4");
                            comboBox_IO.Items.Add("I5");
                            comboBox_IO.Items.Add("I6");
                            comboBox_IO.Items.Add("I7");
                            comboBox_IO.Items.Add("I8");
                            break;
                    }
                    break;
                case "Saída a Relé":
                    switch (device.type_model)
                    {
                        case "5-DI/12-RO":
                            comboBox_IO.Items.Clear();
                            comboBox_IO.Items.Add("O1");
                            comboBox_IO.Items.Add("O2");
                            comboBox_IO.Items.Add("O3");
                            comboBox_IO.Items.Add("O4");
                            comboBox_IO.Items.Add("O5");
                            comboBox_IO.Items.Add("O6");
                            comboBox_IO.Items.Add("O7");
                            comboBox_IO.Items.Add("O8");
                            comboBox_IO.Items.Add("O9");
                            comboBox_IO.Items.Add("O10");
                            comboBox_IO.Items.Add("O11");
                            comboBox_IO.Items.Add("O12");
                            break;
                        case "8-DI/9-RO":
                            comboBox_IO.Items.Clear();
                            comboBox_IO.Items.Add("O1");
                            comboBox_IO.Items.Add("O2");
                            comboBox_IO.Items.Add("O3");
                            comboBox_IO.Items.Add("O4");
                            comboBox_IO.Items.Add("O5");
                            comboBox_IO.Items.Add("O6");
                            comboBox_IO.Items.Add("O7");
                            comboBox_IO.Items.Add("O8");
                            comboBox_IO.Items.Add("O9");
                            break;
                        case "0-DI/12-RO":
                            comboBox_IO.Items.Clear();
                            comboBox_IO.Items.Add("O1");
                            comboBox_IO.Items.Add("O2");
                            comboBox_IO.Items.Add("O3");
                            comboBox_IO.Items.Add("O4");
                            comboBox_IO.Items.Add("O5");
                            comboBox_IO.Items.Add("O6");
                            comboBox_IO.Items.Add("O7");
                            comboBox_IO.Items.Add("O8");
                            comboBox_IO.Items.Add("O9");
                            comboBox_IO.Items.Add("O10");
                            comboBox_IO.Items.Add("O11");
                            comboBox_IO.Items.Add("O12");
                            break;
                    }
                    break;
            }
            switch(device.type_model)
            {
                case "4-TC":
                    comboBox_IO.Items.Clear();
                    comboBox_IO.Items.Add("T1");
                    comboBox_IO.Items.Add("T2");
                    comboBox_IO.Items.Add("T3");
                    comboBox_IO.Items.Add("T4");
                    break;
                case "4-AI":
                    comboBox_IO.Items.Clear();
                    comboBox_IO.Items.Add("AI1");
                    comboBox_IO.Items.Add("AI2");
                    comboBox_IO.Items.Add("AI3");
                    comboBox_IO.Items.Add("AI4");
                    break;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            rele.funcao = comboBox_funcao.Text;
            rele.device = comboBox_device.Text;
            rele.tipo = comboBox_tipo.Text;
            rele.IO = (comboBox_IO.Text);
            
            if (comboBox_funcao.Text == "Produto")
            {
                rele.descricao = comboBox_produto.Text;
            }
            else
            {
                rele.descricao = textBox_description.Text;
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            rele.dateinsert = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

            DataTable dt = bll.getAll(rele.device, "full_name");
            device = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));
            rele.parent = device.parent;

            relebll.insert(rele);

            atualiza_grid("");

            comboBox_produto.SelectedIndex = -1;
            comboBox_device.SelectedIndex = -1;
            comboBox_tipo.SelectedItem = -1;
            comboBox_IO.SelectedIndex = -1;
            comboBox_produto.SelectedIndex = -1;
            textBox_description.Clear();



        }

        private void atualiza_grid(string filtro)
        {
            dataGridView_IO.DataSource = relebll.getAll(filtro, "device");

            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView_IO.CurrentRow != null)
            {
                primeiraLinha = dataGridView_IO.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView_IO.CurrentRow.Index;
                dataGridView_IO.Columns["id"].Visible = false;
                dataGridView_IO.Columns["device"].Width = 120;
                dataGridView_IO.Columns["descricao"].Width = 300;
                dataGridView_IO.Columns["dateinsert"].Visible = false;
                dataGridView_IO.Columns["dateupdate"].Visible = false;
                dataGridView_IO.Columns["funcao"].Width = 265;
                dataGridView_IO.Columns["parent"].Visible = false;
            }

            dataGridView_IO.Refresh();
            dataGridView_IO.ClearSelection();

            if (dataGridView_IO.RowCount != 0)
            {
                dataGridView_IO.Columns["id"].Visible = false;
                dataGridView_IO.Columns["device"].Width = 120;
                dataGridView_IO.Columns["descricao"].Width = 300;
                dataGridView_IO.Columns["dateinsert"].Visible = false;
                dataGridView_IO.Columns["dateupdate"].Visible = false;
                dataGridView_IO.Columns["funcao"].Width = 265;
                dataGridView_IO.Columns["parent"].Visible = false;
            }
        }

        private void comboBox_funcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_device.Items.Clear();
            comboBox_device.Text = "";
            comboBox_tipo.Items.Clear();
            comboBox_tipo.Text = "";
            comboBox_IO.Items.Clear();
            comboBox_IO.Text = "";
            //comboBox_produto.Items.Clear();
            //comboBox_produto.Text = "";
            textBox_description.Clear();

            if (comboBox_funcao.SelectedIndex==0)
            {
                textBox_description.Visible = false;
                comboBox_produto.Location = new Point(556, 25);
                comboBox_produto.Visible = true;
            }
            if (comboBox_funcao.SelectedIndex==1)
            {
                textBox_description.Visible = true;
                //comboBox_produto.Location = new Point(516, 25);
                comboBox_produto.Visible = false;
            }

            load_comboBox_device();
        }

        private void load_comboBox_produto()
        {
            List<Materia_Prima> list = mpbll.getAllCustom();

                if (list != null)
                {
                    foreach (Materia_Prima item in list)
                    {
                            comboBox_produto.Items.Add(item.descricao_completa);
                    }
                }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var itemselecionado = dataGridView_IO.Rows[dataGridView_IO.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(itemselecionado))
                {
                    MessageBox.Show("Selecione um item para deletar!");
                    return;
                }

                var confirmResult = MessageBox.Show("Você realmente deseja excluir este usuário?", "Confirmação de exclusão!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    relebll.delete(Convert.ToInt32(dataGridView_IO.Rows[dataGridView_IO.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                }

                atualiza_grid("");
            }
            catch (Exception ex)
            {
                atualiza_grid("");
            }
        }

        private void dataGridView_IO_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = dataGridView_IO.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    //m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    contextMenuStrip1.Show(dataGridView_IO, new Point(e.X, e.Y));
                }
            }
        }
    }
}
