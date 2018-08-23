using PscsCardReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{

    /// <summary>
    ///
    /// </summary>
    public class CpuCard
    {

        /// <summary>
        /// 如果发送数据出错，重试次数
        /// </summary>
        static int TryNum = 3;

        ICPUCardReader carder;

        //每次读取或写入的默认自己长度
        int DefalutReadLenght = 250;
        

        /// <summary>
        /// 默认二进制储存字符串的编码格式
        /// </summary>
        public Encoding DefaultConding = Encoding.Unicode;

        /// <summary>
        /// 初始化，必须有读卡器设备
        /// </summary>
        /// <param name="_carder"></param>
        public CpuCard(ICPUCardReader _carder)
        {
            this.carder = _carder;
        }

        #region 身份验证
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public ApduMsg Auth(string Key)
        {
            return Auth(CPUCardHelper.ConverToBytes(Key));
        }


        /// <summary>
        /// 外部身份验证
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public ApduMsg Auth(byte[] Key)
        {
            if (Key.Length != 8)
            {
                return new ApduMsg("身份验证Key长度不正确");
            }
            string RANDOMCMD = "0084000004";


            byte[] Random = SendStrCommand(RANDOMCMD);

            CPUCardLogHelper.AddLog("获取随机数：" + BitConverter.ToString(Random));

            if (Random.Length != 6)
            {
                return new ApduMsg("返回随机数长度不正确");
            }

            byte[] Randomdata = new byte[8];

            Array.Copy(Random, 0, Randomdata, 0, 4);

            List<byte> cmdList = new List<byte>();
            cmdList.AddRange(CPUCardHelper.ConverToBytes("00 82 00 00 08"));
            cmdList.AddRange(CPUCardHelper.Encrypt(Randomdata, Key));

            byte[] data = carder.SendCommand(cmdList.ToArray());

            CPUCardLogHelper.AddLog(LogTypeEnum.info, "身份验证接收", BitConverter.ToString(data));

            return ApduMsg.GetApduByData(data);

        }
        #endregion

        #region 通用方法

        /// <summary>
        /// 发送十六进制字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] SendStrCommand(string str)
        {
            return carder.SendCommand(CPUCardHelper.ConverToBytes(str));
        }

        /// <summary>
        /// 发送adpu 命令对象
        /// </summary>
        /// <param name="apdu"></param>
        /// <returns></returns>
        public byte[] SendStrCommand(ApduCommand apdu)
        {
            return carder.SendCommand(apdu.ToArray());
        }


        #endregion



        /// <summary>
        /// 根据文件标识选择文件ID
        /// </summary>
        /// <returns></returns>
        public ApduMsg SelectFileById(ushort fileId)
        {
            string cmd = "00A4000002";
            byte[] data = SendStrCommand(cmd + CPUCardHelper.ConvertoHEX(fileId,4));    
            return ApduMsg.GetApduByData(data);
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ApduMsg DeleteFile(ushort fileId)
        {
            //先选择文件后删除
            ApduMsg msg = SelectFileById(fileId);
            if (msg.IsSuccess)
            {
                return RemoveDF();
            }
            return msg;
        }



        public ApduMsg SendCommand(string hex)
        {
            return ApduMsg.GetApduByData(SendStrCommand(hex));
        }


        public ApduMsg SelectFileName(string fileName)
        {
            byte[] value = Encoding.ASCII.GetBytes(fileName);
            return SelectFileName(value);
        }

        /// <summary>
        /// 根据文件名称选择
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ApduMsg SelectFileName(byte[] fileName)
        {
            //00A40400 09 A00000000386980701
            byte[] dd = CPUCardHelper.ConverToBytes("00A40400");
            

            List<byte> result = new List<byte>();
            result.AddRange(dd);
            result.Add((byte)fileName.Length);
            result.AddRange(fileName);
            byte[] cmd = result.ToArray();
            byte[] data = carder.SendCommand(cmd);
            return ApduMsg.GetApduByData(data);

        }

        /// <summary>
        /// 选择MF（顶层目录）
        /// </summary>
        /// <returns></returns>
        public ApduMsg SelectMF()
        {
            return ApduMsg.GetApduByData(SendStrCommand("00A40000023F00"));

        }


        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileIDHex">文件标识符2字节</param>
        /// <param name="fileType">枚举文件类型</param>
        /// <param name="fileLenght">文件长度</param>
        /// <param name="fileNameHex">文件名称，十六进制</param>
        /// <param name="FileAccess"></param>
        /// <returns></returns>
        public ApduMsg CreateFile(ushort fileID, CPUFileType fileType, int fileLenght, string FileAccess = "0000")
        {
            //Demo
            //80E0-EF01-07-28-002A-F00E-FF-80
            //EF01 文件标识
            //07 LC data 长度（07）
            //28 文件类型（二进制）
            //002A 文件长度
            //F00E 读写权限
            //FF 保留
            //80 不支持线路保护

            ApduCommand cmd = new ApduCommand();
            cmd.CLA = 0x80;
            cmd.INS = 0xE0;
            cmd.SetP1P2(fileID); 

            //构造一个data  ，长度，权限，
            List<byte> data = new List<byte>();
            //文件类型
            data.Add((byte)fileType);
            //文件长度
            data.AddRange(CPUCardHelper.IntConvertTo2Byte(fileLenght));
            //添加读写权限
            data.AddRange(CPUCardHelper.ConverToBytes(FileAccess));
            //添加文件名
            data.AddRange(CPUCardHelper.ConverToBytes("FF"));

            //不支持线路保护
            data.Add(0x80);

            cmd.Data = data.ToArray();

            ApduMsg msg = ApduMsg.GetApduByData(SendStrCommand(cmd));

            if (msg.Code == "6A-86")
            {
                msg.Msg += "(文件已存在)";
            }

            return msg;
        }



        /// <summary>
        /// 创建二进制文件并写入
        /// </summary>
        /// <param name="flieID"></param>
        /// <param name="fileContent"></param>
        /// <param name="fileLenght">指定文件大小</param>
        /// <returns></returns>
        public ApduMsg CreateAndWriteContent(ushort flieID, string fileContent, int fileLenght = 0, string fileName = "FF")
        {
            //需要写入的文件
            byte[] WriteData = DefaultConding.GetBytes(fileContent);

            if (fileLenght  < WriteData.Length  ) 
            {
                fileLenght = WriteData.Length;
            }
            ApduMsg msg = CreateFile(flieID, CPUFileType.BinFile, fileLenght, fileName);
            if (!msg.IsSuccess)
            {
                //文件已存在 则删除？？？
                if (msg.Code == "6A-86")
                {
                    msg.Msg += "文件已存在";
                }

                if (msg.Code == "6A-84")
                {
                    msg.Msg += "文件预留空间不足";
                }

                return msg;
            }
            //创建后，选择文件。有的不会自动选择
            SelectFileById(flieID);

            return WriteFileContent(flieID, WriteData);

        }

        public ApduMsg WriteContent(ushort flieID, string content)
        {
            return WriteFileContent(flieID, DefaultConding.GetBytes(content));
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="flieID"></param>
        /// <returns></returns>
        public ApduMsg WriteFileContent(ushort flieID,byte[] data)
        {
            
            //每次传输文件的大小
            int WriteLenght = DefalutReadLenght; 

            //将要写入的data数据，按照每次传输的最大的大小切割成data[]的List，用于分组发送
            List<byte[]> arrayData = CPUCardHelper.SplitByteToArray(data, WriteLenght);
            ushort index = 0;

            //是否写完
            bool isWriteOver = true;
            string errorMsg = "";

            for (int i = 0; i < arrayData.Count; i++)
            {
                ApduMsg msg = WriteContent(index, arrayData[i]);
                if (!msg.IsSuccess)
                {
                    bool isSuccess = false;
                    //如果写入错误为6700，则是长度错误
                    if (msg.Code == "67-00")
                    {
                        errorMsg = "写入长度错误";
                        break;
                    }
                    //如果写入未成功，重试
                    for (int t = 0; t < TryNum; t++)
                    {
                        if (WriteContent(index, arrayData[i]).IsSuccess)
                        {
                            isSuccess = true;
                            break;
                        }
                    }
                    //写入失败后重试后，还失败
                    if (!isSuccess)
                    {
                        isWriteOver = false;
                    }
                }
                index += (ushort)arrayData[i].Length;
            }

            ApduMsg apdu = new ApduMsg();
            if (isWriteOver)
            {
                apdu.Status = ApduMsgStatusEnum.正常;
            }
            else
            {
                apdu.Msg = errorMsg;
            }

            return apdu;

        }

        /// <summary>
        /// 根据偏移量，写入数据到当前文件
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private ApduMsg WriteContent(ushort index, byte[] data)
        {

            //string fileLenghtHexStr = Convert.ToString(fileLenght, 16).PadLeft(4, '0');

            //00D6-0000-02-0102
            //0000 文件偏移量
            //02 LC，data 长度
            //0102数据
            //FMCOS写文件说明，若P1点高三位为100，则低五位为短的二进制文件标识符。P2为欲写入的文件偏移量
            //若P1点最高位不为1，则P1，P2为欲写入的文件偏移量，所写文件为当前文件

            ApduCommand cmd = new ApduCommand();
            cmd.CLA = 0x00;
            cmd.INS = 0xD6;
            cmd.SetP1P2(index);
            cmd.Data = data;




            //List<byte> array = new List<byte>();
            //array.Add(0x00);
            //array.Add(0xD6);

            ////添加P1 P2参数为文件偏移量

            //array.Add((byte)(index / 256));
            //array.Add((byte)(index % 256));

            ////添加LC，为数据长度
            //array.Add((byte)data.Length);
            ////添加数据
            //array.AddRange(data);
            //ApduMsg msg = ApduMsg.GetApduByData(carder.SendCommand(array.ToArray()));

            ApduMsg msg = ApduMsg.GetApduByData(SendStrCommand(cmd));

            return msg;

        }


        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="flieID">文件名称</param>
        /// <param name="contentOrMsg"></param>
        /// <returns></returns>
        public bool ReadFile(ushort flieID, out string contentOrMsg)
        {
            contentOrMsg = "";
            ApduMsg msgd = SelectFileById(flieID);
            if (!msgd.IsSuccess)
            {
                contentOrMsg = "文件选择失败，可能文件不存在";
                return false;
            }

            List<byte> ResultData = new List<byte>();

            int index = 0;

            
            //由于读取文件时，不能取得二进制文件的大小。所以循环读取，每次读取ReadLenght 长度
            //如果读取结果小于（ReadLenght + 2（状态码））的长度，则认为文件已经读取完毕
            int MAXINDEX = 300;
            int ReadLenght = DefalutReadLenght;
            for (int i = 0; i < MAXINDEX; i++)
            {
                ApduMsg msg = ReadFile(index, ReadLenght);

                if (msg.IsSuccess)
                {

                    ResultData.AddRange(msg.GetData());

                    //如果给我返回的长度，小于我参数的长度，是否代表已经读到最后
                    if (msg.ResponseData.Length < ReadLenght + 2)
                    {
                        //break;
                    }
                }
                else
                {
                    //根据文档定义，修改读取长度 6Cxx 出错 Le长度错误，实际长度是xx

                    if (msg.StatusCode != null && msg.StatusCode.Length >0  && msg.StatusCode[0] == 0x6C)
                    {
                      
                        if (msg.StatusCode[1] > 0)
                        {
                            //修改读取长度
                            ReadLenght = msg.StatusCode[1];
                            //重读一遍
                            i--;
                            continue;
                        } 
                    }


                    if (msg.Code == "6B-00")
                    {
                        //读取完毕
                        break;
                    }

                    break;
                }
                index += ReadLenght;
            }

            contentOrMsg = DefaultConding.GetString(ResultData.ToArray()).Trim();
            return true;

        }

        /// <summary>
        /// 根据偏移量，读取当前文件
        /// </summary>
        /// <param name="index">偏移量</param>
        /// <param name="lenght">长度</param>
        /// <returns></returns>
        private ApduMsg ReadFile(int index, int lenght)
        {
            //string cmd = "00B0--0000FE";
            string cmd = "00B0--{0}--{1}";

            //读取文件偏移量
            string fileLenghtHexStr = Convert.ToString(index, 16).PadLeft(4, '0');

            //读取的长度
            string lenghtStr = Convert.ToString(lenght, 16).PadLeft(2, '0');

            cmd = string.Format(cmd, fileLenghtHexStr, lenghtStr);
            return ApduMsg.GetApduByData(SendStrCommand(cmd));

        }

        /// <summary>
        /// 删除当前文件 删除DF
        /// </summary>
        /// <returns></returns>
        public ApduMsg RemoveDF()
        {
            return ApduMsg.GetApduByData(SendStrCommand("800E000000"));
        }


        /// <summary>
        /// 根据文件标识符，枚举一下所有的文件
        /// </summary>
        /// <returns></returns>
        public string[] GetALlFiles()
        {

            //文档中规定，短文件标识符只能由前五位来确定，也就是最大可用文件标识符为31
            List<string> allFile = new List<string>();

            for (ushort j = 1; j < ushort.MaxValue; j++)
            {
                ApduMsg msg = SelectFileById(j);
                if (msg.Msg != "该文件未找到\r")
                {
                    Console.WriteLine(msg.Msg);
                }

                if (msg.IsSuccess)
                {
                    allFile.Add(Convert.ToString(j,16).PadLeft(4,'0').ToUpper());
                }
            }
            return allFile.ToArray();

        }

        public void ReadGongjiaoka()
        {
            //1pay.sysddf01
            byte[] fileName = new byte[] {
            (byte)'1', (byte)'P', (byte)'A', (byte)'Y',
            (byte)'.', (byte)'S', (byte)'Y', (byte)'S', (byte)'.', (byte)'D', (byte)'D',
            (byte)'F', (byte)'0', (byte)'1'};



            string cmd = "00A40400" + Convert.ToString((byte)fileName.Length, 16).PadLeft(2, '0') + BitConverter.ToString(fileName);
            ApduMsg msg = SendCommand(cmd);
            Console.WriteLine(msg);

        }

        /// <summary>
        /// 读余额
        /// </summary>
        public ApduMsg GetBalance(bool IsWallet)
        {
            ApduCommand cmd = new ApduCommand();
            cmd.CLA = 0x80;
            cmd.INS = 0x5C;
            //根据文档，01用于电子存折，02用于电子钱包
            if (!IsWallet)
            {
                cmd.P2 = 0x01;
            }
            else
            {
                cmd.P2 = 0x02;
            }

            cmd.LE = 0x4;

            return ApduMsg.GetApduByData(SendStrCommand(cmd));
        }


    }

    /// <summary>
    /// CPU 卡的文件类型
    /// </summary>
    public enum CPUFileType
    {
        /// <summary>
        /// 目录文件MF 或 DF 
        /// </summary>
        MFDF = 0x38,
        /// <summary>
        /// 二进制文件
        /// </summary>
        BinFile = 0x28,
        /// <summary>
        /// 定长记录
        /// </summary>
        FixLenght = 0x2A,
        /// <summary>
        /// 边长记录
        /// </summary>
        ChangeLenght = 0x2C,

        /// <summary>
        /// 循环文件
        /// </summary>
        LoopFile = 0x2E,
        /// <summary>
        /// 钱包文件
        /// </summary>
        Wall = 0x2F,
        /// <summary>
        /// Key文件
        /// </summary>
        Key = 0x3f
    }






}
