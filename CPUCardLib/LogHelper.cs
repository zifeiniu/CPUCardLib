using CPUCardLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PscsCardReaderLib
{
    /// <summary>
    /// 记录  CPU卡访问日志
    /// </summary>
    public class CPUCardLogHelper
    {

        public static event Action<LogInfo> logAction;

        public static void DisplayApduMsg(ApduMsg msg)
        {
            string result = string.Format("{0} {1} {2}",msg.Status,msg.Msg,msg.ResponseData);
            AddLog(result);
        }

        public static void AddLog(string msg)
        {
            LogInfo info = new LogInfo() { msg = msg };
            logAction?.BeginInvoke(info, null, null);
        }

        public static void AddLog(LogTypeEnum logType, string msg,byte[] command)
        {
            LogInfo info = new LogInfo() { logType = logType,msg = msg,command= command };
            logAction?.BeginInvoke(info, null, null);
        }

        public static void AddLog(LogTypeEnum logType, string msg, string command)
        {
            LogInfo info = new LogInfo() { logType = logType, msg = msg,commandStr = command };
            logAction?.BeginInvoke(info, null, null);
        }
    }

    /// <summary>
    /// 设备发送日志
    /// </summary>
    public class LogInfo
    {

        public LogTypeEnum logType = LogTypeEnum.info;

        public string msg;

        public byte[] command;

        public string commandStr;

        private string GetCommandStr()
        {
            if (!string.IsNullOrEmpty(commandStr))
            {
                return commandStr;
            }
            else if (command != null)
            {
                return BitConverter.ToString(command);
            }
            return "";
        }

        public string GetTypeMsg()
        {
            switch (logType)
            {
                case LogTypeEnum.Send:
                    return "发送";
                case LogTypeEnum.Recivie:
                    return "接收";
                case LogTypeEnum.info:
                    return "信息";
                case LogTypeEnum.error:
                    return "错误";
                default:
                    return "其他";
            }
        }

        public override string ToString()
        {
            return  string.Format("{0},{1},{2}", GetTypeMsg(),msg,GetCommandStr());
        }

    }

    public enum LogTypeEnum
    {
        Send = 0,
        Recivie=1,
        info =2,
        error = 3
    }




}
