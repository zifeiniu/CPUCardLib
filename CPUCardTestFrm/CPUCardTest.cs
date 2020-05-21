using CPUCardTestFrm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CPUCardTestFrm
{
    /// <summary>
    /// 简单的命令行测试卡
    /// </summary>
    public class CPUCardTest
    {
        public static bool TestFileNew() 
        {
            ushort fileId = 10;
            string fileContent = "abcdefg";
            if (!CPUCardWrapper.CreateFile(fileId, fileContent, out string msg))
            {

                Console.WriteLine("创建文件失败" + msg);
                
            }
            return true;


        }

        public static void ReadALlCard()
        {
            //string fileName = $"cpudata-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Second}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}.log";
            //StreamWriter sw = File.CreateText(fileName);

            
            for (ushort i = 1; i <= 100; i++)
            {

                //sw.WriteLine(i.ToString());
                if (CPUCardWrapper.ReadFile(i, out string msg))
                {
                    Console.WriteLine(i + "分区读取失败" + msg);
                    //    sw.WriteLine(i + "分区读取成功" + msg);
                }
                else
                {
                    Console.WriteLine(i + "分区读取失败" + msg);
                    //sw.WriteLine(i + "分区读取失败" + msg);
                }

            }
        }


        /// <summary>
        /// 测试最大单文件,读取文件最大偏移量为7FFFF,最大可读取32767
        /// </summary>
        public static void TestMaxFile()
        {
            DeleteFile(1);
            int fileLenth = 32767;
            byte[] data = new byte[fileLenth];
            r.NextBytes(data);
            TestFileByte(1, data); ;
        }

        /// <summary>
        /// 测试
        /// </summary>
        public static void TestMain()
        {
            
            //DateTime dt = DateTime.Now;
            ushort FileCount = 100;
            //DeleteFile(FileCount);
            //TestMaxFile();
            //Console.WriteLine();
            //return; 



            for (ushort i = 1; i <= 100; i++)
            {
                int fileLenth = 1024 ;
                CPUCardWrapper.DeleteFile(i);
                byte[] data = new byte[fileLenth];

                r.NextBytes(data);


                if (TestFileByte(i, data))
                {
                    Console.WriteLine(" succ");
                }
                else
                {
                    Console.WriteLine(" false");
                }
            }

            
            return;
            for (int i = 100; i < 1024 * 70; i += 2000)
            {
                TestFile(1, GetRandomString(i));
            }
            return;


            for (ushort i = 1; i < FileCount; i++)
            {
                //测试文件大小
                int FileLenght = 1024;

                TestFile(i, GetRandomString(FileLenght));
            }


        }


        static Random r = new Random();


        public static bool TestFileByte(ushort fileId, byte[] fileContent)
        {
            bool isPass = true;
            DateTime dtStart = DateTime.Now;
             
            if (!CPUCardWrapper.CreateFile(fileId, fileContent, out string msg))
            {

                Console.WriteLine("创建文件失败" + msg);
                isPass = false;
            }

            DateTime dtEnd = DateTime.Now;

            TimeSpan ts = dtEnd - dtStart;
            Console.WriteLine();
            dtStart = DateTime.Now;

            byte[] readData = new byte[0];

            if (!CPUCardWrapper.ReadFile(fileId,out readData, out string m3sg))
            {

                Console.WriteLine("读取文件失败" + m3sg);
                isPass = false;
            }
            dtEnd = DateTime.Now;

            ts = dtEnd - dtStart;
            Console.WriteLine();

            
            if (!compData(fileContent, readData))
            {
                int count = fileContent.Length - m3sg.Length;
                Console.WriteLine("写入文件与读取文件不一致,读取比写入少" + count);
                isPass = false;
            }
            string result = "测试文件{0} ,测试长度{1},测试结果{2}";
            Console.WriteLine(string.Format(result, fileId, fileContent.Length, isPass ? "通过" : "不通过"));
            return isPass;
        }

        public static bool compData(byte[] d1,byte[] d2)
        {
            if (d1.Length != d2.Length)
            {
                return false;
            }
            for (int i = 0; i < d1.Length; i++)
            {
                if (d1[i] != d2[i])
                {
                    return false;

                }
            }

            return true;

        }

        public static bool TestFile(ushort fileId, string fileContent)
        {
            
            bool isPass = true;
            DateTime dtStart = DateTime.Now;

            CPUCardWrapper.DeleteFile(fileId);

            if (!CPUCardWrapper.CreateFile(fileId, fileContent, out string msg))
            {
                
                Console.WriteLine("创建文件失败" + msg);
                isPass = false;
            }

            DateTime dtEnd = DateTime.Now;

            TimeSpan ts = dtEnd - dtStart;
            Console.WriteLine();
            dtStart = DateTime.Now;

            if (!CPUCardWrapper.ReadFile(fileId, out string m3sg))
            {

                Console.WriteLine("读取文件失败" + m3sg);
                isPass = false;
            }
            dtEnd = DateTime.Now;

            ts = dtEnd - dtStart;
            Console.WriteLine();

            if (isPass && fileContent != m3sg)
            {
                int count = fileContent.Length - m3sg.Length;
                Console.WriteLine("写入文件与读取文件不一致,读取比写入少" + count);
                isPass = false;
            }
            string result = "测试文件{0} ,测试长度{1},测试结果{2}";
            Console.WriteLine(string.Format(result, fileId, fileContent.Length, isPass ? "通过" : "不通过"));
            return isPass;
        }

        public static string GetRandomString(int fileLenght)
        {
            StringBuilder sdb = new StringBuilder();

            Random r = new Random();
            for (int i = 0; i < fileLenght/2; i++)
            {
                sdb.Append(r.Next(0, 10).ToString());
            }
            if (Encoding.Unicode.GetBytes(sdb.ToString()).Length != fileLenght)
            {
                Console.WriteLine();
            }

            return sdb.ToString();
                ;
        }

        public static void DeleteFile(ushort no)
        {
            for (ushort i = 1; i <= no; i++)
            {
                CPUCardWrapper.DeleteFile(i);

            }
        }
    }
}
