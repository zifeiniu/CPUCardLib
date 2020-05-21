using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{
    /// <summary>
    /// 相关的帮助类
    /// </summary>
    public static class CPUCardHelper
    {
         

        /// <summary>  
        /// DES加密字节数组,可以使用弱密钥  
        /// </summary>  
        /// <param name="source"></param>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static byte[] Encrypt(byte[] source, byte[] key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Padding = PaddingMode.None;

            Type type = Type.GetType("System.Security.Cryptography.CryptoAPITransformMode");
            object obj = type.GetField("Encrypt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).GetValue(type);

            MethodInfo mi = des.GetType().GetMethod("_NewEncryptor", BindingFlags.Instance | BindingFlags.NonPublic);
            ICryptoTransform desCrypt = (ICryptoTransform)mi.Invoke(des, new object[] { key, CipherMode.ECB, null, 0, obj });

            return desCrypt.TransformFinalBlock(source, 0, source.Length);
        }

        /// <summary>  
        /// DES字节数组解密，可以使用弱密钥  
        /// </summary>  
        /// <param name="source"></param>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static byte[] Decrypt(byte[] source, byte[] key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Padding = PaddingMode.None;

            Type type = Type.GetType("System.Security.Cryptography.CryptoAPITransformMode");
            object obj = type.GetField("Decrypt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).GetValue(type);

            MethodInfo mi = des.GetType().GetMethod("_NewEncryptor", BindingFlags.Instance | BindingFlags.NonPublic);
            ICryptoTransform desCrypt = (ICryptoTransform)mi.Invoke(des, new object[] { key, CipherMode.ECB, null, 0, obj });

            return desCrypt.TransformFinalBlock(source, 0, source.Length);
        }

        /// <summary>
        /// 十六进制字符串 转换为 byte[]
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] ConverToBytes(string hex)
        {
            char[] sp = new char[] { ' ', '-', ',','\r', '\n' };
            return ConverToBytes(hex, sp);
        }

        /// <summary>
        /// 包含空格‘-’
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] ConverToBytes(string hex, char[] splicChat)
        {
            try
            {
                hex = hex.Trim();

                string[] alldatas = hex.Trim().Split(splicChat);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < alldatas.Length; i++)
                {
                    sb.Append(alldatas[i]);
                }
                hex = sb.ToString();

                if (hex.Length % 2 == 1)
                {
                    throw new Exception("长度错误");
                }

                byte[] commandBytes = new byte[hex.Length / 2];

                for (int i = 0; i < hex.Length; i += 2)
                {
                    commandBytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
                return commandBytes;
            }
            catch (Exception ex)
            {
                //不是十六进制
                throw ex;
            }
             
        }


        /// <summary>
        /// 将一个大的byte数组按照splitLenght的长度切割，用于分组发送
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MaxCount"></param>
        /// <returns></returns>
        public static List<byte[]> SplitByteToArray(byte[] data,int splitLenght)
        {
            if (splitLenght<=0)
            {
                throw new ArgumentException();
            }
            List<byte[]> DataArray = new List<byte[]>();

            //当前偏移量
            int index = 0;
            while (index < data.Length)
            {
                //开始偏移量
                int start = index;
                //长度
                int lenght = data.Length - index < splitLenght ? data.Length - index : splitLenght;
                index += lenght;
                byte[] sendData = new byte[lenght];
                Array.Copy(data, start, sendData, 0, lenght);
                DataArray.Add(sendData);
            }
            return DataArray;

        }


        /// <summary>
        /// 转换成十六进制字符串左对齐的长度
        /// </summary>
        /// <param name="b"></param>
        /// <param name="LeftPadLenght"></param>
        /// <returns></returns>
        public static string ConvertoHEX(ushort b,int LeftPadLenght = 2)
        {
            return Convert.ToString(b, 16).PadLeft(LeftPadLenght, '0').ToUpper();
        }

        /// <summary>
        /// 将Int 转换为长度为2的byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] IntConvertTo2Byte(int value)
        {
            byte[] data = new byte[2];
            data[0] = (byte)(value / 256);
            data[1] = (byte)(value % 256);
            return data;
        }
    }
}
