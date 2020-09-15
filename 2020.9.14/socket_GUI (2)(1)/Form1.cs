using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace socket_GUI
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public XMLInfoGather InfoGather;
        public XMLInfoWLJKRet InfoWLJKRet;
        public XMLControlCommand ControlCommand;
        public XMLControlFeedback ControlFeedback;




        private void Form1_Load(object sender, EventArgs e)
        {
            InfoGather = new XMLInfoGather();
            InfoWLJKRet = new XMLInfoWLJKRet();
            ControlCommand = new XMLControlCommand();
            ControlFeedback = new XMLControlFeedback();

            Output.Display_Output = output_taxtbox;
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void box_Click(object sender, EventArgs e)
        {

        }

        private void XMLInfoGather_Butter_Click(object sender, EventArgs e)
        {
            InfoGather.Show();
            input_groupBox.Controls.Clear();
            input_groupBox.Controls.Add(InfoGather);
            Output.Display_Output.AppendText("打开了" + "XMLInfoGather" + "界面\r\n");
        }

        private void XMLInfoWLJKRet_Butter_Click(object sender, EventArgs e)
        {
            InfoWLJKRet.Show();
            input_groupBox.Controls.Clear();
            input_groupBox.Controls.Add(InfoWLJKRet);
            Output.Display_Output.AppendText("打开了" + "XMLInfoWLJKRet" + "界面\r\n");
        }

        private void XMLControlCommand_Butter_Click(object sender, EventArgs e)
        {
            ControlCommand.Show();
            input_groupBox.Controls.Clear();
            input_groupBox.Controls.Add(ControlCommand);
            Output.Display_Output.AppendText("打开了" + "XMLControlCommand" + "界面\r\n");
        }

        private void XMLControlFeedback_Butter_Click(object sender, EventArgs e)
        {
            ControlFeedback.Show();
            input_groupBox.Controls.Clear();
            input_groupBox.Controls.Add(ControlFeedback);
            Output.Display_Output.AppendText("打开了" + "XMLControlFeedback" + "界面\r\n");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        //创建接收消息的线程
        Thread threadReceive;
        string str;
        private void connect_Butter_Click(object sender, EventArgs e)
        {
            if (CommonData.Key_atatus == false)
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(IP_textBox.Text);

                    CommonData.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    CommonData.clientSocket.Connect(new IPEndPoint(ip, int.Parse(Port1_textBox.Text))); //配置服务器IP与端口  
                    Output.Display_Output.AppendText("socket连接成功\r\n");
                    connect_Butter.Text = "断开连接";
                    CommonData.Key_atatus = true;
                    IP_textBox.Enabled = false;
                    Port1_textBox.Enabled = false;
                    Port2_textBox.Enabled = false;


                    SocketServer socketServer = new SocketServer(IP_textBox.Text, int.Parse(Port2_textBox.Text));
                    socketServer.StartListen();



                }
                catch
                {
                    Output.Display_Output.AppendText("socket连接失败请加检查你的IP地址和端口号是否正确\r\n");
                    MessageBox.Show("连接失败");

                }
            }
            else
            {
                CommonData.clientSocket.Close();
                connect_Butter.Text = "连接";
                IP_textBox.Enabled = true;
                Port1_textBox.Enabled = true;
                Port2_textBox.Enabled = true;

                Output.Display_Output.AppendText("socket以断开连接\r\n");
                CommonData.Key_atatus = false;
            }
        }


    }

        public static class Output
        {
            private static TextBox display;

            public static TextBox Display_Output
            {
                get
                {
                    return display;
                }
                set
                {
                    display = value;

                }
            }
        }

    
}






