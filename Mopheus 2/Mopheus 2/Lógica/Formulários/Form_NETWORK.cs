using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Entidades;
using BLL;
using System.Globalization;
using System.Threading;
using System.Configuration;


namespace Mopheus_2
{
    public partial class Form_REDE : Form

    {
        //public int controlmix_id_treeview = 1;
        //public int addr_controlmix;
        //public int indicador_id_treeview;
        //public int expansao_id_treeview;

        NetworkBLL bll = new NetworkBLL("Network");
        Network device = new Network();

        public Form_REDE()
        {
            InitializeComponent();

            populate_image_list();

            load_xmlfile_network();

            atualiza("");

            comboBox_Speed.Items.Add("9600");
            comboBox_Speed.Items.Add("19200");
            comboBox_Speed.Items.Add("38400");
            comboBox_Speed.Items.Add("57600");
            comboBox_Speed.Items.Add("115200");
        }

        public void populate_image_list()
        {
            imageList_rede.Images.Add(Image.FromFile("pc.png"));
            imageList_rede.Images.Add(Image.FromFile("clp.png"));
            imageList_rede.Images.Add(Image.FromFile("balanca.png"));
            imageList_rede.Images.Add(Image.FromFile("inversor.jpg"));
            treeView_rede.ImageList = imageList_rede;
            TreeNode root = treeView_rede.Nodes.Add(System.Windows.Forms.SystemInformation.ComputerName);
            root.ImageIndex = root.SelectedImageIndex = 0;
            treeView_rede.Refresh();
        }

        private void treeView_rede_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode id = treeView_rede.GetNodeAt(e.X, e.Y);

            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:

                    break;

                case System.Windows.Forms.MouseButtons.Right:
                    treeView_rede.SelectedNode = id;

