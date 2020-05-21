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
    public partial class FrmCardTest : Form
    {
        public FrmCardTest()
        {
            InitializeComponent();
        }

        public ushort GetCurrentFileID() 
        {
            return Convert.ToUInt16(txtFileName.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            CPUCardWrapper.CreateFile(GetCurrentFileID(), txtInput.Text, out string msg);
            WireLog(msg);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CPUCardWrapper.DeleteFile(GetCurrentFileID()))
            {
                WireLog("删除成功");
            }
            else
            {
                WireLog("删除失败");
            }
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (CPUCardWrapper.ReadFile(GetCurrentFileID(),out string msg))
            {
                txtoutput.Text = msg;
                WireLog("读取成功"+ msg);
            }
            else
            {
                txtoutput.Text = "读取失败" + msg;
                WireLog("读取失败" + msg);
            }
        }

        private void FrmCardTest_Load(object sender, EventArgs e)
        {
            CPUCardWrapper.WriteLog("开始");
            CPUCardWrapper.cpuCard.ShowLog += WireLog;
        }

        public void WireLog(string log) 
        {
            txtLog.AppendText(log);
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ASCII = Encoding.ASCII.GetString(CPUCardHelper.ConverToBytes(textBox1.Text));
            WireLog("ASCII ：" + ASCII + "\r\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            CPUCardWrapper.cpuCard.CardSendCommand(CPUCardHelper.ConverToBytes(txtCMD.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            for (ushort i = 1; i < 20; i++)
            {
                string data = GetRandomData(r.Next(100, 1000));
                CPUCardWrapper.CreateFile(i, data, out string msg);
            }

         
        }

        Random r = new Random();

        public string GetRandomData(int lenght) 
        {
             StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                sb.Append(r.Next(0, 9));
            }
            return sb.ToString();
        
        }
    }
}
