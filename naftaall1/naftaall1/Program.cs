using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace naftaall1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         public static string ConnectionString; 
        [STAThread]

        static void Main()
        {

            // Load connection string from config at startup

            // Load the saved connection string




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }

    }
}
