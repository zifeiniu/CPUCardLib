using CPUCardLib;
using CYYFSystem.Public.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUCardTestFrm
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int max = Convert.ToInt32(textBox2.Text);

            DeCardReader deCardReader = new DeCardReader();
            CpuCard CardReader = new CpuCard(deCardReader);


            for (ushort i = 1; i <= max; i++)
            {
                //ApduMsg msg = CardReader.SelectFileById(i);
                if (CardReader.ReadFile(i, out string msg))
                {
                   // DataSet ds =   ZipHelper.GetDatasetByString(msg);

                    textBox1.AppendText( i + "成功:" + msg +"\r\n");

                    
                }
                else
                {
                    textBox1.AppendText(i + "失败:" + msg + "\r\n");
                }

                
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int max = Convert.ToInt32(textBox2.Text);

            DeCardReader deCardReader = new DeCardReader();
            CpuCard CardReader = new CpuCard(deCardReader);


            for (ushort i = 1; i <= max; i++)
            {

               ApduMsg m= CardReader.DeleteFile(i);

                
                textBox1.AppendText("删除文件:" + i + "\r\n");
                


            }
        }
    }
}
