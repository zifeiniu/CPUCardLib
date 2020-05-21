using CPUCardLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUCardTestFrm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (false)
            {
                CPUCardTest.TestFileNew();
                //CPUCardTest.ReadALlCard();

                //CPUCardTest.TestMain();
                Console.Read();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmCardTest());
            }
            
        }

        

    }
}
