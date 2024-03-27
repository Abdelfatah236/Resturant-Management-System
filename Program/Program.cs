using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    static class Program
    {
        public static string n = "abdelfatah";
        public static int p = 2020;
        public static bool f = false;
        public static int ord;


        [STAThread]
        static void Main()
        {
   

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form5());
           
        }
    }
}
