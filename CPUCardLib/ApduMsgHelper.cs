using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{

    /// <summary>
    /// 通用信息封装
    /// </summary>
    public static class ApduMsgHelper
    {
        /// <summary>
        /// 定义发送命令
        /// </summary>
        private const string DefindSendMsgCodeArray = @"
0020 验证口令 VERIFY
0082 外部认证 EXTERNAL AUTHENTICATE
0084 取随机数 GET CHALLENGE 
0088 内部认证 INTERNAL AUTHENTICATE
00A4 选择文件 SELECT
00B0 读二进制文件 READ BINARY
00B2 读记录文件 READ RECORD
00C0 取响应数据 GET RESPONSE 
00D6 写二进制文件 UPDATE BINARY 
00D0 写二进制文件 UPDATE BINARY 
04D6 写二进制文件 UPDATE BINARY 
04D0 写二进制文件 UPDATE BINARY 
00DC 写记录文件 UPDATE RECORD
00D2 写记录文件 UPDATE RECORD
04DC 写记录文件 UPDATE RECORD
04D2 写记录文件 UPDATE RECORD
8416 卡片锁定 CARD BLOCK
8418 应用解锁 APPLICATION UNBLOCK 
841E 应用锁定 APPLICATION BLOCK 
8024 个人密码解锁 PIN UNBLOCK
8424 个人密码解锁 PIN UNBLOCK
802C 解锁被锁住的口令 UNBLOCK
8050 初始化交易 INITIALIZE
8052 圈存 CREDIT FOR LOAD 
8054 消费/取现/圈提 DEBIT FOR PURCHASE/CASE WITHDRAW/UNLOAD
8058 修改透支限额 UPDATE OVERDRAW LIMIT 
805A 取交易认证 GET TRANSCATION PROVE
805C 读余额 GET BALANCE 
805E 重装/修改个人密码 RELOAD/CHANGE PIN 
800E 擦除 DF ERASE DF
8030 专用消费 PULL 
8032 专用充值 CHARGE 
84D4 增加或修改密钥 WRITE KEY 
80D4 增加或修改密钥 WRITE KEY 
80E0 建立文件 CREATE
0000 写数据 EEPROM WRITE EEPROM 
0004 读数据 EEPROM READ EEPROM
0002 初始化 EEPROM INITIAL EEPROM 
000C 读程序 ROM READ ROM 
000A 计算程序 ROM CRC CALCULATE ROM CRC ";


        /// <summary>
        /// 定义信息常量
        /// </summary>
        private const string DefindMsgCodeArray = @"
9000 正常 成功执行
6200 警告 信息未提供
6281 警告 回送数据可能出错
6282 警告 文件长度小于Le
6283 警告 选中的文件无效
6284 警告 FCI格式与P2指定的不符
6300 警告 鉴别失败
63Cx 警告 校验失败（x－允许重试次数）
6400 出错 状态标志位没有变
6581 出错 内存失败
6700 出错 长度错误
6882 出错 不支持安全报文
6981 出错 命令与文件结构不相容，当前文件非所需文件
6982 出错 操作条件（AC）不满足，没有校验PIN
6983 出错 认证方法锁定，PIN被锁定
6984 出错 随机数无效，引用的数据无效
6985 出错 使用条件不满足
6986 出错 不满足命令执行条件（不允许的命令，INS有错）
6987 出错 MAC丢失
6988 出错 MAC不正确
698D 保留
6A80 出错 数据域参数不正确(记录个数小于 2 或目录级数大于三级)
6A81 出错 功能不支持；创建不允许；目录无效；应用锁定
6A82 出错 该文件未找到
6A83 出错 该记录未找到
6A84 出错 文件预留空间不足
6A86 出错 文件已存在
6A88 出错 密匙未找到
6B00 出错 参数错误
6Cxx 出错 Le长度错误，实际长度是xx
6E00 出错 不支持的类：CLA有错
6F00 出错 数据无效
6D00 出错 不支持的指令代码
9301 出错 资金不足
9302 出错 MAC无效
9303 出错 应用被永久锁定
9401 出错 交易金额不足
9402 出错 交易计数器达到最大值
9403 出错 密钥索引不支持
9406 出错 所需MAC不可用
6900 出错 不能处理
6901 出错 命令不接受（无效状态）
61xx 正常 需发GET RESPONSE命令
6600 出错 接收通讯超时
6601 出错 接收字符奇偶错
6602 出错 校验和不对
6603 警告 当前DF文件无FCI
6604 警告 当前DF下无SF或KF";

        /// <summary>
        /// 缓存所有的通用卡消息
        /// </summary>
        private static Dictionary<string, ApduMsg> AllMsgDic = new Dictionary<string, ApduMsg>();

        private static Dictionary<string, string> AllSendMsgDic = new Dictionary<string, string>();


        static ApduMsgHelper()
        {

            //初始化所有的常用信息到Dic 中缓存
            InitSendMsgDic();
            InitRecMsgDic();
        }

        private static void InitSendMsgDic() 
        {
           
             
            string[] allLines = DefindSendMsgCodeArray.Split('\n');

            for (int i = 0; i < allLines.Length; i++)
            {
                int index = allLines[i].IndexOf(' ');
                if (index > 1)
                {
                    string cmd = allLines[i].Substring(0, index).ToUpper();
                    string msg = allLines[i].Substring(index, allLines[i].Length - index);
                    if (!AllSendMsgDic.ContainsKey(cmd))
                    {
                        AllSendMsgDic.Add(cmd, msg);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }


        public static string GetSendCmdNote(byte CLA,byte INS) 
        {
            string CLAStr  = CPUCardHelper.ConvertoHEX(CLA);
            string INSStr = CPUCardHelper.ConvertoHEX(INS);
            string cmd = CLAStr + INSStr;
            if (AllSendMsgDic.TryGetValue(cmd, out string msg))
            {
                return msg;
            }
            return "未找到指令" + cmd;


        }

        private static void InitRecMsgDic() 
        {
            //初始化所有的常用信息到Dic 中缓存

            string[] allLines = DefindMsgCodeArray.Split('\n');

            for (int i = 0; i < allLines.Length; i++)
            {
                string[] allItems = allLines[i].Split(' ');

                if (allItems.Length < 2)
                {
                    continue;
                }
                else
                {
                    try
                    {
                        ApduMsg msg = new ApduMsg();

                        msg.Code = allItems[0];
                        ApduMsgStatusEnum statusEnum;
                        if (Enum.TryParse(allItems[1], out statusEnum))
                        {
                            msg.Status = statusEnum;
                        }
                        else
                        {
                            msg.Status = ApduMsgStatusEnum.其他;
                        }

                        if (allItems.Length >= 3)
                        {
                            msg.Msg = allItems[2];
                        }

                        if (!AllMsgDic.ContainsKey(msg.Code))
                        {
                            AllMsgDic.Add(msg.Code, msg);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                    }

                }
            }

        }


        public static ApduMsg GetApduMsg(byte[] data)
        {
            ApduMsg reslut = new ApduMsg ();
            reslut.ResponseData = data;

            if (data.Length < 2)
            {
                //reslut.Msg = "返回信息长度错误";
                return reslut;
            }

            //赋值data最后两个字节，作为状态码
            byte[] code = new byte[2];
            Array.Copy(data, data.Length - 2, code, 0, 2);

            string codeStr = BitConverter.ToString(code);
            if (AllMsgDic.TryGetValue(codeStr, out reslut))
            {
                reslut = (ApduMsg)reslut.Clone();
            }
            else
            {
                reslut = new ApduMsg();

                reslut.Msg = "未找到已定义到状态信息";

                if (codeStr.StartsWith("6C"))
                {
                    reslut.Msg = "Le长度错误，实际长度是xx";
                }
                
                
            }

            reslut.ResponseData = data;


            return reslut;
        }
    }
}
