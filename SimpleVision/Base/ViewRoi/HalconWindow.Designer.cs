namespace SimpleVision.Base.ViewRoi
{
    partial class HalconWindow
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
            this.components = new System.ComponentModel.Container();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无动作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复位窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.hWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(680, 484);
            this.hWindowControl1.TabIndex = 3;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(680, 484);
            this.hWindowControl1.SizeChanged += new System.EventHandler(this.hWindowControl1_SizeChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.缩放ToolStripMenuItem,
            this.移动ToolStripMenuItem,
            this.无动作ToolStripMenuItem,
            this.复位窗口ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 92);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.缩放ToolStripMenuItem.Text = "缩放+移动";
            this.缩放ToolStripMenuItem.Click += new System.EventHandler(this.缩放ToolStripMenuItem_Click);
            // 
            // 移动ToolStripMenuItem
            // 
            this.移动ToolStripMenuItem.Name = "移动ToolStripMenuItem";
            this.移动ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.移动ToolStripMenuItem.Text = "仅移动";
            this.移动ToolStripMenuItem.Click += new System.EventHandler(this.移动ToolStripMenuItem_Click);
            // 
            // 无动作ToolStripMenuItem
            // 
            this.无动作ToolStripMenuItem.Name = "无动作ToolStripMenuItem";
            this.无动作ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.无动作ToolStripMenuItem.Text = "无动作";
            this.无动作ToolStripMenuItem.Click += new System.EventHandler(this.无动作ToolStripMenuItem_Click);
            // 
            // 复位窗口ToolStripMenuItem
            // 
            this.复位窗口ToolStripMenuItem.Name = "复位窗口ToolStripMenuItem";
            this.复位窗口ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.复位窗口ToolStripMenuItem.Text = "复位窗口";
            this.复位窗口ToolStripMenuItem.Click += new System.EventHandler(this.复位窗口ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(680, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // HalconWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.hWindowControl1);
            this.Name = "HalconWindow";
            this.Size = new System.Drawing.Size(680, 484);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.ToolStripMenuItem 缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无动作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复位窗口ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}
