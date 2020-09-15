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
using static socket_GUI.CommonData;

namespace socket_GUI
{
    public partial class XMLInfoGather : UserControl
    {
        public XMLInfoGather()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void XMLInfoGather_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void send_xml_Click(object sender, EventArgs e)
        {
            Send c = new Send();


            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            xml.AppendChild(root);

            XmlElement rootFirst = xml.CreateElement("GATHER_INFO");//根节点
            rootFirst.SetAttribute("AREA_ID", "0000000000");//场站编码
            rootFirst.SetAttribute("CHNL_NO", "0000000000");//通道编码
            rootFirst.SetAttribute("I_E_TYPE", "I");//进出口标志  I表示进卡口 E表示出卡口
            rootFirst.SetAttribute("SEQ_NO", "");//SEQ_NO为20位的字符串。表示报文的序列号，为当时报文唯一标志，在返回放行指令的时候，需要原文返回
            xml.AppendChild(rootFirst);


            //创建 第一行
            //XmlNode row1 = xml.CreateNode(XmlNodeType.Element, "row1", null);
            //row1.InnerText = "第一行";
            //rootFirst.AppendChild(row1);

            //
            XElement row1 = new XElement("IC",//第一节点
                                new XElement("DR_IC_NO", DR_IC_NO.Text), //为第二子节点   IC卡号
                                new XElement("IC_DR_CUSTOMS_NO", IC_DR_CUSTOMS_NO.Text),//也是第二子节点     司机信息（可以为空）
                                new XElement("IC_CO_CUSTOMS_NO", IC_CO_CUSTOMS_NO.Text),//也是第二子节点    公司海关编号（可以为空）
                                new XElement("IC_BILL_NO", IC_BILL_NO.Text),//也是第二子节点          单证号（标签必须有，但是值可以为空）
                                new XElement("IC_GROSS_WT", IC_GROSS_WT.Text),//也是第二子节点         卡内重量（标签必须有，但是值可以为空）
                                new XElement("IC_VE_CUSTOMS_NO", IC_VE_CUSTOMS_NO.Text),//也是第二子节点    卡内重量（标签必须有，但是值可以为空）
                                new XElement("IC_VE_NAME", IC_VE_NAME.Text),//也是第二子节点          卡内车牌号（标签必须有，但是值可以为空）
                                new XElement("IC_CONTA_ID", IC_CONTA_ID.Text),//              卡内集装箱号（标签必须有，但是值可以为空）32位，双箱以”|”分隔，未识别则为NULL
                                new XElement("IC_ESEAL_ID", IC_ESEAL_ID.Text),//也是第二子节点         卡内关锁号（标签必须有，但是值可以为空）
                                new XElement("IC_BUSS_TYPE", IC_BUSS_TYPE.Text),//也是第二子节点        业务类型  最大为10 个字节
                                new XElement("IC_EX_DATA", IC_EX_DATA.Text)//也是第二子节点           

                            //new XAttribute("ID", "1"),//row2属性  id为属性名1为属性值
                            //new XAttribute("name", "cognexPhotoShower")
                            );

            XmlElement cxml = xml.ReadNode(row1.CreateReader()) as XmlElement;//将xml.ReadNode(xmlReader)转型为XmlElement，此时转型操作会失败，不会抛出异常，但cxml会被设为null.
            rootFirst.AppendChild(cxml);


            //创建第二行
            XElement row2 = new XElement("WEIGHT",
                                new XElement("GROSS_WT", GROSS_WT.Text)
                            );


            //将第二行转成 XmlElement ，并添加至 rootFirst 中
            XmlElement cxm2 = xml.ReadNode(row2.CreateReader()) as XmlElement;//将xml.ReadNode(xmlReader)转型为XmlElement，此时转型操作会失败，不会抛出异常，但cxml会被设为null.
            rootFirst.AppendChild(cxm2);



            XElement row3 = new XElement("CAR",
                                new XElement("VE_NAME", VE_NAME.Text),                   //实际车辆牌照号（值可以为空）,如有多个电子标签采用”|”隔开，如只有一个则没有上面分隔符
                                new XElement("CAR_EC_NO", CAR_EC_NO.Text), //车辆电子车牌ID
                                new XElement("CAR_EC_NO2", CAR_EC_NO2.Text),                //车辆电子车牌ID
                                new XElement("VE_CUSTOMS_NO", VE_CUSTOMS_NO.Text),             //海关车辆编号（值可以为空）
                                new XElement("VE_WT", VE_WT.Text)                      //车自重

                            );

            rootFirst.AppendChild(xml.ReadNode(row3.CreateReader()) as XmlElement);

            XElement row4 = new XElement("TRAILER",//车架数据
                                 new XElement("TR_EC_NO", TR_EC_NO.Text),//电子车牌号（标签必须有，但是值可以为空）
                                 new XElement("TR_NAME", TR_NAME.Text),//架号（标签必须有，但是值可以为空）
                                 new XElement("TR_WT", TR_WT.Text)//重量（KG）（标签必须有，但是值可以为空）
                            );
            rootFirst.AppendChild(xml.ReadNode(row4.CreateReader()) as XmlElement);

            XElement row5 = new XElement("CONTA",//集装箱号
                                new XElement("CONTA_NUM", ""),
                                new XElement("CONTA_RECO", CONTA_RECO.Text),//识别是否正常  1正常 0错


                                new XElement("CONTA_ID_F", CONTA_ID_F.Text),//前箱号（标签必须有，但是值可以为空）
                                new XElement("CONTA_ID_B", CONTA_ID_B.Text),//后箱号（标签必须有，但是值可以为空）
                                new XElement("CONTA_MODEL_F", CONTA_MODEL_F.Text),//前箱型（标签必须有，但是值可以为空）
                                new XElement("CONTA_MODEL_B", CONTA_MODEL_B.Text)//后箱型（标签必须有，但是值可以为空）
                );
            rootFirst.AppendChild(xml.ReadNode(row5.CreateReader()) as XmlElement);


            XElement row6 = new XElement("SEAL",
                                new XElement("ESEAL_ID", ESEAL_ID.Text),//电子关锁号,双锁中间以“|”分开
                                new XElement("SEAL_KEY", "")//值为空

                );
            rootFirst.AppendChild(xml.ReadNode(row6.CreateReader()) as XmlElement);

            XElement row7 = new XElement("BAR_CODE", BAR_CODE.Text);//条码号，值可以为空
            rootFirst.AppendChild(xml.ReadNode(row7.CreateReader()) as XmlElement);

            xml.Save("XMLInfoGather");
            string content = c.XmlToString(xml);
            c.SendXml(content, 0x21);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Text = "";
            }
            List<GroupBox> groupBox_list = new List<GroupBox>();
            groupBox_list.Add(groupBox1);
            groupBox_list.Add(groupBox2);
            groupBox_list.Add(groupBox3);
            groupBox_list.Add(groupBox4);


            foreach (GroupBox i in groupBox_list)
            {
                foreach (Control ctrl in i.Controls)
                {
                    if (ctrl is TextBox)
                        ctrl.Text = "";
                }
            }
            ESEAL_ID.Text = "";
            BAR_CODE.Text = "";



        }
    }
}
