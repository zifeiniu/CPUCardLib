namespace CPUCardTestFrm
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button11 = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCMd = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button13 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.labYue = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1095, 567);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(112, 34);
            this.button11.TabIndex = 47;
            this.button11.Text = "读取文件";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(54, 612);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(439, 439);
            this.txtContent.TabIndex = 46;
            this.txtContent.Text = "ABCDEF";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(504, 675);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(183, 34);
            this.button10.TabIndex = 45;
            this.button10.Text = "写入文件";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(504, 621);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(183, 34);
            this.button6.TabIndex = 44;
            this.button6.Text = "创建二进制文件";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(490, 453);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(225, 34);
            this.button9.TabIndex = 43;
            this.button9.Text = "选择文件夹";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(237, 274);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(165, 34);
            this.button8.TabIndex = 42;
            this.button8.Text = "擦除当前DF/文件";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "PIN";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(146, 188);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(324, 28);
            this.txtPin.TabIndex = 40;
            this.txtPin.Text = "FFFFFFFFFFFF";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(490, 188);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 34);
            this.button7.TabIndex = 39;
            this.button7.Text = "VERIFY PIN";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 453);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "文件标识";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(738, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "命令";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(146, 123);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(324, 28);
            this.txtPwd.TabIndex = 35;
            this.txtPwd.Text = "FFFFFFFFFFFFFFFF";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1154, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 34;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(146, 448);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(324, 28);
            this.txtFileName.TabIndex = 33;
            this.txtFileName.Text = "0001";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(490, 364);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(225, 34);
            this.button5.TabIndex = 32;
            this.button5.Text = "选择文件(根据名称)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(88, 274);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 31;
            this.button4.Text = "选择MF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(490, 123);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 30;
            this.button2.Text = "外部认证";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(490, 46);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 29;
            this.button3.Text = "选择设备";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCMd
            // 
            this.txtCMd.Location = new System.Drawing.Point(820, 52);
            this.txtCMd.Margin = new System.Windows.Forms.Padding(4);
            this.txtCMd.Multiline = true;
            this.txtCMd.Name = "txtCMd";
            this.txtCMd.Size = new System.Drawing.Size(326, 72);
            this.txtCMd.TabIndex = 28;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(146, 46);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(324, 26);
            this.comboBox1.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 50;
            this.label3.Text = "读卡器";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(194, 567);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(183, 34);
            this.button12.TabIndex = 51;
            this.button12.Text = "打开文件";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 579);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 52;
            this.label6.Text = "要写入的内容";
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(768, 612);
            this.txtRead.Margin = new System.Windows.Forms.Padding(4);
            this.txtRead.Multiline = true;
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(439, 439);
            this.txtRead.TabIndex = 53;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(504, 734);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(183, 34);
            this.button13.TabIndex = 54;
            this.button13.Text = "创建并写入文件";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtLog.Location = new System.Drawing.Point(1340, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(608, 1178);
            this.txtLog.TabIndex = 55;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(444, 274);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(112, 34);
            this.button14.TabIndex = 56;
            this.button14.Text = "Test";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(1154, 90);
            this.button15.Margin = new System.Windows.Forms.Padding(4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(112, 34);
            this.button15.TabIndex = 57;
            this.button15.Text = "解析命令";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(1102, 287);
            this.button16.Margin = new System.Windows.Forms.Padding(4);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(208, 45);
            this.button16.TabIndex = 58;
            this.button16.Text = "枚举所有的文件标识符";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(1104, 341);
            this.button17.Margin = new System.Windows.Forms.Padding(4);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(208, 45);
            this.button17.TabIndex = 59;
            this.button17.Text = "读取长安通公交卡余额";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(88, 332);
            this.button18.Margin = new System.Windows.Forms.Padding(4);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(165, 30);
            this.button18.TabIndex = 60;
            this.button18.Text = "创建目录文件";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // labYue
            // 
            this.labYue.AutoSize = true;
            this.labYue.Location = new System.Drawing.Point(1068, 300);
            this.labYue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labYue.Name = "labYue";
            this.labYue.Size = new System.Drawing.Size(17, 18);
            this.labYue.TabIndex = 61;
            this.labYue.Text = " ";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(920, 383);
            this.button19.Margin = new System.Windows.Forms.Padding(4);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(165, 30);
            this.button19.TabIndex = 62;
            this.button19.Text = "创建目录文件";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(860, 527);
            this.button20.Margin = new System.Windows.Forms.Padding(4);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(225, 34);
            this.button20.TabIndex = 63;
            this.button20.Text = "选择目录（根据标识符）";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(831, 146);
            this.button21.Margin = new System.Windows.Forms.Padding(4);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(112, 34);
            this.button21.TabIndex = 64;
            this.button21.Text = "ASCII解码";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(1229, 1017);
            this.button22.Margin = new System.Windows.Forms.Padding(4);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(112, 34);
            this.button22.TabIndex = 65;
            this.button22.Text = "清空日志";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(490, 505);
            this.button23.Margin = new System.Windows.Forms.Padding(4);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(225, 34);
            this.button23.TabIndex = 66;
            this.button23.Text = "选择文件";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1948, 1178);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.labYue);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtCMd);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " CPU 卡 操作工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCMd;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Label labYue;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
    }
}

