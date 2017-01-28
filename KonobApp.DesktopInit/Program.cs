using KonobApp.Controller;
using KonobApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonobApp.DesktopInit
{
    class Program
    {
        static void Main(string[] args)
        {
            MainController controller = new MainController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainWindow(controller));
        }
    }
}
