using System;
using System.Windows.Forms;

namespace nothinbutdotnet.concepts
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
            Application.Run(new Form1(new SecuredComponent(new OurServiceLayerComponent(new BasicDataAccess()))));
        }
    }
}