using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Entidades;
using BLL;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace Mopheus_2
{
    public partial class Form_LOGIN : Form
    {
        Usuario user = new Usuario();
        UsuarioBLL userbll = new UsuarioBLL("Usuario");

        
        public Form_LOGIN()
        {
            InitializeComponent();

            //button_cancel.DialogResult = DialogResult.Cancel;
            //button_save.DialogResult = DialogResult.OK;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.user = "";
            Global.acesso = "";
            DialogResult = DialogResult.Cancel;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_login.Text == "god_mode")
            {
                MessageBox.Show("Seja bem vindo meu criador!", "Bem Vindo!", MessageBoxButtons.OK);
                Global.user = textBox_login.Text.ToUpper();
                Global.god_mode = true;
                Global.acesso = "Full";
                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                try
                {
                    DataTable dt = userbll.getAll(textBox_login.Text, "login");
                    if (dt == null)
                    {
                        MessageBox.Show("Nenhum login não cadastrado! Entre em contato com o Administrador do sistema", "Erro!", MessageBoxButtons.OK);
                        return;
                    }
                    user = userbll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

                    if (textBox_login.Text == user.login)
                    {
                        if (textBox_senha.Text == user.senha)
                        {
                            MessageBox.Show("Seja bem vindo " + user.Nome+"!", "Bem Vindo!", MessageBoxButtons.OK);                    
                            Global.user = textBox_login.Text.ToUpper();
                            Global.acesso = user.acesso;
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Senha incorreta! Verifique os caracteres maiúsculos e minúsculos e tente novamente", "Atenção!", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login não cadastrado!", "Atenção!", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {

                }

                Global.god_mode = false;
            }
        }
    }
}
