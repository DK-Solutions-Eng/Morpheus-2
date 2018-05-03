namespace Mopheus_2
{
    partial class Form_REDE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_REDE));
            this.treeView_rede = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novoControlMIXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoIndicadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaExpansãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propriedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_rede = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Speed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save_config = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_addr_device = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_rede
            // 
            this.treeView_rede.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView_rede.ImageIndex = 0;
            this.treeView_rede.ImageList = this.imageList_rede;
            this.treeView_rede.Location = new System.Drawing.Point(12, 27);
            this.treeView_rede.Name = "treeView_rede";
            this.treeView_rede.SelectedImageIndex = 0;
            this.treeView_rede.ShowNodeToolTips = true;
            this.treeView_rede.Size = new System.Drawing.Size(250, 300);
            this.treeView_rede.TabIndex = 4;
            this.treeView_rede.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView_rede_MouseClick);
            this.treeView_rede.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_rede_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoControlMIXToolStripMenuItem,
            this.novoIndicadorToolStripMenuItem,
            this.novaExpansãoToolStripMenuItem,
            this.excluirToolStripMenuItem,
            this.propriedadesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 114);
            // 
            // novoControlMIXToolStripMenuItem
            // 
            this.novoControlMIXToolStripMenuItem.Name = "novoControlMIXToolStripMenuItem";
            this.novoControlMIXToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.novoControlMIXToolStripMenuItem.Text = "Novo ControlMix";
            this.novoControlMIXToolStripMenuItem.Click += new System.EventHandler(this.novoControlMIXToolStripMenuItem_Click);
            // 
            // novoIndicadorToolStripMenuItem
            // 
            this.novoIndicadorToolStripMenuItem.Name = "novoIndicadorToolStripMenuItem";
            this.novoIndicadorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.novoIndicadorToolStripMenuItem.Text = "Novo Indicador";
            this.novoIndicadorToolStripMenuItem.Click += new System.EventHandler(this.novoIndicadorToolStripMenuItem_Click);
            // 
            // novaExpansãoToolStripMenuItem
            // 
            this.novaExpansãoToolStripMenuItem.Name = "novaExpansãoToolStripMenuItem";
            this.novaExpansãoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.novaExpansãoToolStripMenuItem.Text = "Nova Expansão";
            this.novaExpansãoToolStripMenuItem.Click += new System.EventHandler(this.novaExpansãoToolStripMenuItem_Click);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
            // 
            // propriedadesToolStripMenuItem
            // 
            this.propriedadesToolStripMenuItem.Name = "propriedadesToolStripMenuItem";
            this.propriedadesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.propriedadesToolStripMenuItem.Text = "Propriedades";
            // 
            // imageList_rede
            // 
            this.imageList_rede.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_rede.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_rede.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(516, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarToolStripMenuItem,
            this.salvarToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // carregarToolStripMenuItem
            // 
            this.carregarToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.OpenFolder_16x;
            this.carregarToolStripMenuItem.Name = "carregarToolStripMenuItem";
            this.carregarToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.carregarToolStripMenuItem.Text = "Carregar";
            this.carregarToolStripMenuItem.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Save_16x_32;
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Speed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_save_config);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_addr_device);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(268, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 162);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Propriedades";
            // 
            // comboBox_Speed
            // 
            this.comboBox_Speed.FormattingEnabled = true;
            this.comboBox_Speed.Location = new System.Drawing.Point(113, 36);
            this.comboBox_Speed.Name = "comboBox_Speed";
            this.comboBox_Speed.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Speed.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Velocidade";
            // 
            // button_save_config
            // 
            this.button_save_config.Location = new System.Drawing.Point(82, 119);
            this.button_save_config.Name = "button_save_config";
            this.button_save_config.Size = new System.Drawing.Size(75, 23);
            this.button_save_config.TabIndex = 4;
            this.button_save_config.Text = "Salvar";
            this.button_save_config.UseVisualStyleBackColor = true;
            this.button_save_config.Click += new System.EventHandler(this.button_save_config_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome do Dispositivo";
            // 
            // textBox_addr_device
            // 
            this.textBox_addr_device.Location = new System.Drawing.Point(7, 37);
            this.textBox_addr_device.Name = "textBox_addr_device";
            this.textBox_addr_device.Size = new System.Drawing.Size(100, 20);
            this.textBox_addr_device.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Endereço na Rede";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(516, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(406, 302);
            this.dataGridView1.TabIndex = 8;
            // 
            // Form_REDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 341);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeView_rede);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_REDE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rede";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_REDE_FormClosing);
            this.Load += new System.EventHandler(this.Form_REDE_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView_rede;
        private System.Windows.Forms.ImageList imageList_rede;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoControlMIXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoIndicadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propriedadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaExpansãoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_addr_device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Speed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_save_config;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}