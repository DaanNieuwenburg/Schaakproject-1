using System;
using System.Windows.Forms;
using System.Drawing;

namespace Schaakproject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Color _border = Color.SandyBrown;
            Color _vakje1 = Color.FromArgb(255, 224, 192);
            Color _vakje2 = Color.SaddleBrown;
            Color _select = Color.HotPink;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Hoofdmenu(_border, _select, _vakje1, _vakje2));

        }
    }
}
