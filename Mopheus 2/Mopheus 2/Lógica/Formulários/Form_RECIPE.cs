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

namespace Mopheus_2
{
    public partial class Form_receita : Form
    {
        ReceitaBLL receitabll = new ReceitaBLL("Receita");
        Receita obj = new Receita();

        ItensReceita itensreceita = new ItensReceita();
        ItensReceitaBLL itensreceitabll = new ItensReceitaBLL("ItensReceita");

        ReleBLL relebll = new ReleBLL("Rele");
        Rele rele = new Rele();

        Network network = new Network();
        NetworkBLL networkbll = new NetworkBLL("Network");

        public Form_receita()
        {
            InitializeComponent();

            load_comboboxs();

            atualiza_receitas("");

            disable_all_itens();

            timeEdit_tempo_espera_evento_anterior.Enabled = false;
            comboBox_IO.Enabled = false;
            label20.Visible = false;
            textBox_setpoint.Visible = false;
            radioButton_OFF_evento_anterior.Visible = false;
            radioButton_ON_evento_anterior.Visible = false;

            label8.Visible = false;
            timeEdit_tempo_espera_evento_anterior.Visible = false;
            label18.Visible = false;
            comboBox_IO.Visible = false;
        }

        private void load_comboboxs()
        {
            comboBox_repeticao.Items.Add("Manual");
            comboBox_repeticao.Items.Add("Automático");
            comboBox_repeticao.SelectedIndex = 0;
            label_vezez.Visible = false;
            textBox_vezes.Visible = false;
            label_intervalo.Visible = false;
            timeEdit_intervalo.Visible = false;

            comboBox_processo.Items.Add("Enchimento");
            comboBox_processo.Items.Add("Escoamento");
            comboBox_processo.Items.Add("N/A");

            comboBox_evento_anterior_tipo.Items.Add("Tempo");
            comboBox_evento_anterior_tipo.Items.Add("Entrada");
            comboBox_evento_anterior_tipo.Items.Add("Imediato");

            comboBox_evento_posterior_tipo.Items.Add("Peso");
            comboBox_evento_posterior_tipo.Items.Add("Entrada");
            comboBox_evento_posterior_tipo.Items.Add("Tempo");
            //comboBox_evento_posterior_tipo.SelectedIndex = 0;

            List<Network> list = networkbll.getAllCustom();
            if (list != null)
            {
                foreach (Network item in list)
                {
                    if (item.model == "ControlMix")
                    {
                        comboBox_device.Items.Add(item.full_name);
                        //textBox_endereco.Text = item.addr.ToString();
                    }
                }
            }
        }

