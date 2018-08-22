using PscsCardReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{
    /// <summary>
    /// 德卡 D3 D8读卡器
    /// </summary>
    public class DeCardReader : ICPUCardReader
    {

        public bool DevicesStatus { get; private set; }

        /// <summary>
        /// 每BeepTimes 次，beep一次
        /// </summary>
        public int BeepTimes = 5;

        /// <summary>
        /// 读卡器是否每次读取都要有声音
        /// </summary>
        public bool NeedBeep = true;

        /// <summary>
        /// 设备ID
        /// </summary>
        int icdev;

        public bool CloseReader()
        {
            if (icdev < 0)
            {
                dc_exit(icdev);
                icdev = 0;
            }

            DevicesStatus = false;
            return true;
        }

        public bool OpenReader(out string msg)
        {
            msg = "";
            //初始化
            icdev = dc_init(100, 115200);
            if (icdev < 0)
            {
                msg = "初始化失败，可能未找到读卡器";
                return false;
            }

            //配置
            dc_config_card(icdev, 0x41);
            dc_reset(icdev, 10);
            GetCardCardID();
            UpDian();
            msg = "";
            DevicesStatus = true;

            return true;
        }


        /// <summary>
        /// 获取卡 ID
        /// </summary>
        /// <returns></returns>
        public string GetCardCardID()
        {
            char[] ssnr = new char[128];

            int st = dc_card_double_hex(icdev, 0, ssnr);
            if (st != 0)
            {
                dc_exit(icdev);
            }
            return new string(ssnr);
        }

        /// <summary>
        /// 上电复位
        /// </summary>
        /// <returns></returns>
        private bool UpDian()
        {
            byte[] rbuff;

            rbuff = new byte[128];
            byte rlen = 0;
            int st = dc_pro_reset(icdev, ref rlen, rbuff);
            if (st != 0)
            {
                dc_exit(icdev);
                return false;
            }
            //"reset information " + byteToChar(rlen, rbuff);
            return true;
        }

        private int curBeep;

        /// <summary>
        ///发送命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public byte[] SendCommand(byte[] cmd)
        {
            byte[] result = new byte[0];

            if (!DevicesStatus)
            {
                if (!OpenReader(out string msg))
                {
                    throw new Exception(msg);
                    return result;
                }
            }
            CPUCardLogHelper.AddLog(LogTypeEnum.Send, "", cmd);
             
            StringBuilder temp1 = new StringBuilder(64);
            byte[] rbuff = new byte[256];
            byte rlen = 0;

            int st = dc_pro_command(icdev, (byte)cmd.Length, cmd, ref rlen, rbuff, (byte)7);

            if (st != 0)
            {
                //throw new Exception("设备发送失败");
                dc_exit(icdev);
                return result;
            }
            result = new byte[rlen];
            Array.Copy(rbuff, 0, result, 0, result.Length);
            CPUCardLogHelper.AddLog(LogTypeEnum.Recivie, "", result);

            if (NeedBeep)
            {
                //由于程序每发送一次指令响一次，太频繁，也影响速度。所以每BeepTimes一次才响一次。
                if (curBeep == 0)
                {
                    Beep();
                }
                curBeep++;
                if (curBeep >= BeepTimes)
                {
                    curBeep = 0;
                }
            }
            
            return result;
        }

        public void Beep()
        {
            if (icdev > 0)
            {
                dc_beep(icdev, 10);
            }

        }

        [DllImport("dcrf32.dll")]
        public static extern int dc_init(Int16 port, Int32 baud);  //初试化
        [DllImport("dcrf32.dll")]
        public static extern short dc_exit(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_beep(int icdev, ushort misc);
        [DllImport("dcrf32.dll")]
        public static extern short dc_reset(int icdev, uint sec);
        [DllImport("dcrf32.dll")]
        public static extern short dc_config_card(int icdev, byte cardType);
        [DllImport("dcrf32.dll")]

        public static extern short dc_card(int icdev, byte model, ref ulong snr);

        [DllImport("dcrf32.dll")]
        public static extern short dc_card_double(int icdev, byte model, [Out] byte[] snr);

        [DllImport("dcrf32.dll")]
        public static extern short dc_card_double_hex(int icdev, byte model, [Out]char[] snr);

        [DllImport("dcrf32.dll")]
        public static extern short dc_pro_reset(int icdev, ref byte rlen, [Out] byte[] recvbuff);
        [DllImport("dcrf32.dll")]
        public static extern short dc_pro_command(int icdev, byte slen, byte[] sendbuff, ref byte rlen,
                                                     [Out]byte[] recvbuff, byte timeout);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_b(int icdev, [Out] byte[] atqb);


        [DllImport("dcrf32.dll")]
        public static extern short dc_setcpu(int icdev, byte address);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpureset(int icdev, ref byte rlen, byte[] rdata);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpuapdu(int icdev, byte slen, byte[] sendbuff, ref byte rlen,
                                                     [Out]byte[] recvbuff);

        [DllImport("dcrf32.dll")]
        public static extern short dc_readpincount_4442(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_4442(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_4442(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_verifypin_4442(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readpin_4442(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_changepin_4442(int icdev, byte[] password);

        [DllImport("dcrf32.dll")]
        public static extern short dc_readpincount_4428(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_4428(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_4428(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_verifypin_4428(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readpin_4428(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_changepin_4428(int icdev, byte[] password);

        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication(int icdev, int _Mode, int _SecNr);

        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass(int icdev, int _Mode, int _SecNr, byte[] nkey);

        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass_hex(int icdev, int _Mode, int _SecNr, string nkey);

        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key(int icdev, int mode, int secnr, byte[] nkey);  //密码装载到读写模块中


        [DllImport("dcrf32.dll")]
        public static extern int dc_write(int icdev, int adr, [In] byte[] sdata);  //向卡中写入数据

        [DllImport("dcrf32.dll")]
        public static extern int dc_write_hex(int icdev, int adr, [In] string sdata);  //向卡中写入数据


        [DllImport("dcrf32.dll")]
        public static extern int dc_read(int icdev, int adr, [Out] byte[] sdata);  //从卡中读数据

        [DllImport("dcrf32.dll")]
        public static extern short dc_read_24c(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_24c(int icdev, Int16 offset, Int16 lenth, byte[] buffer);

        [DllImport("dcrf32.dll")]
        public static extern short dc_read_24c64(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_24c64(int icdev, Int16 offset, Int16 lenth, byte[] buffer);


    }
}
