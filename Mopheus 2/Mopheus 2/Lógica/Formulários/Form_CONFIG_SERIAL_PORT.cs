using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using BLL;
using Entidades;

namespace Mopheus_2
{
    public partial class Form_CONFIG_serialPort : Form
    {
        ConfiguracaoBLL bll = new ConfiguracaoBLL("Configuracao");
        Configuracao obj = new Configuracao();

        string RxString;


        public Form_CONFIG_serialPort()
        {
            InitializeComponent();
            timerCOM.Enabled = true;
        }

        private void button_conectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Comumnication.serialPort.IsOpen)
                {
                    button_conectar.Text = "CONECTAR";
                    Serial_Comumnication.serialPort.Close();
                }
                else
                {
                    if (string.IsNullOrEmpty(comboBox_porta_arduino.Text))
                    {
                        MessageBox.Show("Selecione a Porta Serial","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }

                    if (string.IsNullOrEmpty(comboBox_Speed.Text))
                    {
                        MessageBox.Show("Selecione a Velocidade", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    obj.porta_arduino = comboBox_porta_arduino.Text;
                    obj.baud_rate = Convert.ToInt32(comboBox_Speed.Text);
                    bll.update(obj);


                    //Global.serialPort_status = true;

                    Serial_Comumnication.serialPort.PortName = comboBox_porta_arduino.Text;
                    Serial_Comumnication.serialPort.BaudRate = Convert.ToInt32(comboBox_Speed.Text);
                    Serial_Comumnication.serialPort.DataBits = 8;
                    Serial_Comumnication.serialPort.StopBits = System.IO.Ports.StopBits.Two;
                    Serial_Comumnication.serialPort.Parity = System.IO.Ports.Parity.None;
              
                    Serial_Comumnication.serialPort.Open();
                    if (Serial_Comumnication.serialPort.IsOpen)
                    {
                        button_conectar.Text = "DESCONECTAR";
                        MessageBox.Show("Porta serial aberta com sucesso!","Sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(0);
                //Global.serialPort_status = false;
            }
        }

        private void Form_CONFIG_serialPort_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox_porta_arduino.Items.AddRange(SerialPort.GetPortNames());

                if (comboBox_porta_arduino.Items.Count == 0)
                {
                    throw new Exception("Não existe porta serial instalada!");
                }
                else
                {
                    comboBox_porta_arduino.SelectedIndex = 0;

                    comboBox_Speed.Items.Add(1200);
                    comboBox_Speed.Items.Add(2400);
                    comboBox_Speed.Items.Add(4800);
                    comboBox_Speed.Items.Add(9600);
                    comboBox_Speed.Items.Add(19200);
                    comboBox_Speed.Items.Add(38400);
                    comboBox_Speed.Items.Add(57600);
                    comboBox_Speed.Items.Add(115200);

                    DataTable dt = bll.getAll("", "porta_arduino");
                    if (dt == null)
                    {
                        bll.insert(obj);
                        dt = bll.getAll("", "porta_arduino");
                    }
                    obj = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));
                    comboBox_porta_arduino.SelectedItem = obj.porta_arduino;
                    comboBox_Speed.Text = obj.baud_rate.ToString();

                    if (Serial_Comumnication.serialPort.IsOpen)
                    {
                        button_conectar.Text = "DESCONECTAR";
                    }
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(0);
            }


        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_Comumnication.serialPort.IsOpen)
                {
                    if (checkBox_CR_LF.Checked)
                    {
                        Serial_Comumnication.serialPort.Write(textBox_tx.Text + "\r\n");
                    }
                    else
                    {
                        Serial_Comumnication.serialPort.Write(textBox_tx.Text);
                    }
                    if (checkBox_limpar.Checked)
                    {
                        textBox_tx.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("A porta serial não foi aberta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clear_tx_Click(object sender, EventArgs e)
        {
            textBox_tx.Clear();
        }

        private void button_clear_rx_Click(object sender, EventArgs e)
        {
            textBox_rx.Clear();
        }

        private void checkBox_Continuos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_continuous.Checked)
            {
                button_enviar.Enabled = false;
                checkBox_CR_LF.Enabled = false;
                checkBox_CR_LF.Checked = false;
            }
            else
            {
                button_enviar.Enabled = true;
                checkBox_CR_LF.Enabled = true;
            }
        }

        private void textBox_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (checkBox_continuous.Checked)
                {
                    Serial_Comumnication.serialPort.Write(e.KeyChar.ToString());
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            atualizaListaCOMs();
        }

        private void atualizaListaCOMs()
        {
            //int i;
            //bool quantDiferente; //flag para sinalizar que a quantidade de portas mudou

            //i = 0;
            //quantDiferente = false;

            //se a quantidade de portas mudou
            if (comboBox_porta_arduino.Items.Count == SerialPort.GetPortNames().Length)
            {
                //foreach (string s in SerialPort.GetPortNames())
                //{
                //    if (comboBox_porta_arduino.Items[i++].Equals(s) == false)
                //    {
                //        quantDiferente = true;
                //    }
                //}
                return;
            }
            else
            {
                //quantDiferente = true;
                string last_com_name = comboBox_porta_arduino.SelectedText.ToString();
                //MessageBox.Show(last_com_name);
                comboBox_porta_arduino.Items.Clear();
                //adiciona todas as COM diponíveis na lista
                foreach (string s in SerialPort.GetPortNames())
                {
                    comboBox_porta_arduino.Items.Add(s);
                }
                comboBox_porta_arduino.SelectedIndex = comboBox_porta_arduino.FindStringExact(last_com_name);
                //comboBox_porta_arduino.Sorted = true;
                //seleciona a primeira posição da lista
                //comboBox_porta_arduino.SelectedIndex = 0;
            }

            //Se não foi detectado diferença
            //if (quantDiferente == false)
            //{
            //    return;                     //retorna
            //}

            //limpa comboBox
            //comboBox_porta_arduino.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            //foreach (string s in SerialPort.GetPortNames())
            //{
            //    comboBox_porta_arduino.Items.Add(s);
            //}
            //seleciona a primeira posição da lista
            //comboBox_porta_arduino.SelectedIndex = 0;
        }

        private void DisplayText(object sender, EventArgs e)
        {
            if (!checkBox_HEX_format.Checked)
            {
                //textBox_rx.AppendText(Program.rx_string);
            }
            else
            {
                char[] charValues = RxString.ToCharArray();
                string hexOutput = "";
                foreach (char _eachChar in charValues)
                {
                    // Get the integral value of the character.
                    int value = Convert.ToInt32(_eachChar);
                    // Convert the decimal value to a hexadecimal value in string form.
                    hexOutput += "0x"+String.Format("{0:X}", value)+" ";
                    // to make output as your eg 
                    //  hexOutput +=" "+ String.Format("{0:X}", value);
                    
                }
                textBox_rx.AppendText(hexOutput);
            }
        }

        private void checkBox_HEX_format_CheckedChanged(object sender, EventArgs e)
        {
            textBox_rx.Clear();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //this.Invoke(new EventHandler(DisplayText));
            RxString = Program.rx_string;
            DisplayText(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Program.rx_string);
            textBox_rx.Text = Program.rx_string;
        }
    }
}
