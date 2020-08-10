namespace SimpleVision.Tool.SSZN
{
    partial class FormSSZNAcquisitio
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
            this.DisConnectBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DisConnectBtn
            // 
            this.DisConnectBtn.Enabled = false;
            this.DisConnectBtn.Location = new System.Drawing.Point(117, 84);
            this.DisConnectBtn.Name = "DisConnectBtn";
            this.DisConnectBtn.Size = new System.Drawing.Size(53, 23);
            this.DisConnectBtn.TabIndex = 16;
            this.DisConnectBtn.Text = "断开";
            this.DisConnectBtn.UseVisualStyleBackColor = true;
            this.DisConnectBtn.Click += new System.EventHandler(this.DisConnectBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(183, 84);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(53, 23);
            this.ExitBtn.TabIndex = 15;
            this.ExitBtn.Text = "退出";
            this.ExitBtn.UseVisualStyleBackColor = true;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(56, 84);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(53, 23);
            this.ConnectBtn.TabIndex = 14;
            this.ConnectBtn.Text = "连接";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(194, 57);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 21);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "120";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(148, 57);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 21);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 21);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "168";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "192";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP地址：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormSSZNAcquisitio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DisConnectBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormSSZNAcquisitio";
            this.Text = "FormSSZNAcquisitio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DisConnectBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}