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
using Entidades;


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

            hide_menus();
        }

        private void hide_menus()
        {
            loginToolStripMenuItem.Visible = true;
            receitaToolStripMenuItem.Visible = false;
            lerLogsToolStripMenuItem.Visible = false;
            carregamentoToolStripMenuItem.Visible = false;
            statusDosDispositivosToolStripMenuItem.Visible = false;
            sairToolStripMenuItem.Visible = true;
            comunicaçãoToolStripMenuItem.Visible = false;
            redeStripMenuItem.Visible = false;
            entradaESaídasToolStripMenuItem.Visible = false;
            matériaPrimaToolStripMenuItem.Visible = false;
            fornecedoresToolStripMenuItem.Visible = false;
            usuáriosToolStripMenuItem.Visible = false;
            helpToolStripMenuItem.Visible = true;
            sobreToolStripMenuItem.Visible = true;
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
            toolStripStatusLabel2.Text = Global.user;
            toolStripStatusLabel3.Text = Global.acesso;
            verifica_acesso();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"Manual.pdf");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }


        }

        private void entradaESaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_IO form_IO;
            form_IO = new Form_IO();
            form_IO.ShowDialog();
        }

        private void Form_PRINCIPAL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (Serial_Comumnication.serial_port.IsOpen)
                    {
                        Serial_Comumnication.serial_port.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fechar a porta serial!" + "\r\n" + ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (Serial_Comumnication.serial_port.IsOpen)
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

        private void lerLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matériaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_MATERIA_PRIMA form_MP;
            form_MP = new Form_MATERIA_PRIMA();
            form_MP.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_FORNECEDOR form_fornecedor;
            form_fornecedor = new Form_FORNECEDOR();
            form_fornecedor.ShowDialog();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            /* Exibindo novamente o programa */
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void Form_MAIN_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hide_menus();
            Form_LOGIN form_LOGIN;
            form_LOGIN = new Form_LOGIN();
            form_LOGIN.ShowDialog();
            toolStripStatusLabel2.Text = Global.user;
            toolStripStatusLabel3.Text = Global.acesso;
            verifica_acesso();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_USERS form_USER;
            form_USER = new Form_USERS();
            form_USER.ShowDialog();
        }

        private void verifica_acesso()
        {
            switch (Global.acesso)
            {
                case "Administrador":
                    loginToolStripMenuItem.Visible = true;
                    receitaToolStripMenuItem.Visible = true;
                    carregamentoToolStripMenuItem.Visible = true;
                    lerLogsToolStripMenuItem.Visible = true;
                    statusDosDispositivosToolStripMenuItem.Visible = true;
                    sairToolStripMenuItem.Visible = true;
                    comunicaçãoToolStripMenuItem.Visible = true;
                    redeStripMenuItem.Visible = true;
                    entradaESaídasToolStripMenuItem.Visible = true;
                    matériaPrimaToolStripMenuItem.Visible = true;
                    fornecedoresToolStripMenuItem.Visible = true;
                    usuáriosToolStripMenuItem.Visible = true;
                    helpToolStripMenuItem.Visible = true;
                    sobreToolStripMenuItem.Visible = true;
                    break;
                case "Full":
                    loginToolStripMenuItem.Visible = true;
                    receitaToolStripMenuItem.Visible = true;
                    carregamentoToolStripMenuItem.Visible = true;
                    lerLogsToolStripMenuItem.Visible = true;
                    statusDosDispositivosToolStripMenuItem.Visible = true;
                    sairToolStripMenuItem.Visible = true;
                    comunicaçãoToolStripMenuItem.Visible = true;
                    redeStripMenuItem.Visible = true;
                    entradaESaídasToolStripMenuItem.Visible = true;
                    matériaPrimaToolStripMenuItem.Visible = true;
                    fornecedoresToolStripMenuItem.Visible = true;
                    usuáriosToolStripMenuItem.Visible = true;
                    helpToolStripMenuItem.Visible = true;
                    sobreToolStripMenuItem.Visible = true;
                    break;
                case "Recebedor":
                    loginToolStripMenuItem.Visible = true;
                    receitaToolStripMenuItem.Visible = false;
                    carregamentoToolStripMenuItem.Visible = true;
                    lerLogsToolStripMenuItem.Visible = false;
                    statusDosDispositivosToolStripMenuItem.Visible = false;
                    sairToolStripMenuItem.Visible = true;
                    comunicaçãoToolStripMenuItem.Visible = false;
                    redeStripMenuItem.Visible = false;
                    entradaESaídasToolStripMenuItem.Visible = false;
                    matériaPrimaToolStripMenuItem.Visible = false;
                    fornecedoresToolStripMenuItem.Visible = false;
                    usuáriosToolStripMenuItem.Visible = false;
                    helpToolStripMenuItem.Visible = true;
                    sobreToolStripMenuItem.Visible = true;
                    break;
                case "Operador":
                    loginToolStripMenuItem.Visible = true;
                    receitaToolStripMenuItem.Visible = true;
                    carregamentoToolStripMenuItem.Visible = false;
                    lerLogsToolStripMenuItem.Visible = false;
                    statusDosDispositivosToolStripMenuItem.Visible = true;
                    sairToolStripMenuItem.Visible = true;
                    comunicaçãoToolStripMenuItem.Visible = false;
                    redeStripMenuItem.Visible = false;
                    entradaESaídasToolStripMenuItem.Visible = false;
                    matériaPrimaToolStripMenuItem.Visible = false;
                    fornecedoresToolStripMenuItem.Visible = false;
                    usuáriosToolStripMenuItem.Visible = false;
                    helpToolStripMenuItem.Visible = true;
                    sobreToolStripMenuItem.Visible = true;
                    break;
                case "Supervisor":
                    loginToolStripMenuItem.Visible = true;
                    receitaToolStripMenuItem.Visible = true;
                    carregamentoToolStripMenuItem.Visible = false;
                    lerLogsToolStripMenuItem.Visible = false;
                    statusDosDispositivosToolStripMenuItem.Visible = true;
                    sairToolStripMenuItem.Visible = true;
                    comunicaçãoToolStripMenuItem.Visible = true;
                    redeStripMenuItem.Visible = true;
                    entradaESaídasToolStripMenuItem.Visible = true;
                    matériaPrimaToolStripMenuItem.Visible = false;
                    fornecedoresToolStripMenuItem.Visible = false;
                    usuáriosToolStripMenuItem.Visible = false;
                    helpToolStripMenuItem.Visible = true;
                    sobreToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void carregamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CARREGAMENTO form_carregamento = new Form_CARREGAMENTO();
            form_carregamento.ShowDialog();
        }
    }
}
