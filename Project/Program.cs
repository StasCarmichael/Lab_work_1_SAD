using System;
using System.Configuration;
using System.Windows.Forms;

using PL;

namespace Project
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var idCodeBuilderPath = ConfigurationManager.AppSettings.Get("CodeBuilderPath");
            var dbPath = ConfigurationManager.AppSettings.Get("DBPath");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DataManagementForm(idCodeBuilderPath, dbPath));
        }
    }
}
