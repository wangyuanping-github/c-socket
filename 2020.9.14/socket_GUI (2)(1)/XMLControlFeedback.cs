using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using socket_GUI;

namespace socket_GUI
{
    public partial class XMLControlFeedback : UserControl
    {
        public XMLControlFeedback()
        {
            InitializeComponent();
        }

        private void XMLControlFeedback_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            Send c = new Send();



            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            xml.AppendChild(root);

            XmlElement rootFirst = xml.CreateElement("COMMAND_INFO");//根节点
            rootFirst.SetAttribute("AREA_ID", "0000000000");//场站编码
            rootFirst.SetAttribute("CHNL_NO", "0000000000");//通道编码
            rootFirst.SetAttribute("I_E_TYPE", "I");//进出口标志  I表示进卡口 E表示出卡口
            rootFirst.SetAttribute("SEQ_NO", "");//SEQ_NO为20位的字符串。表示报文的序列号，为当时报文唯一标志，在返回放行指令的时候，需要原文返回
            xml.AppendChild(rootFirst);

            XElement row1 = new XElement("CHECK_RESULT", "00000000000000000000");




            XmlElement cxml = xml.ReadNode(row1.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxml);

            XElement row2 = new XElement("GPS",
                    new XElement("VE_NAME", ""),
                    new XElement("GPS_ID", ""),
                    new XElement("ORIGIN_CUSTOMS", ""),
                    new XElement("DEST_CUSTOMS", "")

                );

            XmlElement cxm2 = xml.ReadNode(row2.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm2);

            XElement row3 = new XElement("SEAL",
                     new XElement("ESEAL_ID", ""),
                     new XElement("SEAL_KEY", "")
                     );

            XmlElement cxm3 = xml.ReadNode(row3.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm3);

            XElement row4 = new XElement("FORM_ID", ""
                     );

            XmlElement cxm4 = xml.ReadNode(row4.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm4);


            XElement row5 = new XElement("OP_HINT", ""
                     );

            XmlElement cxm5 = xml.ReadNode(row5.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm5);

            Console.WriteLine(c.XmlToString(xml));
            xml.Save("XMLInfoGather");
            string content = c.XmlToString(xml);
            c.SendXml(content, 0x32);

        }
    }
}
