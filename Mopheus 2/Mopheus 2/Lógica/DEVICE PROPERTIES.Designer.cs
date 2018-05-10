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
            this.SuspendLayout();
            // 
            // comboBox_Speed
            // 
            this.comboBox_Speed.FormattingEnabled = true;
            this.comboBox_Speed.Location = new System.Drawing.Point(118, 65);
            this.comboBox_Speed.Name = "comboBox_Speed";
            this.comboBox_Speed.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Speed.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Velocidade";
            // 
            // button_save_config
            // 
            this.button_save_config.Location = new System.Drawing.Point(91, 96);
            this.button_save_config.Name = "button_save_config";
            this.button_save_config.Size = new System.Drawing.Size(75, 23);
            this.button_save_config.TabIndex = 11;
            this.button_save_config.Text = "Salvar";
            this.button_save_config.UseVisualStyleBackColor = true;
            // 
            // textBox_name_device
            // 
            this.textBox_name_device.Location = new System.Drawing.Point(12, 26);
            this.textBox_name_device.Name = "textBox_name_device";
            this.textBox_name_device.Size = new System.Drawing.Size(228, 20);
            this.textBox_name_device.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome do Dispositivo";
            // 
            // textBox_addr_device
            // 
            this.textBox_addr_device.Location = new System.Drawing.Point(12, 66);
            this.textBox_addr_device.Name = "textBox_addr_device";
            this.textBox_addr_device.Size = new System.Drawing.Size(100, 20);
            this.textBox_addr_device.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Endereço na Rede";
            // 
            // DEVICE_PROPERTIES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 126);
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
    }
}