using CPUCardLib;
using System;
using System.Collections.Generic;
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

        static CpuCard cpuCard;

        static ICPUCardReader cardReader;

        /// <summary>
        /// 初始化包装器
        /// </summary>
        static CPUCardWrapper()
        {
            cardReader = GetCardReader();
            cpuCard = new CpuCard(cardReader);
        }



        /// <summary>
        /// 选择使用的读卡器
        /// </summary>
        /// <returns></returns>
        private static ICPUCardReader GetCardReader() {

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

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="msg">错误消息</param>
        /// <returns></returns>
        public static bool CreateFile(ushort fileID, string content, out string msg)
        {
            //默认进行身份验证
            Auth();

            msg = "";
            ApduMsg msgApd = cpuCard.CreateAndWriteContent(fileID, content);
            if (!msgApd.IsSuccess)
            {
                msg = msgApd.Msg;
                return false;
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
            //默认进行身份验证
            Auth();
            ApduMsg msg = cpuCard.DeleteFile(fileID);
            if (msg.IsSuccess)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="msg">错误消息</param>
        /// <returns></returns>
        public static bool ReadFile(ushort fileID, out string contentOrMsg)
        {
            //默认进行身份验证
            Auth();
            try
            {
                return cpuCard.ReadFile(fileID, out contentOrMsg);
            }
            catch (Exception ex)
            {
                contentOrMsg = ex.Message;
                return false;


            }
        }

        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Auth(string key= DefaultKEY)
        {
            return cpuCard.Auth(DefaultKEY).IsSuccess;
        }
         



    }
}
