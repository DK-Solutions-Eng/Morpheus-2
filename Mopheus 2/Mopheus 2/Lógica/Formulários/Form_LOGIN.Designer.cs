namespace Mopheus_2
{
    partial class Form_LOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LOGIN));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_senha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 25);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(234, 20);
            this.textBox_login.TabIndex = 1;
            this.textBox_login.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_login_KeyUp);
            // 
            // textBox_senha
            // 
            this.textBox_senha.Location = new System.Drawing.Point(12, 64);
            this.textBox_senha.Name = "textBox_senha";
            this.textBox_senha.PasswordChar = '*';
            this.textBox_senha.Size = new System.Drawing.Size(234, 20);
            this.textBox_senha.TabIndex = 3;
            this.textBox_senha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_senha_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // button_login
            // 
            this.button_login.Image = global::Mopheus_2.Properties.Resources.Login_16x;
            this.button_login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_login.Location = new System.Drawing.Point(40, 90);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Image = global::Mopheus_2.Properties.Resources.Cancel_16x;
            this.button_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cancel.Location = new System.Drawing.Point(139, 90);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 122);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_senha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_senha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_cancel;
    }
}