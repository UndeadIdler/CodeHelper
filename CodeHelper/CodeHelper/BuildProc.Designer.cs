namespace CodeHelper
{
    partial class BuildProc
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cBType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BPReturnID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cBType
            // 
            this.cBType.FormattingEnabled = true;
            this.cBType.Items.AddRange(new object[] {
            "Add",
            "Delete",
            "Update",
            "IsExists",
            "Get",
            "GetAll"});
            this.cBType.Location = new System.Drawing.Point(81, 26);
            this.cBType.Name = "cBType";
            this.cBType.Size = new System.Drawing.Size(109, 20);
            this.cBType.TabIndex = 0;
            this.cBType.SelectedIndexChanged += new System.EventHandler(this.cBType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "操作类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "是否返回ID：";
            // 
            // BPReturnID
            // 
            this.BPReturnID.FormattingEnabled = true;
            this.BPReturnID.Items.AddRange(new object[] {
            "是",
            "否"});
            this.BPReturnID.Location = new System.Drawing.Point(81, 60);
            this.BPReturnID.Name = "BPReturnID";
            this.BPReturnID.Size = new System.Drawing.Size(109, 20);
            this.BPReturnID.TabIndex = 3;
            this.BPReturnID.SelectedIndexChanged += new System.EventHandler(this.BPReturnID_SelectedIndexChanged);
            // 
            // BuildProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BPReturnID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBType);
            this.Name = "BuildProc";
            this.Size = new System.Drawing.Size(193, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BPReturnID;
    }
}
