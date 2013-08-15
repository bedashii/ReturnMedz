using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolisticsCommander
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("IsServer")))
                Application.Run(new ServerForm());
            else
                Application.Run(new ClientForm());
        }
    }
}
