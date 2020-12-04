using DynamicScreen.Data;
using System;
using System.Windows.Forms;

namespace DynamicScreen
{
    static class Program
    {
        public static Context _context;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            _context = new Context();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(_context));
        }
    }
}