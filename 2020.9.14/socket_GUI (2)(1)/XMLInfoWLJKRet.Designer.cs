namespace socket_GUI
{
    partial class XMLInfoWLJKRet
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SEQ_NO = new System.Windows.Forms.TextBox();
            this.CHNL_NO = new System.Windows.Forms.TextBox();
            this.I_E_TYPE = new System.Windows.Forms.TextBox();
            this.AREA_ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OPEN_TIMES = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.send_xml = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EXECUTE_RESULT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SEQ_NO);
            this.groupBox1.Controls.Add(this.CHNL_NO);
            this.groupBox1.Controls.Add(this.I_E_TYPE);
            this.groupBox1.Controls.Add(this.AREA_ID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(85, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 248);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            // 
            // SEQ_NO
            // 
            this.SEQ_NO.Location = new System.Drawing.Point(101, 202);
            this.SEQ_NO.Name = "SEQ_NO";
            this.SEQ_NO.Size = new System.Drawing.Size(121, 21);
            this.SEQ_NO.TabIndex = 15;
            // 
            // CHNL_NO
            // 
            this.CHNL_NO.Location = new System.Drawing.Point(101, 92);
            this.CHNL_NO.Name = "CHNL_NO";
            this.CHNL_NO.Size = new System.Drawing.Size(121, 21);
            this.CHNL_NO.TabIndex = 14;
            // 
            // I_E_TYPE
            // 
            this.I_E_TYPE.Location = new System.Drawing.Point(101, 145);
            this.I_E_TYPE.Name = "I_E_TYPE";
            this.I_E_TYPE.Size = new System.Drawing.Size(121, 21);
            this.I_E_TYPE.TabIndex = 12;
            // 
            // AREA_ID
            // 
            this.AREA_ID.Location = new System.Drawing.Point(101, 40);
            this.AREA_ID.Name = "AREA_ID";
            this.AREA_ID.Size = new System.Drawing.Size(121, 21);
            this.AREA_ID.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "通道编码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "报文序列号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "进出口卡口标志";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "场地编码";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OPEN_TIMES);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(436, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 93);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "关锁信息部分";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // OPEN_TIMES
            // 
            this.OPEN_TIMES.Location = new System.Drawing.Point(111, 37);
            this.OPEN_TIMES.Name = "OPEN_TIMES";
            this.OPEN_TIMES.Size = new System.Drawing.Size(106, 21);
            this.OPEN_TIMES.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-2, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "电子锁开启次数";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(615, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // send_xml
            // 
            this.send_xml.Location = new System.Drawing.Point(436, 231);
            this.send_xml.Name = "send_xml";
            this.send_xml.Size = new System.Drawing.Size(75, 23);
            this.send_xml.TabIndex = 19;
            this.send_xml.Text = "发送";
            this.send_xml.UseVisualStyleBackColor = true;
            this.send_xml.Click += new System.EventHandler(this.send_xml_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "0x32 XMLControlFeedback";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EXECUTE_RESULT
            // 
            this.EXECUTE_RESULT.Location = new System.Drawing.Point(547, 177);
            this.EXECUTE_RESULT.Name = "EXECUTE_RESULT";
            this.EXECUTE_RESULT.Size = new System.Drawing.Size(106, 21);
            this.EXECUTE_RESULT.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "控制指令执行结果";
            // 
            // XMLInfoWLJKRet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EXECUTE_RESULT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.send_xml);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "XMLInfoWLJKRet";
            this.Size = new System.Drawing.Size(770, 310);
            this.Load += new System.EventHandler(this.XMLInfoWLJKRet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SEQ_NO;
        private System.Windows.Forms.TextBox CHNL_NO;
        private System.Windows.Forms.TextBox I_E_TYPE;
        private System.Windows.Forms.TextBox AREA_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox OPEN_TIMES;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button send_xml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EXECUTE_RESULT;
        private System.Windows.Forms.Label label4;
    }
}
