using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace Mopheus_2
{
    public partial class Form_MAIN : Form
    {
        Form_CONFIG_SERIAL_PORT form_config_serial;

        public Form_MAIN()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();

            
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form_Sobre form_sobre;
            form_sobre = new Form_Sobre();
            form_sobre.ShowDialog();
        }

        public void comunicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            form_config_serial = new Form_CONFIG_SERIAL_PORT();
            form_config_serial.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_REDE form_rede;
            form_rede = new Form_REDE();
            form_rede.ShowDialog();
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_receita form_receita;
            form_receita = new Form_receita();
            form_receita.ShowDialog();
        }

        private void Form_PRINCIPAL_Load(object sender, EventArgs e)
        {
            Form_Splash splash = new Form_Splash();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Manual.pdf");
        }

        private void entradaESaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_IO form_IO;
            form_IO = new Form_IO();
            form_IO.ShowDialog();
        }

        private void Form_PRINCIPAL_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Serial_Comumnication.serial_port.IsOpen)
                {
                    Serial_Comumnication.serial_port.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao fechar a porta serial!"+ "\r\n"+ ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if(Serial_Comumnication.serial_port.IsOpen)
            {
                toolStripStatusLabel1.Text = "CONECTADO";
                if (toolStripStatusLabel1.BackColor == System.Drawing.Color.Green)
                {
                    toolStripStatusLabel1.BackColor = SystemColors.Control;
                }
                else
                {
                    toolStripStatusLabel1.BackColor = System.Drawing.Color.Green;
                }

            }
            else
            {
                toolStripStatusLabel1.Text = "DESCONECTADO";
                toolStripStatusLabel1.BackColor = System.Drawing.Color.Red;
            }

            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
