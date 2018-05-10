using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mopheus_2
{
    public partial class DEVICE_PROPERTIES : Form
    {
        public DEVICE_PROPERTIES(string name,string model,string baud_rate,int addr)
        {
            InitializeComponent();

            comboBox_Speed.Items.Add("9600");
            comboBox_Speed.Items.Add("19200");
            comboBox_Speed.Items.Add("38400");
            comboBox_Speed.Items.Add("57600");
            comboBox_Speed.Items.Add("115200");

            textBox_addr_device.Text = addr.ToString();
            textBox_name_device.Text = name;
            comboBox_Speed.Text = baud_rate;
        }
    }
}
