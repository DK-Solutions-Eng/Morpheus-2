using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Entidades;
using BLL;
using System.Globalization;
using System.Threading;
using System.Configuration;
using Microsoft.VisualBasic;

namespace Mopheus_2
{
    public partial class Form_USERS : Form
    {
        Usuario usuario = new Usuario();
        UsuarioBLL usuariobll = new UsuarioBLL("Usuario");

        bool show_senha = false;

        public Form_USERS()
        {
            InitializeComponent();

            comboBox_tipo_acesso.Items.Add("Administrador");
            comboBox_tipo_acesso.Items.Add("Supervisor");
            comboBox_tipo_acesso.Items.Add("Operador");
            comboBox_tipo_acesso.Items.Add("Recebedor");

            atualiza_grid("");

            if (Global.acesso == "Full")
            {
                show_senha = true;
            }
            else
            {
                show_senha = false;
            }


        }
        private void atualiza_grid(string filtro)
        {
            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView_usuarios.CurrentRow != null)
            {
                primeiraLinha = dataGridView_usuarios.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView_usuarios.CurrentRow.Index;
            }
            dataGridView_usuarios.DataSource = usuariobll.getAll(filtro, "Nome");
            dataGridView_usuarios.Refresh();
            dataGridView_usuarios.ClearSelection();

            if(dataGridView_usuarios.RowCount>0)
            {
                dataGridView_usuarios.Columns["id"].Visible = false;
                dataGridView_usuarios.Columns["dateinsert"].Visible = false;
                dataGridView_usuarios.Columns["dateupdate"].Visible = false;
                dataGridView_usuarios.Columns["Nome"].Width = 267;
                dataGridView_usuarios.Columns["login"].Width = 150;
                dataGridView_usuarios.Columns["senha"].Width = 150;
                dataGridView_usuarios.Columns["acesso"].Width = 150;

            }
        }

        private void dataGridView_usuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (show_senha == false)
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.Value != null)
                    {
                        e.Value = new string('*', e.Value.ToString().Length);
                    }
                    else
                        e.Value = "Null";
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_nome_completo.Text != null && textBox_login.Text != null && textBox_senha.Text != null && comboBox_tipo_acesso.SelectedIndex != -1)
                {
                    usuario.Nome = textBox_nome_completo.Text;
                    usuario.login = textBox_login.Text;
                    usuario.senha = textBox_senha.Text;
                    usuario.acesso = comboBox_tipo_acesso.Text;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    usuario.dateinsert = DateTime.Now;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                    usuariobll.insert(usuario);
                    atualiza_grid("");

                    textBox_nome_completo.Clear();
                    textBox_login.Clear();
                    textBox_senha.Clear();
                    comboBox_tipo_acesso.Text = "";
                }
                else
                {
                    MessageBox.Show("Existem campos em branco!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
          catch(Exception ex)
            {

            }

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var itemselecionado = dataGridView_usuarios.Rows[dataGridView_usuarios.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(itemselecionado))
                {
                    MessageBox.Show("Selecione um item para deletar!");
                    return;
                }

                var confirmResult = MessageBox.Show("Você realmente deseja excluir este usuário?", "Confirmação de exclusão!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    usuariobll.delete(Convert.ToInt32(dataGridView_usuarios.Rows[dataGridView_usuarios.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                }

                atualiza_grid("");
            }
            catch (Exception ex)
            {
                atualiza_grid("");
            }
        }

        private void dataGridView_usuarios_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = dataGridView_usuarios.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    //m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    contextMenuStrip1.Show(dataGridView_usuarios, new Point(e.X, e.Y));
                }
            }
        }
    }
}
