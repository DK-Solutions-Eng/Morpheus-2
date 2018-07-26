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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.Configuration;
using Microsoft.VisualBasic;
using Common;


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
            MessageBox.Show("Função em desenvolvimento, aguarde!", "Atenção!");
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
                    atualizarDataEHoraToolStripMenuItem.Visible = true;
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
                    atualizarDataEHoraToolStripMenuItem.Visible = true;
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
                    atualizarDataEHoraToolStripMenuItem.Visible = false;
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
                    atualizarDataEHoraToolStripMenuItem.Visible = false;
                    break;
                case "Supervisor":
                    loginToolStripMenuItem.Visible = true;
                    receitaToolStripMenuItem.Visible = true;
                    carregamentoToolStripMenuItem.Visible = false;
                    lerLogsToolStripMenuItem.Visible = true;
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
                    atualizarDataEHoraToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void carregamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CARREGAMENTO form_carregamento = new Form_CARREGAMENTO();
            form_carregamento.ShowDialog();
        }

        private void atualizarDataEHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String hora;
            String data;
            String dia_semana;
            byte[] cmd_data_hora;
            cmd_data_hora = new byte[12];
            UInt16 crc;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            hora = DateTime.Now.ToLongTimeString().ToString();
            data = DateTime.Now.ToShortDateString().ToString();
            dia_semana = DateTime.Now.DayOfWeek.ToString().ToUpper();
            byte temp_dia_semana = 0;
            switch (dia_semana)
            {
                case "SUNDAY":
                    temp_dia_semana = 1;
                    break;
                case "MONDAY":
                    temp_dia_semana = 2;
                    break;
                case "TUESDAY":
                    temp_dia_semana = 3;
                    break;
                case "WEDNESDAY":
                    temp_dia_semana = 4;
                    break;
                case "THURSDAY":
                    temp_dia_semana = 5;
                    break;
                case "FRIDAY":
                    temp_dia_semana = 6;
                    break;
                case "SATURDAY":
                    temp_dia_semana = 7;
                    break;
                default:
                    break;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

            cmd_data_hora[0] = 0x00;
            cmd_data_hora[1] = 0x60;
            cmd_data_hora[2] = temp_dia_semana;
            //dia
            cmd_data_hora[3] = Convert.ToByte(data.Substring(0, 2));    //00/00/0000
            //mes
            cmd_data_hora[4] = Convert.ToByte(data.Substring(3, 2));
            //ano high
            cmd_data_hora[5] = Convert.ToByte(data.Substring(6, 2));
            //ano low
            cmd_data_hora[6] = Convert.ToByte(data.Substring(8, 2));
            //hora
            cmd_data_hora[7] = Convert.ToByte(hora.Substring(0, 2));    //00:00:00
            //minuto
            cmd_data_hora[8] = Convert.ToByte(hora.Substring(3, 2));
            //segundo
            cmd_data_hora[9] = Convert.ToByte(hora.Substring(6, 2));

            crc = Crc16.ComputeCrc(cmd_data_hora);
            cmd_data_hora[10] = Convert.ToByte(crc >> 8);
            cmd_data_hora[11] = Convert.ToByte(crc & 0xff);

            if (Serial_Comumnication.serial_port.IsOpen)
            {
                try
                {
                    //Serial_Comumnication.serial_port.Write(60.ToString() + temp_dia_semana.ToString() + data + hora);
                    Serial_Comumnication.serialPort.Write(cmd_data_hora,0,cmd_data_hora.Length);
                    MessageBox.Show("Dia da Semana: " + dia_semana + "\r\n" + "Data: " + data + "\r\n" + "Horário: " + hora + "\r\n", "Atualização de Data e Hora");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Erro no envio do comando! Verificar a comunicação serial.", "Atualização de Data e Hora");
                }
            }
            else
            {
                MessageBox.Show("Porta Serial não configurada!", "Atualização de Data e Hora");
            }

        }

        private void statusDosDispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função em desenvolvimento, aguarde!", "Atenção!");
        }
    }
}
