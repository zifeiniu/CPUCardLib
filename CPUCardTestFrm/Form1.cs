using CPUCardLib; 
using PscsCardReaderLib;
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


        PcscCardReader device = null;

        CpuCard CardReader = null;

        public Form1()
        {
            InitializeComponent();

            //初始化设备，订阅日志
            device = new PcscCardReader();

            CPUCardLogHelper.logAction += CPUCardLogHelper_logAction; ;


            string[] dd = device.GetAllReader();
            comboBox1.Items.AddRange(device.GetAllReader());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
             
        }

        private void CPUCardLogHelper_logAction(LogInfo obj)
        {
            this.Invoke(new Action(()=> {
                  
                 
                txtLog.AppendText("###LOG###" + obj.ToString() + "\r\n");

            }));
            
        } 

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*”";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                txtContent.Text = File.ReadAllText(openFileDialog1.FileName,Encoding.Default);
            }
        }
         

        private void button3_Click(object sender, EventArgs e)
        {
            SelectDevice();
        }

        public void SelectDevice()
        {
            
            if (true)
            {
                //使用德卡
                DeCardReader deCardReader = new DeCardReader();
                CardReader = new CpuCard(deCardReader);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
                {
                    device.CardReaderName = comboBox1.SelectedItem.ToString();
                    if (!device.OpenReader(out string msg))
                    {
                        MessageBox.Show(msg);
                    }
                    else
                    {
                        CardReader = new CpuCard(device);
                    }
                }
            }

            
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

        private void button6_Click(object sender, EventArgs e)
        {
            ApduMsg msg = CardReader.CreateFile(GetFileID(), CPUFileType.BinFile, txtContent.Text.Length);
            DisplayLog(msg);
        }

        public void DisplayLog(ApduMsg apduMsg)
        {
            if (apduMsg != null)
            {
                string msg = "----------------------\r\n状态:{0}  信息:{1} 结果:{2} \r\n";


                txtLog.AppendText(string.Format(msg, apduMsg.Status, apduMsg.Msg, BitConverter.ToString(apduMsg.ResponseData)));
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            CardReader.ReadFile(GetFileID(), out string msg );
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
            SelectDevice();
        }

        private void button14_Click(object sender, EventArgs e)
        {
             

        }

        private void button7_Click(object sender, EventArgs e)
        {

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
            ApduMsg msg = CardReader.WriteContent(GetFileID(), txtContent.Text);
            
            DisplayLog(msg);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            CardReader.GetALlFiles();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            CardReader.ReadGongjiaoka();
            

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }
    }
     
}
