using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{
    /// <summary>
    /// Apdu 命令封装
    /// </summary>
    public class ApduCommand
    {

        public ApduCommand()
        { }

        /// <summary>
        /// 初始化，转换命令为ApduCommad
        /// </summary>
        /// <param name="cmdData"></param>
        public ApduCommand(byte[] cmdData)
        {
            //命令长度最少4字节
            if (cmdData.Length < 4)
            {
                Msg = "命令长度小于4";
                IsPass = false;
                return;
            }



            //设置固定字段的值
            CLA = cmdData[0];
            INS = cmdData[1];
            P1 = cmdData[2];
            P2 = cmdData[3];


            CmdNote = ApduMsgHelper.GetSendCmdNote(CLA, INS);

            if (cmdData.Length == 5)
            {
                //只有5字节，则最后一个是LE..
                LE = cmdData[4];
                //LE不能大于136
                if (LE > 136)
                {
                    CmdNote += $"-LE长度超过限制{LE}-";
                }
                return;
            }


            if (cmdData.Length > 4)
            {
                //如果有LC，则判断Data的长度是否符合LC
                if (cmdData[4] > 0)
                {
                    LC = cmdData[4];
                    
                    if (cmdData.Length < LC + 4)
                    {
                        Msg = "LC 长度错误:" + LC;
                        IsPass = false;
                        return;
                    }
                    //取出Data并赋值
                    Data = new byte[LC];
                    Array.Copy(cmdData, 5, Data, 0, LC);

                }
                else
                {


                }
            }
        }

        public void FixLC() 
        {
            byte[] allData =  this.ToArray();
            LC = (byte)(allData.Length - 4);
             

        }

        /// <summary>
        /// 命令说明
        /// </summary>
        public string CmdNote;
        

        /// <summary>
        /// 命令格式是否正确
        /// </summary>
        public bool IsPass = true;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg;

        /// <summary>
        /// 指令类别;
        /// </summary>
        public byte CLA = 0x00;

        /// <summary>
        /// 指令类型的指令码
        /// </summary>
        public byte INS = 0x00;

        /// <summary>
        /// 命令参数
        /// </summary>
        public byte P1 =  0x00;

        /// <summary>
        /// 命令参数
        /// </summary>
        public byte P2 = 0x00;
         

        /// <summary>
        /// Data 长度，不可超过239
        /// </summary>
        public byte LC = 0x00;

        /// <summary>
        /// 荷载数据
        /// </summary>
        public byte[] Data = new byte[0];

        /// <summary>
        /// 要求返回的数据长度，如果是00，则返回最多可用
        /// </summary>
        public byte? LE = null;

        /// <summary>
        /// 设置P1P2（int类型，比如设置文件偏移量）
        /// </summary>
        public void SetP1P2(ushort value)
        {
            byte[] data = CPUCardHelper.IntConvertTo2Byte(value);
            P1 = data[0];
            P2 = data[1];
        }

        /// <summary>
        /// 设置P1P2，（字符串类型，比如设置文件标识符）
        /// </summary>
        /// <param name="Hexvalue"></param>
        public bool SetP1P2(string Hexvalue)
        {
            try
            {
                byte[] data = CPUCardHelper.ConverToBytes(Hexvalue);
                P1 = data[0];
                P2 = data[1];

                if (data.Length != 2)
                {
                    return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
            
        }

        public void SetCLA(string hexValue)
        {
            CLA =  Convert.ToByte(hexValue, 16);
        }

        public void SetINS(string hexValue)
        {
            INS = Convert.ToByte(hexValue, 16);
        }

        public void SetP1(string hexValue)
        {
            P1= Convert.ToByte(hexValue, 16);
        }

        public void SetP2(string hexValue)
        {
            P2 = Convert.ToByte(hexValue, 16);
        }

        public void SetData(string hexValue)
        {
            Data =  CPUCardHelper.ConverToBytes(hexValue);
        }


        public byte[] ToArray()
        {
            List<byte> list = new List<byte>();
            list.Add(CLA);
            list.Add(INS);
            list.Add(P1);
            list.Add(P2);
            //如果有data，则计算LC长度，并添加到Data里
            if (Data != null && Data.Length > 0)
            {
                LC = (byte)Data.Length;
                list.Add(LC);
                list.AddRange(Data);
            }

            if (LE != null)
            {
                list.Add(LE.Value);
            }
            return list.ToArray();
        }

        public override string ToString()
        {
            try
            {

                return CmdNote +"\r\n"+ string.Format("CLA:{0},INS:{1} P1:{2} P2:{3} LC:{4} Data:{5} LE:{6} MSG \r\n",
                CPUCardHelper.ConvertoHEX(CLA),
                CPUCardHelper.ConvertoHEX(INS),
                CPUCardHelper.ConvertoHEX(P1),
                CPUCardHelper.ConvertoHEX(P2),
                CPUCardHelper.ConvertoHEX(LC),
                BitConverter.ToString(Data),
                CPUCardHelper.ConvertoHEX((LE) ??(ushort)0),
               Msg);
            }
            catch (Exception ex)
            {
                return "解析命令出错"+ex.Message;
            }

        }




    }
}
