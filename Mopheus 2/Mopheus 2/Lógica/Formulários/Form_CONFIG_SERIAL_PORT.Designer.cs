namespace Mopheus_2
{
    partial class Form_CONFIG_SERIAL_PORT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CONFIG_SERIAL_PORT));
            this.button_conectar = new System.Windows.Forms.Button();
            this.comboBox_porta_arduino = new System.Windows.Forms.ComboBox();
            this.comboBox_Speed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_rx = new System.Windows.Forms.TextBox();
            this.textBox_tx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_clear_tx = new System.Windows.Forms.Button();
            this.button_clear_rx = new System.Windows.Forms.Button();
            this.checkBox_continuous = new System.Windows.Forms.CheckBox();
            this.checkBox_CR_LF = new System.Windows.Forms.CheckBox();
            this.button_enviar = new System.Windows.Forms.Button();
            this.checkBox_limpar = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_conectar
            // 
            this.button_conectar.Location = new System.Drawing.Point(268, 99);
            this.button_conectar.Name = "button_conectar";
            this.button_conectar.Size = new System.Drawing.Size(100, 37);
            this.button_conectar.TabIndex = 5;
            this.button_conectar.Text = "CONECTAR";
            this.button_conectar.UseVisualStyleBackColor = true;
            this.button_conectar.Click += new System.EventHandler(this.button_conectar_Click);
            // 
            // comboBox_porta_arduino
            // 
            this.comboBox_porta_arduino.FormattingEnabled = true;
            this.comboBox_porta_arduino.Location = new System.Drawing.Point(268, 32);
            this.comboBox_porta_arduino.Name = "comboBox_porta_arduino";
            this.comboBox_porta_arduino.Size = new System.Drawing.Size(100, 21);
            this.comboBox_porta_arduino.TabIndex = 3;
            // 
            // comboBox_Speed
            // 
            this.comboBox_Speed.FormattingEnabled = true;
            this.comboBox_Speed.Location = new System.Drawing.Point(268, 72);
            this.comboBox_Speed.Name = "comboBox_Speed";
            this.comboBox_Speed.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Speed.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PORTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "VELOCIDADE";
            // 
            // textBox_rx
            // 
            this.textBox_rx.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_rx.Location = new System.Drawing.Point(9, 48);
            this.textBox_rx.Multiline = true;
            this.textBox_rx.Name = "textBox_rx";
            this.textBox_rx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_rx.Size = new System.Drawing.Size(250, 148);
            this.textBox_rx.TabIndex = 1;
            // 
            // textBox_tx
            // 
            this.textBox_tx.Location = new System.Drawing.Point(9, 231);
            this.textBox_tx.Multiline = true;
            this.textBox_tx.Name = "textBox_tx";
            this.textBox_tx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_tx.Size = new System.Drawing.Size(250, 148);
            this.textBox_tx.TabIndex = 6;
            this.textBox_tx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_tx_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "RECEPÇÃO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "TRANSMISSÃO:";
            // 
            // button_clear_tx
            // 
            this.button_clear_tx.Location = new System.Drawing.Point(184, 202);
            this.button_clear_tx.Name = "button_clear_tx";
            this.button_clear_tx.Size = new System.Drawing.Size(75, 23);
            this.button_clear_tx.TabIndex = 7;
            this.button_clear_tx.Text = "Limpa TX";
            this.button_clear_tx.UseVisualStyleBackColor = true;
            this.button_clear_tx.Click += new System.EventHandler(this.button_clear_tx_Click);
            // 
            // button_clear_rx
            // 
            this.button_clear_rx.Location = new System.Drawing.Point(184, 19);
            this.button_clear_rx.Name = "button_clear_rx";
            this.button_clear_rx.Size = new System.Drawing.Size(75, 23);
            this.button_clear_rx.TabIndex = 2;
            this.button_clear_rx.Text = "Limpa RX";
            this.button_clear_rx.UseVisualStyleBackColor = true;
            this.button_clear_rx.Click += new System.EventHandler(this.button_clear_rx_Click);
            // 
            // checkBox_continuous
            // 
            this.checkBox_continuous.AutoSize = true;
            this.checkBox_continuous.Location = new System.Drawing.Point(268, 319);
            this.checkBox_continuous.Name = "checkBox_continuous";
            this.checkBox_continuous.Size = new System.Drawing.Size(100, 17);
            this.checkBox_continuous.TabIndex = 9;
            this.checkBox_continuous.Text = "Envio Contínuo";
            this.checkBox_continuous.UseVisualStyleBackColor = true;
            this.checkBox_continuous.CheckedChanged += new System.EventHandler(this.checkBox_Continuos_CheckedChanged);
            // 
            // checkBox_CR_LF
            // 
            this.checkBox_CR_LF.AutoSize = true;
            this.checkBox_CR_LF.Location = new System.Drawing.Point(268, 296);
            this.checkBox_CR_LF.Name = "checkBox_CR_LF";
            this.checkBox_CR_LF.Size = new System.Drawing.Size(58, 17);
            this.checkBox_CR_LF.TabIndex = 8;
            this.checkBox_CR_LF.Text = "CR/LF";
            this.checkBox_CR_LF.UseVisualStyleBackColor = true;
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(268, 342);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(100, 37);
            this.button_enviar.TabIndex = 10;
            this.button_enviar.Text = "ENVIAR";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // checkBox_limpar
            // 
            this.checkBox_limpar.AutoSize = true;
            this.checkBox_limpar.Location = new System.Drawing.Point(268, 273);
            this.checkBox_limpar.Name = "checkBox_limpar";
            this.checkBox_limpar.Size = new System.Drawing.Size(104, 17);
            this.checkBox_limpar.TabIndex = 11;
            this.checkBox_limpar.Text = "Limpar ao enviar";
            this.checkBox_limpar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button_conectar);
            this.groupBox2.Controls.Add(this.button_clear_rx);
            this.groupBox2.Controls.Add(this.comboBox_porta_arduino);
            this.groupBox2.Controls.Add(this.textBox_rx);
            this.groupBox2.Controls.Add(this.comboBox_Speed);
            this.groupBox2.Controls.Add(this.checkBox_limpar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_tx);
            this.groupBox2.Controls.Add(this.button_enviar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBox_CR_LF);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkBox_continuous);
            this.groupBox2.Controls.Add(this.button_clear_tx);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 388);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Testes";
            // 
            // timerCOM
            // 
            this.timerCOM.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_CONFIG_SERIAL_PORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 409);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CONFIG_SERIAL_PORT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunicação";
            this.Load += new System.EventHandler(this.Form_CONFIG_SERIAL_PORT_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_conectar;
        private System.Windows.Forms.ComboBox comboBox_porta_arduino;
        private System.Windows.Forms.ComboBox comboBox_Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_rx;
        private System.Windows.Forms.TextBox textBox_tx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_clear_tx;
        private System.Windows.Forms.Button button_clear_rx;
        private System.Windows.Forms.CheckBox checkBox_continuous;
        private System.Windows.Forms.CheckBox checkBox_CR_LF;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.CheckBox checkBox_limpar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerCOM;
    }
}