                    if (id != null)
                    {
                        if (id.Text == System.Windows.Forms.SystemInformation.ComputerName)
                        {
                            ToolStripMenuItem addControlMIXLabel = new ToolStripMenuItem();
                            novoControlMIXToolStripMenuItem.Visible = true;
                            novoInversorToolStripMenuItem.Visible = false;
                            novoIndicadorToolStripMenuItem.Visible = false;
                            novaExpansãoToolStripMenuItem.Visible = false;
                            excluirToolStripMenuItem.Visible = false;
                            propriedadesToolStripMenuItem.Visible = true;
                        }

                        if (id.Text.IndexOf("ControlMix") != -1)
                        {
                            ToolStripMenuItem addControlMIXLabel = new ToolStripMenuItem();
                            novoControlMIXToolStripMenuItem.Visible = false;
                            novoInversorToolStripMenuItem.Visible = true;
                            novoIndicadorToolStripMenuItem.Visible = true;
                            novaExpansãoToolStripMenuItem.Visible = true;
                            excluirToolStripMenuItem.Visible = true;
                            propriedadesToolStripMenuItem.Visible = true;
                        }

                        if (id.Text.IndexOf("Indicador") != -1)
                        {
                            ToolStripMenuItem addControlMIXLabel = new ToolStripMenuItem();
                            novoControlMIXToolStripMenuItem.Visible = false;
                            novoInversorToolStripMenuItem.Visible = false;
                            novoIndicadorToolStripMenuItem.Visible = false;
                            novaExpansãoToolStripMenuItem.Visible = false;
                            excluirToolStripMenuItem.Visible = true;
                            propriedadesToolStripMenuItem.Visible = true;
                        }
                        if (id.Text.IndexOf("Inversor") != -1)
                        {
                            ToolStripMenuItem addControlMIXLabel = new ToolStripMenuItem();
                            novoControlMIXToolStripMenuItem.Visible = false;
                            novoInversorToolStripMenuItem.Visible = false;
                            novoIndicadorToolStripMenuItem.Visible = false;
                            novaExpansãoToolStripMenuItem.Visible = false;
                            excluirToolStripMenuItem.Visible = true;
                            propriedadesToolStripMenuItem.Visible = true;
                        }
                    }
                    break;
            }
        }

        public void novoControlMIXToolStripMenuItem_Click(object sender, EventArgs e)
        {


            TreeNode newNode = new TreeNode("ControlMix");
            newNode.ImageIndex = 1;
            newNode.ImageIndex = newNode.SelectedImageIndex = 1;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "ControlMix";
            device.type_model = "5-DI/12-RO";
            device.type_control = "MODBUS-RTU";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            newNode.Text = newNode.Text + "-" + device.name;
            device.full_name = newNode.Text;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));
            device.parent = newNode.Parent.ToString();
            device.baud_rate = 19200;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            device.dateinsert = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
            bll.insert(device);

            MessageBox.Show("Configuração salva com sucesso!");

            atualiza("");

        }

        private void novoIndicadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Indicador");
            newNode.ImageIndex = 2;
            newNode.ImageIndex = newNode.SelectedImageIndex = 2;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "Indicador";
            device.type_model = "Matrix";
            device.type_control = "MODBUS-RTU";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            newNode.Text = newNode.Text + "-" + device.name;
            device.full_name = newNode.Text;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            device.dateinsert = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
            device.parent = newNode.Parent.ToString();
            device.baud_rate = 19200;
            bll.insert(device);

            MessageBox.Show("Configuração salva com sucesso!");

            atualiza("");
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_rede.SelectedNode.Name != System.Windows.Forms.SystemInformation.ComputerName)
            {


                DataTable dt = bll.getAll(treeView_rede.SelectedNode.Text, "full_name");
                if (dt == null)
                {
                    //bll.insert(device);
                    //dt = bll.getAll(treeView_rede.SelectedNode.Text, "name");
                    return;
                }
                device = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

                //textBox_addr_device.Text = device.addr.ToString();
                //comboBox_Speed.Text = device.baud_rate.ToString();
                //textBox_name_device.Text = device.name;
                //comboBox_Speed.Text = device.baud_rate.ToString();
                //treeView_rede.Refresh();
                bll.delete(device.id);
                treeView_rede.SelectedNode.Remove();
            }

        }

        private void novaExpansãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Expansão");
            newNode.ImageIndex = 1;
            newNode.ImageIndex = newNode.SelectedImageIndex = 1;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "Expansão";
            device.type_model = "0-DI/12-RO";
            device.type_control = "MODBUS-RTU";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            newNode.Text = newNode.Text + "-" + device.name;
            device.full_name = newNode.Text;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            device.dateinsert = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
            device.parent = newNode.Parent.ToString();
            device.baud_rate = 19200;
            bll.insert(device);

            MessageBox.Show("Configuração salva com sucesso!");

            atualiza("");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = Application.StartupPath + @"Network.xml";
            if (saveFile.ShowDialog() != DialogResult.OK) return;

            TreeViewSerializer serializer = new TreeViewSerializer();
            serializer.SerializeTreeView(this.treeView_rede, saveFile.FileName);
        }

        private void btnLoad_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = Application.StartupPath + "|DataDirectory|\network.xml";
            if (openFile.ShowDialog() != DialogResult.OK) return;
            this.treeView_rede.Nodes.Clear();
            TreeViewSerializer serializer = new TreeViewSerializer();
            serializer.DeserializeTreeView(this.treeView_rede, openFile.FileName);
            treeView_rede.ExpandAll();
        }

        private void button_save_config_Click(object sender, EventArgs e)
        {

        }

        private void Form_REDE_Load(object sender, EventArgs e)
        {

        }

        public void load_xmlfile_network()
        {
            List<Network> list = bll.getAllCustom();
            if (list.Count == 0)
            {
                return;
            }
            else
            {
                try
                {


                    if (System.IO.File.Exists(@"network.xml"))
                    {
                        this.treeView_rede.Nodes.Clear();
                        TreeViewSerializer serializer = new TreeViewSerializer();
                        serializer.DeserializeTreeView(this.treeView_rede, @"network.xml");
                        treeView_rede.ExpandAll();
                    }
                }

                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message.ToString(), "Atenção!");
                    TreeNode root = treeView_rede.Nodes.Add(System.Windows.Forms.SystemInformation.ComputerName);
                    root.ImageIndex = root.SelectedImageIndex = 0;
                }
            }
        }

        private void Form_REDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveFileDialog saveFile = new SaveFileDialog();
            //saveFile.FileName = Application.StartupPath + @"Network.xml";
            //if (saveFile.ShowDialog() != DialogResult.OK) return;

            TreeViewSerializer serializer = new TreeViewSerializer();
            serializer.SerializeTreeView(treeView_rede, @"network.xml");
        }

        public void atualiza(string filtro)
        {
            int linhaSelecionada = 0, primeiraLinha = 0;
            if (dataGridView1.CurrentRow != null)
            {
                primeiraLinha = dataGridView1.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = dataGridView1.CurrentRow.Index;
            }
            dataGridView1.DataSource = bll.getAll(filtro, "addr");
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void treeView_rede_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (treeView_rede.SelectedNode.Text != System.Windows.Forms.SystemInformation.ComputerName)
            //{
            //    DataTable dt = bll.getAll(treeView_rede.SelectedNode.Text, "full_name");
            //    if (dt == null)
            //    {
            //        //bll.insert(device);
            //        //dt = bll.getAll(treeView_rede.SelectedNode.Text, "name");
            //        return;
            //    }
            //    device = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

            //    textBox_addr_device.Text = device.addr.ToString();
            //    comboBox_Speed.Text = device.baud_rate.ToString();
            //    textBox_name_device.Text = device.name;
            //    comboBox_Speed.Text = device.baud_rate.ToString();
            //    treeView_rede.Refresh();
            //}

            //DEVICE_PROPERTIES _PROPERTIES = new DEVICE_PROPERTIES(device.name, device.model, device.baud_rate.ToString(), device.addr);
            //_PROPERTIES.ShowDialog();

        }

        private void propriedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_rede.SelectedNode.Text != System.Windows.Forms.SystemInformation.ComputerName)
            {
                DataTable dt = bll.getAll(treeView_rede.SelectedNode.Text, "full_name");
                if (dt == null)
                {
                    //bll.insert(device);
                    //dt = bll.getAll(treeView_rede.SelectedNode.Text, "name");
                    return;
                }
                device = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

                //textBox_addr_device.Text = device.addr.ToString();
                //comboBox_Speed.Text = device.baud_rate.ToString();
                //textBox_name_device.Text = device.name;
                //comboBox_Speed.Text = device.baud_rate.ToString();
                //treeView_rede.Refresh();
            }

            DEVICE_PROPERTIES _PROPERTIES = new DEVICE_PROPERTIES(device.id, device.name, device.model, device.type_model, device.type_control, device.full_name, device.addr, device.baud_rate, device.parent, device.dateinsert, device.dateupdate);
            _PROPERTIES.ShowDialog();
        }

        private void treeView_rede_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void novoInversorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Inversor");
            newNode.ImageIndex = 3;
            newNode.ImageIndex = newNode.SelectedImageIndex = 3;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "Inversor";
            device.type_model = "OMROM MX2";
            device.type_control = "MODBUS-RTU";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            newNode.Text = newNode.Text + "-" + device.name;
            device.full_name = newNode.Text;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));
            device.parent = newNode.Parent.ToString();
            device.baud_rate = 19200;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            device.dateinsert = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);
            bll.insert(device);

            MessageBox.Show("Configuração salva com sucesso!");

            atualiza("");

        }
    }
}
