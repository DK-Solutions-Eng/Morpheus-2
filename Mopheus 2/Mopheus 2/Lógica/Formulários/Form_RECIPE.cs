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
        Receita obj;
        ItensReceita objitensreceita;
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
                radioButton_OFF_evento_anterior.Location= new Point(9, 61);
                radioButton_ON_evento_anterior.Location = new Point(9, 61);

            }
            if(comboBox_evento_anterior_tipo.Text == "Imediato")
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
                    receitabll.delete(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                }

                atualiza_receitas("");
            }
            catch (Exception ex)
            {
                atualiza_receitas("");
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
            dataGridView_itens_receita.DataSource = itensreceitabll.getCustomReceita(id_receita);
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

            obj = new Receita();
            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                obj.nome = textBox_nome_receita.Text;
                obj.dateinsert = DateTime.Now;
                receitabll.insert(obj);
                obj = receitabll.getCustomUltimo();
                textBox_id.Text = obj.id.ToString();
            }
            else
            {
                obj = receitabll.get(Convert.ToInt32(textBox_id.Text));
            }

            if (objitensreceita != null)
            {
                objitensreceita.id_receita = objitensreceita.id_receita;
                objitensreceita.etapa = textBox_etapa.Text;
                objitensreceita.processo = comboBox_processo.Text;
                objitensreceita.produto = comboBox_produto.Text;
                objitensreceita.rele = Convert.ToInt32(textBox_rele.Text);
                objitensreceita.tipo_evento_anterior = comboBox_evento_anterior_tipo.Text;
                objitensreceita.tempo_espera_evento_anterior = timeEdit_tempo_espera_evento_anterior.Text;
                //objitensreceita.entrada_evento_anterior = comboBox_tipo_entrada_evento_anterior.Text;
                //if (radioButton_ON_evento_anterior.Checked)
                //{
                //    objitensreceita.status_entrada_digital_evento_anterior = true;
                //}
                //if (radioButton_OFF_evento_anterior.Checked)
                //{
                //    objitensreceita.status_entrada_digital_evento_anterior = false;
                //}
                //objitensreceita.temperatura_evento_anterior = Convert.ToInt32(textBox_limite_temperatura_evento_anterior.Text);
                objitensreceita.tipo_evento_posterior = comboBox_evento_posterior_tipo.Text;
                objitensreceita.pre_corte = Convert.ToInt32(textBox_precorte.Text);
                objitensreceita.corte = Convert.ToInt32(textBox_corte.Text);
                objitensreceita.limite_peso_seguranca_evento_posterior = Convert.ToInt32(textBox_peso_limite.Text);
                objitensreceita.tempo_on = Convert.ToInt32(textBox_tempo_on.Text);
                objitensreceita.tempo_off = Convert.ToInt32(textBox_tempo_off.Text);
                objitensreceita.entrada_evento_posterior = comboBox_IO_evento_posterior.Text;
                if (radioButton_ON_evento_posterior.Checked)
                {
                    objitensreceita.status_entrada_digital_evento_posterior = true;
                }
                if (radioButton_OFF_evento_posterior.Checked)
                {
                    objitensreceita.status_entrada_digital_evento_posterior = false;
                }
                objitensreceita.setpoint_evento_posterior = Convert.ToInt32(textBox_setpoint_evento_posterior.Text);
                objitensreceita.setpoint_limite_evento_posterior = Convert.ToInt32(textBox_setpoint_limite_evento_posterior.Text);
                objitensreceita.tempo_evento_posterior = timeEdit_tempo_evento_posterior.Text;
                //objitensreceita.tempo_seguranca_evento_posterior = timeEdit_tempo_limite_evento_posterior.Text;
                objitensreceita.tempo_limite_total = timeEdit_tempo_limite_total.Text;
                if (checkBox_alerta.Checked)
                {
                    objitensreceita.alerta_emergencia = true;
                }
                else
                {
                    objitensreceita.alerta_emergencia = false;
                }
                if (checkBox_pausar.Checked)
                {
                    objitensreceita.pausar_receita = true;
                }
                else
                {
                    objitensreceita.pausar_receita = false;
                }
                if (checkBox_saida.Checked)
                {
                    objitensreceita.acionar_saida = true;
                    objitensreceita.saida_seguranca = comboBox_saida_emergencia.Text;
                }
                else
                {
                    objitensreceita.acionar_saida = true;
                    objitensreceita.saida_seguranca = "";
                }
                objitensreceita.dateinsert = objitensreceita.dateinsert;
                objitensreceita.dateupdate = objitensreceita.dateupdate;

                //considero as linhas do grid porque por padrao ele conta o cabeçalho... resumindo seria a nova linha
                objitensreceita.sequencia = 0;
                itensreceitabll.update(objitensreceita);
                carregaItensReceita(obj.id);
                clean_itens_receita();
                objitensreceita = null;
                tabControl2.SelectedIndex = 0;
                textBox_etapa.Focus();
            }
            else
            {
                ItensReceita item = new ItensReceita();
                item.id_receita = obj.id;
                item.etapa = textBox_etapa.Text;
                item.processo = comboBox_processo.Text;
                item.produto = comboBox_produto.Text;
                item.rele = Convert.ToInt32(textBox_rele.Text);
                item.tipo_evento_anterior = comboBox_evento_anterior_tipo.Text;
                item.tempo_espera_evento_anterior = timeEdit_tempo_espera_evento_anterior.Text;
                //item.entrada_evento_anterior = comboBox_tipo_entrada_evento_anterior.Text;
                //if (radioButton_ON_evento_anterior.Checked)
                //{
                //    item.status_entrada_digital_evento_anterior = true;
                //}
                //if (radioButton_OFF_evento_anterior.Checked)
                //{
                //    item.status_entrada_digital_evento_anterior = false;
                //}
                //item.temperatura_evento_anterior = Convert.ToInt32(textBox_limite_temperatura_evento_anterior.Text);
                item.tipo_evento_posterior = comboBox_evento_posterior_tipo.Text;
                item.pre_corte = Convert.ToInt32(textBox_precorte.Text);
                item.corte = Convert.ToInt32(textBox_corte.Text);
                item.tempo_on = Convert.ToInt32(textBox_tempo_on.Text);
                item.tempo_off = Convert.ToInt32(textBox_tempo_off.Text);
                item.limite_peso_seguranca_evento_posterior = Convert.ToInt32(textBox_peso_limite.Text);
                item.entrada_evento_posterior = comboBox_IO_evento_posterior.Text;
                if (radioButton_ON_evento_posterior.Checked)
                {
                    item.status_entrada_digital_evento_posterior = true;
                }
                if (radioButton_OFF_evento_posterior.Checked)
                {
                    item.status_entrada_digital_evento_posterior = false;
                }
                item.setpoint_evento_posterior = Convert.ToInt32(textBox_setpoint_evento_posterior.Text);
                item.setpoint_limite_evento_posterior = Convert.ToInt32(textBox_setpoint_limite_evento_posterior.Text);
                item.tempo_evento_posterior = timeEdit_tempo_evento_posterior.Text;
                //item.tempo_seguranca_evento_posterior = timeEdit_tempo_limite_evento_posterior.Text;
                item.tempo_limite_total = timeEdit_tempo_limite_total.Text;
                if (checkBox_alerta.Checked)
                {
                    item.alerta_emergencia = true;
                }
                else
                {
                    item.alerta_emergencia = false;
                }
                if (checkBox_pausar.Checked)
                {
                    item.pausar_receita = true;
                }
                else
                {
                    item.pausar_receita = false;
                }
                if (checkBox_saida.Checked)
                {
                    item.acionar_saida = true;
                    item.saida_seguranca = comboBox_saida_emergencia.Text;
                }
                else
                {
                    item.acionar_saida = true;
                    item.saida_seguranca = "";
                }
                item.dateinsert = DateTime.Now;

                //considero as linhas do grid porque por padrao ele conta o cabeçalho... resumindo seria a nova linha
                item.sequencia = 0;
                //bllitensreceita.getCustomReceita(obj.id) == null ? 1 : bllitensreceita.getCustomReceita(obj.id).Rows.Count + 1;
                itensreceitabll.insert(item);
                carregaItensReceita(obj.id);
                clean_itens_receita();
                tabControl2.SelectedIndex = 0;
                textBox_etapa.Focus();
            }

            itensreceitabll.ordenaSequencia(obj.id);
            carregaItensReceita(obj.id);

            //verifica se tem item para a receita
            DataTable dt = itensreceitabll.getCustomReceita(Convert.ToInt32(textBox_id.Text));
            if (dt == null)
            {
                MessageBox.Show("Adicione pelo menos um item na receita!");
                return;
            }
            if (obj == null)
            {
                obj = new Receita();
            }
            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                obj.nome = textBox_nome_receita.Text;
                obj.dateinsert = DateTime.Now;
                receitabll.insert(obj);
                MessageBox.Show("Receita salva com sucesso!");
            }
            else
            {
                obj.id = Convert.ToInt32(textBox_id.Text);
                obj.nome = textBox_nome_receita.Text;
                obj.dateupdate = DateTime.Now;
                obj.dateinsert = this.obj.dateinsert;
                receitabll.update(obj);
                MessageBox.Show("Receita atualizada com sucesso!");
            }
            tabControl1.SelectedIndex = 0;
            atualiza_itens_receita("");
            carregaItensReceita(0);
            clean_itens_receita();
        }

        private void clean_itens_receita()
        {
            #region limpeza dos dados da receita
            textBox_id.Text = "";
            textBox_nome_receita.Text = "";
            comboBox_device.Text = "";
            textBox_endereco.Text = "";
            textBox_linhas.Text = "";
            comboBox_repeticao.Text = "";
            textBox_vezes.Text = "";
            timeEdit_intervalo.Text = "00:00:00";
            #endregion

            #region limpeza dos itens da receita
            textBox_etapa.Text = "";
            comboBox_processo.Text = "";
            comboBox_produto.Text = "";
            comboBox_produto.Text = "";
            comboBox_evento_anterior_tipo.Text = "";
            timeEdit_tempo_espera_evento_anterior.Text = "00:00:00";
            //comboBox_tipo_entrada_evento_anterior.Text = "";
            //textBox_limite_temperatura_evento_anterior.Text = "";
            comboBox_evento_posterior_tipo.Text="";
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
            dataGridView_itens_receita.DataSource = receitabll.getAll(filtro, "NOME");
            dataGridView_itens_receita.Refresh();
            dataGridView_itens_receita.ClearSelection();
        }

        private void descenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[9].Value != null)
                {
                    int sequencia = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (sequencia != 1)
                    {
                        itensreceitabll.updateCustomMoveAbaixoSequencia(sequencia, Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[29].Value.ToString()));
                        carregaItensReceita(obj.id);
                        dataGridView_itens_receita.ClearSelection();
                        dataGridView_itens_receita.CurrentCell = dataGridView_itens_receita.Rows[(sequencia - 2)].Cells[0];
                        dataGridView_itens_receita.Rows[(sequencia - 2)].Selected = true;
                        clean_itens_receita();
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
                if(comboBox_device.Text==item.full_name)
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
                                
                                comboBox_IO.Items.Add(item.IO + "-"+ item.descricao);
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
            try
            {
                if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[9].Value != null)
                {
                    int sequencia = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (sequencia != 1)
                    {
                        itensreceitabll.updateCustomMoveAbaixoSequencia(sequencia, Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[9].Value.ToString()));
                        carregaItensReceita(obj.id);
                        dataGridView_itens_receita.ClearSelection();
                        dataGridView_itens_receita.CurrentCell = dataGridView_itens_receita.Rows[(sequencia - 2)].Cells[0];
                        dataGridView_itens_receita.Rows[(sequencia - 2)].Selected = true;
                        clean_itens_receita();
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
                var confirmResult = MessageBox.Show("Você deseja editar esse item?","Edição",MessageBoxButtons.YesNo);
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
    }
}
