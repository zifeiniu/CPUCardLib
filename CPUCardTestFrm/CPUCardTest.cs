using CPUCardTestFrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPUCardTestFrm
{
    /// <summary>
    /// 简单的命令行测试卡
    /// </summary>
    public class CPUCardTest
    {

        /// <summary>
        /// 测试
        /// </summary>
        public static void TestMain()
        {
            DateTime dt = DateTime.Now;
            ushort FileCount = 10;
           // DeleteFile(FileCount);

             
            for (int i = 40000; i < 1024 * 70; i +=2000)
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
            for (ushort i = 1; i < no; i++)
            {
                CPUCardWrapper.DeleteFile(i);

            }
        }
    }
}
