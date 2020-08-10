namespace SimpleVision
{
    partial class FormTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvw_tools = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvw_tools
            // 
            this.tvw_tools.AllowDrop = true;
            this.tvw_tools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw_tools.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_tools.FullRowSelect = true;
            this.tvw_tools.Indent = 30;
            this.tvw_tools.ItemHeight = 30;
            this.tvw_tools.LineColor = System.Drawing.Color.Green;
            this.tvw_tools.Location = new System.Drawing.Point(0, 0);
            this.tvw_tools.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tvw_tools.Name = "tvw_tools";
            this.tvw_tools.ShowLines = false;
            this.tvw_tools.ShowPlusMinus = false;
            this.tvw_tools.ShowRootLines = false;
            this.tvw_tools.Size = new System.Drawing.Size(395, 450);
            this.tvw_tools.TabIndex = 24;
            this.tvw_tools.DoubleClick += new System.EventHandler(this.tvw_job_DoubleClick);
            // 
            // FormTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.tvw_tools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTools";
            this.Text = "FormTools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTools_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvw_tools;
    }
}