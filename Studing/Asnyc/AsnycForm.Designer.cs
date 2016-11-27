namespace Asnyc
{
    partial class AsnycForm
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
            this.btnAsnyc = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsnycAdvance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAsnyc
            // 
            this.btnAsnyc.Location = new System.Drawing.Point(61, 51);
            this.btnAsnyc.Name = "btnAsnyc";
            this.btnAsnyc.Size = new System.Drawing.Size(75, 23);
            this.btnAsnyc.TabIndex = 0;
            this.btnAsnyc.Text = "异步调用";
            this.btnAsnyc.UseVisualStyleBackColor = true;
            this.btnAsnyc.Click += new System.EventHandler(this.btnAsnyc_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(61, 115);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "同步调用";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsnycAdvance
            // 
            this.btnAsnycAdvance.Location = new System.Drawing.Point(61, 171);
            this.btnAsnycAdvance.Name = "btnAsnycAdvance";
            this.btnAsnycAdvance.Size = new System.Drawing.Size(75, 23);
            this.btnAsnycAdvance.TabIndex = 2;
            this.btnAsnycAdvance.Text = "异步进阶";
            this.btnAsnycAdvance.UseVisualStyleBackColor = true;
            this.btnAsnycAdvance.Click += new System.EventHandler(this.btnAsnycAdvance_Click);
            // 
            // AsnycForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnAsnycAdvance);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnAsnyc);
            this.Name = "AsnycForm";
            this.Text = "AsnycForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAsnyc;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsnycAdvance;
    }
}

