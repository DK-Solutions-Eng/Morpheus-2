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

namespace Mopheus_2
{
    public partial class Form_receita : Form
    {
        ReceitaBLL bll = new ReceitaBLL("Receita");
        Receita obj;
        ItensReceita objitensreceita;
        ItensReceitaBLL bllitensreceita = new ItensReceitaBLL("ItensReceita");
        ComandoBLL bllcomando = new ComandoBLL("Comando");
        ReleBLL bllrele = new ReleBLL("Rele");

        public Form_receita()
        {
            InitializeComponent();

            load_comboboxs();

            atualiza_receitas("");

            disable_all_itens();
        }

        private void load_comboboxs()
        {
            comboBox_repeticao.Items.Add("Manual");
            comboBox_repeticao.Items.Add("Automático");
            comboBox_repeticao.SelectedIndex = 0;
            label_vezez.Visible = false;
            textBox_vezes.Visible = false;
            label_intervalo.Visible = false;
            textBox_intervalo.Visible = false;

            comboBox_processo.Items.Add("Enchimento");
            comboBox_processo.Items.Add("Escoamento");

            comboBox_evento_anterior_tipo.Items.Add("Tempo");
            comboBox_evento_anterior_tipo.Items.Add("Entrada");
            comboBox_evento_anterior_tipo.Items.Add("Imediato");

            comboBox_evento_posterior_tipo.Items.Add("Peso");
            comboBox_evento_posterior_tipo.Items.Add("Entrada");
            comboBox_evento_posterior_tipo.Items.Add("Tempo");
            comboBox_evento_posterior_tipo.SelectedIndex = 0;

        }

