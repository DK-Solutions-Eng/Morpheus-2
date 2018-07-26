namespace Mopheus_2
{
    partial class DEVICE_PROPERTIES
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
            this.comboBox_Speed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save_config = new System.Windows.Forms.Button();
            this.textBox_name_device = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_addr_device = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_type_model = new System.Windows.Forms.ComboBox();
            this.comboBox_type_control = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_Speed
            // 
            this.comboBox_Speed.FormattingEnabled = true;
            this.comboBox_Speed.Location = new System.Drawing.Point(118, 65);
            this.comboBox_Speed.Name = "comboBox_Speed";
            this.comboBox_Speed.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Speed.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Velocidade";
            // 
            // button_save_config
            // 
            this.button_save_config.Image = global::Mopheus_2.Properties.Resources.Save_16x_32;
            this.button_save_config.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save_config.Location = new System.Drawing.Point(179, 102);
            this.button_save_config.Name = "button_save_config";
            this.button_save_config.Size = new System.Drawing.Size(63, 23);
            this.button_save_config.TabIndex = 5;
            this.button_save_config.Text = "Salvar";
            this.button_save_config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save_config.UseVisualStyleBackColor = true;
            this.button_save_config.Click += new System.EventHandler(this.button_save_config_Click);
            // 
            // textBox_name_device
            // 
            this.textBox_name_device.Location = new System.Drawing.Point(12, 26);
            this.textBox_name_device.Name = "textBox_name_device";
            this.textBox_name_device.Size = new System.Drawing.Size(228, 20);
            this.textBox_name_device.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome do Dispositivo";
            // 
            // textBox_addr_device
            // 
            this.textBox_addr_device.Location = new System.Drawing.Point(12, 66);
            this.textBox_addr_device.Name = "textBox_addr_device";
            this.textBox_addr_device.Size = new System.Drawing.Size(100, 20);
            this.textBox_addr_device.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Endereço na Rede";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Modelo";
            // 
            // comboBox_type_model
            // 
            this.comboBox_type_model.FormattingEnabled = true;
            this.comboBox_type_model.Location = new System.Drawing.Point(246, 25);
            this.comboBox_type_model.Name = "comboBox_type_model";
            this.comboBox_type_model.Size = new System.Drawing.Size(160, 21);
            this.comboBox_type_model.TabIndex = 2;
            // 
            // comboBox_type_control
            // 
            this.comboBox_type_control.FormattingEnabled = true;
            this.comboBox_type_control.Location = new System.Drawing.Point(246, 65);
            this.comboBox_type_control.Name = "comboBox_type_control";
            this.comboBox_type_control.Size = new System.Drawing.Size(160, 21);
            this.comboBox_type_control.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo de Controle";
            // 
            // DEVICE_PROPERTIES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 137);
            this.Controls.Add(this.comboBox_type_control);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_type_model);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Speed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_save_config);
            this.Controls.Add(this.textBox_name_device);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_addr_device);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DEVICE_PROPERTIES";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propriedades";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Speed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_save_config;
        private System.Windows.Forms.TextBox textBox_name_device;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_addr_device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_type_model;
        private System.Windows.Forms.ComboBox comboBox_type_control;
        private System.Windows.Forms.Label label5;
    }
}