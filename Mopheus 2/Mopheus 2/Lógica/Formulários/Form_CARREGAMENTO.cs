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

namespace Mopheus_2
{
    public partial class Form_CARREGAMENTO : Form
    {
        CarregamentoBLL carregamentobll = new CarregamentoBLL("Carregamento");
        Carregamento carregamento;

        FornecedorBLL bllfornecedor = new FornecedorBLL("Fornecedor");
        Fornecedor fornecedor;

        Usuario user = new Usuario();
        UsuarioBLL usuariobll = new UsuarioBLL("Usuario");

        
        Materia_PrimaBLL mpbll = new Materia_PrimaBLL("Produto");
        Materia_Prima mp;

        public Form_CARREGAMENTO()
        {
            InitializeComponent();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("FORNECEDOR: " + comboBox_Fornecedor.Text, drawFont, drawBrush, 10, 45);
            e.Graphics.DrawString("NF: " + textBox_NumeroNota.Text, drawFont, drawBrush, 10, 57);
            e.Graphics.DrawString("PRODUTO: " + comboBox_Produto.Text, drawFont, drawBrush, 10, 69);
            e.Graphics.DrawString("PESO NF:" + textBox_PesoNota.Text + " KG", drawFont, drawBrush, 10, 81);
            e.Graphics.DrawString("PL: " + textBox_PesoReal.Text + " KG", drawFont, drawBrush, 10, 93);

            //e.Graphics.DrawString(pesoinicial.ToString() + " - " + listitenscarregamento.OrderBy(p => p.id).FirstOrDefault().data_inicial, drawFont, drawBrush, 10, 105);
            //e.Graphics.DrawString("PESO LIQUIDO FINAL", drawFont, drawBrush, 10, 117);
            //e.Graphics.DrawString((pesofinal + pesoinicial).ToString() + " - " + listitenscarregamento.OrderByDescending(p => p.id).FirstOrDefault().data_final, drawFont, drawBrush, 10, 129);

            e.Graphics.DrawString("DIF. DA NF:" + textBox_DiferencaNota.Text + " KG", drawFont, drawBrush, 10, 105);
            e.Graphics.DrawString("TARA:" + textBox_tara.Text + " KG", drawFont, drawBrush, 10, 117);
            //e.Graphics.DrawString(txtDiferencaNota.Text, drawFont, drawBrush, 10, 153);
            e.Graphics.DrawString("RESP.: " + comboBox_recebedor.Text, drawFont, drawBrush, 10, 129);
        }
    }
}
