using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUCardLib
{
   /// <summary>
   /// 封装CPU卡返回的Apdu信息
   /// </summary>
    public class ApduMsg:ICloneable
    {

        /// <summary>
        /// 获取apduMsg对象
        /// </summary>
        /// <param name="ApduMsg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApduMsg GetApduByData(byte[] ResponseData)
        {
            return ApduMsgHelper.GetApduMsg(ResponseData);
        }

        public object Clone()
        {
            ApduMsg apdu = new ApduMsg();
            apdu.Code = this.Code;
            apdu.Msg = this.Msg;
            apdu.Status = this.Status;
            return apdu;
        }

        public ApduMsg() { }

        public ApduMsg(string msg)
        {
            this.Msg = msg;
        }


        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool IsSuccess
        {
            get { return Status == ApduMsgStatusEnum.正常; }
        }

        /// <summary>
        ///字符串 状态码
        /// </summary>
        public string Code
        {
            get
            {
                if (StatusCode != null)
                {
                    return BitConverter.ToString(_StatusCode); 
                }
                return "";
            }
            set
            {
                _StatusCode = CPUCardHelper.ConverToBytes(value);
            }

        }

        byte[] _StatusCode;
        /// <summary>
        /// 状态码
        /// </summary>
        public byte[] StatusCode
        {
            get
            {
                if (_StatusCode == null && ResponseData != null)
                {
                    if (ResponseData.Length  >= 2)
                    {
                        _StatusCode = new byte[] { ResponseData[ResponseData .Length- 2], ResponseData[ResponseData.Length - 1] };
                    }
                }
                return _StatusCode;
            }
            set { _StatusCode = value; }
        }

        /// <summary>
        /// 状态类型
        /// </summary>
        public ApduMsgStatusEnum Status = ApduMsgStatusEnum.其他;

        /// <summary>
        /// 状态类型
        /// </summary>
        public string Msg = string.Empty;

        /// <summary>
        /// CPU卡返回的所有数据，包括状态码
        /// </summary>
        public byte[] ResponseData
        {
            get;
            set;
        } =new byte[0];


        /// <summary>
        /// 获取除了状态码以外的数据
        /// </summary>
        /// <returns></returns>
        public byte[] GetData ()
        {
            
            if (ResponseData.Length > 2)
            {
                byte[] result = new byte[ResponseData.Length - 2];
                Array.Copy(ResponseData, 0, result, 0, result.Length);
                return result;
            }

            return new byte[0];

        }


    }

   /// <summary>
   /// 枚举状态
   /// </summary>
    public enum ApduMsgStatusEnum
    {
        警告,
        出错,
        正常,
        保留,
        其他
    }
}
