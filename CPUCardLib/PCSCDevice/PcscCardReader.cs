using PCSC;
using PCSC.Iso7816; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPUCardLib
{
    public class PcscCardReader : ICPUCardReader
    {
        /// <summary>
        /// 读卡器名称
        /// </summary>
        public string CardReaderName { get; set; } = "ACS ACR122 0";

        ISCardContext _context;

        ISCardContext Context
        {
            get
            {
                if (_context == null)
                {
                    var contextFactory = ContextFactory.Instance;
                    _context = contextFactory.Establish(SCardScope.System);
                }
                return _context;
            }
        }

        ICardReader _rfidReader;

        ICardReader RfidReader
        {
            get
            {
                if (_rfidReader == null)
                {
                    _rfidReader = Context.ConnectReader(CardReaderName, SCardShareMode.Shared, SCardProtocol.Any);
                }
                return _rfidReader;
            }
        }


        public PcscCardReader()
        {

        }

        public PcscCardReader(string _readerName)
        {
            CardReaderName = _readerName;
        }




        public string[] GetAllReader()
        {
            var contextFactory = ContextFactory.Instance;
            using (var context1 = contextFactory.Establish(SCardScope.System))
            {
                return context1.GetReaders();
            }
        }


        public bool CloseReader()
        {
            //rfidReader.Disconnect(SCardReaderDisposition.Unpower);
            return true;
        }

        public bool OpenReader(out string msg)
        {
            msg = "";
            return true;
            if (string.IsNullOrEmpty(CardReaderName))
            {
                string[] AllCards = GetAllReader();
                if (AllCards.Length > 0)
                {
                    CardReaderName = AllCards[0];
                }
                else
                {
                    msg = "未找到读卡器";
                    return false;
                }
            }

            return true;
        }


        public byte[] SendCommand2(byte[] command)
        {
            var contextFactory = ContextFactory.Instance;
            using (var context = contextFactory.Establish(SCardScope.System))
            {

                using (var rfidReader = context.ConnectReader(CardReaderName, SCardShareMode.Shared, SCardProtocol.Any))
                {

                    using (rfidReader.Transaction(SCardReaderDisposition.Leave))
                    {
                        Console.WriteLine("Retrieving the UID .... ");

                        var sendPci = SCardPCI.GetPci(rfidReader.Protocol);
                        var receivePci = new SCardPCI(); // IO returned protocol control information.

                        var receiveBuffer = new byte[256];

                        command = new byte[] { 0, 132, 0, 0, 4 };
                        var bytesReceived = rfidReader.Transmit(
                            sendPci, // Protocol Control Information (T0, T1 or Raw)
                            command, // command APDU
                            command.Length,
                            receivePci, // returning Protocol Control Information
                            receiveBuffer,
                            receiveBuffer.Length); // data buffer

                        //var responseApdu =
                        //    new ResponseApdu(receiveBuffer, bytesReceived, IsoCase.Case2Short, rfidReader.Protocol);
                        //Console.Write("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}",
                        //    responseApdu.SW1,
                        //    responseApdu.SW2,
                        //    responseApdu.HasData ? BitConverter.ToString(responseApdu.GetData()) : "No uid received");


                        byte[] receiveData = new byte[bytesReceived];

                        //byte[] result = responseApdu.GetData();

                        Array.Copy(receiveBuffer, receiveData, bytesReceived);

                        //  log?.AddLog("接收:" + BitConverter.ToString(receiveData));

                        return receiveData;


                    }
                }
            }
        }


        public byte[] SendCommand(byte[] command)
        {
            //  return SendCommand2(command);

            using (RfidReader.Transaction(SCardReaderDisposition.Leave))
            {

                
                var sendPci = SCardPCI.GetPci(RfidReader.Protocol);

                var receivePci = new SCardPCI(); // IO returned protocol control information.

                var receiveBuffer = new byte[256];
                try
                {

                    var bytesReceived = RfidReader.Transmit(
                        sendPci, // Protocol Control Information (T0, T1 or Raw)
                        command, // command APDU
                        command.Length,
                        receivePci, // returning Protocol Control Information
                        receiveBuffer,
                        receiveBuffer.Length); // data buffer

                    //var responseApdu = new ResponseApdu(receiveBuffer, bytesReceived, IsoCase.Case2Short, rfidReader.Protocol);

                    byte[] receiveData = new byte[bytesReceived];

                    //byte[] result = responseApdu.GetData();

                    Array.Copy(receiveBuffer, receiveData, bytesReceived);
                    
                    //CPUCardLogHelper.AddLog(LogTypeEnum.Recivie, "", receiveData);

                    return receiveData;
                }
                catch (Exception ex)
                {
                    //CPUCardLogHelper.AddLog(LogTypeEnum.error, "设备发送异常" + ex.Message, command);
                    return new byte[0];
                }
            }
        }

        public void Beep()
        {
            
        }
    }
}
