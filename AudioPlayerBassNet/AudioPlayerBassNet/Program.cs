using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AudioPlayerBassNet
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Presenters presenter = new Presenters(new Form1());
            Application.Run();
        }
    }
}
