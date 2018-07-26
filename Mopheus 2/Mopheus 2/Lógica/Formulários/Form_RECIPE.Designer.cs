using System.Threading;
using System.Globalization;

namespace Mopheus_2
{
    partial class Form_receita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_receita));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.receitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaReceitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarReceitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adionarItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarReceitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarReceitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pausarReceitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pararReceitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetarControlMixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarDataEHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusDosDispositivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_receitas = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_receita = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarreceitatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarreceitatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirreceitatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_itens_receita = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_etapas_receita = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novaEtapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarEtapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_pausar_receita = new System.Windows.Forms.Button();
            this.button_executar_receita = new System.Windows.Forms.Button();
            this.button_parar_receita = new System.Windows.Forms.Button();
            this.button_enviar_receita = new System.Windows.Forms.Button();
            this.button_copiar = new System.Windows.Forms.Button();
            this.button_add_item = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox_estado_saida = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.comboBox_inversor = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox_addr_inversor = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_velocidade_hz = new System.Windows.Forms.TextBox();
            this.checkBox_velocidade = new System.Windows.Forms.CheckBox();
            this.textBox_etapa = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.comboBox_produto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_rele = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_processo = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.radioButton_ON_evento_anterior = new System.Windows.Forms.RadioButton();
            this.radioButton_OFF_evento_anterior = new System.Windows.Forms.RadioButton();
            this.textBox_setpoint_evento_anterior = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timeEdit_tempo_espera_evento_anterior = new DevExpress.XtraEditors.TimeEdit();
            this.comboBox_IO_evento_anterior = new System.Windows.Forms.ComboBox();
            this.comboBox_evento_anterior_tipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox_tempo = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.timeEdit_tempo_evento_posterior = new DevExpress.XtraEditors.TimeEdit();
            this.groupBox_entrada = new System.Windows.Forms.GroupBox();
            this.radioButton_OFF_evento_posterior = new System.Windows.Forms.RadioButton();
            this.radioButton_ON_evento_posterior = new System.Windows.Forms.RadioButton();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox_setpoint_limite_evento_posterior = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.comboBox_IO_evento_posterior = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox_setpoint_evento_posterior = new System.Windows.Forms.TextBox();
            this.groupBox_peso = new System.Windows.Forms.GroupBox();
            this.textBox_addr_indicador = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.comboBox_indicador = new System.Windows.Forms.ComboBox();
            this.textBox_passos = new System.Windows.Forms.TextBox();
            this.button_dosagem_incremental = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox_peso_total = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox_incremento = new System.Windows.Forms.TextBox();
            this.checkBox_dosagem_incremental = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_peso_limite = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_tempo_on = new System.Windows.Forms.TextBox();
            this.textBox_corte = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_tempo_off = new System.Windows.Forms.TextBox();
            this.textBox_precorte = new System.Windows.Forms.TextBox();
            this.comboBox_evento_posterior_tipo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.timeEdit_tempo_limite_total = new DevExpress.XtraEditors.TimeEdit();
            this.comboBox_saida_emergencia = new System.Windows.Forms.ComboBox();
            this.checkBox_saida = new System.Windows.Forms.CheckBox();
            this.checkBox_pausar = new System.Windows.Forms.CheckBox();
            this.checkBox_alerta = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeEdit_intervalo = new DevExpress.XtraEditors.TimeEdit();
            this.label32 = new System.Windows.Forms.Label();
            this.comboBox_repeticao = new System.Windows.Forms.ComboBox();
            this.label_intervalo = new System.Windows.Forms.Label();
            this.textBox_vezes = new System.Windows.Forms.TextBox();
            this.label_vezez = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_linhas = new System.Windows.Forms.TextBox();
            this.textBox_endereco = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_device = new System.Windows.Forms.ComboBox();
            this.textBox_nome_receita = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_receitas)).BeginInit();
            this.contextMenuStrip_receita.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_itens_receita)).BeginInit();
            this.contextMenuStrip_etapas_receita.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_tempo_espera_evento_anterior.Properties)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox_tempo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_tempo_evento_posterior.Properties)).BeginInit();
            this.groupBox_entrada.SuspendLayout();
            this.groupBox_peso.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_tempo_limite_total.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_intervalo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receitasToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.comandosToolStripMenuItem,
            this.visualizarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // receitasToolStripMenuItem
            // 
            this.receitasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaReceitaToolStripMenuItem,
            this.carregarToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.exportarReceitaToolStripMenuItem,
            this.imprimirToolStripMenuItem});
            this.receitasToolStripMenuItem.Name = "receitasToolStripMenuItem";
            this.receitasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.receitasToolStripMenuItem.Text = "Arquivo";
            // 
            // novaReceitaToolStripMenuItem
            // 
            this.novaReceitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.NewFile_16x;
            this.novaReceitaToolStripMenuItem.Name = "novaReceitaToolStripMenuItem";
            this.novaReceitaToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.novaReceitaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.novaReceitaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.novaReceitaToolStripMenuItem.Text = "Nova Receita";
            this.novaReceitaToolStripMenuItem.Click += new System.EventHandler(this.novaReceitaToolStripMenuItem_Click);
            // 
            // carregarToolStripMenuItem
            // 
            this.carregarToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.OpenFolder_16x;
            this.carregarToolStripMenuItem.Name = "carregarToolStripMenuItem";
            this.carregarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.carregarToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.carregarToolStripMenuItem.Text = "Abrir Receita";
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.SaveTable_16x;
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.salvarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.salvarToolStripMenuItem.Text = "Salvar no Banco de Dados";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // exportarReceitaToolStripMenuItem
            // 
            this.exportarReceitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.ExportTableToFile_16x;
            this.exportarReceitaToolStripMenuItem.Name = "exportarReceitaToolStripMenuItem";
            this.exportarReceitaToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
            this.exportarReceitaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportarReceitaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.exportarReceitaToolStripMenuItem.Text = "Exportar Receita";
            this.exportarReceitaToolStripMenuItem.Click += new System.EventHandler(this.exportarReceitaToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Print_16x;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+P";
            this.imprimirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir Receita";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adionarItemToolStripMenuItem,
            this.copiarItemToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // adionarItemToolStripMenuItem
            // 
            this.adionarItemToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Add_16x;
            this.adionarItemToolStripMenuItem.Name = "adionarItemToolStripMenuItem";
            this.adionarItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adionarItemToolStripMenuItem.Text = "Adicionar Item";
            this.adionarItemToolStripMenuItem.Click += new System.EventHandler(this.button_add_item_Click);
            // 
            // copiarItemToolStripMenuItem
            // 
            this.copiarItemToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.ASX_Copy_blue_16x;
            this.copiarItemToolStripMenuItem.Name = "copiarItemToolStripMenuItem";
            this.copiarItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copiarItemToolStripMenuItem.Text = "Copiar Item";
            this.copiarItemToolStripMenuItem.Click += new System.EventHandler(this.button_copiar_Click);
            // 
            // comandosToolStripMenuItem
            // 
            this.comandosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarReceitaToolStripMenuItem,
            this.executarReceitaToolStripMenuItem,
            this.pausarReceitaToolStripMenuItem,
            this.pararReceitaToolStripMenuItem,
            this.resetarControlMixToolStripMenuItem,
            this.atualizarDataEHoraToolStripMenuItem});
            this.comandosToolStripMenuItem.Name = "comandosToolStripMenuItem";
            this.comandosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.comandosToolStripMenuItem.Text = "Comandos";
            // 
            // enviarReceitaToolStripMenuItem
            // 
            this.enviarReceitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Upload_16x;
            this.enviarReceitaToolStripMenuItem.Name = "enviarReceitaToolStripMenuItem";
            this.enviarReceitaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.enviarReceitaToolStripMenuItem.Text = "Enviar Receita";
            this.enviarReceitaToolStripMenuItem.Click += new System.EventHandler(this.enviarReceitaToolStripMenuItem_Click);
            // 
            // executarReceitaToolStripMenuItem
            // 
            this.executarReceitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.PlayVideo_16x;
            this.executarReceitaToolStripMenuItem.Name = "executarReceitaToolStripMenuItem";
            this.executarReceitaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.executarReceitaToolStripMenuItem.Text = "Executar Receita";
            // 
            // pausarReceitaToolStripMenuItem
            // 
            this.pausarReceitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Pause_16x;
            this.pausarReceitaToolStripMenuItem.Name = "pausarReceitaToolStripMenuItem";
            this.pausarReceitaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pausarReceitaToolStripMenuItem.Text = "Pausar Receita";
            // 
            // pararReceitaToolStripMenuItem
            // 
            this.pararReceitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Stop_grey_16x;
            this.pararReceitaToolStripMenuItem.Name = "pararReceitaToolStripMenuItem";
            this.pararReceitaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pararReceitaToolStripMenuItem.Text = "Parar Receita";
            // 
            // resetarControlMixToolStripMenuItem
            // 
            this.resetarControlMixToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Cancel_16x;
            this.resetarControlMixToolStripMenuItem.Name = "resetarControlMixToolStripMenuItem";
            this.resetarControlMixToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.resetarControlMixToolStripMenuItem.Text = "Resetar ControlMix";
            // 
            // atualizarDataEHoraToolStripMenuItem
            // 
            this.atualizarDataEHoraToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.History_16x;
            this.atualizarDataEHoraToolStripMenuItem.Name = "atualizarDataEHoraToolStripMenuItem";
            this.atualizarDataEHoraToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.atualizarDataEHoraToolStripMenuItem.Text = "Atualizar Data e Hora";
            this.atualizarDataEHoraToolStripMenuItem.Click += new System.EventHandler(this.atualizarDataEHoraToolStripMenuItem_Click);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDosDispositivosToolStripMenuItem});
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // statusDosDispositivosToolStripMenuItem
            // 
            this.statusDosDispositivosToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.StatusAlert_16x;
            this.statusDosDispositivosToolStripMenuItem.Name = "statusDosDispositivosToolStripMenuItem";
            this.statusDosDispositivosToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.statusDosDispositivosToolStripMenuItem.Text = "Status dos Dispositivos";
            this.statusDosDispositivosToolStripMenuItem.Click += new System.EventHandler(this.statusDosDispositivosToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(986, 622);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.dataGridView_receitas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(978, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Receitas Cadastradas";
            // 
            // dataGridView_receitas
            // 
            this.dataGridView_receitas.AllowUserToAddRows = false;
            this.dataGridView_receitas.AllowUserToDeleteRows = false;
            this.dataGridView_receitas.AllowUserToResizeColumns = false;
            this.dataGridView_receitas.AllowUserToResizeRows = false;
            this.dataGridView_receitas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_receitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_receitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_receitas.ContextMenuStrip = this.contextMenuStrip_receita;
            this.dataGridView_receitas.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_receitas.Name = "dataGridView_receitas";
            this.dataGridView_receitas.Size = new System.Drawing.Size(966, 584);
            this.dataGridView_receitas.TabIndex = 0;
            this.dataGridView_receitas.DoubleClick += new System.EventHandler(this.dataGridView_receitas_DoubleClick);
            // 
            // contextMenuStrip_receita
            // 
            this.contextMenuStrip_receita.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarreceitatoolStripMenuItem,
            this.editarreceitatoolStripMenuItem,
            this.excluirreceitatoolStripMenuItem});
            this.contextMenuStrip_receita.Name = "contextMenuStrip_etapas_receita";
            this.contextMenuStrip_receita.Size = new System.Drawing.Size(167, 70);
            // 
            // adicionarreceitatoolStripMenuItem
            // 
            this.adicionarreceitatoolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Add_16x;
            this.adicionarreceitatoolStripMenuItem.Name = "adicionarreceitatoolStripMenuItem";
            this.adicionarreceitatoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.adicionarreceitatoolStripMenuItem.Text = "Adicionar Receita";
            this.adicionarreceitatoolStripMenuItem.Click += new System.EventHandler(this.novaReceitaToolStripMenuItem_Click);
            // 
            // editarreceitatoolStripMenuItem
            // 
            this.editarreceitatoolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.ASX_Edit_grey_16x;
            this.editarreceitatoolStripMenuItem.Name = "editarreceitatoolStripMenuItem";
            this.editarreceitatoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editarreceitatoolStripMenuItem.Text = "Editar Receita";
            this.editarreceitatoolStripMenuItem.Click += new System.EventHandler(this.dataGridView_receitas_DoubleClick);
            // 
            // excluirreceitatoolStripMenuItem
            // 
            this.excluirreceitatoolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Cancel_16x;
            this.excluirreceitatoolStripMenuItem.Name = "excluirreceitatoolStripMenuItem";
            this.excluirreceitatoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.excluirreceitatoolStripMenuItem.Text = "Excluir Receita";
            this.excluirreceitatoolStripMenuItem.Click += new System.EventHandler(this.excluirreceitatoolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dataGridView_itens_receita);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(978, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Itens da Receita";
            // 
            // dataGridView_itens_receita
            // 
            this.dataGridView_itens_receita.AllowUserToAddRows = false;
            this.dataGridView_itens_receita.AllowUserToDeleteRows = false;
            this.dataGridView_itens_receita.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_itens_receita.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_itens_receita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_itens_receita.ContextMenuStrip = this.contextMenuStrip_etapas_receita;
            this.dataGridView_itens_receita.Location = new System.Drawing.Point(6, 391);
            this.dataGridView_itens_receita.Name = "dataGridView_itens_receita";
            this.dataGridView_itens_receita.ReadOnly = true;
            this.dataGridView_itens_receita.Size = new System.Drawing.Size(962, 200);
            this.dataGridView_itens_receita.TabIndex = 17;
            // 
            // contextMenuStrip_etapas_receita
            // 
            this.contextMenuStrip_etapas_receita.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaEtapaToolStripMenuItem,
            this.excluirToolStripMenuItem,
            this.editarEtapaToolStripMenuItem,
            this.ascenderToolStripMenuItem,
            this.descenderToolStripMenuItem});
            this.contextMenuStrip_etapas_receita.Name = "contextMenuStrip_etapas_receita";
            this.contextMenuStrip_etapas_receita.Size = new System.Drawing.Size(158, 114);
            // 
            // novaEtapaToolStripMenuItem
            // 
            this.novaEtapaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Add_16x;
            this.novaEtapaToolStripMenuItem.Name = "novaEtapaToolStripMenuItem";
            this.novaEtapaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.novaEtapaToolStripMenuItem.Text = "Adicionar Etapa";
            this.novaEtapaToolStripMenuItem.Click += new System.EventHandler(this.novaEtapaToolStripMenuItem_Click);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Cancel_16x;
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.excluirToolStripMenuItem.Text = "Excluir Etapa";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
            // 
            // editarEtapaToolStripMenuItem
            // 
            this.editarEtapaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.ASX_Edit_grey_16x;
            this.editarEtapaToolStripMenuItem.Name = "editarEtapaToolStripMenuItem";
            this.editarEtapaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.editarEtapaToolStripMenuItem.Text = "Editar Etapa";
            this.editarEtapaToolStripMenuItem.Click += new System.EventHandler(this.editarEtapaToolStripMenuItem_Click);
            // 
            // ascenderToolStripMenuItem
            // 
            this.ascenderToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Upload_16x;
            this.ascenderToolStripMenuItem.Name = "ascenderToolStripMenuItem";
            this.ascenderToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ascenderToolStripMenuItem.Text = "Nível Acima";
            this.ascenderToolStripMenuItem.Click += new System.EventHandler(this.ascenderToolStripMenuItem_Click);
            // 
            // descenderToolStripMenuItem
            // 
            this.descenderToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Download_16x;
            this.descenderToolStripMenuItem.Name = "descenderToolStripMenuItem";
            this.descenderToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.descenderToolStripMenuItem.Text = "Nível Abaixo";
            this.descenderToolStripMenuItem.Click += new System.EventHandler(this.descenderToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_pausar_receita);
            this.groupBox2.Controls.Add(this.button_executar_receita);
            this.groupBox2.Controls.Add(this.button_parar_receita);
            this.groupBox2.Controls.Add(this.button_enviar_receita);
            this.groupBox2.Controls.Add(this.button_copiar);
            this.groupBox2.Controls.Add(this.button_add_item);
            this.groupBox2.Controls.Add(this.tabControl2);
            this.groupBox2.Location = new System.Drawing.Point(6, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 307);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados da Receita";
            // 
            // button_pausar_receita
            // 
            this.button_pausar_receita.Image = global::Mopheus_2.Properties.Resources.Pause_16x;
            this.button_pausar_receita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_pausar_receita.Location = new System.Drawing.Point(804, 210);
            this.button_pausar_receita.Name = "button_pausar_receita";
            this.button_pausar_receita.Size = new System.Drawing.Size(150, 23);
            this.button_pausar_receita.TabIndex = 31;
            this.button_pausar_receita.Text = "Pausar Receita";
            this.button_pausar_receita.UseVisualStyleBackColor = true;
            // 
            // button_executar_receita
            // 
            this.button_executar_receita.Image = global::Mopheus_2.Properties.Resources.PlayVideo_16x;
            this.button_executar_receita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_executar_receita.Location = new System.Drawing.Point(804, 181);
            this.button_executar_receita.Name = "button_executar_receita";
            this.button_executar_receita.Size = new System.Drawing.Size(150, 23);
            this.button_executar_receita.TabIndex = 30;
            this.button_executar_receita.Text = "Executar Receita";
            this.button_executar_receita.UseVisualStyleBackColor = true;
            // 
            // button_parar_receita
            // 
            this.button_parar_receita.Image = global::Mopheus_2.Properties.Resources.Stop_grey_16x;
            this.button_parar_receita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_parar_receita.Location = new System.Drawing.Point(804, 239);
            this.button_parar_receita.Name = "button_parar_receita";
            this.button_parar_receita.Size = new System.Drawing.Size(150, 23);
            this.button_parar_receita.TabIndex = 29;
            this.button_parar_receita.Text = "Parar Receita";
            this.button_parar_receita.UseVisualStyleBackColor = true;
            // 
            // button_enviar_receita
            // 
            this.button_enviar_receita.Image = global::Mopheus_2.Properties.Resources.Upload_16x;
            this.button_enviar_receita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_enviar_receita.Location = new System.Drawing.Point(804, 152);
            this.button_enviar_receita.Name = "button_enviar_receita";
            this.button_enviar_receita.Size = new System.Drawing.Size(150, 23);
            this.button_enviar_receita.TabIndex = 28;
            this.button_enviar_receita.Text = "Enviar Receita";
            this.button_enviar_receita.UseVisualStyleBackColor = true;
            // 
            // button_copiar
            // 
            this.button_copiar.Image = global::Mopheus_2.Properties.Resources.ASX_Copy_blue_16x;
            this.button_copiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_copiar.Location = new System.Drawing.Point(804, 70);
            this.button_copiar.Name = "button_copiar";
            this.button_copiar.Size = new System.Drawing.Size(150, 23);
            this.button_copiar.TabIndex = 27;
            this.button_copiar.Text = "Copiar Item";
            this.button_copiar.UseVisualStyleBackColor = true;
            this.button_copiar.Click += new System.EventHandler(this.button_copiar_Click);
            // 
            // button_add_item
            // 
            this.button_add_item.Image = global::Mopheus_2.Properties.Resources.Add_16x;
            this.button_add_item.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add_item.Location = new System.Drawing.Point(804, 41);
            this.button_add_item.Name = "button_add_item";
            this.button_add_item.Size = new System.Drawing.Size(150, 23);
            this.button_add_item.TabIndex = 26;
            this.button_add_item.Text = "Adicionar Item";
            this.button_add_item.UseVisualStyleBackColor = true;
            this.button_add_item.Click += new System.EventHandler(this.button_add_item_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Location = new System.Drawing.Point(6, 19);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(794, 282);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.comboBox_estado_saida);
            this.tabPage3.Controls.Add(this.label27);
            this.tabPage3.Controls.Add(this.comboBox_inversor);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.textBox_addr_inversor);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.textBox_velocidade_hz);
            this.tabPage3.Controls.Add(this.checkBox_velocidade);
            this.tabPage3.Controls.Add(this.textBox_etapa);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.comboBox_produto);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox_rele);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.comboBox_processo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(786, 256);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Principal";
            // 
            // comboBox_estado_saida
            // 
            this.comboBox_estado_saida.FormattingEnabled = true;
            this.comboBox_estado_saida.ItemHeight = 13;
            this.comboBox_estado_saida.Location = new System.Drawing.Point(703, 18);
            this.comboBox_estado_saida.Name = "comboBox_estado_saida";
            this.comboBox_estado_saida.Size = new System.Drawing.Size(77, 21);
            this.comboBox_estado_saida.TabIndex = 17;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(700, 2);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 13);
            this.label27.TabIndex = 32;
            this.label27.Text = "Estado";
            // 
            // comboBox_inversor
            // 
            this.comboBox_inversor.FormattingEnabled = true;
            this.comboBox_inversor.ItemHeight = 13;
            this.comboBox_inversor.Location = new System.Drawing.Point(9, 81);
            this.comboBox_inversor.Name = "comboBox_inversor";
            this.comboBox_inversor.Size = new System.Drawing.Size(150, 21);
            this.comboBox_inversor.TabIndex = 17;
            this.comboBox_inversor.SelectedIndexChanged += new System.EventHandler(this.comboBox_inversor_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 105);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "Velocidade";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "Inversor";
            // 
            // textBox_addr_inversor
            // 
            this.textBox_addr_inversor.Enabled = false;
            this.textBox_addr_inversor.Location = new System.Drawing.Point(165, 81);
            this.textBox_addr_inversor.Name = "textBox_addr_inversor";
            this.textBox_addr_inversor.ReadOnly = true;
            this.textBox_addr_inversor.Size = new System.Drawing.Size(50, 20);
            this.textBox_addr_inversor.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(162, 65);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "Endereço";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(57, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "Hz";
            // 
            // textBox_velocidade_hz
            // 
            this.textBox_velocidade_hz.Location = new System.Drawing.Point(9, 121);
            this.textBox_velocidade_hz.Name = "textBox_velocidade_hz";
            this.textBox_velocidade_hz.Size = new System.Drawing.Size(45, 20);
            this.textBox_velocidade_hz.TabIndex = 26;
            // 
            // checkBox_velocidade
            // 
            this.checkBox_velocidade.AutoSize = true;
            this.checkBox_velocidade.Location = new System.Drawing.Point(9, 45);
            this.checkBox_velocidade.Name = "checkBox_velocidade";
            this.checkBox_velocidade.Size = new System.Drawing.Size(136, 17);
            this.checkBox_velocidade.TabIndex = 25;
            this.checkBox_velocidade.Text = "Controle de Velocidade";
            this.checkBox_velocidade.UseVisualStyleBackColor = true;
            this.checkBox_velocidade.CheckedChanged += new System.EventHandler(this.checkBox_velocidade_CheckedChanged);
            // 
            // textBox_etapa
            // 
            this.textBox_etapa.Location = new System.Drawing.Point(9, 19);
            this.textBox_etapa.Name = "textBox_etapa";
            this.textBox_etapa.Size = new System.Drawing.Size(250, 20);
            this.textBox_etapa.TabIndex = 17;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(90, 13);
            this.label31.TabIndex = 21;
            this.label31.Text = "Etapa da Receita";
            // 
            // comboBox_produto
            // 
            this.comboBox_produto.FormattingEnabled = true;
            this.comboBox_produto.Location = new System.Drawing.Point(391, 18);
            this.comboBox_produto.Name = "comboBox_produto";
            this.comboBox_produto.Size = new System.Drawing.Size(250, 21);
            this.comboBox_produto.TabIndex = 19;
            this.comboBox_produto.SelectedIndexChanged += new System.EventHandler(this.comboBox_produto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(644, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Relé";
            // 
            // textBox_rele
            // 
            this.textBox_rele.Enabled = false;
            this.textBox_rele.Location = new System.Drawing.Point(647, 19);
            this.textBox_rele.Name = "textBox_rele";
            this.textBox_rele.Size = new System.Drawing.Size(50, 20);
            this.textBox_rele.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Produto/Acionamento/Sensoriamento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Processo";
            // 
            // comboBox_processo
            // 
            this.comboBox_processo.FormattingEnabled = true;
            this.comboBox_processo.ItemHeight = 13;
            this.comboBox_processo.Location = new System.Drawing.Point(265, 18);
            this.comboBox_processo.Name = "comboBox_processo";
            this.comboBox_processo.Size = new System.Drawing.Size(120, 21);
            this.comboBox_processo.TabIndex = 18;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.radioButton_ON_evento_anterior);
            this.tabPage4.Controls.Add(this.radioButton_OFF_evento_anterior);
            this.tabPage4.Controls.Add(this.textBox_setpoint_evento_anterior);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.timeEdit_tempo_espera_evento_anterior);
            this.tabPage4.Controls.Add(this.comboBox_IO_evento_anterior);
            this.tabPage4.Controls.Add(this.comboBox_evento_anterior_tipo);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(786, 256);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Evento Anterior";
            // 
            // radioButton_ON_evento_anterior
            // 
            this.radioButton_ON_evento_anterior.AutoSize = true;
            this.radioButton_ON_evento_anterior.Location = new System.Drawing.Point(266, 101);
            this.radioButton_ON_evento_anterior.Name = "radioButton_ON_evento_anterior";
            this.radioButton_ON_evento_anterior.Size = new System.Drawing.Size(41, 17);
            this.radioButton_ON_evento_anterior.TabIndex = 29;
            this.radioButton_ON_evento_anterior.Text = "ON";
            this.radioButton_ON_evento_anterior.UseVisualStyleBackColor = true;
            // 
            // radioButton_OFF_evento_anterior
            // 
            this.radioButton_OFF_evento_anterior.AutoSize = true;
            this.radioButton_OFF_evento_anterior.Checked = true;
            this.radioButton_OFF_evento_anterior.Location = new System.Drawing.Point(215, 101);
            this.radioButton_OFF_evento_anterior.Name = "radioButton_OFF_evento_anterior";
            this.radioButton_OFF_evento_anterior.Size = new System.Drawing.Size(45, 17);
            this.radioButton_OFF_evento_anterior.TabIndex = 28;
            this.radioButton_OFF_evento_anterior.TabStop = true;
            this.radioButton_OFF_evento_anterior.Text = "OFF";
            this.radioButton_OFF_evento_anterior.UseVisualStyleBackColor = true;
            // 
            // textBox_setpoint_evento_anterior
            // 
            this.textBox_setpoint_evento_anterior.Location = new System.Drawing.Point(9, 137);
            this.textBox_setpoint_evento_anterior.Name = "textBox_setpoint_evento_anterior";
            this.textBox_setpoint_evento_anterior.Size = new System.Drawing.Size(110, 20);
            this.textBox_setpoint_evento_anterior.TabIndex = 30;
            this.textBox_setpoint_evento_anterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_setpoint_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "Set Point";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Entrada";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Tempo de Espera";
            // 
            // timeEdit_tempo_espera_evento_anterior
            // 
            this.timeEdit_tempo_espera_evento_anterior.EditValue = new System.DateTime(2018, 5, 8, 0, 0, 0, 0);
            this.timeEdit_tempo_espera_evento_anterior.Location = new System.Drawing.Point(9, 58);
            this.timeEdit_tempo_espera_evento_anterior.Name = "timeEdit_tempo_espera_evento_anterior";
            this.timeEdit_tempo_espera_evento_anterior.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_tempo_espera_evento_anterior.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_tempo_espera_evento_anterior.Size = new System.Drawing.Size(110, 20);
            this.timeEdit_tempo_espera_evento_anterior.TabIndex = 26;
            // 
            // comboBox_IO_evento_anterior
            // 
            this.comboBox_IO_evento_anterior.FormattingEnabled = true;
            this.comboBox_IO_evento_anterior.Location = new System.Drawing.Point(9, 97);
            this.comboBox_IO_evento_anterior.Name = "comboBox_IO_evento_anterior";
            this.comboBox_IO_evento_anterior.Size = new System.Drawing.Size(200, 21);
            this.comboBox_IO_evento_anterior.TabIndex = 27;
            this.comboBox_IO_evento_anterior.SelectedIndexChanged += new System.EventHandler(this.comboBox_IO_SelectedIndexChanged);
            // 
            // comboBox_evento_anterior_tipo
            // 
            this.comboBox_evento_anterior_tipo.FormattingEnabled = true;
            this.comboBox_evento_anterior_tipo.Location = new System.Drawing.Point(9, 19);
            this.comboBox_evento_anterior_tipo.Name = "comboBox_evento_anterior_tipo";
            this.comboBox_evento_anterior_tipo.Size = new System.Drawing.Size(110, 21);
            this.comboBox_evento_anterior_tipo.TabIndex = 25;
            this.comboBox_evento_anterior_tipo.SelectedIndexChanged += new System.EventHandler(this.comboBox_evento_anterior_tipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tipo";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.groupBox_tempo);
            this.tabPage5.Controls.Add(this.groupBox_entrada);
            this.tabPage5.Controls.Add(this.groupBox_peso);
            this.tabPage5.Controls.Add(this.comboBox_evento_posterior_tipo);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(786, 256);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Evento Posterior";
            // 
            // groupBox_tempo
            // 
            this.groupBox_tempo.Controls.Add(this.label24);
            this.groupBox_tempo.Controls.Add(this.timeEdit_tempo_evento_posterior);
            this.groupBox_tempo.Location = new System.Drawing.Point(656, 46);
            this.groupBox_tempo.Name = "groupBox_tempo";
            this.groupBox_tempo.Size = new System.Drawing.Size(124, 68);
            this.groupBox_tempo.TabIndex = 75;
            this.groupBox_tempo.TabStop = false;
            this.groupBox_tempo.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 0;
            this.label24.Tag = "55";
            this.label24.Text = "Tempo";
            // 
            // timeEdit_tempo_evento_posterior
            // 
            this.timeEdit_tempo_evento_posterior.EditValue = new System.DateTime(2018, 5, 8, 0, 0, 0, 0);
            this.timeEdit_tempo_evento_posterior.Location = new System.Drawing.Point(9, 32);
            this.timeEdit_tempo_evento_posterior.Name = "timeEdit_tempo_evento_posterior";
            this.timeEdit_tempo_evento_posterior.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_tempo_evento_posterior.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_tempo_evento_posterior.Size = new System.Drawing.Size(101, 20);
            this.timeEdit_tempo_evento_posterior.TabIndex = 54;
            // 
            // groupBox_entrada
            // 
            this.groupBox_entrada.Controls.Add(this.radioButton_OFF_evento_posterior);
            this.groupBox_entrada.Controls.Add(this.radioButton_ON_evento_posterior);
            this.groupBox_entrada.Controls.Add(this.label34);
            this.groupBox_entrada.Controls.Add(this.textBox_setpoint_limite_evento_posterior);
            this.groupBox_entrada.Controls.Add(this.label33);
            this.groupBox_entrada.Controls.Add(this.comboBox_IO_evento_posterior);
            this.groupBox_entrada.Controls.Add(this.label30);
            this.groupBox_entrada.Controls.Add(this.textBox_setpoint_evento_posterior);
            this.groupBox_entrada.Location = new System.Drawing.Point(335, 46);
            this.groupBox_entrada.Name = "groupBox_entrada";
            this.groupBox_entrada.Size = new System.Drawing.Size(315, 107);
            this.groupBox_entrada.TabIndex = 75;
            this.groupBox_entrada.TabStop = false;
            this.groupBox_entrada.Visible = false;
            // 
            // radioButton_OFF_evento_posterior
            // 
            this.radioButton_OFF_evento_posterior.AutoSize = true;
            this.radioButton_OFF_evento_posterior.Checked = true;
            this.radioButton_OFF_evento_posterior.Location = new System.Drawing.Point(215, 33);
            this.radioButton_OFF_evento_posterior.Name = "radioButton_OFF_evento_posterior";
            this.radioButton_OFF_evento_posterior.Size = new System.Drawing.Size(45, 17);
            this.radioButton_OFF_evento_posterior.TabIndex = 47;
            this.radioButton_OFF_evento_posterior.TabStop = true;
            this.radioButton_OFF_evento_posterior.Text = "OFF";
            this.radioButton_OFF_evento_posterior.UseVisualStyleBackColor = true;
            // 
            // radioButton_ON_evento_posterior
            // 
            this.radioButton_ON_evento_posterior.AutoSize = true;
            this.radioButton_ON_evento_posterior.Location = new System.Drawing.Point(266, 33);
            this.radioButton_ON_evento_posterior.Name = "radioButton_ON_evento_posterior";
            this.radioButton_ON_evento_posterior.Size = new System.Drawing.Size(41, 17);
            this.radioButton_ON_evento_posterior.TabIndex = 48;
            this.radioButton_ON_evento_posterior.Text = "ON";
            this.radioButton_ON_evento_posterior.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(122, 56);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 13);
            this.label34.TabIndex = 53;
            this.label34.Text = "Set Point Limite";
            // 
            // textBox_setpoint_limite_evento_posterior
            // 
            this.textBox_setpoint_limite_evento_posterior.Location = new System.Drawing.Point(125, 72);
            this.textBox_setpoint_limite_evento_posterior.Name = "textBox_setpoint_limite_evento_posterior";
            this.textBox_setpoint_limite_evento_posterior.Size = new System.Drawing.Size(110, 20);
            this.textBox_setpoint_limite_evento_posterior.TabIndex = 50;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(44, 13);
            this.label33.TabIndex = 51;
            this.label33.Text = "Entrada";
            // 
            // comboBox_IO_evento_posterior
            // 
            this.comboBox_IO_evento_posterior.FormattingEnabled = true;
            this.comboBox_IO_evento_posterior.Location = new System.Drawing.Point(9, 32);
            this.comboBox_IO_evento_posterior.Name = "comboBox_IO_evento_posterior";
            this.comboBox_IO_evento_posterior.Size = new System.Drawing.Size(200, 21);
            this.comboBox_IO_evento_posterior.TabIndex = 46;
            this.comboBox_IO_evento_posterior.SelectedIndexChanged += new System.EventHandler(this.comboBox_IO_evento_posterior_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 56);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 52;
            this.label30.Text = "Set Point";
            // 
            // textBox_setpoint_evento_posterior
            // 
            this.textBox_setpoint_evento_posterior.Location = new System.Drawing.Point(9, 72);
            this.textBox_setpoint_evento_posterior.Name = "textBox_setpoint_evento_posterior";
            this.textBox_setpoint_evento_posterior.Size = new System.Drawing.Size(110, 20);
            this.textBox_setpoint_evento_posterior.TabIndex = 49;
            // 
            // groupBox_peso
            // 
            this.groupBox_peso.Controls.Add(this.textBox_addr_indicador);
            this.groupBox_peso.Controls.Add(this.label37);
            this.groupBox_peso.Controls.Add(this.label36);
            this.groupBox_peso.Controls.Add(this.comboBox_indicador);
            this.groupBox_peso.Controls.Add(this.textBox_passos);
            this.groupBox_peso.Controls.Add(this.button_dosagem_incremental);
            this.groupBox_peso.Controls.Add(this.label28);
            this.groupBox_peso.Controls.Add(this.textBox_peso_total);
            this.groupBox_peso.Controls.Add(this.label35);
            this.groupBox_peso.Controls.Add(this.textBox_incremento);
            this.groupBox_peso.Controls.Add(this.checkBox_dosagem_incremental);
            this.groupBox_peso.Controls.Add(this.label9);
            this.groupBox_peso.Controls.Add(this.textBox_peso_limite);
            this.groupBox_peso.Controls.Add(this.label11);
            this.groupBox_peso.Controls.Add(this.label13);
            this.groupBox_peso.Controls.Add(this.label25);
            this.groupBox_peso.Controls.Add(this.label14);
            this.groupBox_peso.Controls.Add(this.textBox_tempo_on);
            this.groupBox_peso.Controls.Add(this.textBox_corte);
            this.groupBox_peso.Controls.Add(this.label12);
            this.groupBox_peso.Controls.Add(this.label15);
            this.groupBox_peso.Controls.Add(this.textBox_tempo_off);
            this.groupBox_peso.Controls.Add(this.textBox_precorte);
            this.groupBox_peso.Location = new System.Drawing.Point(6, 46);
            this.groupBox_peso.Name = "groupBox_peso";
            this.groupBox_peso.Size = new System.Drawing.Size(323, 204);
            this.groupBox_peso.TabIndex = 68;
            this.groupBox_peso.TabStop = false;
            this.groupBox_peso.Visible = false;
            // 
            // textBox_addr_indicador
            // 
            this.textBox_addr_indicador.Enabled = false;
            this.textBox_addr_indicador.Location = new System.Drawing.Point(261, 110);
            this.textBox_addr_indicador.Name = "textBox_addr_indicador";
            this.textBox_addr_indicador.ReadOnly = true;
            this.textBox_addr_indicador.Size = new System.Drawing.Size(50, 20);
            this.textBox_addr_indicador.TabIndex = 76;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(258, 94);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(53, 13);
            this.label37.TabIndex = 77;
            this.label37.Text = "Endereço";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(122, 94);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(51, 13);
            this.label36.TabIndex = 75;
            this.label36.Text = "Indicador";
            // 
            // comboBox_indicador
            // 
            this.comboBox_indicador.FormattingEnabled = true;
            this.comboBox_indicador.Location = new System.Drawing.Point(125, 109);
            this.comboBox_indicador.Name = "comboBox_indicador";
            this.comboBox_indicador.Size = new System.Drawing.Size(130, 21);
            this.comboBox_indicador.TabIndex = 74;
            this.comboBox_indicador.SelectedIndexChanged += new System.EventHandler(this.comboBox_indicador_SelectedIndexChanged);
            // 
            // textBox_passos
            // 
            this.textBox_passos.Enabled = false;
            this.textBox_passos.Location = new System.Drawing.Point(160, 173);
            this.textBox_passos.Name = "textBox_passos";
            this.textBox_passos.ReadOnly = true;
            this.textBox_passos.Size = new System.Drawing.Size(70, 20);
            this.textBox_passos.TabIndex = 72;
            // 
            // button_dosagem_incremental
            // 
            this.button_dosagem_incremental.Location = new System.Drawing.Point(236, 171);
            this.button_dosagem_incremental.Name = "button_dosagem_incremental";
            this.button_dosagem_incremental.Size = new System.Drawing.Size(75, 23);
            this.button_dosagem_incremental.TabIndex = 73;
            this.button_dosagem_incremental.Text = "Calcular";
            this.button_dosagem_incremental.UseVisualStyleBackColor = true;
            this.button_dosagem_incremental.Click += new System.EventHandler(this.button_dosagem_incremental_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(82, 157);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 13);
            this.label28.TabIndex = 70;
            this.label28.Text = "Incremento";
            // 
            // textBox_peso_total
            // 
            this.textBox_peso_total.Location = new System.Drawing.Point(8, 173);
            this.textBox_peso_total.Name = "textBox_peso_total";
            this.textBox_peso_total.Size = new System.Drawing.Size(70, 20);
            this.textBox_peso_total.TabIndex = 67;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 157);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(31, 13);
            this.label35.TabIndex = 69;
            this.label35.Text = "Total";
            // 
            // textBox_incremento
            // 
            this.textBox_incremento.Location = new System.Drawing.Point(84, 173);
            this.textBox_incremento.Name = "textBox_incremento";
            this.textBox_incremento.Size = new System.Drawing.Size(70, 20);
            this.textBox_incremento.TabIndex = 68;
            // 
            // checkBox_dosagem_incremental
            // 
            this.checkBox_dosagem_incremental.AutoSize = true;
            this.checkBox_dosagem_incremental.Location = new System.Drawing.Point(9, 137);
            this.checkBox_dosagem_incremental.Name = "checkBox_dosagem_incremental";
            this.checkBox_dosagem_incremental.Size = new System.Drawing.Size(129, 17);
            this.checkBox_dosagem_incremental.TabIndex = 66;
            this.checkBox_dosagem_incremental.Text = "Dosagem Incremental";
            this.checkBox_dosagem_incremental.UseVisualStyleBackColor = true;
            this.checkBox_dosagem_incremental.CheckedChanged += new System.EventHandler(this.checkBox_dosagem_automatica_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Pré-Corte";
            // 
            // textBox_peso_limite
            // 
            this.textBox_peso_limite.Location = new System.Drawing.Point(8, 110);
            this.textBox_peso_limite.Name = "textBox_peso_limite";
            this.textBox_peso_limite.Size = new System.Drawing.Size(110, 20);
            this.textBox_peso_limite.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Corte";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(158, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Passos";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 94);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 13);
            this.label25.TabIndex = 45;
            this.label25.Text = "Limite de Segurança";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(200, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = "mseg";
            // 
            // textBox_tempo_on
            // 
            this.textBox_tempo_on.Location = new System.Drawing.Point(124, 32);
            this.textBox_tempo_on.Name = "textBox_tempo_on";
            this.textBox_tempo_on.Size = new System.Drawing.Size(70, 20);
            this.textBox_tempo_on.TabIndex = 37;
            // 
            // textBox_corte
            // 
            this.textBox_corte.Location = new System.Drawing.Point(8, 71);
            this.textBox_corte.Name = "textBox_corte";
            this.textBox_corte.Size = new System.Drawing.Size(110, 20);
            this.textBox_corte.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(122, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Tempo ON";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(199, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "mseg";
            // 
            // textBox_tempo_off
            // 
            this.textBox_tempo_off.Location = new System.Drawing.Point(124, 71);
            this.textBox_tempo_off.Name = "textBox_tempo_off";
            this.textBox_tempo_off.Size = new System.Drawing.Size(70, 20);
            this.textBox_tempo_off.TabIndex = 39;
            // 
            // textBox_precorte
            // 
            this.textBox_precorte.Location = new System.Drawing.Point(8, 32);
            this.textBox_precorte.Name = "textBox_precorte";
            this.textBox_precorte.Size = new System.Drawing.Size(110, 20);
            this.textBox_precorte.TabIndex = 36;
            // 
            // comboBox_evento_posterior_tipo
            // 
            this.comboBox_evento_posterior_tipo.FormattingEnabled = true;
            this.comboBox_evento_posterior_tipo.Location = new System.Drawing.Point(9, 19);
            this.comboBox_evento_posterior_tipo.Name = "comboBox_evento_posterior_tipo";
            this.comboBox_evento_posterior_tipo.Size = new System.Drawing.Size(110, 21);
            this.comboBox_evento_posterior_tipo.TabIndex = 35;
            this.comboBox_evento_posterior_tipo.SelectedIndexChanged += new System.EventHandler(this.comboBox_evento_posterior_tipo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Tipo";
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage11.Controls.Add(this.timeEdit_tempo_limite_total);
            this.tabPage11.Controls.Add(this.comboBox_saida_emergencia);
            this.tabPage11.Controls.Add(this.checkBox_saida);
            this.tabPage11.Controls.Add(this.checkBox_pausar);
            this.tabPage11.Controls.Add(this.checkBox_alerta);
            this.tabPage11.Controls.Add(this.label29);
            this.tabPage11.Controls.Add(this.label19);
            this.tabPage11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(786, 256);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "Segurança";
            // 
            // timeEdit_tempo_limite_total
            // 
            this.timeEdit_tempo_limite_total.EditValue = new System.DateTime(2018, 5, 8, 0, 0, 0, 0);
            this.timeEdit_tempo_limite_total.Location = new System.Drawing.Point(9, 19);
            this.timeEdit_tempo_limite_total.Name = "timeEdit_tempo_limite_total";
            this.timeEdit_tempo_limite_total.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_tempo_limite_total.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_tempo_limite_total.Size = new System.Drawing.Size(67, 20);
            this.timeEdit_tempo_limite_total.TabIndex = 56;
            // 
            // comboBox_saida_emergencia
            // 
            this.comboBox_saida_emergencia.FormattingEnabled = true;
            this.comboBox_saida_emergencia.Location = new System.Drawing.Point(109, 104);
            this.comboBox_saida_emergencia.Name = "comboBox_saida_emergencia";
            this.comboBox_saida_emergencia.Size = new System.Drawing.Size(121, 21);
            this.comboBox_saida_emergencia.TabIndex = 60;
            this.comboBox_saida_emergencia.Visible = false;
            // 
            // checkBox_saida
            // 
            this.checkBox_saida.AutoSize = true;
            this.checkBox_saida.Location = new System.Drawing.Point(9, 106);
            this.checkBox_saida.Name = "checkBox_saida";
            this.checkBox_saida.Size = new System.Drawing.Size(94, 17);
            this.checkBox_saida.TabIndex = 59;
            this.checkBox_saida.Text = "Acionar Saída";
            this.checkBox_saida.UseVisualStyleBackColor = true;
            this.checkBox_saida.CheckedChanged += new System.EventHandler(this.checkBox_saida_CheckedChanged);
            // 
            // checkBox_pausar
            // 
            this.checkBox_pausar.AutoSize = true;
            this.checkBox_pausar.Location = new System.Drawing.Point(9, 82);
            this.checkBox_pausar.Name = "checkBox_pausar";
            this.checkBox_pausar.Size = new System.Drawing.Size(99, 17);
            this.checkBox_pausar.TabIndex = 58;
            this.checkBox_pausar.Text = "Pausar Receita";
            this.checkBox_pausar.UseVisualStyleBackColor = true;
            // 
            // checkBox_alerta
            // 
            this.checkBox_alerta.AutoSize = true;
            this.checkBox_alerta.Location = new System.Drawing.Point(9, 58);
            this.checkBox_alerta.Name = "checkBox_alerta";
            this.checkBox_alerta.Size = new System.Drawing.Size(127, 17);
            this.checkBox_alerta.TabIndex = 57;
            this.checkBox_alerta.Text = "Alerta de Emergência";
            this.checkBox_alerta.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 42);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(32, 13);
            this.label29.TabIndex = 62;
            this.label29.Text = "Ação";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "Tempo Limite";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeEdit_intervalo);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.comboBox_repeticao);
            this.groupBox1.Controls.Add(this.label_intervalo);
            this.groupBox1.Controls.Add(this.textBox_vezes);
            this.groupBox1.Controls.Add(this.label_vezez);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox_linhas);
            this.groupBox1.Controls.Add(this.textBox_endereco);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox_device);
            this.groupBox1.Controls.Add(this.textBox_nome_receita);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 66);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações da Receita";
            // 
            // timeEdit_intervalo
            // 
            this.timeEdit_intervalo.EditValue = "00:00:00";
            this.timeEdit_intervalo.Location = new System.Drawing.Point(842, 33);
            this.timeEdit_intervalo.Name = "timeEdit_intervalo";
            this.timeEdit_intervalo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_intervalo.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_intervalo.Size = new System.Drawing.Size(112, 20);
            this.timeEdit_intervalo.TabIndex = 8;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(695, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 13);
            this.label32.TabIndex = 14;
            this.label32.Text = "Repetição";
            // 
            // comboBox_repeticao
            // 
            this.comboBox_repeticao.FormattingEnabled = true;
            this.comboBox_repeticao.ItemHeight = 13;
            this.comboBox_repeticao.Location = new System.Drawing.Point(695, 32);
            this.comboBox_repeticao.Name = "comboBox_repeticao";
            this.comboBox_repeticao.Size = new System.Drawing.Size(80, 21);
            this.comboBox_repeticao.TabIndex = 6;
            this.comboBox_repeticao.SelectedIndexChanged += new System.EventHandler(this.comboBox_repeticao_SelectedIndexChanged);
            // 
            // label_intervalo
            // 
            this.label_intervalo.AutoSize = true;
            this.label_intervalo.Location = new System.Drawing.Point(839, 16);
            this.label_intervalo.Name = "label_intervalo";
            this.label_intervalo.Size = new System.Drawing.Size(115, 13);
            this.label_intervalo.TabIndex = 16;
            this.label_intervalo.Text = "Intervalo de Repetição";
            // 
            // textBox_vezes
            // 
            this.textBox_vezes.Location = new System.Drawing.Point(781, 32);
            this.textBox_vezes.Name = "textBox_vezes";
            this.textBox_vezes.Size = new System.Drawing.Size(55, 20);
            this.textBox_vezes.TabIndex = 7;
            // 
            // label_vezez
            // 
            this.label_vezez.AutoSize = true;
            this.label_vezez.Location = new System.Drawing.Point(778, 16);
            this.label_vezez.Name = "label_vezez";
            this.label_vezez.Size = new System.Drawing.Size(36, 13);
            this.label_vezez.TabIndex = 15;
            this.label_vezez.Text = "Vezes";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(636, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Linhas";
            // 
            // textBox_linhas
            // 
            this.textBox_linhas.Enabled = false;
            this.textBox_linhas.Location = new System.Drawing.Point(639, 32);
            this.textBox_linhas.Name = "textBox_linhas";
            this.textBox_linhas.ReadOnly = true;
            this.textBox_linhas.Size = new System.Drawing.Size(50, 20);
            this.textBox_linhas.TabIndex = 5;
            // 
            // textBox_endereco
            // 
            this.textBox_endereco.Enabled = false;
            this.textBox_endereco.Location = new System.Drawing.Point(583, 32);
            this.textBox_endereco.Name = "textBox_endereco";
            this.textBox_endereco.ReadOnly = true;
            this.textBox_endereco.Size = new System.Drawing.Size(50, 20);
            this.textBox_endereco.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(580, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Endereço";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(424, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Dispositivo";
            // 
            // comboBox_device
            // 
            this.comboBox_device.FormattingEnabled = true;
            this.comboBox_device.ItemHeight = 13;
            this.comboBox_device.Location = new System.Drawing.Point(427, 31);
            this.comboBox_device.Name = "comboBox_device";
            this.comboBox_device.Size = new System.Drawing.Size(150, 21);
            this.comboBox_device.TabIndex = 3;
            this.comboBox_device.SelectedIndexChanged += new System.EventHandler(this.comboBox_device_SelectedIndexChanged);
            // 
            // textBox_nome_receita
            // 
            this.textBox_nome_receita.Location = new System.Drawing.Point(70, 32);
            this.textBox_nome_receita.Name = "textBox_nome_receita";
            this.textBox_nome_receita.Size = new System.Drawing.Size(351, 20);
            this.textBox_nome_receita.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nome da Receita";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID Receita";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(9, 32);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(55, 20);
            this.textBox_id.TabIndex = 1;
            // 
            // Form_receita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 653);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_receita";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receitas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_receita_FormClosing);
            this.Load += new System.EventHandler(this.Form_receita_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_receitas)).EndInit();
            this.contextMenuStrip_receita.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_itens_receita)).EndInit();
            this.contextMenuStrip_etapas_receita.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_tempo_espera_evento_anterior.Properties)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox_tempo.ResumeLayout(false);
            this.groupBox_tempo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_tempo_evento_posterior.Properties)).EndInit();
            this.groupBox_entrada.ResumeLayout(false);
            this.groupBox_entrada.PerformLayout();
            this.groupBox_peso.ResumeLayout(false);
            this.groupBox_peso.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_tempo_limite_total.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_intervalo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem receitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarReceitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarReceitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pausarReceitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pararReceitaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_itens_receita;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox_etapa;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox comboBox_produto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_rele;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_processo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox comboBox_evento_anterior_tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBox_peso_limite;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_precorte;
        private System.Windows.Forms.TextBox textBox_corte;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_tempo_on;
        private System.Windows.Forms.TextBox textBox_tempo_off;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radioButton_OFF_evento_posterior;
        private System.Windows.Forms.RadioButton radioButton_ON_evento_posterior;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBox_evento_posterior_tipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox comboBox_repeticao;
        private System.Windows.Forms.Label label_intervalo;
        private System.Windows.Forms.TextBox textBox_vezes;
        private System.Windows.Forms.Label label_vezez;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_linhas;
        private System.Windows.Forms.TextBox textBox_endereco;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_device;
        private System.Windows.Forms.TextBox textBox_nome_receita;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.ToolStripMenuItem novaReceitaToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_receitas;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusDosDispositivosToolStripMenuItem;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox_saida_emergencia;
        private System.Windows.Forms.CheckBox checkBox_saida;
        private System.Windows.Forms.CheckBox checkBox_pausar;
        private System.Windows.Forms.CheckBox checkBox_alerta;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_etapas_receita;
        private System.Windows.Forms.ToolStripMenuItem novaEtapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarEtapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private DevExpress.XtraEditors.TimeEdit timeEdit_intervalo;
        private DevExpress.XtraEditors.TimeEdit timeEdit_tempo_espera_evento_anterior;
        private DevExpress.XtraEditors.TimeEdit timeEdit_tempo_evento_posterior;
        private DevExpress.XtraEditors.TimeEdit timeEdit_tempo_limite_total;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_IO_evento_anterior;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_setpoint_evento_anterior;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RadioButton radioButton_ON_evento_anterior;
        private System.Windows.Forms.RadioButton radioButton_OFF_evento_anterior;
        private System.Windows.Forms.GroupBox groupBox_entrada;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox_setpoint_limite_evento_posterior;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox comboBox_IO_evento_posterior;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox_setpoint_evento_posterior;
        private System.Windows.Forms.GroupBox groupBox_peso;
        private System.Windows.Forms.GroupBox groupBox_tempo;
        private System.Windows.Forms.ToolStripMenuItem exportarReceitaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_receita;
        private System.Windows.Forms.ToolStripMenuItem adicionarreceitatoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirreceitatoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarreceitatoolStripMenuItem;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox_velocidade_hz;
        private System.Windows.Forms.CheckBox checkBox_velocidade;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox_addr_inversor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBox_inversor;
        private System.Windows.Forms.ComboBox comboBox_estado_saida;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adionarItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarItemToolStripMenuItem;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox_peso_total;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox_incremento;
        private System.Windows.Forms.CheckBox checkBox_dosagem_incremental;
        private System.Windows.Forms.Button button_dosagem_incremental;
        private System.Windows.Forms.TextBox textBox_passos;
        private System.Windows.Forms.Button button_pausar_receita;
        private System.Windows.Forms.Button button_executar_receita;
        private System.Windows.Forms.Button button_parar_receita;
        private System.Windows.Forms.Button button_enviar_receita;
        private System.Windows.Forms.Button button_copiar;
        private System.Windows.Forms.Button button_add_item;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox comboBox_indicador;
        private System.Windows.Forms.ToolStripMenuItem resetarControlMixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarDataEHoraToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_addr_indicador;
        private System.Windows.Forms.Label label37;
    }
}