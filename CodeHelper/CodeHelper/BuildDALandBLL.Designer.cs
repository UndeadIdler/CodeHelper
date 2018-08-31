namespace CodeHelper
{
    partial class BuildDALandBLL
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
            this.label1 = new System.Windows.Forms.Label();
            this.cBReturnType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBOperation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBCommandType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BReturnID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "返回值类型：";
            // 
            // cBReturnType
            // 
            this.cBReturnType.FormattingEnabled = true;
            this.cBReturnType.Items.AddRange(new object[] {
            "string",
            "int",
            "bool",
            "Entity",
            "List<Entity>"});
            this.cBReturnType.Location = new System.Drawing.Point(88, 35);
            this.cBReturnType.Name = "cBReturnType";
            this.cBReturnType.Size = new System.Drawing.Size(99, 20);
            this.cBReturnType.TabIndex = 2;
            this.cBReturnType.SelectedIndexChanged += new System.EventHandler(this.cBReturnType_SelectedIndexChanged);
            this.cBReturnType.SelectedValueChanged += new System.EventHandler(this.cBReturnType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "操作类型：";
            // 
            // cBOperation
            // 
            this.cBOperation.FormattingEnabled = true;
            this.cBOperation.Location = new System.Drawing.Point(88, 9);
            this.cBOperation.Name = "cBOperation";
            this.cBOperation.Size = new System.Drawing.Size(99, 20);
            this.cBOperation.TabIndex = 4;
            this.cBOperation.SelectedIndexChanged += new System.EventHandler(this.cBOperation_SelectedIndexChanged);
            this.cBOperation.SelectedValueChanged += new System.EventHandler(this.cBOperation_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "CommandType：";
            // 
            // cBCommandType
            // 
            this.cBCommandType.FormattingEnabled = true;
            this.cBCommandType.Items.AddRange(new object[] {
            "Text",
            "StoredProcedure"});
            this.cBCommandType.Location = new System.Drawing.Point(88, 61);
            this.cBCommandType.Name = "cBCommandType";
            this.cBCommandType.Size = new System.Drawing.Size(99, 20);
            this.cBCommandType.TabIndex = 6;
            this.cBCommandType.SelectedIndexChanged += new System.EventHandler(this.cBCommandType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "是否返回ID：";
            // 
            // BReturnID
            // 
            this.BReturnID.FormattingEnabled = true;
            this.BReturnID.Items.AddRange(new object[] {
            "是",
            "否"});
            this.BReturnID.Location = new System.Drawing.Point(88, 87);
            this.BReturnID.Name = "BReturnID";
            this.BReturnID.Size = new System.Drawing.Size(99, 20);
            this.BReturnID.TabIndex = 11;
            this.BReturnID.SelectedIndexChanged += new System.EventHandler(this.BReturnID_SelectedIndexChanged);
            // 
            // BuildDALandBLL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BReturnID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBCommandType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBOperation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBReturnType);
            this.Name = "BuildDALandBLL";
            this.Size = new System.Drawing.Size(193, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBReturnType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBOperation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBCommandType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BReturnID;
    }
}
