using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{
    /// <summary>
    /// 读卡器接口
    /// </summary>
    public interface ICPUCardReader
    {

        /// <summary>
        /// 打开读卡器
        /// </summary>
        bool OpenReader(out string msg);

        /// <summary>
        /// 关闭读卡器
        /// </summary>
        bool CloseReader();


        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        byte[] SendCommand(byte[] cmd);


        /// <summary>
        ///读卡器发出声音
        /// </summary>
        void Beep();
    }

}
