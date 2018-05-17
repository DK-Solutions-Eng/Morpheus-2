using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;
using System.Globalization;
using System.Threading;
using System.Configuration;


namespace Mopheus_2
{
    public partial class DEVICE_PROPERTIES : Form
    {
        NetworkBLL bll = new NetworkBLL("Network");
        Network device = new Network();

        public DEVICE_PROPERTIES(int id, string name, string model, string type_model, string full_name, int addr, int baud_rate, string parent, DateTime? dateinsert, DateTime? dateupdate)
        {
            InitializeComponent();
            load_components(name, model, baud_rate, addr,type_model);


            device.id = id;
            device.name = name;
            device.model = model;
            device.baud_rate = baud_rate;
            device.addr = addr;
            device.full_name = full_name;
            device.type_model = type_model;
            device.dateinsert = dateinsert;
            device.dateupdate = dateupdate;
            device.parent = parent;



        }

        private void load_components(string name, string model, int baud_rate, int addr,string type_model)
        {
            comboBox_Speed.Items.Add("9600");
            comboBox_Speed.Items.Add("19200");
            comboBox_Speed.Items.Add("38400");
            comboBox_Speed.Items.Add("57600");
            comboBox_Speed.Items.Add("115200");
            load_models(model);

            textBox_addr_device.Text = addr.ToString();
            textBox_name_device.Text = name;
            comboBox_Speed.Text = baud_rate.ToString();
            comboBox_type_model.SelectedIndex = (comboBox_type_model.FindStringExact(type_model));            
        }
        private void load_models(string model)
        {
            switch (model)
            {
                case "ControlMix":
                    comboBox_type_model.Items.Clear();
                    comboBox_type_model.Items.Add("5-DI/12-RO");
                    
                    if(Global.god_mode)
                    {
                        comboBox_type_model.Items.Add("4-DI/1-AI-12-RO");
                        comboBox_type_model.Items.Add("3-DI/2-AI-12-RO");
                        comboBox_type_model.Items.Add("2-DI/3-AI-12-RO");
                        comboBox_type_model.Items.Add("1-DI/4-AI-12-RO");
                        comboBox_type_model.Items.Add("0-DI/5-AI-12-RO");
                        comboBox_type_model.Items.Add("4-DI/1-AI-12-RO");
                    }
                    comboBox_type_model.SelectedIndex = 0;
                    break;
                case "Expansão":
                    comboBox_type_model.Items.Clear();
                    comboBox_type_model.Items.Add("0-DI/12-RO");
                    comboBox_type_model.Items.Add("8-DI/9-RO");
                    comboBox_type_model.Items.Add("4-TC");
                    comboBox_type_model.Items.Add("4-AI");
                    comboBox_type_model.SelectedIndex = 0;
                    break;
                case "Indicador":
                    comboBox_type_model.Items.Clear();
                    comboBox_type_model.Items.Add("Matrix");
                    comboBox_type_model.Items.Add("Onix");
                    comboBox_type_model.Items.Add("Orion");
                    comboBox_type_model.SelectedIndex = 0;
                    break;
            }
        }

        private void button_save_config_Click(object sender, EventArgs e)
        {
            device.name = textBox_name_device.Text;
            device.type_model = comboBox_type_model.Text;
            device.addr = Convert.ToInt32(textBox_addr_device.Text);
            device.baud_rate = Convert.ToInt32(comboBox_Speed.Text);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            device.dateupdate = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

            bll.update(device);

            this.Close();
            
        }
    }
}
