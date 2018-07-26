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
    public partial class Form_Splash : Form
    {
        public Form_Splash()
        {
            InitializeComponent();
        }

        private void Form_Splash_Load(object sender, EventArgs e)
        {
            System.Threading.Mutex hSolution = null;
            // verifica se programa já está rodando
            try
            {
                hSolution = System.Threading.Mutex.OpenExisting("Morpheus 2.exe");
            }
            catch (System.Threading.WaitHandleCannotBeOpenedException)
            {
                // Não existe Instancia do programa aberto
            }

            if (hSolution == null)
            {
                hSolution = new System.Threading.Mutex(true, "Morpheus 2.exe");
                this.Refresh();
            }
            else
            {
                this.Visible = false;
                MessageBox.Show("O Programa já está em Execução! Verifique na barra de notificações se o programa encontra-se minimizado", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}