        private void comboBox_evento_posterior_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_evento_posterior_tipo.Text == "Peso")
            {
                groupBox_entrada.Visible = false;
                groupBox_peso.Visible = true;
                groupBox_tempo.Visible = false;

            }
            if (comboBox_evento_posterior_tipo.Text == "Entrada")
            {
                groupBox_entrada.Visible = true;
                groupBox_peso.Visible = false;
                groupBox_tempo.Visible = false;

                groupBox_entrada.Location = new Point(6, 46);
            }
            if (comboBox_evento_posterior_tipo.Text == "Tempo")
            {
                groupBox_entrada.Visible = false;
                groupBox_peso.Visible = false;
                groupBox_tempo.Visible = true;

                groupBox_tempo.Location = new Point(6, 46);
            }
        }

        private void comboBox_repeticao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_repeticao.Text == "Manual")
            {
                label_vezez.Visible = false;
                textBox_vezes.Visible = false;
                label_intervalo.Visible = false;
                timeEdit_intervalo.Visible = false;
            }
            else
            {
                label_vezez.Visible = true;
                textBox_vezes.Visible = true;
                label_intervalo.Visible = true;
                timeEdit_intervalo.Visible = true;
            }
        }

        private void comboBox_evento_anterior_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_evento_anterior_tipo.Text == "Tempo")
            {
                //tabControl_evento_anterior.SelectTab(0);
                timeEdit_tempo_espera_evento_anterior.Enabled = true;
                comboBox_IO.Enabled = false;

                label8.Visible = true;
                timeEdit_tempo_espera_evento_anterior.Visible = true;

                label18.Visible = false;
                comboBox_IO.Visible = false;

                radioButton_OFF_evento_anterior.Visible = false;
                radioButton_ON_evento_anterior.Visible = false;

            }
            if (comboBox_evento_anterior_tipo.Text == "Entrada")
            {
                //tabControl_evento_anterior.SelectTab(1);
                timeEdit_tempo_espera_evento_anterior.Enabled = false;
                comboBox_IO.Enabled = true;

                label8.Visible = false;
                label8.Location = new Point(6, 42);
                timeEdit_tempo_espera_evento_anterior.Visible = false;

                label18.Visible = true;
                label18.Location = new Point(6, 42);
                comboBox_IO.Visible = true;
                comboBox_IO.Location = new Point(9, 58);
                radioButton_OFF_evento_anterior.Location = new Point(9, 61);
                radioButton_ON_evento_anterior.Location = new Point(9, 61);

            }
            if (comboBox_evento_anterior_tipo.Text == "Imediato")
            {
                timeEdit_tempo_espera_evento_anterior.Enabled = false;
                comboBox_IO.Enabled = false;

                label8.Visible = false;
                timeEdit_tempo_espera_evento_anterior.Visible = false;

                label18.Visible = false;
                comboBox_IO.Visible = false;

                radioButton_OFF_evento_anterior.Visible = false;
                radioButton_ON_evento_anterior.Visible = false;
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
            try
            {
                var itemselecionado = dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(itemselecionado))
                {
                    MessageBox.Show("Selecione um item para deletar!");
                    return;
                }

                var confirmResult = MessageBox.Show("Você realmente deseja deletar este item?", "Confirmação de exclusão!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    itensreceitabll.delete(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                }

                //atualiza_receitas("");
                carregaItensReceita(Convert.ToInt32(textBox_id.Text));
            }
            catch (Exception ex)
            {
                //atualiza_receitas("");
                carregaItensReceita(Convert.ToInt32(textBox_id.Text));
            }
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
                    Receita obj = receitabll.get(Convert.ToInt32(dataGridView_receitas.Rows[dataGridView_receitas.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
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
            timeEdit_intervalo.Text = obj.intervalo;
            DataTable temp_itens_receita = itensreceitabll.getCustomItensReceita(obj.id);
            if(temp_itens_receita.Rows.Count>0)
            {
                textBox_linhas.Text = Convert.ToString(temp_itens_receita.Rows.Count);
            }
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
            dataGridView_receitas.DataSource = receitabll.getAll(filtro, "NOME");
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
            dataGridView_itens_receita.DataSource = itensreceitabll.getCustomItensReceita(id_receita);
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
            /*
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
            */

            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                #region Gravação da primeira linha de Receita

                obj.nome = textBox_nome_receita.Text;
                obj.dispositivo = comboBox_device.Text;
                obj.endereco = Convert.ToInt32(textBox_endereco.Text);
                obj.repeticao = comboBox_repeticao.Text;
                obj.intervalo = timeEdit_intervalo.Text;
                if (textBox_vezes.Text != "")
                {
                    obj.vezes = Convert.ToInt32(textBox_vezes.Text);
                }
                else
                {
                    obj.vezes = 1;
                }


                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                obj.dateinsert = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                #region Aba Principal

                itensreceita.id_receita = obj.id;
                itensreceita.etapa = textBox_etapa.Text;
                itensreceita.processo = comboBox_processo.Text;
                itensreceita.produto = comboBox_produto.Text;
                itensreceita.rele = (textBox_rele.Text);

                #endregion

                #region Aba Evento Anterior

                itensreceita.tipo_evento_anterior = comboBox_evento_anterior_tipo.Text;
                if (comboBox_evento_anterior_tipo.Text == "Tempo")
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    itensreceita.tempo_espera_evento_anterior = timeEdit_tempo_espera_evento_anterior.Text;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
                }
                else
                {
                    itensreceita.tempo_espera_evento_anterior = null;
                }

                if (comboBox_evento_anterior_tipo.Text == "Entrada")
                {
                    itensreceita.entrada_evento_anterior = comboBox_IO.Text;
                    if (comboBox_evento_anterior_tipo.Text == "Digital")
                    {
                        itensreceita.setpoint_evento_anterior = 0;

                        if (radioButton_ON_evento_anterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_anterior = 1;
                        }
                        if (radioButton_OFF_evento_anterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_anterior = 0;
                        }
                    }
                    else
                    {
                        itensreceita.setpoint_evento_anterior = Convert.ToInt32(textBox_setpoint.Text);
                        itensreceita.status_entrada_digital_evento_anterior = 0;
                    }
                }
                else
                {
                    itensreceita.entrada_evento_anterior = null;
                }

                if (comboBox_evento_anterior_tipo.Text == "Imediato")
                {
                    itensreceita.tempo_espera_evento_anterior = null;
                    itensreceita.entrada_evento_anterior = null;
                    itensreceita.setpoint_evento_anterior = 0;
                    itensreceita.status_entrada_digital_evento_anterior = 0;
                }

                #endregion

                #region Aba Evento Posterior

                itensreceita.tipo_evento_posterior = comboBox_evento_posterior_tipo.Text;

                if (comboBox_evento_posterior_tipo.Text == "Tempo")
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    itensreceita.tempo_evento_posterior = timeEdit_tempo_evento_posterior.Text;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
                }


                if (comboBox_evento_posterior_tipo.Text == "Peso")
                {
                    itensreceita.pre_corte = Convert.ToInt32(textBox_precorte.Text);
                    itensreceita.corte = Convert.ToInt32(textBox_corte.Text);
                    itensreceita.tempo_on = Convert.ToInt32(textBox_tempo_on.Text);
                    itensreceita.tempo_off = Convert.ToInt32(textBox_tempo_off.Text);
                    itensreceita.limite_peso_seguranca_evento_posterior = Convert.ToInt32(textBox_peso_limite.Text);
                }
                else
                {
                    itensreceita.pre_corte = 0;
                    itensreceita.corte = 0;
                    itensreceita.tempo_on = 0;
                    itensreceita.tempo_off = 0;
                    itensreceita.limite_peso_seguranca_evento_posterior = 0;
                }

                if (comboBox_evento_posterior_tipo.Text == "Entrada")
                {
                    itensreceita.entrada_evento_posterior = comboBox_IO_evento_posterior.Text;
                    if (comboBox_IO_evento_posterior.Text == "Entrada Digital")
                    {
                        itensreceita.setpoint_evento_posterior = 0;
                        itensreceita.setpoint_limite_evento_posterior = 0;
                        if (radioButton_ON_evento_posterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_posterior = 1;
                        }
                        if (radioButton_OFF_evento_posterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_posterior = 0;
                        }
                    }
                    else
                    {
                        itensreceita.status_entrada_digital_evento_posterior = 0;
                        itensreceita.setpoint_evento_posterior = Convert.ToInt32(textBox_setpoint_evento_posterior.Text);
                        itensreceita.setpoint_limite_evento_posterior = Convert.ToInt32(textBox_setpoint_limite_evento_posterior.Text);
                    }


                }

                #endregion

                #region Aba Segurança

                itensreceita.tempo_limite_total = timeEdit_tempo_limite_total.Text;

                if (checkBox_alerta.Checked)
                {
                    itensreceita.alerta_emergencia = 1;
                }
                else
                {
                    itensreceita.alerta_emergencia = 0;
                }

                if (checkBox_pausar.Checked)
                {
                    itensreceita.pausar_receita = 1;
                }
                else
                {
                    itensreceita.pausar_receita = 0;
                }

                if (checkBox_saida.Checked)
                {
                    itensreceita.acionar_saida = 1;
                    itensreceita.saida_seguranca = comboBox_saida_emergencia.Text;
                }
                else
                {
                    itensreceita.acionar_saida = 1;
                    itensreceita.saida_seguranca = "";
                }

                #endregion

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                itensreceita.dateinsert = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                itensreceita.sequencia = 0;

                #region Gravação em Banco de Dados


                receitabll.insert(obj);
                obj = receitabll.getCustomUltimo();
                itensreceita.id_receita = obj.id;
                itensreceitabll.insert(itensreceita);


                #endregion

                textBox_id.Text = obj.id.ToString();
                itensreceitabll.ordenaSequencia(obj.id);
                carregaItensReceita(obj.id);
                clean_itens_receita();
                tabControl1.SelectedIndex = 1;
                tabControl2.SelectedIndex = 0;

                #endregion
            }
            else
            {
                #region Gravação das demais linhas de Receita

                obj = receitabll.get(Convert.ToInt32(textBox_id.Text));

                obj.nome = textBox_nome_receita.Text;
                obj.dispositivo = comboBox_device.Text;
                obj.endereco = Convert.ToInt32(textBox_endereco.Text);
                obj.repeticao = comboBox_repeticao.Text;
                obj.intervalo = timeEdit_intervalo.Text;
                if (textBox_vezes.Text != "")
                {
                    obj.vezes = Convert.ToInt32(textBox_vezes.Text);
                }
                else
                {
                    obj.vezes = 1;
                }


                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                obj.dateupdate = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

                #region Aba Principal

                itensreceita.id_receita = obj.id;
                itensreceita.etapa = textBox_etapa.Text;
                itensreceita.processo = comboBox_processo.Text;
                itensreceita.produto = comboBox_produto.Text;
                itensreceita.rele = (textBox_rele.Text);

                #endregion

                #region Aba Evento Anterior

                itensreceita.tipo_evento_anterior = comboBox_evento_anterior_tipo.Text;
                if (comboBox_evento_anterior_tipo.Text == "Tempo")
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    itensreceita.tempo_espera_evento_anterior = timeEdit_tempo_espera_evento_anterior.Text;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
                }
                else
                {
                    itensreceita.tempo_espera_evento_anterior = null;
                }

                if (comboBox_evento_anterior_tipo.Text == "Entrada")
                {
                    itensreceita.entrada_evento_anterior = comboBox_IO.Text;
                    if (comboBox_evento_anterior_tipo.Text == "Digital")
                    {
                        itensreceita.setpoint_evento_anterior = 0;

                        if (radioButton_ON_evento_anterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_anterior = 1;
                        }
                        if (radioButton_OFF_evento_anterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_anterior = 0;
                        }
                    }
                    else
                    {
                        itensreceita.setpoint_evento_anterior = Convert.ToInt32(textBox_setpoint.Text);
                        itensreceita.status_entrada_digital_evento_anterior = 0;
                    }
                }
                else
                {
                    itensreceita.entrada_evento_anterior = null;
                }

                if (comboBox_evento_anterior_tipo.Text == "Imediato")
                {
                    itensreceita.tempo_espera_evento_anterior = null;
                    itensreceita.entrada_evento_anterior = null;
                    itensreceita.setpoint_evento_anterior = 0;
                    itensreceita.status_entrada_digital_evento_anterior = 0;
                }

                #endregion

                #region Aba Evento Posterior

                itensreceita.tipo_evento_posterior = comboBox_evento_posterior_tipo.Text;

                if (comboBox_evento_posterior_tipo.Text == "Tempo")
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    itensreceita.tempo_evento_posterior = timeEdit_tempo_evento_posterior.Text;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
                }


                if (comboBox_evento_posterior_tipo.Text == "Peso")
                {
                    itensreceita.pre_corte = Convert.ToInt32(textBox_precorte.Text);
                    itensreceita.corte = Convert.ToInt32(textBox_corte.Text);
                    itensreceita.tempo_on = Convert.ToInt32(textBox_tempo_on.Text);
                    itensreceita.tempo_off = Convert.ToInt32(textBox_tempo_off.Text);
                    itensreceita.limite_peso_seguranca_evento_posterior = Convert.ToInt32(textBox_peso_limite.Text);
                }
                else
                {
                    itensreceita.pre_corte = 0;
                    itensreceita.corte = 0;
                    itensreceita.tempo_on = 0;
                    itensreceita.tempo_off = 0;
                    itensreceita.limite_peso_seguranca_evento_posterior = 0;
                }

                if (comboBox_evento_posterior_tipo.Text == "Entrada")
                {
                    itensreceita.entrada_evento_posterior = comboBox_IO_evento_posterior.Text;
                    if (comboBox_IO_evento_posterior.Text == "Entrada Digital")
                    {
                        itensreceita.setpoint_evento_posterior = 0;
                        itensreceita.setpoint_limite_evento_posterior = 0;
                        if (radioButton_ON_evento_posterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_posterior = 1;
                        }
                        if (radioButton_OFF_evento_posterior.Checked)
                        {
                            itensreceita.status_entrada_digital_evento_posterior = 0;
                        }
                    }
                    else
                    {
                        itensreceita.status_entrada_digital_evento_posterior = 0;
                        itensreceita.setpoint_evento_posterior = Convert.ToInt32(textBox_setpoint_evento_posterior.Text);
                        itensreceita.setpoint_limite_evento_posterior = Convert.ToInt32(textBox_setpoint_limite_evento_posterior.Text);
                    }


                }

                #endregion

                #region Aba Segurança

                itensreceita.tempo_limite_total = timeEdit_tempo_limite_total.Text;

                if (checkBox_alerta.Checked)
                {
                    itensreceita.alerta_emergencia = 1;
                }
                else
                {
                    itensreceita.alerta_emergencia = 0;
                }

                if (checkBox_pausar.Checked)
                {
                    itensreceita.pausar_receita = 1;
                }
                else
                {
                    itensreceita.pausar_receita = 0;
                }

                if (checkBox_saida.Checked)
                {
                    itensreceita.acionar_saida = 1;
                    itensreceita.saida_seguranca = comboBox_saida_emergencia.Text;
                }
                else
                {
                    itensreceita.acionar_saida = 1;
                    itensreceita.saida_seguranca = "";
                }

                #endregion

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                itensreceita.dateupdate = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);


                ItensReceita temp_itens_receita = itensreceitabll.getCustomUltimo();
                itensreceita.sequencia = temp_itens_receita.sequencia + 1;

                #region Atualização do Banco de Dados

                receitabll.update(obj);

                obj = receitabll.getCustomUltimo();
                itensreceita.id_receita = obj.id;

                itensreceitabll.insert(itensreceita);

                #endregion

                textBox_id.Text = obj.id.ToString();
                itensreceitabll.ordenaSequencia(obj.id);
                carregaItensReceita(obj.id);
                clean_itens_receita();
                tabControl1.SelectedIndex = 1;
                tabControl2.SelectedIndex = 0;

                #endregion
            }
        }

        private void clean_itens_receita()
        {
            #region limpeza dos dados da receita
            //textBox_id.Text = "";
            //textBox_nome_receita.Text = "";
            //comboBox_device.Text = "";
            //textBox_endereco.Text = "";
            //textBox_linhas.Text = "";
            //comboBox_repeticao.Text = "";
            //textBox_vezes.Text = "";
            //timeEdit_intervalo.Text = "00:00:00";
            #endregion

            #region limpeza dos itens da receita
            textBox_etapa.Text = "";
            comboBox_processo.Text = "";
            comboBox_produto.Text = "";
            comboBox_produto.Text = "";
            textBox_rele.Clear();
            comboBox_evento_anterior_tipo.Text = "";
            timeEdit_tempo_espera_evento_anterior.Text = "00:00:00";
            //comboBox_tipo_entrada_evento_anterior.Text = "";
            //textBox_limite_temperatura_evento_anterior.Text = "";
            comboBox_evento_posterior_tipo.Text = "";
            textBox_precorte.Text = "";
            textBox_corte.Text = "";
            textBox_peso_limite.Text = "";
            textBox_tempo_on.Text = "";
            textBox_tempo_off.Text = "";
            comboBox_evento_posterior_tipo.Text = "";
            textBox_setpoint_evento_posterior.Text = "";
            textBox_setpoint_limite_evento_posterior.Text = "";
            timeEdit_tempo_evento_posterior.Text = "00:00:00";
            //timeEdit_tempo_limite_evento_posterior.Text = "00:00:00";
            timeEdit_tempo_limite_total.Text = "00:00:00";
            checkBox_alerta.Checked = false;
            checkBox_pausar.Checked = false;
            checkBox_saida.Checked = false;
            comboBox_saida_emergencia.Text = "";
            comboBox_saida_emergencia.Enabled = false;
            #endregion
        }

        public void atualiza_itens_receita(string filtro)
        {
            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView_itens_receita.CurrentRow != null)
            {
                primeiraLinha = dataGridView_itens_receita.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView_itens_receita.CurrentRow.Index;
            }
            dataGridView_itens_receita.DataSource = itensreceitabll.getAll(filtro, "sequencia");
            dataGridView_itens_receita.Refresh();
            dataGridView_itens_receita.ClearSelection();
        }

        private void descenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value != null)
                {
                    int sequencia = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value.ToString());
                    if (sequencia != 1)
                    {
                        itensreceitabll.updateCustomMoveAcimaSequencia(sequencia, Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value.ToString()));

                        carregaItensReceita(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value.ToString()));
                        dataGridView_itens_receita.ClearSelection();

                        //dataGridView_itens_receita.CurrentCell = dataGridView_itens_receita.Rows[(sequencia - 2)].Cells[0];
                        //dataGridView_itens_receita.Rows[(sequencia - 2)].Selected = true;
                        //clean_itens_receita();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBox_device_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_produto.Items.Clear();
            comboBox_IO.Items.Clear();

            List<Rele> list = relebll.getCustomListRele();
            DataTable dt;



            List<Network> listnet = networkbll.getAllCustom();
            foreach (Network item in listnet)
            {
                if (comboBox_device.Text == item.full_name)
                {
                    textBox_endereco.Text = item.addr.ToString();
                }
            }

            if (list != null)
            {
                foreach (Rele item in list)
                {
                    if (item.device == comboBox_device.Text || item.parent == "TreeNode: " + comboBox_device.Text)
                    {
                        comboBox_produto.Items.Add(item.descricao);
                        switch (item.tipo)
                        {
                            case "Entrada Digital":

                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = true;
                                radioButton_ON_evento_anterior.Visible = true;
                                break;
                            case "Entrada Analógica":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "AI-Tensão":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "AI-Corrente":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-K":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-J":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-T":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-N":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-S":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-E":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-B":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-R":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                radioButton_OFF_evento_anterior.Visible = false;
                                radioButton_ON_evento_anterior.Visible = false;
                                textBox_setpoint.Visible = true;
                                break;
                            case "Saída a Relé":
                                comboBox_saida_emergencia.Items.Add(item.IO + "-" + item.descricao);
                                break;
                            default:
                                break;
                        }


                    }
                }
            }

        }

        private void enviarReceitaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_IO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Rele> list = relebll.getCustomListRele();

            foreach (Rele item in list)
            {
                if (comboBox_produto.Text == item.descricao)
                {
                    textBox_rele.Text = item.IO.ToString();
                }
            }
        }

        private void ascenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value.ToString());
            try
            {
                if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value != null)
                {
                    int sequencia = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value.ToString());
                    if (sequencia != 1)
                    {
                        itensreceitabll.updateCustomMoveAbaixoSequencia(sequencia, Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[27].Value.ToString()));

                        carregaItensReceita(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value.ToString()));
                        dataGridView_itens_receita.ClearSelection();

                        //dataGridView_itens_receita.CurrentCell = dataGridView_itens_receita.Rows[(sequencia - 2)].Cells[0];
                        //dataGridView_itens_receita.Rows[(sequencia - 2)].Selected = true;
                        //clean_itens_receita();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void editarEtapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Você deseja editar esse item?", "Edição", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[9].Value != null)
                    {
                        ItensReceita obj = itensreceitabll.get(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[9].Value.ToString()));
                        mostrar_ItensReceita(obj);
                        //cboObjetivo.Enabled = true;
                        //enableButtonItensReceita(false, true, true, true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void mostrar_ItensReceita(ItensReceita obj)
        {

        }

        private void textBox_setpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void novaEtapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;

            textBox_etapa.Focus();
        }
    }
}
