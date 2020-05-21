using CPUCardLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardTestFrm
{
    /// <summary>
    /// 调用封装
    /// 由于调用方只关心读取文件和写入文件两个方法，所以在此做个简单的封装
    /// </summary>
    public static class CPUCardWrapper
    {
        public const string DefaultKEY = "FFFFFFFFFFFFFFFF";

        public static CpuCard cpuCard;

        static StreamWriter sw;

        public static ICPUCardReader cardReader;

        const string ERRORMSG = "访问读卡器失败,其他程序正在使用读卡器";

        static bool NeedLog = true;

        static Encoding encod = Encoding.UTF8;
         
        static string CardLogDIR= "CardLog";

         
        /// <summary>
        /// 初始化包装器
        /// </summary>
        static CPUCardWrapper()
        {
            InitCard();
            
        }

        public static void WriteLog(string msg)
        {
            if (sw != null)
            {
                sw.WriteLine(msg);
                sw.Flush();
            }
        }


        public static void InitCard()
        {
            cardReader = GetCardReader();
            cpuCard = new CpuCard(cardReader);
            cpuCard.ShowLog = WriteLog;

            try
            {
                Directory.CreateDirectory(CardLogDIR);
                string logPath = $"{CardLogDIR}\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.log";
                sw = File.CreateText(logPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }

        }



        /// <summary>
        /// 选择使用的读卡器
        /// </summary>
        /// <returns></returns>
        private static ICPUCardReader GetCardReader()
        {

            ICPUCardReader cardReader = null;

            //可以从配置文件中指定使用哪种读卡器
            if (true)
            {
                cardReader = new DeCardReader();
            }
            else
            {
                cardReader = new PcscCardReader();
            }
            return cardReader;
        }

      
        public static bool CreateFile(ushort fileID, string content, out string msg)
        {
            msg = "";
           
            byte[] data = encod.GetBytes(content);
            bool reslut= CreateFile(fileID, data, out msg);
            WriteLog("***********************\r\n");
            WriteLog($"写入文件{fileID}---- {reslut} ---- {msg} ---- {content}");
            WriteLog("***********************\r\n");
            return reslut;
        }


        public static ushort fixFileID = 100;

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="msg">错误消息</param>
        /// <returns></returns>
        public static bool CreateFile(ushort fileID, byte[] content, out string msg)
        {
            try
            {
                if (!cardReader.OpenReader(out msg))
                {
                    return false;
                }

                //默认进行身份验证
                if (!Auth())
                {
                  
                }

                //先选择根目录
                cpuCard.SelectMF();
                //创建文件夹(文件夹创建的时候大一点)
                cpuCard.CreateDFFile(fileID, content.Length + 100);

                //选择创建的文件夹
                cpuCard.SelectFileById(fileID);

                 
                ApduMsg msgApd = cpuCard.CreateAndWriteContent(fixFileID, content);


                if (!msgApd.IsSuccess)
                {
                    msg = msgApd.Msg;
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                cardReader.CloseReader();
                //run.Close();
            }


            return true;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public static bool DeleteFile(ushort fileID)
        {
            
            try
            {
                cardReader.OpenReader(out string msgInf);

                //默认进行身份验证
                Auth();

                //先选择根目录
                cpuCard.SelectMF();

                //选择创建的文件夹
                cpuCard.SelectFileById(fileID);

                ApduMsg msg = cpuCard.RemoveDF();

                //再退出到根目录
                cpuCard.SelectMF();
                if (msg.IsSuccess)
                {
                    return true;
                }
               // cardReader.CloseReader();
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
               // run.Close();
            }
            return false;
        }


        public static bool ReadFile(ushort fileID, out string msg)
        {
           
            byte[] data = new byte[0];
            string contentOrMsg;
            msg = "";
            bool result;
            if (ReadFile(fileID, out data, out contentOrMsg))
            {
                
                contentOrMsg = encod.GetString(data);
                msg = contentOrMsg;
                result =true;

                WriteLog($"读取成功{fileID},读取长度{data.Length} 解码内容 {contentOrMsg}   ###end " );
            }
            else
            {
                msg = contentOrMsg;

                result = false;
                WriteLog($"读取失败{fileID},错误原因{contentOrMsg}");
            }
 
            return result;

        }


        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="msg">错误消息</param>
        /// <returns></returns>
        public static bool ReadFile(ushort fileID, out byte[] data, out string contentOrMsg)
        {
 
            data = new byte[0];
           
            cardReader.OpenReader(out string msgInf);

            //默认进行身份验证
            Auth();
            try
            {
                //先选择根目录
                cpuCard.SelectMF();

                //选择创建的文件夹
                cpuCard.SelectFileById(fileID);

                //选择文件
                cpuCard.SelectFileById(fixFileID);
                //读取

                bool res = cpuCard.ReadFile(fixFileID, out data, out contentOrMsg);

                //再退出到根目录
                cpuCard.SelectMF();
                return res;

            }
            catch (Exception ex)
            { 
                contentOrMsg = ex.Message;
                return false;
            }
            finally
            {
                cardReader.CloseReader();
               // run.Close();
            }


        }

        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Auth(string key = DefaultKEY)
        {
            return cpuCard.Auth(DefaultKEY).IsSuccess;
        }

    }
}
