namespace CodeHelper
{
    partial class MainFrm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBPW = new System.Windows.Forms.TextBox();
            this.tBUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cBDataSource = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBDLLName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBResultType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBDatabase = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btBuild = new System.Windows.Forms.Button();
            this.btChoose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBPW);
            this.groupBox1.Controls.Add(this.tBUserName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBDataSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录数据库";
            // 
            // tBPW
            // 
            this.tBPW.Location = new System.Drawing.Point(68, 102);
            this.tBPW.Name = "tBPW";
            this.tBPW.PasswordChar = '*';
            this.tBPW.Size = new System.Drawing.Size(111, 21);
            this.tBPW.TabIndex = 6;
            this.tBPW.TextChanged += new System.EventHandler(this.tBPW_TextChanged);
            // 
            // tBUserName
            // 
            this.tBUserName.Location = new System.Drawing.Point(68, 71);
            this.tBUserName.Name = "tBUserName";
            this.tBUserName.Size = new System.Drawing.Size(110, 21);
            this.tBUserName.TabIndex = 5;
            this.tBUserName.TextChanged += new System.EventHandler(this.tBUserName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "密码:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "用户名:";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(104, 129);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 2;
            this.btLogin.Text = "登录";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库服务器";
            // 
            // cBDataSource
            // 
            this.cBDataSource.FormattingEnabled = true;
            this.cBDataSource.Location = new System.Drawing.Point(15, 36);
            this.cBDataSource.Name = "cBDataSource";
            this.cBDataSource.Size = new System.Drawing.Size(165, 20);
            this.cBDataSource.TabIndex = 0;
            this.cBDataSource.SelectedIndexChanged += new System.EventHandler(this.cBDataSource_SelectedIndexChanged);
            this.cBDataSource.SelectedValueChanged += new System.EventHandler(this.cBDataSource_SelectedValueChanged);
            this.cBDataSource.TextChanged += new System.EventHandler(this.cBDataSource_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBDLLName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cBResultType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cBDatabase);
            this.groupBox2.Location = new System.Drawing.Point(12, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 285);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "具体操作";
            // 
            // cBDLLName
            // 
            this.cBDLLName.FormattingEnabled = true;
            this.cBDLLName.Location = new System.Drawing.Point(13, 216);
            this.cBDLLName.Name = "cBDLLName";
            this.cBDLLName.Size = new System.Drawing.Size(165, 20);
            this.cBDLLName.TabIndex = 10;
            this.cBDLLName.SelectedIndexChanged += new System.EventHandler(this.cBDLLName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "使用的类库:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "生成的类型:";
            // 
            // cBResultType
            // 
            this.cBResultType.FormattingEnabled = true;
            this.cBResultType.Location = new System.Drawing.Point(13, 259);
            this.cBResultType.Name = "cBResultType";
            this.cBResultType.Size = new System.Drawing.Size(165, 20);
            this.cBResultType.TabIndex = 7;
            this.cBResultType.SelectedIndexChanged += new System.EventHandler(this.cBResultType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "选择数据表：";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(13, 74);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(165, 124);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择数据库:";
            // 
            // cBDatabase
            // 
            this.cBDatabase.FormattingEnabled = true;
            this.cBDatabase.Location = new System.Drawing.Point(13, 32);
            this.cBDatabase.Name = "cBDatabase";
            this.cBDatabase.Size = new System.Drawing.Size(165, 20);
            this.cBDatabase.TabIndex = 1;
            this.cBDatabase.SelectedIndexChanged += new System.EventHandler(this.cBDatabase_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 471);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 116);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "具体要求：";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(228, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 603);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // btBuild
            // 
            this.btBuild.Location = new System.Drawing.Point(116, 593);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(86, 23);
            this.btBuild.TabIndex = 15;
            this.btBuild.Text = "产生代码";
            this.btBuild.UseVisualStyleBackColor = true;
            this.btBuild.Click += new System.EventHandler(this.btBuild_Click);
            // 
            // btChoose
            // 
            this.btChoose.Location = new System.Drawing.Point(13, 593);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(85, 23);
            this.btChoose.TabIndex = 14;
            this.btChoose.Text = "选择传入参数";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 622);
            this.Controls.Add(this.btBuild);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.Text = "代码助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBDataSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox tBPW;
        private System.Windows.Forms.TextBox tBUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.ComboBox cBResultType;
        private System.Windows.Forms.ComboBox cBDLLName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;

    }
}

