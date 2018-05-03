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
        public int controlmix_id_treeview = 1;
        public int addr_controlmix;
        public int indicador_id_treeview;
        public int expansao_id_treeview;

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
            //imageList_rede.Images.Add(Image.FromFile("pc.png"));
            //imageList_rede.Images.Add(Image.FromFile("clp.png"));
            //imageList_rede.Images.Add(Image.FromFile("balanca.png"));
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
                            novoIndicadorToolStripMenuItem.Visible = false;
                            novaExpansãoToolStripMenuItem.Visible = false;
                            excluirToolStripMenuItem.Visible = false;
                            propriedadesToolStripMenuItem.Visible = true;
                        }

                        if (id.Text.IndexOf("ControlMix") != -1)
                        {
                            ToolStripMenuItem addControlMIXLabel = new ToolStripMenuItem();
                            novoControlMIXToolStripMenuItem.Visible = false;
                            novoIndicadorToolStripMenuItem.Visible = true;
                            novaExpansãoToolStripMenuItem.Visible = true;
                            excluirToolStripMenuItem.Visible = true;
                            propriedadesToolStripMenuItem.Visible = true;
                        }

                        if (id.Text.IndexOf("Indicador") != -1)
                        {
                            ToolStripMenuItem addControlMIXLabel = new ToolStripMenuItem();
                            novoControlMIXToolStripMenuItem.Visible = false;
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
            newNode.ImageIndex = newNode.SelectedImageIndex = 1;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "ControlMIX";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            //newNode.Text = newNode.Text + "-" + device.name;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            device.dateinsert = DateTime.Now;
            bll.insert(device);
            MessageBox.Show("Configuração salva com sucesso!");

            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

            atualiza("");



        }

        private void novoIndicadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Indicador");
            newNode.ImageIndex = newNode.SelectedImageIndex = 2;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "Indicador";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            //newNode.Text = newNode.Text + "-" + device.name;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            device.dateinsert = DateTime.Now;
            bll.insert(device);
            MessageBox.Show("Configuração salva com sucesso!");

            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

            atualiza("");
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView_rede.SelectedNode.Remove();
        }

        private void novaExpansãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Expansão");
            newNode.ImageIndex = newNode.SelectedImageIndex = 1;
            treeView_rede.SelectedNode.Nodes.Add(newNode);
            treeView_rede.ExpandAll();
            treeView_rede.Refresh();

            device.model = "Expansão";
            device.name = Interaction.InputBox("Insira o nome do Dispositivo!", "Nome do Dispositivo");
            //newNode.Text = newNode.Text + "-" + device.name;
            device.addr = Convert.ToInt32(Interaction.InputBox("Insira o endereço do nó!", "Endereço do Dispositivo", "0"));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            device.dateinsert = DateTime.Now;
            bll.insert(device);
            MessageBox.Show("Configuração salva com sucesso!");

            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["current"]);

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

        private void treeView_rede_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(treeView_rede.SelectedNode.Name);
        }

        private void Form_REDE_Load(object sender, EventArgs e)
        {

        }

        public void load_xmlfile_network()
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

        private void Form_REDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveFileDialog saveFile = new SaveFileDialog();
            //saveFile.FileName = Application.StartupPath + @"Network.xml";
            //if (saveFile.ShowDialog() != DialogResult.OK) return;

            TreeViewSerializer serializer = new TreeViewSerializer();
            serializer.SerializeTreeView(this.treeView_rede, @"network.xml");
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
    }
}
