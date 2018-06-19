namespace Mopheus_2
{
    partial class Form_FORNECEDOR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FORNECEDOR));
            this.button_save = new System.Windows.Forms.Button();
            this.dataGridView_fornecedor = new System.Windows.Forms.DataGridView();
            this.textBox_nome_resumido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nome_completo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fornecedor)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.Image = global::Mopheus_2.Properties.Resources.Save_16x_32;
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(444, 22);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 12;
            this.button_save.Text = "Salvar";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // dataGridView_fornecedor
            // 
            this.dataGridView_fornecedor.AllowUserToAddRows = false;
            this.dataGridView_fornecedor.AllowUserToDeleteRows = false;
            this.dataGridView_fornecedor.AllowUserToResizeColumns = false;
            this.dataGridView_fornecedor.AllowUserToResizeRows = false;
            this.dataGridView_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_fornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_fornecedor.Location = new System.Drawing.Point(12, 51);
            this.dataGridView_fornecedor.Name = "dataGridView_fornecedor";
            this.dataGridView_fornecedor.ReadOnly = true;
            this.dataGridView_fornecedor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_fornecedor.Size = new System.Drawing.Size(507, 498);
            this.dataGridView_fornecedor.TabIndex = 14;
            this.dataGridView_fornecedor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_fornecedor_MouseClick);
            // 
            // textBox_nome_resumido
            // 
            this.textBox_nome_resumido.Location = new System.Drawing.Point(318, 25);
            this.textBox_nome_resumido.Name = "textBox_nome_resumido";
            this.textBox_nome_resumido.Size = new System.Drawing.Size(120, 20);
            this.textBox_nome_resumido.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nome Resumido";
            // 
            // textBox_nome_completo
            // 
            this.textBox_nome_completo.Location = new System.Drawing.Point(12, 25);
            this.textBox_nome_completo.Name = "textBox_nome_completo";
            this.textBox_nome_completo.Size = new System.Drawing.Size(300, 20);
            this.textBox_nome_completo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome Completo";
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
            // Form_FORNECEDOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 561);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.dataGridView_fornecedor);
            this.Controls.Add(this.textBox_nome_resumido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nome_completo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_FORNECEDOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fornecedor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fornecedor)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridView dataGridView_fornecedor;
        private System.Windows.Forms.TextBox textBox_nome_resumido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_nome_completo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
    }
}