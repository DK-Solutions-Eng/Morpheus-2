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
            //// Create a new object, representing the Brazilian culture.  
            //CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");

            //// The following line provides localization for the application's user interface.  
            //Thread.CurrentThread.CurrentUICulture = culture;

            //// The following line provides localization for data formats.  
            //Thread.CurrentThread.CurrentCulture = culture;

            //// Set this culture as the default culture for all threads in this application.  
            //// Note: The following properties are supported in the .NET Framework 4.5+ 
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            Form_Splash frmSplash = new Form_Splash();
            frmSplash.Show();
            Application.DoEvents();
            Thread.Sleep(2000);
            frmSplash.Dispose();

            Form_LOGIN login = new Form_LOGIN();
            //login.Show();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form_MAIN());
            }
        }

        
        
    }
}
