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

            comboBox_estado_saida.Items.Add("OFF");
            comboBox_estado_saida.Items.Add("ON");

            comboBox_evento_anterior_tipo.Items.Add("Tempo");
            comboBox_evento_anterior_tipo.Items.Add("Entrada");
            comboBox_evento_anterior_tipo.Items.Add("Imediato");

            comboBox_evento_posterior_tipo.Items.Add("Peso");
            comboBox_evento_posterior_tipo.Items.Add("Entrada");
            comboBox_evento_posterior_tipo.Items.Add("Tempo");
            comboBox_evento_posterior_tipo.Items.Add("Imediato");
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
                if (comboBox_indicador.Items.Count > 0)
                {
                    groupBox_entrada.Visible = false;
                    groupBox_peso.Visible = true;
                    groupBox_tempo.Visible = false;
                }
                else
                {
                    MessageBox.Show("Não existe indicador cadastrado. Adicione ao menos um indicador na rede.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox_evento_posterior_tipo.SelectedIndex = -1;
                    return;
                }

            }
            if (comboBox_evento_posterior_tipo.Text == "Entrada")
            {
                if (comboBox_IO_evento_posterior.Items.Count > 0)
                {
                    groupBox_entrada.Visible = true;
                    groupBox_peso.Visible = false;
                    groupBox_tempo.Visible = false;

                    groupBox_entrada.Location = new Point(6, 46);
                }
                else
                {
                    MessageBox.Show("Não existe entrada cadastrada. Adicione ao menos uma entrada na configuração de I/O.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox_evento_posterior_tipo.SelectedIndex = -1;
                    return;
                }
            }
            if (comboBox_evento_posterior_tipo.Text == "Tempo")
            {
                groupBox_entrada.Visible = false;
                groupBox_peso.Visible = false;
                groupBox_tempo.Visible = true;

                groupBox_tempo.Location = new Point(6, 46);
            }
            if (comboBox_evento_posterior_tipo.Text == "Imediato")
            {
                groupBox_entrada.Visible = false;
                groupBox_peso.Visible = false;
                groupBox_tempo.Visible = false;
            }
        }

        private void comboBox_repeticao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_repeticao.Text == "Automático")
            {
                label_vezez.Visible = true;
                textBox_vezes.Visible = true;
                label_intervalo.Visible = true;
                timeEdit_intervalo.Visible = true;
            }
            else
            {
                label_vezez.Visible = false;
                textBox_vezes.Visible = false;
                label_intervalo.Visible = false;
                timeEdit_intervalo.Visible = false;
            }
        }

        private void comboBox_evento_anterior_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_evento_anterior_tipo.Text == "Tempo")
            {
                label8.Visible = true;
                timeEdit_tempo_espera_evento_anterior.Visible = true;

                label18.Visible = false;
                comboBox_IO_evento_anterior.Visible = false;
                radioButton_OFF_evento_anterior.Visible = false;
                radioButton_ON_evento_anterior.Visible = false;

                label20.Visible = false;
                textBox_setpoint_evento_anterior.Visible = false;

            }
            if (comboBox_evento_anterior_tipo.Text == "Entrada")
            {
                if (comboBox_IO_evento_posterior.Items.Count > 0)
                {
                    label8.Visible = false;
                    label8.Location = new Point(6, 42);
                    timeEdit_tempo_espera_evento_anterior.Visible = false;

                    label18.Visible = true;
                    label18.Location = new Point(6, 42);
                    comboBox_IO_evento_anterior.Visible = true;
                    comboBox_IO_evento_anterior.Location = new Point(9, 58);
                    radioButton_OFF_evento_anterior.Visible = true;
                    radioButton_ON_evento_anterior.Visible = true;
                    radioButton_OFF_evento_anterior.Location = new Point(215, 61);
                    radioButton_ON_evento_anterior.Location = new Point(266, 61);

                    //label20.Visible = false;
                    //textBox_setpoint_evento_anterior.Visible = false;
                }
                else
                {
                    MessageBox.Show("Não existe entrada cadastrada. Adicione ao menos uma entrada na configuração de I/O.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox_evento_anterior_tipo.SelectedIndex = -1;
                    return;
                }

            }
            if (comboBox_evento_anterior_tipo.Text == "Imediato")
            {
                label8.Visible = false;
                timeEdit_tempo_espera_evento_anterior.Visible = false;

                label18.Visible = false;
                comboBox_IO_evento_anterior.Visible = false;
                radioButton_OFF_evento_anterior.Visible = false;
                radioButton_ON_evento_anterior.Visible = false;

                label20.Visible = false;
                textBox_setpoint_evento_anterior.Visible = false;
            }
        }

        private void statusDosDispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função em desenvolvimento, aguarde!", "Atenção!");

            //Form_Device_Status form_device_status;
            //form_device_status = new Form_Device_Status();
            //form_device_status.ShowDialog();
        }

        private void checkBox_saida_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_saida.Checked)
            {
                if (comboBox_saida_emergencia.Items.Count > 0)
                {
                    comboBox_saida_emergencia.Visible = true;
                }
                else
                {
                    MessageBox.Show("Não existe sáida cadastrada. Adicione ao menos uma saída na configuração de I/O.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBox_saida.Checked = false;
                    return;
                }
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

                var confirmResult = MessageBox.Show("Você realmente deseja deletar este item?", "Confirmação de exclusão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show("Erro ao abrir receita!" + "\r\n" + ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (temp_itens_receita.Rows.Count > 0)
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

            textBox_velocidade_hz.Visible = false;
            label21.Visible = false;

            timeEdit_tempo_espera_evento_anterior.Visible = false;
            comboBox_IO_evento_anterior.Visible = false;
            label20.Visible = false;
            textBox_setpoint_evento_anterior.Visible = false;
            radioButton_OFF_evento_anterior.Visible = false;
            radioButton_ON_evento_anterior.Visible = false;

            label8.Visible = false;
            timeEdit_tempo_espera_evento_anterior.Visible = false;
            label18.Visible = false;
            comboBox_IO_evento_anterior.Visible = false;

            radioButton_OFF_evento_posterior.Visible = false;
            radioButton_ON_evento_posterior.Visible = false;
            label30.Visible = false;
            label34.Visible = false;
            textBox_setpoint_evento_posterior.Visible = false;
            textBox_setpoint_limite_evento_posterior.Visible = false;

            textBox_peso_total.Enabled = false;
            textBox_incremento.Enabled = false;


            checkBox_velocidade.Checked = false;
            textBox_velocidade_hz.Visible = false;
            label21.Visible = false;
            label26.Visible = false;
            label23.Visible = false;
            comboBox_inversor.Visible = false;
            comboBox_inversor.Items.Clear();
            label22.Visible = false;
            textBox_addr_inversor.Visible = false;
        }

        private void novaReceitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            //textBox_nome_receita.Enabled = true;
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
            add_item();

            clean_itens_receita();
            clean_receita();
            tabControl1.SelectedIndex = 0;
            tabControl2.SelectedIndex = 0;
            atualiza_receitas("");
        }

        private void clean_itens_receita()
        {
            #region limpeza dos itens da receita

            textBox_etapa.Clear();
            comboBox_processo.SelectedIndex = -1;
            comboBox_produto.SelectedIndex = -1;
            comboBox_produto.SelectedIndex = -1;
            textBox_rele.Clear();
            comboBox_estado_saida.SelectedIndex = -1;
            checkBox_velocidade.Checked = false;
            textBox_velocidade_hz.Clear();
            comboBox_evento_anterior_tipo.SelectedIndex = -1;
            timeEdit_tempo_espera_evento_anterior.Text = "00:00:00";
            comboBox_evento_posterior_tipo.SelectedIndex = -1;
            textBox_precorte.Clear();
            textBox_corte.Clear();
            textBox_peso_limite.Clear();
            textBox_tempo_on.Clear();
            textBox_tempo_off.Clear();
            textBox_peso_total.Clear();
            textBox_incremento.Clear();
            textBox_passos.Clear();
            checkBox_dosagem_incremental.Checked = false;
            comboBox_indicador.SelectedIndex = -1;
            comboBox_evento_posterior_tipo.SelectedIndex = -1;
            groupBox_peso.Visible = false;
            groupBox_entrada.Visible = false;
            groupBox_tempo.Visible = false;
            textBox_setpoint_evento_posterior.Clear();
            textBox_setpoint_limite_evento_posterior.Clear();
            timeEdit_tempo_evento_posterior.Text = "00:00:00";
            timeEdit_tempo_limite_total.Text = "00:00:00";
            checkBox_alerta.Checked = false;
            checkBox_pausar.Checked = false;
            checkBox_saida.Checked = false;
            comboBox_saida_emergencia.SelectedIndex = -1;
            comboBox_saida_emergencia.Visible = false;

            label8.Visible = false;
            timeEdit_tempo_espera_evento_anterior.Visible = false;

            label18.Visible = false;
            comboBox_IO_evento_anterior.Visible = false;
            radioButton_OFF_evento_anterior.Visible = false;
            radioButton_ON_evento_anterior.Visible = false;

            label20.Visible = false;
            textBox_setpoint_evento_anterior.Visible = false;

            #endregion
        }

        private void clean_receita()
        {
            #region limpeza dos dados da receita
            textBox_id.Clear();
            textBox_nome_receita.Clear();
            comboBox_device.SelectedIndex = -1;
            textBox_endereco.Clear();
            textBox_linhas.Clear();
            comboBox_repeticao.SelectedIndex = -1;
            textBox_vezes.Clear();
            timeEdit_intervalo.Text = "00:00:00";
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
                if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value != null)
                {
                    int sequencia = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                    if (sequencia != 1 | sequencia == 1)
                    {
                        itensreceitabll.updateCustomMoveAcimaSequencia(sequencia, Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));

                        carregaItensReceita(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[2].Value.ToString()));
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
            comboBox_IO_evento_anterior.Items.Clear();
            comboBox_indicador.Items.Clear();

            List<Rele> list = relebll.getCustomListRele();

            List<Network> listnet = networkbll.getAllCustom();
            foreach (Network item in listnet)
            {
                if (comboBox_device.Text == item.full_name)
                {
                    textBox_endereco.Text = item.addr.ToString();
                }
                if (item.parent == "TreeNode: " + comboBox_device.Text)
                {
                    comboBox_indicador.Items.Add(item.full_name);
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
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = true;
                                //radioButton_ON_evento_anterior.Visible = true;
                                break;
                            case "Entrada Analógica":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "AI-Tensão":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "AI-Corrente":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-K":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-J":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-T":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-N":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-S":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-E":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-B":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
                                break;
                            case "Termopar-R":
                                //comboBox_IO.Items.Clear();
                                comboBox_IO_evento_anterior.Items.Add(item.IO + "-" + item.descricao);
                                comboBox_IO_evento_posterior.Items.Add(item.IO + "-" + item.descricao);
                                //radioButton_OFF_evento_anterior.Visible = false;
                                //radioButton_ON_evento_anterior.Visible = false;
                                //textBox_setpoint.Visible = true;
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
                if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value != null)
                {
                    int sequencia = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                    if (sequencia != 1)
                    {
                        itensreceitabll.updateCustomMoveAbaixoSequencia(sequencia, Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));

                        carregaItensReceita(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[2].Value.ToString()));
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
            MessageBox.Show("Função ainda não implementada, aguarde!", "Atenção");

            //try
            //{
            //    var confirmResult = MessageBox.Show("Você deseja editar esse item?", "Atenção", MessageBoxButtons.YesNo);
            //    if (confirmResult == DialogResult.Yes)
            //    {
            //        if (dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[1].Value != null)
            //        {
            //            ItensReceita obj = itensreceitabll.get(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
            //            mostrar_ItensReceita(obj);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
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

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função ainda não implementada, aguarde!", "Atenção");
            //if (tabControl1.SelectedIndex == 1)
            //{
            //    if(string.IsNullOrEmpty(textBox_id.Text))
            //    {

            //    }
            //}
        }

        private void button_add_item_Click(object sender, EventArgs e)
        {
            if (checkBox_dosagem_incremental.Checked)
            {
                if (String.IsNullOrEmpty(textBox_passos.Text))
                {
                    MessageBox.Show("Calcule a quantidade de passos da dosagem incremental. Clique no Botão Calcular!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (int i = 0; i < Convert.ToInt32(textBox_passos.Text); i++)
                    {
                        add_item();
                    }
                }
            }
            else
            {
                add_item();
            }


            clean_itens_receita();
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 0;

            textBox_etapa.Focus();
        }

        private void button_copiar_Click(object sender, EventArgs e)
        {
            add_item();

            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 0;

            textBox_etapa.Focus();
        }

        private void add_item()
        {
            /*
            #region Verificação de campos em branco

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

            if (comboBox_repeticao.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo de repetição!");
                return;
            }

            if (comboBox_repeticao.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(textBox_vezes.Text))
                {
                    MessageBox.Show("Informe a quantide de repetições!");
                    return;
                }
                if (timeEdit_intervalo.Text == "00:00:00")
                {
                    MessageBox.Show("Defina o intervalo de repetição");
                    return;
                }
            }

            if (string.IsNullOrEmpty(textBox_etapa.Text))
            {
                MessageBox.Show("Insira a etapa do processo!");
                return;
            }

            if (comboBox_processo.SelectedIndex == -1)
            {
                MessageBox.Show("Defina o tipo do processo!");
                return;
            }

            if (comboBox_produto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Produto!");
                return;
            }

            if (comboBox_evento_anterior_tipo.SelectedIndex == -1)
            {
                MessageBox.Show("Defina do evento anterior!");
                return;
            }

            if (comboBox_evento_anterior_tipo.SelectedIndex == 0)
            {
                if (timeEdit_tempo_espera_evento_anterior.Text == "00:00:00")
                {
                    MessageBox.Show("Defina um tempo de espera!");
                    return;
                }
            }

            if (comboBox_evento_anterior_tipo.SelectedIndex == 1)
            {
                if (comboBox_IO.SelectedIndex == -1)
                {
                    MessageBox.Show("Escolha uma saída!");
                    return;
                }

                //if(comboBox_IO.SelectedIndex==1)
                //{
                //    if(string.IsNullOrEmpty(textBox_setpoint.Text))
                //    {
                //        MessageBox.Show("Digite um valor para o setpont da entrada analógica");
                //    }
                //}
            }

            if (comboBox_evento_posterior_tipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo de evento posterior!");
                return;
            }

            if (comboBox_evento_posterior_tipo.SelectedIndex == 0)
            {
                MessageBox.Show("Defina um tempo de espera!");
                return;
            }

            if (comboBox_evento_posterior_tipo.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(textBox_precorte.Text))
                {
                    MessageBox.Show("Defina o peso de pré-corte!");
                    return;
                }

                if (string.IsNullOrEmpty(textBox_corte.Text))
                {
                    MessageBox.Show("Defina o peso de corte!");
                    return;
                }
                if (string.IsNullOrEmpty(textBox_peso_limite.Text))
                {
                    MessageBox.Show("Defina o limite de segurança de peso!");
                    return;
                }

                if (string.IsNullOrEmpty(textBox_tempo_on.Text))
                {
                    MessageBox.Show("Defina um tempo de duração do rele ligado!");
                    return;
                }

                if (string.IsNullOrEmpty(textBox_tempo_off.Text))
                {
                    MessageBox.Show("Defina um tempo de duração do rele desligado!");
                    return;
                }
            }
            if (comboBox_evento_posterior_tipo.SelectedIndex == 2)
            {
                if (comboBox_IO_evento_posterior.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione uma entrada!");
                    return;
                }
            }
            if (timeEdit_tempo_limite_total.Text == "00:00:00")
            {
                MessageBox.Show("Defina um tempo máximo para a conclusão da etapa!");
                return;
            }

            if (checkBox_saida.Checked)
            {
                if (comboBox_saida_emergencia.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione uma saída!");
                    return;
                }
            }


            #endregion
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
                if (checkBox_velocidade.Checked)
                {
                    itensreceita.controle_velocidade = 1;
                    itensreceita.name_inversor = comboBox_inversor.Text;
                    itensreceita.addr_inversor = Convert.ToInt32(textBox_addr_inversor.Text);
                    itensreceita.velocidade = Convert.ToInt32(textBox_velocidade_hz.Text);
                }
                else
                {
                    itensreceita.controle_velocidade = 0;
                    itensreceita.name_inversor = "";
                    itensreceita.addr_inversor = 0;
                    itensreceita.velocidade = 0;
                }

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
                    itensreceita.entrada_evento_anterior = comboBox_IO_evento_anterior.Text;
                    if (comboBox_evento_anterior_tipo.Text.Substring(0, 1) == "I")
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
                    if (comboBox_evento_anterior_tipo.Text.Substring(0, 1) == "A")
                    {
                        itensreceita.setpoint_evento_anterior = Convert.ToInt32(textBox_setpoint_evento_anterior.Text);
                        itensreceita.status_entrada_digital_evento_anterior = 0;
                    }
                }
                else
                {
                    itensreceita.entrada_evento_anterior = "-";
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
                    if (comboBox_IO_evento_posterior.Text.Substring(0, 1) == "I")
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
                    itensreceita.acionar_saida = 0;
                    itensreceita.saida_seguranca = null;
                }

                #endregion

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                itensreceita.dateupdate = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);


                //ItensReceita temp_itens_receita = itensreceitabll.getCustomUltimo();
                itensreceita.sequencia = 1;

                #region Atualização do Banco de Dados

                receitabll.insert(obj);

                obj = receitabll.getCustomUltimo();
                itensreceita.id_receita = obj.id;

                itensreceitabll.insert(itensreceita);

                #endregion

                textBox_id.Text = obj.id.ToString();
                itensreceitabll.ordenaSequencia(obj.id);
                carregaItensReceita(obj.id);

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
                if (checkBox_velocidade.Checked)
                {
                    itensreceita.controle_velocidade = 1;
                    itensreceita.name_inversor = comboBox_inversor.Text;
                    itensreceita.addr_inversor = Convert.ToInt32(textBox_addr_inversor.Text);
                    itensreceita.velocidade = Convert.ToInt32(textBox_velocidade_hz.Text);

                }
                else
                {
                    itensreceita.controle_velocidade = 0;
                    itensreceita.name_inversor = "";
                    itensreceita.addr_inversor = 0;
                    itensreceita.velocidade = 0;
                }


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
                    itensreceita.entrada_evento_anterior = comboBox_IO_evento_anterior.Text;
                    if (comboBox_evento_anterior_tipo.Text.Substring(0, 1) == "I")
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
                    if (comboBox_evento_anterior_tipo.Text.Substring(0, 1) == "A")
                    {
                        itensreceita.setpoint_evento_anterior = Convert.ToInt32(textBox_setpoint_evento_anterior.Text);
                        itensreceita.status_entrada_digital_evento_anterior = 0;
                    }
                }
                else
                {
                    itensreceita.entrada_evento_anterior = "-";
                }

                if (comboBox_evento_anterior_tipo.Text == "Imediato")
                {
                    itensreceita.tempo_espera_evento_anterior = null;
                    itensreceita.entrada_evento_anterior = "-";
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
                else
                {
                    itensreceita.tempo_evento_posterior = null;
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
                    if (comboBox_IO_evento_posterior.Text.Substring(0, 1) == "I")
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
                    itensreceita.acionar_saida = 0;
                    itensreceita.saida_seguranca = null;
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

                #endregion

                atualiza_itens_receita("");
            }
        }

        private void button_dosagem_incremental_Click(object sender, EventArgs e)
        {
            if (checkBox_dosagem_incremental.Checked)
            {
                //int peso_total = Convert.ToInt32(Interaction.InputBox("Digite o valor total a ser dosado:", "Atenção!"));
                //int incremento = Convert.ToInt32(Interaction.InputBox("Digite o valor de cada incremento da dosagem:", "Atenção!"));
                int peso_total = Convert.ToInt32(textBox_peso_total.Text);
                int incremento = Convert.ToInt32(textBox_incremento.Text);
                int vezes = peso_total / incremento;
                int resto = peso_total % incremento;
                DialogResult resultado = MessageBox.Show("A dosagem será feita em " + vezes.ToString() + " incrementos de " + incremento.ToString() + " e o último incremento de " + resto.ToString() + "!", "Confirmação de Dosagem Automática", MessageBoxButtons.OKCancel);

                if (resto > 0)
                {
                    textBox_passos.Text = vezes.ToString();
                }
                else
                {
                    textBox_passos.Text = (vezes + 1).ToString();
                }

                textBox_corte.Text = incremento.ToString();

                //if (resultado == DialogResult.OK)
                //{
                //    for (int i = 0; i < vezes; i++)
                //    {
                //        add_item();
                //    }
                //    add_item();
                //}
                //else
                //{
                //    
                //}
            }
            else
            {
                MessageBox.Show("Selecione Dosagem Incremental!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exportarReceitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função ainda não implementada, aguarde!", "Atenção");
        }

        private void checkBox_velocidade_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Função ainda não implementada, aguarde!", "Atenção");

            if (checkBox_velocidade.Checked)
            {
                textBox_velocidade_hz.Visible = true;
                label21.Visible = true;
                label26.Visible = true;
                label23.Visible = true;
                comboBox_inversor.Visible = true;
                List<Network> list = networkbll.getAllCustom();
                if (list != null)
                {
                    foreach (Network item in list)
                    {
                        if (item.model == "Inversor")
                        {
                            comboBox_inversor.Items.Add(item.full_name);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não existe inversor de frequência cadastrado na rede!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                label22.Visible = true;
                textBox_addr_inversor.Visible = true;
            }
            else
            {
                textBox_velocidade_hz.Visible = false;
                label21.Visible = false;
                label26.Visible = false;
                label23.Visible = false;
                comboBox_inversor.Visible = false;
                comboBox_inversor.Items.Clear();
                label22.Visible = false;
                textBox_addr_inversor.Visible = false;
            }
        }

        private void comboBox_inversor_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Network> listnet = networkbll.getAllCustom();
            foreach (Network item in listnet)
            {
                if (comboBox_inversor.Text == item.full_name)
                {
                    textBox_addr_inversor.Text = item.addr.ToString();
                }
            }
        }

        private void excluirreceitatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_receita;
            try
            {
                var itemselecionado = dataGridView_receitas.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(itemselecionado))
                {
                    MessageBox.Show("Selecione uma receita para deletar!");
                    return;
                }
                var confirmResult = MessageBox.Show("Você realmente deseja deletar esta receita?", "Confirmação de exclusão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    id_receita = Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    receitabll.delete(Convert.ToInt32(dataGridView_itens_receita.Rows[dataGridView_itens_receita.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                    itensreceitabll.delete_by_campo("id_receita", id_receita);
                }

                atualiza_receitas("");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exluir receita" + "\r\n" + ex.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_IO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_IO_evento_anterior.Text.Substring(0, 1) == "A")
            {
                label20.Visible = true;
                textBox_setpoint_evento_anterior.Visible = true;
                radioButton_OFF_evento_anterior.Visible = false;
                radioButton_ON_evento_anterior.Visible = false;
            }
            else
            {
                label20.Visible = false;
                textBox_setpoint_evento_anterior.Visible = false;
                radioButton_OFF_evento_anterior.Visible = true;
                radioButton_ON_evento_anterior.Visible = true;

            }
        }

        private void comboBox_IO_evento_posterior_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_IO_evento_posterior.Text.Substring(0, 1) == "A")
            {
                label30.Visible = true;
                label34.Visible = true;
                textBox_setpoint_evento_posterior.Visible = true;
                textBox_setpoint_limite_evento_posterior.Visible = true;
                radioButton_OFF_evento_posterior.Visible = false;
                radioButton_ON_evento_posterior.Visible = false;
            }
            else
            {
                label30.Visible = false;
                label34.Visible = false;
                textBox_setpoint_evento_posterior.Visible = false;
                textBox_setpoint_limite_evento_posterior.Visible = false;
                radioButton_OFF_evento_posterior.Visible = true;
                radioButton_ON_evento_posterior.Visible = true;
            }
        }

        private void checkBox_dosagem_automatica_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_dosagem_incremental.Checked)
            {
                textBox_corte.Enabled = false;
                textBox_peso_total.Enabled = true;
                textBox_incremento.Enabled = true;
            }
            else
            {
                textBox_corte.Enabled = true;
                textBox_peso_total.Enabled = false;
                textBox_incremento.Enabled = false;
            }
        }

        private void atualizarDataEHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_endereco.Text))
            {
                MessageBox.Show("Selecione o dispositivo da rede que deseja atualizar data e hora!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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

                cmd_data_hora[0] = Convert.ToByte(textBox_endereco.Text);
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

                crc = Crc16.ComputeCrc(cmd_data_hora, cmd_data_hora.Length - 2);
                cmd_data_hora[10] = Convert.ToByte(crc >> 8);
                cmd_data_hora[11] = Convert.ToByte(crc & 0xff);

                if (Serial_Comumnication.serialPort.IsOpen)
                {
                    try
                    {
                        //Serial_Comumnication.serialPort.Write(60.ToString() + temp_dia_semana.ToString() + data + hora);
                        Serial_Comumnication.serialPort.Write(cmd_data_hora, 0, cmd_data_hora.Length);
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
        }

        private void comboBox_indicador_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Network> listnet = networkbll.getAllCustom();
            foreach (Network item in listnet)
            {
                if (comboBox_indicador.Text == item.full_name)
                {
                    textBox_addr_indicador.Text = item.addr.ToString();
                }
            }
        }

        private void Form_receita_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (groupBox1.Enabled == true & groupBox2.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Deseja salvar a receita antes de sair?", "Salvar Receita?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (result == DialogResult.Yes)
                {
                    salvarToolStripMenuItem_Click(sender, e);
                }
                if (result == DialogResult.No)
                {
                    return;
                }

            }


        }
    }
}