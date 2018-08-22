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
6A80 出错 数据域参数不正确
6A81 出错 功能不支持；创建不允许；目录无效；应用锁定
6A82 出错 该文件未找到
6A83 出错 该记录未找到
6A84 出错 文件预留空间不足
6A86 出错 P1或P2不正确
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

        static ApduMsgHelper()
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

                        if (Enum.TryParse(allItems[1], out ApduMsgStatusEnum statusEnum))
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
                        Console.WriteLine(  );
                    }

                }
            }

        }


        public static ApduMsg GetMsg(byte sw1, byte sw2)
        {
            return GetApduMsg(new byte[] { sw1, sw2 });
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

            if (AllMsgDic.TryGetValue(BitConverter.ToString(code), out reslut))
            {
                reslut = (ApduMsg)reslut.Clone();
            }
            else
            {
                reslut = new ApduMsg();    
                reslut.Msg = "未找到已定义到状态信息";
            }

            reslut.ResponseData = data;


            return reslut;
        }
    }
}
