﻿namespace CodeHelper
{
    partial class BuildEntity
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
            this.label2 = new System.Windows.Forms.Label();
            this.cBEntityType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "实体类型：";
            // 
            // cBEntityType
            // 
            this.cBEntityType.FormattingEnabled = true;
            this.cBEntityType.Location = new System.Drawing.Point(91, 18);
            this.cBEntityType.Name = "cBEntityType";
            this.cBEntityType.Size = new System.Drawing.Size(99, 20);
            this.cBEntityType.TabIndex = 6;
            this.cBEntityType.SelectedIndexChanged += new System.EventHandler(this.cBEntityType_SelectedIndexChanged);
            // 
            // BuildEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBEntityType);
            this.Name = "BuildEntity";
            this.Size = new System.Drawing.Size(193, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBEntityType;
    }
}
