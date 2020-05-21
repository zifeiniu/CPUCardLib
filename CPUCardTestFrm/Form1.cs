using CPUCardLib; 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUCardTestFrm
{
    public partial class Form1 : Form
    {


        CpuCard CardReader = null;

        public Form1()
        {
            InitializeComponent(); 
            //SetAllCardReader();
        }

        public void SetAllCardReader()
        {
            //初始化设备，订阅日志
            PcscCardReader device = new PcscCardReader();
            string[] dd = device.GetAllReader();
            comboBox1.Items.AddRange(device.GetAllReader());

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

       
        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*”";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtContent.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UseDeCard();
        }

        /// <summary>
        /// 使用德卡读卡器
        /// </summary>
        public void UseDeCard()
        {
            DeCardReader deCardReader = new DeCardReader();
            CardReader = new CpuCard(deCardReader);
            CardReader.ShowLog += this.ShowLog;
        }



        /// <summary>
        /// 使用标准的PCSC设备
        /// </summary>
        public void SelectPCSCDevice()
        {
            //if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
            //{
            //    PcscCardReader device = new PcscCardReader();
            //    device.CardReaderName = comboBox1.SelectedItem.ToString();
            //    if (!device.OpenReader(out string msg))
            //    {
            //        MessageBox.Show(msg);
            //    }
            //    else
            //    {
            //        CardReader = new CpuCard(device);
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.Auth(txtPwd.Text);
            DisplayLog(msg);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.SelectFileName(txtFileName.Text);
            DisplayLog(msg);
        }

        public ushort GetFileID()
        {
            if (ushort.TryParse(txtFileName.Text, out ushort resut))
            {
                return resut;
            }
            MessageBox.Show("文件ID请输入数字");
            return 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.SelectFileById(GetFileID());
            DisplayLog(msg);
        }

        public ushort GetFixFileID() 
        {

            return (ushort)100;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.CreateFile(GetFixFileID(), CPUFileType.BinFile, txtContent.Text.Length);
            DisplayLog(msg);
        }

        public void ShowLog( string log)
        {
            txtLog.AppendText(log);
        }


        public void DisplayLog(ApduMsg apduMsg)
        {
            return;
            if (apduMsg != null)
            {
                string msg = "----------------------\r\n状态:{0}  信息:{1} 结果:{2} \r\n";

                txtLog.AppendText(string.Format(msg, apduMsg.Status, apduMsg.Msg, BitConverter.ToString(apduMsg.ResponseData)));
            } 
        }

        private void button11_Click(object sender, EventArgs e)
        {

            CardReader.ReadFile(GetFixFileID(), out string msg);
            txtRead.Text = msg;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.CreateAndWriteContent(GetFileID(), txtContent.Text);
            DisplayLog(msg);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CardReader.SendCommand(txtCMd.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("命令有误");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.RemoveDF();
            DisplayLog(msg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.SelectMF();
            DisplayLog(msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UseDeCard();
            SelectPCSCDevice();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = CPUCardHelper.ConverToBytes(txtCMd.Text);

                ApduCommand cmd = new ApduCommand(data);
                txtLog.AppendText("解析命令:" + cmd.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.WriteContent(GetFixFileID(), txtContent.Text);

            DisplayLog(msg);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            CardReader.GetALlFiles();
        }

        /// <summary>
        /// 长安通 公交卡  A00000000386980701
        /// </summary>
        byte[] ChangAnTongName = { (byte) 0xA0, (byte) 0x00,
(byte) 0x00, (byte) 0x00, (byte) 0x03, (byte) 0x86, (byte) 0x98,
(byte) 0x07, (byte) 0x01, };
         
        private void button17_Click(object sender, EventArgs e)
        {
            CardReader.SelectFileName("1PAY.SYS.DDF01"); 
            CardReader.SelectFileName(ChangAnTongName);
            ApduMsg msg = CardReader.GetBalance(true);
            if (msg.IsSuccess)
            {
               byte[] data =  msg.GetData();
                if (data.Length == 4)
                {
                    double Balance = ((data[0] << (8 * 3)) + (data[1] << (8 * 2)) + (data[2] << (8 * 1)) + data[3]) / 100.0;
                    labYue.Text = "公交卡余额为" + Balance;
                    return;
                }
            }
            labYue.Text = "读取失败";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //创建目录
            ApduMsg msg = CardReader.CreateFile(200, CPUFileType.MFDF, txtContent.Text.Length);

            DisplayLog(msg);
        }




        private void button19_Click(object sender, EventArgs e)
        {

            CardReader.CreateDFFile(GetFileID(), 100); 
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ApduMsg msg1 = CardReader.SelectDFFile(GetFileID());
            DisplayLog(msg1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string ASCII = Encoding.ASCII.GetString(CPUCardHelper.ConverToBytes(txtCMd.Text));
            ShowLog("ASCII ：" + ASCII+"\r\n");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //CardReader.Auth()
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.SelectFileById(GetFixFileID());
            DisplayLog(msg);
        }
    }
     
}
