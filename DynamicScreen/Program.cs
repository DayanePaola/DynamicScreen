using System;
using System.Windows.Forms;

namespace DynamicScreen
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var connString = "Server=127.0.0.1;Port=5432;Database=DynamicScreen;User Id=DynamicScreen;Password=dinscr@123;";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(connString));
        }
    }
}