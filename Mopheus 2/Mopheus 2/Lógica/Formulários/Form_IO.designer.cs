namespace Mopheus_2
{
    partial class Form_IO
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
            this.comboBox_IO = new System.Windows.Forms.ComboBox();
            this.comboBox_device = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.dataGridView_IO = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_funcao = new System.Windows.Forms.ComboBox();
            this.comboBox_produto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IO)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_IO
            // 
            this.comboBox_IO.FormattingEnabled = true;
            this.comboBox_IO.Location = new System.Drawing.Point(430, 25);
            this.comboBox_IO.Name = "comboBox_IO";
            this.comboBox_IO.Size = new System.Drawing.Size(120, 21);
            this.comboBox_IO.TabIndex = 4;
            // 
            // comboBox_device
            // 
            this.comboBox_device.FormattingEnabled = true;
            this.comboBox_device.Location = new System.Drawing.Point(178, 25);
            this.comboBox_device.Name = "comboBox_device";
            this.comboBox_device.Size = new System.Drawing.Size(120, 21);
            this.comboBox_device.TabIndex = 2;
            this.comboBox_device.SelectedIndexChanged += new System.EventHandler(this.comboBox_device_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dispositivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "I/O";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(556, 25);
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(300, 20);
            this.textBox_description.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Descrição";
            // 
            // button_save
            // 
            this.button_save.Image = global::Mopheus_2.Properties.Resources.Save_16x_32;
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(862, 23);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Salvar";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // dataGridView_IO
            // 
            this.dataGridView_IO.AllowUserToAddRows = false;
            this.dataGridView_IO.AllowUserToDeleteRows = false;
            this.dataGridView_IO.AllowUserToResizeColumns = false;
            this.dataGridView_IO.AllowUserToResizeRows = false;
            this.dataGridView_IO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_IO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IO.Location = new System.Drawing.Point(12, 52);
            this.dataGridView_IO.Name = "dataGridView_IO";
            this.dataGridView_IO.ReadOnly = true;
            this.dataGridView_IO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_IO.Size = new System.Drawing.Size(925, 397);
            this.dataGridView_IO.TabIndex = 13;
            this.dataGridView_IO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_IO_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 26);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Image = global::Mopheus_2.Properties.Resources.Cancel_16x;
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo";
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(304, 25);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(120, 21);
            this.comboBox_tipo.TabIndex = 3;
            this.comboBox_tipo.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Função";
            // 
            // comboBox_funcao
            // 
            this.comboBox_funcao.FormattingEnabled = true;
            this.comboBox_funcao.Location = new System.Drawing.Point(12, 25);
            this.comboBox_funcao.Name = "comboBox_funcao";
            this.comboBox_funcao.Size = new System.Drawing.Size(160, 21);
            this.comboBox_funcao.TabIndex = 1;
            this.comboBox_funcao.SelectedIndexChanged += new System.EventHandler(this.comboBox_funcao_SelectedIndexChanged);
            // 
            // comboBox_produto
            // 
            this.comboBox_produto.FormattingEnabled = true;
            this.comboBox_produto.Location = new System.Drawing.Point(556, 52);
            this.comboBox_produto.Name = "comboBox_produto";
            this.comboBox_produto.Size = new System.Drawing.Size(300, 21);
            this.comboBox_produto.TabIndex = 6;
            // 
            // Form_IO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 461);
            this.Controls.Add(this.comboBox_produto);
            this.Controls.Add(this.comboBox_funcao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_tipo);
            this.Controls.Add(this.dataGridView_IO);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_device);
            this.Controls.Add(this.comboBox_IO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_IO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas e Saídas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IO)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_IO;
        private System.Windows.Forms.ComboBox comboBox_device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridView dataGridView_IO;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_tipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_funcao;
        private System.Windows.Forms.ComboBox comboBox_produto;
    }
}