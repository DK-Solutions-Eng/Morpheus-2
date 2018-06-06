namespace Mopheus_2
{
    partial class Form_MATERIA_PRIMA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MATERIA_PRIMA));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_descricao_full = new System.Windows.Forms.TextBox();
            this.textBox_descricao_half = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_codigo_sistema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_mp = new System.Windows.Forms.DataGridView();
            this.button_save = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mp)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição Completa";
            // 
            // textBox_descricao_full
            // 
            this.textBox_descricao_full.Location = new System.Drawing.Point(12, 25);
            this.textBox_descricao_full.Name = "textBox_descricao_full";
            this.textBox_descricao_full.Size = new System.Drawing.Size(300, 20);
            this.textBox_descricao_full.TabIndex = 1;
            // 
            // textBox_descricao_half
            // 
            this.textBox_descricao_half.Location = new System.Drawing.Point(318, 25);
            this.textBox_descricao_half.Name = "textBox_descricao_half";
            this.textBox_descricao_half.Size = new System.Drawing.Size(120, 20);
            this.textBox_descricao_half.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição Resumida";
            // 
            // textBox_codigo_sistema
            // 
            this.textBox_codigo_sistema.Location = new System.Drawing.Point(444, 25);
            this.textBox_codigo_sistema.Name = "textBox_codigo_sistema";
            this.textBox_codigo_sistema.Size = new System.Drawing.Size(120, 20);
            this.textBox_codigo_sistema.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Código Sistema";
            // 
            // dataGridView_mp
            // 
            this.dataGridView_mp.AllowUserToAddRows = false;
            this.dataGridView_mp.AllowUserToDeleteRows = false;
            this.dataGridView_mp.AllowUserToResizeColumns = false;
            this.dataGridView_mp.AllowUserToResizeRows = false;
            this.dataGridView_mp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_mp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mp.Location = new System.Drawing.Point(12, 51);
            this.dataGridView_mp.Name = "dataGridView_mp";
            this.dataGridView_mp.ReadOnly = true;
            this.dataGridView_mp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_mp.Size = new System.Drawing.Size(633, 498);
            this.dataGridView_mp.TabIndex = 6;
            this.dataGridView_mp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_mp_MouseClick);
            // 
            // button_save
            // 
            this.button_save.Image = global::Mopheus_2.Properties.Resources.Save_16x_32;
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(570, 22);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Salvar";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
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
            // Form_MATERIA_PRIMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 561);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.dataGridView_mp);
            this.Controls.Add(this.textBox_codigo_sistema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_descricao_half);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_descricao_full);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MATERIA_PRIMA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Matéria Prima";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mp)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_descricao_full;
        private System.Windows.Forms.TextBox textBox_descricao_half;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_codigo_sistema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_mp;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
    }
}