using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.Configuration;
using Microsoft.VisualBasic;
using Common;

namespace Mopheus_2
{
    public partial class Form_CARREGAMENTO : Form
    {
        CarregamentoBLL carregamentobll = new CarregamentoBLL("Carregamento");
        Carregamento carregamento = new Carregamento();

        FornecedorBLL fornecedorbll = new FornecedorBLL("Fornecedor");
        Fornecedor fornecedor = new Fornecedor();

        Usuario user = new Usuario();
        UsuarioBLL usuariobll = new UsuarioBLL("Usuario");

        Materia_PrimaBLL mpbll = new Materia_PrimaBLL("Materia_Prima");
        Materia_Prima mp=new Materia_Prima();

        ReleBLL relebll = new ReleBLL("Rele");
        Rele rele = new Rele();

        Network network = new Network();
        NetworkBLL networkbll = new NetworkBLL("Network");

        byte leitura_indicador = 0;

        byte[] pacote_modbus = new byte[8];

        public Form_CARREGAMENTO()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 0;
            groupBox1.Enabled = false;
            comboBox_device.Enabled = false;
            textBox_peso.Enabled = false;
            load_combobox_fornecedor();
            load_combobox_produto();
            load_combobox_recebedor();
        }

        private void load_combobox_fornecedor()
        {
            List<Fornecedor> list = fornecedorbll.getAllCustom();
            if (list != null)
            {
                foreach (Fornecedor item in list)
                {
                    comboBox_Fornecedor.Items.Add(item.nome_completo);
                }
            }
        }

        private void load_combobox_produto()
        {
            List<Materia_Prima> list = mpbll.getAllCustom();
            if (list != null)
            {
                foreach (Materia_Prima item in list)
                {
                    comboBox_Produto.Items.Add(item.descricao_completa);
                }
            }
        }

        private void load_combobox_recebedor()
        {
            List<Usuario> list = usuariobll.consultaUsuarios();
            if (list != null)
            {
                foreach (Usuario item in list)
                {
                    if (item.acesso == "Recebedor")
                    {
                        comboBox_Recebedor.Items.Add(item.login);
                    }
                }
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("FORNECEDOR: " + comboBox_Fornecedor.Text, drawFont, drawBrush, 10, 45);
            e.Graphics.DrawString("NF: " + textBox_NumeroNota.Text, drawFont, drawBrush, 10, 57);
            e.Graphics.DrawString("PRODUTO: " + comboBox_Produto.Text, drawFont, drawBrush, 10, 69);
            e.Graphics.DrawString("PESO NF:" + textBox_PesoNota.Text + " KG", drawFont, drawBrush, 10, 81);
            e.Graphics.DrawString("PL: " + textBox_PesoReal.Text + " KG", drawFont, drawBrush, 10, 93);

            //e.Graphics.DrawString(pesoinicial.ToString() + " - " + listitenscarregamento.OrderBy(p => p.id).FirstOrDefault().data_inicial, drawFont, drawBrush, 10, 105);
            //e.Graphics.DrawString("PESO LIQUIDO FINAL", drawFont, drawBrush, 10, 117);
            //e.Graphics.DrawString((pesofinal + pesoinicial).ToString() + " - " + listitenscarregamento.OrderByDescending(p => p.id).FirstOrDefault().data_final, drawFont, drawBrush, 10, 129);

            e.Graphics.DrawString("DIF. DA NF:" + textBox_DiferencaNota.Text + " KG", drawFont, drawBrush, 10, 105);
            e.Graphics.DrawString("TARA:" + textBox_tara.Text + " KG", drawFont, drawBrush, 10, 117);
            //e.Graphics.DrawString(txtDiferencaNota.Text, drawFont, drawBrush, 10, 153);
            e.Graphics.DrawString("RESP.: " + comboBox_Recebedor.Text, drawFont, drawBrush, 10, 129);
        }

        private void pararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                leitura_indicador = 0;

                carregamento.fornecedor = comboBox_Fornecedor.Text;
                carregamento.produto = comboBox_Produto.Text;
                carregamento.numero_nota = textBox_NumeroNota.Text;
                if (textBox_PesoNota.Text != "")
                {
                    carregamento.peso_nota_fiscal = Convert.ToInt32(textBox_PesoNota.Text);
                }
                if (textBox_PesoReal.Text != "")
                {
                    carregamento.peso_real = Convert.ToInt32(textBox_PesoReal.Text);
                }
                if (textBox_DiferencaNota.Text != "")
                {
                    carregamento.peso_diferenca = Convert.ToInt32(textBox_DiferencaNota.Text);
                }
                if (textBox_tara.Text != "")
                {
                    carregamento.tara = Convert.ToInt32(textBox_tara.Text);
                }
                carregamento.recebedor = comboBox_Recebedor.Text;
                carregamento.device = comboBox_device.Text;
                carregamento.current_user = Global.user;


                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                carregamento.dateinsert = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                    this.printDocument1.Print();
                }

                carregamentobll.insert(carregamento);

                //MessageBox.Show("Carregamento salvo com sucesso!");

                clear_itens_carregamento();

                tabControl1.SelectedIndex = 0;
                groupBox1.Enabled = false;
                comboBox_device.Enabled = false;
                textBox_peso.Enabled = false;

                
            }
            else
            {
                MessageBox.Show("Esse comando só funciona na aba \"Dados\"!");
            }
        }

        private void clear_itens_carregamento()
        {
            comboBox_Fornecedor.Text = "";
            comboBox_Produto.Text = "";
            textBox_NumeroNota.Clear();
            textBox_PesoNota.Clear();
            textBox_PesoReal.Clear();
            textBox_DiferencaNota.Clear();
            textBox_tara.Clear();
            comboBox_Recebedor.Text = "";
            comboBox_device.Text = "";
            textBox_peso.Text = "000000";
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            groupBox1.Enabled = true;
            comboBox_device.Enabled = true;
            textBox_peso.Enabled = true;

        }

        private void dataGridView_carregamento_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = dataGridView_carregamento.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    //m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    contextMenuStrip1.Show(dataGridView_carregamento, new Point(e.X, e.Y));
                }
            }
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                leitura_indicador = 1;
            }
            else
            {
                MessageBox.Show("Esse comando só funciona na aba \"Dados\"!");
            }
        }

        private void pausarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                leitura_indicador = 2;
            }
            else
            {
                MessageBox.Show("Esse comando só funciona na aba \"Dados\"!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(leitura_indicador)
            {
                case 0:
                    break;
                case 1:
                    try
                    {
                        List<Rele> list = relebll.getCustomListRele();

                        List<Network> listnet = networkbll.getAllCustom();
                        foreach (Network item in listnet)
                        {
                            if (comboBox_device.Text == item.full_name)
                            {
                                pacote_modbus[0] = Convert.ToByte(item.addr);
                            }
                        }

                        pacote_modbus[1] = 0x03;
                        pacote_modbus[2] = 0x00;
                        pacote_modbus[3] = 0x10;
                        pacote_modbus[4] = 0x00;
                        pacote_modbus[5] = 0x02;
                        pacote_modbus[6] = Convert.ToByte(Crc16.ComputeCrc(pacote_modbus) >> 8);
                        pacote_modbus[7] = Convert.ToByte(Crc16.ComputeCrc(pacote_modbus) & 0xff);
                        Serial_Comumnication.serial_port.Write(pacote_modbus, 0, pacote_modbus.Length);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Erro ao enviar mensagem pela porta serial!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
