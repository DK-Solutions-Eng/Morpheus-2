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
        Materia_Prima mp = new Materia_Prima();

        ReleBLL relebll = new ReleBLL("Rele");
        Rele rele = new Rele();

        Network network = new Network();
        NetworkBLL networkbll = new NetworkBLL("Network");

        byte leitura_indicador = 0;

        

        String string_peso;

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
            load_combobox_indicador();

            //Serial_Comumnication.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
        }

        private void load_combobox_indicador()
        {
            List<Network> list = networkbll.getAllCustom();
            if (list != null)
            {
                foreach (Network item in list)
                {
                    if (item.model == "Indicador")
                    {
                        comboBox_device.Items.Add(item.full_name);
                        textBox_device_addr.Text = item.addr.ToString();
                    }
                }
            }
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
            timer1.Enabled = true;

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
            //switch (leitura_indicador)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        try
            //        {
            //            List<Rele> list = relebll.getCustomListRele();

            //            List<Network> listnet = networkbll.getAllCustom();
            //            foreach (Network item in listnet)
            //            {
            //                if (comboBox_device.Text == item.full_name)
            //                {
            //                    pacote_modbus[0] = Convert.ToByte(item.addr);
            //                }
            //            }

            //            pacote_modbus[1] = 0x03;
            //            pacote_modbus[2] = 0x00;
            //            pacote_modbus[3] = 0x10;
            //            pacote_modbus[4] = 0x00;
            //            pacote_modbus[5] = 0x02;
            //            pacote_modbus[6] = Convert.ToByte(Crc16.ComputeCrc(pacote_modbus) >> 8);
            //            pacote_modbus[7] = Convert.ToByte(Crc16.ComputeCrc(pacote_modbus) & 0xff);
            //            Serial_Comumnication.serialPort.Write(pacote_modbus, 0, pacote_modbus.Length);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Erro ao enviar mensagem pela porta serial!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}

            if(Serial_Comumnication.serialPort.IsOpen)
            {
                byte[] pacote_modbus = new byte[8];

                pacote_modbus[0] = 0x10;
                pacote_modbus[1] = 0x03;
                pacote_modbus[2] = 0x00;
                pacote_modbus[3] = 0x10;
                pacote_modbus[4] = 0x00;
                pacote_modbus[5] = 0x02;
                pacote_modbus[7] = Convert.ToByte(Crc16.ComputeCrc(pacote_modbus,pacote_modbus.Length-2) >> 8);
                pacote_modbus[6] = Convert.ToByte(Crc16.ComputeCrc(pacote_modbus,pacote_modbus.Length-2) & 0xff);
                Serial_Comumnication.serialPort.Write(pacote_modbus, 0, pacote_modbus.Length);
            }
        }

        //private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        //{
        //    int bytes_to_read;
        //    byte crch, crcl;
        //    byte crch_received, crcl_received;
        //    try
        //    {
        //        if (Serial_Comumnication.serialPort.IsOpen)
        //        {
        //            bytes_to_read = Serial_Comumnication.serialPort.BytesToRead;
        //            byte[] buffer = new byte[bytes_to_read - 2];

        //            for (int i = 0; i < bytes_to_read - 2; i++)
        //            {
        //                buffer[i] = Convert.ToByte(Serial_Comumnication.serialPort.ReadByte());
        //            }

        //            //Serial_Comumnication.serialPort.Read(buffer, 0, bytes_to_read);

        //            crch = Convert.ToByte(Crc16.ComputeCrc(buffer,buffer.Length) >> 8);
        //            crcl = Convert.ToByte(Crc16.ComputeCrc(buffer, buffer.Length) & 0xff);

        //            crch_received = Convert.ToByte(Serial_Comumnication.serialPort.ReadByte());
        //            crcl_received = Convert.ToByte(Serial_Comumnication.serialPort.ReadByte());

        //            if (crch == crch_received & crcl == crcl_received)
        //            {
        //                string_peso = descobre_peso(buffer);
        //                this.Invoke(new EventHandler(Display_Peso));
        //            }
        //            else
        //            {
        //                string_peso = "ERRO";
        //                this.Invoke(new EventHandler(Display_Peso)); ;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Porta serial não está aberta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao ler a porta serial!\r\n" + ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private string descobre_peso(byte[] buffer)
        {

            string unidade = "KG";
            string format;
            float peso;
            byte status;
            Boolean tipo_peso = false;
            Boolean peso_negativo = false;
            Boolean saturacao = false;
            Boolean sobrecarga = false;
            Boolean peso_bruto = false;
            float multiplicador;

            status = buffer[3];

            #region VERIFICACAO DE PESO LIQUIDO E PESO BRUTO

            if ((status & 0b10000000) == 0x80)
            {
                tipo_peso = true;  //peso bruto
                peso_bruto = tipo_peso;
            }
            if ((status & 0b10000000) == 0)
            {
                tipo_peso = false;  //peso liquido
                peso_bruto = tipo_peso;
            }
            #endregion


            #region VERIFICACAO PESO NEGATIVO

            if ((status & 0b00001000) == 0x08)
            {
                peso_negativo = true;
            }
            if ((status & 0b00001000) == 0)
            {
                peso_negativo = false;
            }
            #endregion VERIFICACAO PESO NEGATIVO


            #region VERIFICACAO DE SOBRECARGA

            if ((status & 0b01000000) == 0x40)
            {
                sobrecarga = true;
            }
            if ((status & 0b01000000) == 0)
            {
                sobrecarga = false;
            }

            #endregion


            #region VERIFICACAO DE SATURACAO

            if ((status & 0b00100000) == 0x20)
            {
                saturacao = true;
            }
            if ((status & 0b00100000) == 0)
            {
                saturacao = false;
            }

            #endregion


            #region POSICAO PONTO DECIMAL

            switch ((status & 0b00000111))
            {
                case 0:
                    multiplicador = 1.0f;
                    format = "{0:F0}";
                    break;

                case 1:
                    multiplicador = 0.1f;
                    format = "{0:F1}";
                    break;

                case 2:
                    multiplicador = 0.01f;
                    format = "{0:F2}";
                    break;

                case 3:
                    multiplicador = 0.001f;
                    format = "{0:F3}";
                    break;

                case 4:
                    multiplicador = 0.0001f;
                    format = "{0:F4}";
                    break;

                default:
                    multiplicador = 1.0f;
                    format = "{0:F0}";
                    break;
            }

            #endregion POSICAO PONTO DECIMAL

            if (peso_negativo)
            {
                peso = ((buffer[4] * 65536) + (buffer[5] * 256) + (buffer[6])) * multiplicador * -1.0f;
            }
            else
            {
                peso = ((buffer[4] * 65536) + (buffer[5] * 256) + (buffer[6])) * multiplicador * 1.0f;
            }

            if (sobrecarga == true)
            {

                string_peso = "SOBRECARGA";

            }
            else if (saturacao == true)
            {

                string_peso = "SATURADO";
            }
            else
            {

                switch (tipo_peso)
                {
                    case false:
                        string_peso = "L" + string.Format(format, peso) + " " + unidade;
                        break;

                    case true:
                        string_peso = "B" + string.Format(format, peso) + " " + unidade;
                        break;

                    default:
                        string_peso = "N/A";
                        break;
                }

            }
            return string_peso;
        }

        private void Display_Peso(object sender, EventArgs e)
        {
            if (string_peso == "ERRO")
            {
                textBox_peso.Text = string_peso;
            }
            else
            {
                textBox_peso.Text = string_peso.Substring(1);
            }

        }

        private void Form_CARREGAMENTO_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
