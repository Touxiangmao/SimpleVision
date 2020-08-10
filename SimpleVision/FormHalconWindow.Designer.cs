namespace SimpleVision
{
      partial class FormHalconWindow
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
            this.halconWindow1 = new SimpleVision.Base.ViewRoi.HalconWindow();
            this.SuspendLayout();
            // 
            // halconWindow1
            // 
            this.halconWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindow1.Location = new System.Drawing.Point(0, 0);
            this.halconWindow1.Name = "halconWindow1";
            this.halconWindow1.Size = new System.Drawing.Size(800, 450);
            this.halconWindow1.TabIndex = 0;
            // 
            // FormHalconWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.halconWindow1);
            this.Name = "FormHalconWindow";
            this.Text = "FormHalconWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private Base.ViewRoi.HalconWindow halconWindow1;
    }
}