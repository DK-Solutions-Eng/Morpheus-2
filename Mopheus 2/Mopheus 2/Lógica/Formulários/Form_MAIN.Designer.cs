namespace Mopheus_2
{
    partial class Form_MAIN
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MAIN));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lerLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusDosDispositivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçãoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradaESaídasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matériaPrimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçãoToolStripMenuItem,
            this.configuraçãoToolStripMenuItem1,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.receitaToolStripMenuItem,
            this.lerLogsToolStripMenuItem,
            this.carregamentoToolStripMenuItem,
            this.statusDosDispositivosToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.configuraçãoToolStripMenuItem.Text = "Exibir";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Login_16x;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+L";
            this.loginToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // receitaToolStripMenuItem
            // 
            this.receitaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.EditPage_16x_32;
            this.receitaToolStripMenuItem.Name = "receitaToolStripMenuItem";
            this.receitaToolStripMenuItem.ShortcutKeyDisplayString = "F2";
            this.receitaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.receitaToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.receitaToolStripMenuItem.Text = "Receita";
            this.receitaToolStripMenuItem.Click += new System.EventHandler(this.receitaToolStripMenuItem_Click);
            // 
            // lerLogsToolStripMenuItem
            // 
            this.lerLogsToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.DownloadFile_16x;
            this.lerLogsToolStripMenuItem.Name = "lerLogsToolStripMenuItem";
            this.lerLogsToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.lerLogsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.lerLogsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.lerLogsToolStripMenuItem.Text = "Logs";
            this.lerLogsToolStripMenuItem.Click += new System.EventHandler(this.lerLogsToolStripMenuItem_Click);
            // 
            // carregamentoToolStripMenuItem
            // 
            this.carregamentoToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.LineArrow_16x;
            this.carregamentoToolStripMenuItem.Name = "carregamentoToolStripMenuItem";
            this.carregamentoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.carregamentoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.carregamentoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.carregamentoToolStripMenuItem.Text = "Carregamento";
            this.carregamentoToolStripMenuItem.Click += new System.EventHandler(this.carregamentoToolStripMenuItem_Click);
            // 
            // statusDosDispositivosToolStripMenuItem
            // 
            this.statusDosDispositivosToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.StatusAlert_16x;
            this.statusDosDispositivosToolStripMenuItem.Name = "statusDosDispositivosToolStripMenuItem";
            this.statusDosDispositivosToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.statusDosDispositivosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.statusDosDispositivosToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.statusDosDispositivosToolStripMenuItem.Text = "Status dos Dispositivos";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Close_16x;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.sairToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // configuraçãoToolStripMenuItem1
            // 
            this.configuraçãoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comunicaçãoToolStripMenuItem,
            this.redeStripMenuItem,
            this.entradaESaídasToolStripMenuItem,
            this.matériaPrimaToolStripMenuItem,
            this.fornecedoresToolStripMenuItem,
            this.usuáriosToolStripMenuItem});
            this.configuraçãoToolStripMenuItem1.Name = "configuraçãoToolStripMenuItem1";
            this.configuraçãoToolStripMenuItem1.Size = new System.Drawing.Size(91, 20);
            this.configuraçãoToolStripMenuItem1.Text = "Configuração";
            // 
            // comunicaçãoToolStripMenuItem
            // 
            this.comunicaçãoToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.SerialPort_16x;
            this.comunicaçãoToolStripMenuItem.Name = "comunicaçãoToolStripMenuItem";
            this.comunicaçãoToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.comunicaçãoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.comunicaçãoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.comunicaçãoToolStripMenuItem.Text = "Comunicação";
            this.comunicaçãoToolStripMenuItem.Click += new System.EventHandler(this.comunicaçãoToolStripMenuItem_Click);
            // 
            // redeStripMenuItem
            // 
            this.redeStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Network_16x;
            this.redeStripMenuItem.Name = "redeStripMenuItem";
            this.redeStripMenuItem.ShortcutKeyDisplayString = "F6";
            this.redeStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.redeStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.redeStripMenuItem.Text = "Rede";
            this.redeStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // entradaESaídasToolStripMenuItem
            // 
            this.entradaESaídasToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.InputOutput_16x;
            this.entradaESaídasToolStripMenuItem.Name = "entradaESaídasToolStripMenuItem";
            this.entradaESaídasToolStripMenuItem.ShortcutKeyDisplayString = "F7";
            this.entradaESaídasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.entradaESaídasToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.entradaESaídasToolStripMenuItem.Text = "Entrada e Saídas";
            this.entradaESaídasToolStripMenuItem.Click += new System.EventHandler(this.entradaESaídasToolStripMenuItem_Click);
            // 
            // matériaPrimaToolStripMenuItem
            // 
            this.matériaPrimaToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.CSTest_16x;
            this.matériaPrimaToolStripMenuItem.Name = "matériaPrimaToolStripMenuItem";
            this.matériaPrimaToolStripMenuItem.ShortcutKeyDisplayString = "F8";
            this.matériaPrimaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.matériaPrimaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.matériaPrimaToolStripMenuItem.Text = "Matéria Prima";
            this.matériaPrimaToolStripMenuItem.Click += new System.EventHandler(this.matériaPrimaToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.ComponentInstallStatus_16x;
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.ShortcutKeyDisplayString = "F9";
            this.fornecedoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.User_noHalo_16x;
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+U";
            this.usuáriosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.Click += new System.EventHandler(this.usuáriosToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.HelpApplication_16x_32;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.UIAboutBox_16x_32;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "STATUS";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "USUÁRIO";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "Morpheus 2";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Morpheus 2";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel3.Text = "ACESSO";
            // 
            // Form_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mopheus_2.Properties.Resources.logo_aeph_do_brasil_back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_MAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AEPH do Brasil - Morpheus 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_PRINCIPAL_FormClosing);
            this.Load += new System.EventHandler(this.Form_PRINCIPAL_Load);
            this.Resize += new System.EventHandler(this.Form_MAIN_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem comunicaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradaESaídasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem redeStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem lerLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matériaPrimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem statusDosDispositivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem carregamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

