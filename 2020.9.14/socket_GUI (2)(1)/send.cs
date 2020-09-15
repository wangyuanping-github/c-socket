using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static socket_GUI.Form1;

namespace socket_GUI
{
    public static class CommonData
    {

        private static Socket ClientSocket;

        public static Socket clientSocket
        {
            get { return ClientSocket; }
            set { ClientSocket = value; }
        }


        private static bool key_status = false;
        public static bool Key_atatus 
        {
            get { return key_status; }
            set { key_status = value; }
        }



    }
    public class Send
        {
            public void SendXml(string content, byte information_type)
            {
            if (CommonData.Key_atatus == true)
            {
                byte[] socket_Baotou = new byte[4];//包头码
                socket_Baotou[0] = 0xE2;
                socket_Baotou[1] = 0x5C;
                socket_Baotou[2] = 0x4B;
                socket_Baotou[3] = 0x89;

                //FileInfo fi = new FileInfo(path);
                //long size = fi.Length;
                //int xml_size = (int)size;


                //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();//新建对象
                //doc.Load(path);//XML文件路径
                //string content = doc.InnerXml;
                //Console.WriteLine(content.Length);
                int xml_size = System.Text.Encoding.Default.GetBytes(content.ToCharArray()).Length;


                byte[] Total_Length = BitConverter.GetBytes(xml_size + 40); //总包总长

                byte[] Information_type = new byte[1];//消息类型

                Information_type[0] = information_type;


                byte[] Identification_code = new byte[4];//辨识码 00 00 00 00 
                Identification_code[0] = 0x00;
                Identification_code[1] = 0x00;
                Identification_code[2] = 0x00;
                Identification_code[3] = 0x00;

                byte[] code_length = BitConverter.GetBytes(xml_size);

                Console.WriteLine("xml_size 文本长度长度为{0}字符串长度{1}", xml_size, code_length);

                byte[] socket_data1 = new byte[2];//发送包尾
                socket_data1[0] = 0xFF;
                socket_data1[1] = 0xFF;



                CommonData.clientSocket.Send(socket_Baotou);//包头码
                CommonData.clientSocket.Send(Total_Length);//总包长
                CommonData.clientSocket.Send(Information_type);//消息类型
                CommonData.clientSocket.Send(Encoding.UTF8.GetBytes(("0000110000")));//场地标志
                CommonData.clientSocket.Send(Encoding.UTF8.GetBytes(("0000001141")));
                CommonData.clientSocket.Send(Encoding.UTF8.GetBytes(("I")));//进出口标志
                CommonData.clientSocket.Send(Identification_code);//辨识码 00 00 00 00 
                CommonData.clientSocket.Send(code_length);

                CommonData.clientSocket.Send(Encoding.UTF8.GetBytes(content));
                CommonData.clientSocket.Send(socket_data1);

                Output.Display_Output.AppendText("socket以发送\r\n");



            }
            else  
            {
                Output.Display_Output.AppendText("socket未连接\r\n");
                MessageBox.Show("请先连接");




            }

        }
            public string XmlToString(XmlDocument xmlDoc)
            {

                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, null);
                writer.Formatting = Formatting.Indented;
                xmlDoc.Save(writer);
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                stream.Position = 0;
                string xmlString = sr.ReadToEnd();
                sr.Close();
                stream.Close();
                return xmlString;

            }

        
    }


    public class SocketServer
    {
        private string _ip = string.Empty;
        private int _port = 0;
        private Socket _socket = null;
        private byte[] buffer = new byte[1024 * 1024 * 2];

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">监听的IP</param>
        /// <param name="port">监听的端口</param>
        public SocketServer(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }
        public SocketServer(int port)
        {
            this._ip = "0.0.0.0";
            this._port = port;
        }

        public void StartListen()
        {
            try
            {
                //1.0 实例化套接字(IP4寻找协议,流式协议,TCP协议)
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.0 创建IP对象
                IPAddress address = IPAddress.Parse(_ip);
                //3.0 创建网络端口,包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, _port);
                //4.0 绑定套接字
                _socket.Bind(endPoint);
                //5.0 设置最大连接数
                _socket.Listen(int.MaxValue);
                Console.WriteLine("监听{0}消息成功", _socket.LocalEndPoint.ToString());
                //6.0 开始监听
                Thread thread = new Thread(ListenClientConnect);
                thread.Start();

            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private void ListenClientConnect()
        {
            try
            {
                while (true)
                {
                    //Socket创建的新连接
                    Socket clientSocket = _socket.Accept();
                    //clientSocket.Send(Encoding.UTF8.GetBytes("服务端发送消息:"));
                    Thread thread = new Thread(ReceiveMessage);
                    thread.Start(clientSocket);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 接收客户端消息
        /// </summary>
        /// <param name="socket">来自客户端的socket</param>
        private void ReceiveMessage(object socket)
        {

            Socket socketSend = socket as Socket;
            while (true)
            {
                //客户端连接成功后，服务器接收客户端发送的消息
                byte[] buffer = new byte[2048];
                //实际接收到的有效字节数
                int count = socketSend.Receive(buffer);
                if (count == 0)//count 表示客户端关闭，要退出循环
                {
                    break;
                }
                else
                {
                    string keyword = Encoding.GetEncoding(936).GetString(buffer, 0, count);
                    string keyword2 = Encoding.ASCII.GetString(buffer, 0, count);

                    string strReceiveMsg = "接收：" + socketSend.RemoteEndPoint + "发送的消息:" + keyword + "\r\n";
                    string strReceiveMsg2 = "接收：" + socketSend.RemoteEndPoint + "发送的消息:" + keyword2 + "\r\n";


                    Output.Display_Output.AppendText(strReceiveMsg);
                    Output.Display_Output.AppendText(strReceiveMsg2);
                    string t1 = "";

                    foreach (byte b in buffer)
                    {

                        t1 += b.ToString("") + "　";

                    }
                    Output.Display_Output.AppendText(t1+"\r\n");



                }


            }

        }
    }
            
            
        
    




}