        private void comboBox_evento_posterior_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_evento_posterior_tipo.Text == "Peso")
            {
                tabControl_evento_posterior.SelectTab(0);
                tabControl_evento_posterior.TabPages[0].Enabled = true;
                tabControl_evento_posterior.TabPages[1].Enabled = false;
                tabControl_evento_posterior.TabPages[2].Enabled = false;
            }
            if (comboBox_evento_posterior_tipo.Text == "Entrada")
            {
                tabControl_evento_posterior.SelectTab(1);
                tabControl_evento_posterior.TabPages[0].Enabled = false;
                tabControl_evento_posterior.TabPages[1].Enabled = true;
                tabControl_evento_posterior.TabPages[2].Enabled = false;
            }
            if (comboBox_evento_posterior_tipo.Text == "Tempo")
            {
                tabControl_evento_posterior.SelectTab(2);
                tabControl_evento_posterior.TabPages[0].Enabled = false;
                tabControl_evento_posterior.TabPages[1].Enabled = false;
                tabControl_evento_posterior.TabPages[2].Enabled = true;
            }
        }

        private void comboBox_repeticao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_repeticao.Text == "Manual")
            {
                label_vezez.Visible = false;
                textBox_vezes.Visible = false;
                label_intervalo.Visible = false;
                textBox_intervalo.Visible = false;
            }
            else
            {
                label_vezez.Visible = true;
                textBox_vezes.Visible = true;
                label_intervalo.Visible = true;
                textBox_intervalo.Visible = true;
            }
        }

        private void comboBox_evento_anterior_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_evento_anterior_tipo.Text == "Tempo")
            {
                tabControl_evento_anterior.SelectTab(0);


            }
            if (comboBox_evento_anterior_tipo.Text == "Entrada")
            {
                tabControl_evento_anterior.SelectTab(1);

            }
        }

        private void statusDosDispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Device_Status form_device_status;
            form_device_status = new Form_Device_Status();
            form_device_status.ShowDialog();
        }

        private void checkBox_saida_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_saida.Checked)
            {
                comboBox_saida_emergencia.Visible = true;
            }
            else
            {
                comboBox_saida_emergencia.Visible = false;
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form_receita_Load(object sender, EventArgs e)
        {


        }
        private void dataGridView_receitas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_receitas.Rows[dataGridView_receitas.SelectedCells[0].RowIndex].Cells[0].Value != null)
                {
                    Receita obj = bll.get(Convert.ToInt32(dataGridView_receitas.Rows[dataGridView_receitas.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                    show_data_recipe(obj);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void show_data_recipe(Receita obj)
        {
            this.obj = obj;
            textBox_id.Text = obj.id.ToString();
            textBox_nome_receita.Text = obj.nome;
            comboBox_device.Text = obj.dispositivo;
            textBox_endereco.Text = obj.endereco.ToString();
            comboBox_repeticao.Text = obj.repeticao;
            textBox_vezes.Text = obj.vezes.ToString();
            textBox_intervalo.Text = obj.intervalo;
            carregaItensReceita(obj.id);
            tabControl1.SelectedIndex = 1;
        }

        public void atualiza_receitas(string filtro)
        {
            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView_receitas.CurrentRow != null)
            {
                primeiraLinha = dataGridView_receitas.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView_receitas.CurrentRow.Index;
            }
            dataGridView_receitas.DataSource = bll.getAll(filtro, "NOME");
            dataGridView_receitas.Refresh();
            dataGridView_receitas.ClearSelection();
        }
        private void disable_all_itens()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void novaReceitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            textBox_nome_receita.Enabled = true;
            textBox_nome_receita.Focus();
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
        }
        public void carregaItensReceita(int? id_receita)
        {
            dataGridView_itens_receita.DataSource = bllitensreceita.getCustomReceita(id_receita);
            dataGridView_itens_receita.Refresh();
            dataGridView_itens_receita.ClearSelection();
            if (dataGridView_itens_receita.DataSource != null)
            {
                ascenderToolStripMenuItem.Enabled = true;
                descenderToolStripMenuItem.Enabled = true;
                excluirToolStripMenuItem.Enabled = true;
                dataGridView_itens_receita.Enabled = true;
            }
            else
            {
                dataGridView_itens_receita.Enabled = false;
                ascenderToolStripMenuItem.Enabled = false;
                descenderToolStripMenuItem.Enabled = false;
                excluirToolStripMenuItem.Enabled = false;
            }
        }
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_nome_receita.Text))
            {
                MessageBox.Show("Informe o nome da receita!");
                return;
            }

            if (comboBox_device.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Dispositivo!");
                return;
            }

            if (Convert.ToInt32(textBox_endereco.Text) == 0)
            {
                MessageBox.Show("Informe o endereço do dispositivo!");
                return;
            }

            if (comboBox_repeticao.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo de repetição!");
                return;
            }

            if (Convert.ToInt32(textBox_vezes.Text) == 0)
            {
                MessageBox.Show("Informe a quantide de repetições!");
                return;
            }

            if(string.IsNullOrEmpty(textBox_intervalo.Text))
            {
                MessageBox.Show("Informe o intervalo da repetição!");
                return;
            }

            //se nao existir id para a receita significa q nao foi adicionado item
            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                MessageBox.Show("Adicione pelo menos um item na receita!");
                return;
            }

            if(string.IsNullOrEmpty(textBox_etapa.Text))
            {
                MessageBox.Show("Insira a etapa do processo!");
                return;
            }
            if(comboBox_processo.SelectedIndex==-1)
            {
                MessageBox.Show("Defina o tipo do processo!");
                return;
            }

            if(comboBox_produto.SelectedIndex==-1)
            {
                MessageBox.Show("Selecione o Produto!");
                return;
            }

            if(string.IsNullOrEmpty(textBox_rele.Text))
            {
                MessageBox.Show("Defina a sáida!");
                return;
            }





            obj = new Receita();
            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                obj.nome = textBox_nome_receita.Text;
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                obj = bll.getCustomUltimo();
                textBox_id.Text = obj.id.ToString();
            }
            else
            {
                obj = bll.get(Convert.ToInt32(textBox_id.Text));
            }

            if (objitensreceita != null)
            {
                objitensreceita.id_receita = objitensreceita.id_receita;
                objitensreceita.etapa = textBox_etapa.Text;
                objitensreceita.processo = comboBox_processo.Text;
                objitensreceita.produto = comboBox_produto.Text;
                objitensreceita.rele = Convert.ToInt32(textBox_rele.Text);
                objitensreceita.tipo_evento_anterior = comboBox_evento_anterior_tipo.Text;
                objitensreceita.tempo_espera_evento_anterior = Convert.ToInt32(textBox_tempo_espera_evento_anterior.Text);
                objitensreceita.entrada_evento_anterior = comboBox_tipo_entrada_evento_anterior.Text;
                if(radioButton_ON_evento_anterior.Checked)
                {
                    objitensreceita.status_entrada_digital_evento_anterior = true;
                }
                if (radioButton_OFF_evento_anterior.Checked)
                {
                    objitensreceita.status_entrada_digital_evento_anterior = false;
                }
                objitensreceita.temperatura_evento_anterior = Convert.ToInt32(textBox_limite_temperatura_evento_anterior.Text);
                objitensreceita.tipo_evento_posterior = comboBox_evento_posterior_tipo.Text;
                objitensreceita.pre_corte = Convert.ToInt32(textBox_precorte.Text);
                objitensreceita.corte = Convert.ToInt32(textBox_corte.Text);
                objitensreceita.limite_seguranca_evento_posterior = Convert.ToInt32(textBox_peso_limite.Text);
                objitensreceita.tempo_on = Convert.ToInt32(textBox_tempo_on.Text);
                objitensreceita.tempo_off = Convert.ToInt32(textBox_tempo_off.Text);
                objitensreceita.entrada_evento_posterior = comboBox_tipo_entrada_evento_posterior.Text;
                if (radioButton_ON_evento_posterior.Checked)
                {
                    objitensreceita.status_entrada_digital_evento_posterior = true;
                }
                if (radioButton_OFF_evento_posterior.Checked)
                {
                    objitensreceita.status_entrada_digital_evento_posterior = false;
                }
                objitensreceita.temperatura_evento_posterior = Convert.ToInt32(textBox_limite_temperatura_evento_posterior.Text);
                objitensreceita.seguranca_temperatura_evento_posterior = Convert.ToInt32(textBox_limite_temperatura_segurança.Text);
                objitensreceita.tempo_evento_posterior = Convert.ToInt32(textBox_tempo_evento_posterior.Text);
                objitensreceita.tempo_limite_evento_posterior = Convert.ToInt32(textBox_tempo_limite_evento_posterior.Text);
                objitensreceita.tempo_limite_total = Convert.ToInt32(textBox_tempo_limite_total.Text);
                if(checkBox_alerta.Checked)
                {
                    objitensreceita.alerta_emergencia = true;
                }
                else
                {
                    objitensreceita.alerta_emergencia = false;
                }
                if(checkBox_pausar.Checked)
                {
                    objitensreceita.pausar_receita = true;
                }
                else
                {
                    objitensreceita.pausar_receita = false;
                }
                if(checkBox_saida.Checked)
                {
                    objitensreceita.acionar_saida = true;
                    objitensreceita.saida_seguranca = comboBox_saida_emergencia.Text;
                }
                else
                {
                    objitensreceita.acionar_saida = true;
                    objitensreceita.saida_seguranca = "";
                }




                objitensreceita.objetivo = cboObjetivo.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                //item.comando_valor = Convert.ToInt32(cboValor.SelectedItem.ToString().Split('-').GetValue(0));
                objitensreceita.valor = txtValor.Text;
                objitensreceita.corte = txtValorCorte.Text;
                objitensreceita.acao = cboAcao.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                objitensreceita.parametro1 = cboParametro1.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                objitensreceita.parametro2 = cboParametro2.SelectedItem == null ? "" : cboParametro2.SelectedValue.ToString();
                objitensreceita.tipo_limite = cboTipoLimite.SelectedItem == null ? "" : cboTipoLimite.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                objitensreceita.valor_limite = txtValorLimite.Text;
                objitensreceita.dateinsert = objitensreceita.dateinsert;
                objitensreceita.dateupdate = objitensreceita.dateupdate;
                //considero as linhas do grid porque por padrao ele conta o cabeçalho... resumindo seria a nova linha
                objitensreceita.sequencia = 0;
                bllitensreceita.update(objitensreceita);
                carregaItensReceita(obj.id);
                //limpaCamposItensReceita();
                objitensreceita = null;
                //cboObjetivo.Focus();
            }
            else
            {
                ItensReceita item = new ItensReceita();
                item.id_receita = obj.id;
                item.objetivo = cboObjetivo.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                //item.comando_valor = Convert.ToInt32(cboValor.SelectedItem.ToString().Split('-').GetValue(0));
                item.valor = txtValor.Text;
                item.corte = txtValorCorte.Text;
                item.acao = cboAcao.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                item.parametro1 = cboParametro1.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                item.parametro2 = cboParametro2.SelectedValue == null ? "" : cboParametro2.SelectedValue.ToString();
                item.tipo_limite = cboTipoLimite.SelectedItem == null ? "" : cboTipoLimite.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                item.valor_limite = txtValorLimite.Text;
                item.dateinsert = DateTime.Now;
                //considero as linhas do grid porque por padrao ele conta o cabeçalho... resumindo seria a nova linha
                item.sequencia = 0;//bllitensreceita.getCustomReceita(obj.id) == null ? 1 : bllitensreceita.getCustomReceita(obj.id).Rows.Count + 1;
                bllitensreceita.insert(item);
                carregaItensReceita(obj.id);
                limpaCamposItensReceita();
                cboObjetivo.Focus();
            }
            gridItensReceita.Left = 6;
            gridItensReceita.Top = 64;
            gridItensReceita.Height = 204;
            enableButtonItensReceita(true, false, false, false);
            bllitensreceita.ordenaSequencia(obj.id);
            carregaItensReceita(obj.id);
            btnNovoItem.Focus();









            //verifica se tem item para a receita
            DataTable dt = bllitensreceita.getCustomReceita(Convert.ToInt32(txtCodigo.Text));
            if (dt == null)
            {
                MessageBox.Show("Adicione pelo menos um item na receita!");
                return;
            }
            if (obj == null)
            {
                obj = new Receita();
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                obj.nome = txtNome.Text;
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                MessageBox.Show("Receita cadastrada com sucesso!");
            }
            else
            {
                obj.id = Convert.ToInt32(txtCodigo.Text);
                obj.nome = txtNome.Text;
                obj.dateupdate = DateTime.Now;
                obj.dateinsert = this.obj.dateinsert;
                bll.update(obj);
                MessageBox.Show("Receita atualizada com sucesso!");
            }
            tabControl1.SelectedIndex = 0;
            atualiza("");
            carregaItensReceita(0);
            limpa();
            limpaCamposItensReceita();
        }
    }
}
