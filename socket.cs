using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;



namespace socket
{
    class Program
    {
        static void Main(string[] args)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 9002)); //配置服务器IP与端口  
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }



            byte[] socket_Baotou = new byte[4];//包头码
            socket_Baotou[0] = 0xE2;
            socket_Baotou[1] = 0x5C;
            socket_Baotou[2] = 0x4B;
            socket_Baotou[3] = 0x89;

            //计算文件长度
            //static int GetFileSize(string sFullName)
            //{
            //    long lSize = 0;
            //    if (File.Exists(sFullName))
            //        lSize = new FileInfo(sFullName).Length;

            //    return (int)lSize;
            //}

            //long xml_size = GetFileSize(@"C:\Users\wangyuanping\Desktop\C#\my\XMLInfoGather.xml");
            //计算文件大小

            string path = @"C:\Users\wangyuanping\Desktop\zz.xml";//文件大小
            //int xml_size = GetFileSize(path);
            FileInfo fi = new FileInfo(path);
            long size = fi.Length;
            int xml_size = (int)size;

            
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();//新建对象
            doc.Load(path);//XML文件路径
            string content = doc.InnerXml;
            Console.WriteLine(content);//把xml文件


            Console.WriteLine("xml_size 字符串长度为{0}字节", xml_size);


            //整数转byte[4]
            static bool ConvertIntToByteArray(long m, ref byte[] arry)//整数转4个字节
            {
                if (arry == null) return false;
                if (arry.Length < 4) return false;

                arry[0] = (byte)(m & 0xFF);
                Console.WriteLine(arry[0]);
                arry[1] = (byte)((m & 0xFF00) >> 8);
                arry[2] = (byte)((m & 0xFF0000) >> 16);
                arry[3] = (byte)((m >> 24) & 0xFF);
                return true;
            }

            //byte[] my_arry = new byte[4];
            //ConvertIntToByteArray(xml_size + 40, ref my_arry); //发送总长

            //Console.WriteLine(my_arry);

            byte[] Total_Length = BitConverter.GetBytes(xml_size + 40); //总包总长
            Console.WriteLine(Total_Length);

            byte[] Information_type = new byte[1];//消息类型

            Information_type[0] = 0x21;//


            byte[] Identification_code = new byte[4];//辨识码 00 00 00 00 
            Identification_code[0] = 0x00;
            Identification_code[1] = 0x00;
            Identification_code[2] = 0x00;
            Identification_code[3] = 0x00;


            byte[] code_length = new byte[4];//xml文件字节大小
            //ConvertIntToByteArray(xml_size, ref code_length); 
            code_length = BitConverter.GetBytes(xml_size);

            Console.WriteLine("xml_size 文本长度长度为{0}字符串长度{1}", xml_size, code_length);

            byte[] socket_data1 = new byte[2];//发送包尾
            socket_data1[0] = 0xFF;
            socket_data1[1] = 0xFF;
        


            clientSocket.Send(socket_Baotou);//包头码
            clientSocket.Send(Total_Length);//总包长
            clientSocket.Send(Information_type);//消息类型
            clientSocket.Send(Encoding.UTF8.GetBytes(("0000110000")));//场地标志
            clientSocket.Send(Encoding.UTF8.GetBytes(("0000001141")));
            clientSocket.Send(Encoding.UTF8.GetBytes(("I")));//进出口标志
            clientSocket.Send(Identification_code);//辨识码 00 00 00 00 
            clientSocket.Send(code_length);//发送包长度
          //clientSocket.Send(Encoding.UTF8.GetBytes("123456789")); //发送文件
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    clientSocket.Send(Encoding.UTF8.GetBytes(line));

                }
             clientSocket.Send(socket_data1);
             Console.ReadLine();






            }
        }
    }
}
