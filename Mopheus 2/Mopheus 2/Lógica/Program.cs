using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Globalization;

namespace Mopheus_2
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form_Splash frmSplash = new Form_Splash();
            frmSplash.Show();
            Application.DoEvents();
            
            Thread.Sleep(2000);

           //Fecha formulário de apresentação

            frmSplash.Dispose();

            //Inicia a aplicação com o Form_MAIN
            Application.Run(new Form_MAIN());            
        }

        
        
    }
}
