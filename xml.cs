using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace socket_cs
{
    class Class1
    {
        public void XMLInfoGather()//0x21 表示向海关平台发送采集数据
        {
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
                                new XElement("DR_IC_NO", "SBM0002035"), //为第二子节点   IC卡号
                                new XElement("IC_DR_CUSTOMS_NO", ""),//也是第二子节点     司机信息（可以为空）
                                new XElement("IC_CO_CUSTOMS_NO", ""),//也是第二子节点    公司海关编号（可以为空）
                                new XElement("IC_BILL_NO", ""),//也是第二子节点          单证号（标签必须有，但是值可以为空）
                                new XElement("IC_GROSS_WT", ""),//也是第二子节点         卡内重量（标签必须有，但是值可以为空）
                                new XElement("IC_VE_CUSTOMS_NO", ""),//也是第二子节点    卡内重量（标签必须有，但是值可以为空）
                                new XElement("IC_VE_NAME", ""),//也是第二子节点          卡内车牌号（标签必须有，但是值可以为空）
                                new XElement("IC_CONTA_ID", "qwerty234"),//              卡内集装箱号（标签必须有，但是值可以为空）32位，双箱以”|”分隔，未识别则为NULL
                                new XElement("IC_ESEAL_ID", ""),//也是第二子节点         卡内关锁号（标签必须有，但是值可以为空）
                                new XElement("IC_BUSS_TYPE", ""),//也是第二子节点        业务类型  最大为10 个字节
                                new XElement("IC_EX_DATA", "")//也是第二子节点           

                            //new XAttribute("ID", "1"),//row2属性  id为属性名1为属性值
                            //new XAttribute("name", "cognexPhotoShower")
                            );

            XmlElement cxml = xml.ReadNode(row1.CreateReader()) as XmlElement;//将xml.ReadNode(xmlReader)转型为XmlElement，此时转型操作会失败，不会抛出异常，但cxml会被设为null.
            rootFirst.AppendChild(cxml);


            //创建第二行
            XElement row2 = new XElement("WEIGHT",
                                new XElement("GROSS_WT", "67899")
                            );


            //将第二行转成 XmlElement ，并添加至 rootFirst 中
            XmlElement cxm2 = xml.ReadNode(row2.CreateReader()) as XmlElement;//将xml.ReadNode(xmlReader)转型为XmlElement，此时转型操作会失败，不会抛出异常，但cxml会被设为null.
            rootFirst.AppendChild(cxm2);



            XElement row3 = new XElement("CAR",
                                new XElement("VE_NAME", ""),                   //实际车辆牌照号（值可以为空）,如有多个电子标签采用”|”隔开，如只有一个则没有上面分隔符
                                new XElement("CAR_EC_NO", "E4004F43405933A0"), //车辆电子车牌ID
                                new XElement("CAR_EC_NO2", ""),                //车辆电子车牌ID
                                new XElement("VE_CUSTOMS_NO", ""),             //海关车辆编号（值可以为空）
                                new XElement("VE_WT", "")                      //车自重

                            );

            rootFirst.AppendChild(xml.ReadNode(row3.CreateReader()) as XmlElement);

            XElement row4 = new XElement("TRAILER",//车架数据
                                 new XElement("TR_EC_NO", ""),//电子车牌号（标签必须有，但是值可以为空）
                                 new XElement("TR_NAME", ""),//车架号（标签必须有，但是值可以为空）
                                 new XElement("TR_WT", "")//重量（KG）（标签必须有，但是值可以为空）
                            );
            rootFirst.AppendChild(xml.ReadNode(row4.CreateReader()) as XmlElement);

            XElement row5 = new XElement("CONTA",//集装箱号
                     new XElement("CONTA_NUM", "2"),
                     new XElement("CONTA_RECO", "1"),//识别是否正常  1正常 0错


                     new XElement("CONTA_ID_F", "HLXU4074106"),//前箱号（标签必须有，但是值可以为空）
                     new XElement("CONTA_ID_B", "FCIU9176921"),//后箱号（标签必须有，但是值可以为空）
                     new XElement("CONTA_MODEL_F", "20"),//前箱型（标签必须有，但是值可以为空）
                     new XElement("CONTA_MODEL_B", "20")//后箱型（标签必须有，但是值可以为空）
                );
            rootFirst.AppendChild(xml.ReadNode(row5.CreateReader()) as XmlElement);


            XElement row6 = new XElement("SEAL",
                     new XElement("ESEAL_ID", "10011003"),//电子关锁号,双锁中间以“|”分开
                     new XElement("SEAL_KEY", "")//值为空

                );
            rootFirst.AppendChild(xml.ReadNode(row6.CreateReader()) as XmlElement);

            XElement row7 = new XElement("BAR_CODE", "");//条码号，值可以为空
            rootFirst.AppendChild(xml.ReadNode(row7.CreateReader()) as XmlElement);
            Console.WriteLine(XmlToString(xml));
            xml.Save("XMLInfoGather");

            //XElement contacts =
            //    new XElement("Contacts",
            //    new XElement("Contact",
            //        new XElement("Name", "Patrick Hines"),
            //        new XElement("Phone", "206-555-0144",
            //            new XAttribute("Type", "Home")),
            //        new XElement("phone", "425-555-0145",
            //            new XAttribute("Type", "Work")),
            //        new XElement("Address",
            //            new XElement("Street1", "123 Main St"),
            //            new XElement("City", "Mercer Island"),
            //            new XElement("State", "WA"),
            //            new XElement("Postal", "68042")
            //        )
            //    )
            //);
        }
        public void XMLInfoWLJKRet()//ox22 表示为海关平台控制数据返回操作
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            xml.AppendChild(root);

            XmlElement rootFirst = xml.CreateElement("COMMAND_INFO");//根节点
            rootFirst.SetAttribute("AREA_ID", "0000000000");//场站编码
            rootFirst.SetAttribute("CHNL_NO", "0000000000");//通道编码
            rootFirst.SetAttribute("I_E_TYPE", "I");//进出口标志  I表示进卡口 E表示出卡口
            rootFirst.SetAttribute("SEQ_NO", "");//SEQ_NO为20位的字符串。表示报文的序列号，为当时报文唯一标志，在返回放行指令的时候，需要原文返回
            xml.AppendChild(rootFirst);

            XElement row1 = new XElement("CHECK_RESULT","00000000000000000000");




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

            XElement row4 = new XElement("FORM_ID",""
                     );

            XmlElement cxm4 = xml.ReadNode(row4.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm4);


            XElement row5 = new XElement("OP_HINT", ""
                     );

            XmlElement cxm5 = xml.ReadNode(row5.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm5);
            
            Console.WriteLine(XmlToString(xml));
            xml.Save("XMLInfoWLJKRet");


        }
        public void XMLControlCommand() 
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            xml.AppendChild(root);

            XmlElement rootFirst = xml.CreateElement("COMMAND_INFO");//根节点
            rootFirst.SetAttribute("AREA_ID", "0000000000");//场站编码
            rootFirst.SetAttribute("CHNL_NO", "0000000000");//通道编码
            rootFirst.SetAttribute("I_E_TYPE", "I");//进出口标志  I表示进卡口 E表示出卡口
            rootFirst.SetAttribute("SEQ_NO", "");//SEQ_NO为20位的字符串。表示报文的序列号，为当时报文唯一标志，在返回放行指令的时候，需要原文返回
            xml.AppendChild(rootFirst);

            XElement row1 = new XElement("EXCUTE_COMMAND",""
                     );

            XmlElement cxm1 = xml.ReadNode(row1.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm1);

            XElement row2 = new XElement("GPS", 
                                new XElement("VE_NAME", ""),
                                new XElement("GPS_ID", ""),
                                new XElement("ORIGIN_CUSTOMS", ""),
                                new XElement("DEST_CUSTOMS", "")
                     );

            XmlElement cxm2 = xml.ReadNode(row2.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm2);

            XElement row3 = new XElement("SEAL",
                    new XElement("ESEAL_ID", "123"),
                    new XElement("SEAL_KEY", "123~!#$"),
                    new XElement("OPEN_TIMES", "")
                    );

            XmlElement cxm3 = xml.ReadNode(row3.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm3);

            XElement row4 = new XElement("ContaNum", "");
            XmlElement cxm4 = xml.ReadNode(row4.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm4);

            XElement row5 = new XElement("OP_TYPE", "");
            XmlElement cxm5 = xml.ReadNode(row5.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm5);

            XElement row6 = new XElement("OP_REASON", "");
            XmlElement cxm6 = xml.ReadNode(row6.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm6);

            XElement row7 = new XElement("OP_ID", "");
            XmlElement cxm7 = xml.ReadNode(row7.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm7);

            Console.WriteLine(XmlToString(xml));
            xml.Save("XMLControlCommand");

        }

        public void XMLControlFeedback()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            xml.AppendChild(root);

            XmlElement rootFirst = xml.CreateElement("COMMAND_INFO");//根节点
            rootFirst.SetAttribute("AREA_ID", "0000000000");//场站编码
            rootFirst.SetAttribute("CHNL_NO", "0000000000");//通道编码
            rootFirst.SetAttribute("I_E_TYPE", "I");//进出口标志  I表示进卡口 E表示出卡口
            rootFirst.SetAttribute("SEQ_NO", "");//SEQ_NO为20位的字符串。表示报文的序列号，为当时报文唯一标志，在返回放行指令的时候，需要原文返回
            xml.AppendChild(rootFirst);

            XElement row1 = new XElement("EXECUTE_RESULT", ""
                     );
            XmlElement cxm1 = xml.ReadNode(row1.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm1);

            XElement row2 = new XElement("SEAL",
                                new XElement("OPEN_TIMES", "")
                     );
            XmlElement cxm2 = xml.ReadNode(row2.CreateReader()) as XmlElement;
            rootFirst.AppendChild(cxm2);


            Console.WriteLine(XmlToString(xml));
            xml.Save("XMLControlFeedback");
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
}
