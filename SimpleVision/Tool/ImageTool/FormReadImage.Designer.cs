namespace SimpleVision.Tool.ImageTool
{
    partial class FormReadImage
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
            this.btn_RunSelect = new System.Windows.Forms.Button();
            this.listBox_image = new System.Windows.Forms.ListBox();
            this.btn_selectImageDirectory = new System.Windows.Forms.Button();
            this.lbl_imageNum = new System.Windows.Forms.Label();
            this.btn_MoveUp = new System.Windows.Forms.Button();
            this.btn_nextImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RunSelect
            // 
            this.btn_RunSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_RunSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RunSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RunSelect.Location = new System.Drawing.Point(183, 506);
            this.btn_RunSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_RunSelect.Name = "btn_RunSelect";
            this.btn_RunSelect.Size = new System.Drawing.Size(84, 32);
            this.btn_RunSelect.TabIndex = 65;
            this.btn_RunSelect.TabStop = false;
            this.btn_RunSelect.Text = "当前图片";
            this.btn_RunSelect.UseVisualStyleBackColor = true;
            this.btn_RunSelect.Click += new System.EventHandler(this.btn_RunSelect_Click);
            // 
            // listBox_image
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBox_image, 5);
            this.listBox_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_image.FormattingEnabled = true;
            this.listBox_image.ItemHeight = 12;
            this.listBox_image.Location = new System.Drawing.Point(3, 3);
            this.listBox_image.Name = "listBox_image";
            this.listBox_image.Size = new System.Drawing.Size(446, 496);
            this.listBox_image.TabIndex = 64;
            this.listBox_image.SelectedIndexChanged += new System.EventHandler(this.listBox_image_SelectedIndexChanged);
            // 
            // btn_selectImageDirectory
            // 
            this.btn_selectImageDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_selectImageDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectImageDirectory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectImageDirectory.Location = new System.Drawing.Point(3, 506);
            this.btn_selectImageDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_selectImageDirectory.Name = "btn_selectImageDirectory";
            this.btn_selectImageDirectory.Size = new System.Drawing.Size(84, 32);
            this.btn_selectImageDirectory.TabIndex = 63;
            this.btn_selectImageDirectory.Text = "选择路径";
            this.btn_selectImageDirectory.UseVisualStyleBackColor = true;
            this.btn_selectImageDirectory.Click += new System.EventHandler(this.btn_selectImageDirectory_Click);
            // 
            // lbl_imageNum
            // 
            this.lbl_imageNum.AutoSize = true;
            this.lbl_imageNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_imageNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_imageNum.Location = new System.Drawing.Point(93, 502);
            this.lbl_imageNum.Name = "lbl_imageNum";
            this.lbl_imageNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_imageNum.Size = new System.Drawing.Size(84, 40);
            this.lbl_imageNum.TabIndex = 62;
            this.lbl_imageNum.Text = "0张";
            this.lbl_imageNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_MoveUp
            // 
            this.btn_MoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_MoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MoveUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveUp.Location = new System.Drawing.Point(273, 506);
            this.btn_MoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_MoveUp.Name = "btn_MoveUp";
            this.btn_MoveUp.Size = new System.Drawing.Size(84, 32);
            this.btn_MoveUp.TabIndex = 9;
            this.btn_MoveUp.TabStop = false;
            this.btn_MoveUp.Text = "<<";
            this.btn_MoveUp.UseVisualStyleBackColor = true;
            this.btn_MoveUp.Click += new System.EventHandler(this.btn_MoveUp_Click);
            // 
            // btn_nextImage
            // 
            this.btn_nextImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_nextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nextImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nextImage.Location = new System.Drawing.Point(363, 506);
            this.btn_nextImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_nextImage.Name = "btn_nextImage";
            this.btn_nextImage.Size = new System.Drawing.Size(86, 32);
            this.btn_nextImage.TabIndex = 8;
            this.btn_nextImage.TabStop = false;
            this.btn_nextImage.Text = ">>";
            this.btn_nextImage.UseVisualStyleBackColor = true;
            this.btn_nextImage.Click += new System.EventHandler(this.btn_nextImage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_RunSelect, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_nextImage, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_MoveUp, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_selectImageDirectory, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox_image, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_imageNum, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 542);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // FormReadImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormReadImage";
            this.Text = "FormReadImage";
            this.Load += new System.EventHandler(this.FormReadImage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btn_selectImageDirectory;
        public System.Windows.Forms.Label lbl_imageNum;
        internal System.Windows.Forms.Button btn_MoveUp;
        internal System.Windows.Forms.Button btn_nextImage;
        private System.Windows.Forms.ListBox listBox_image;
        internal System.Windows.Forms.Button btn_RunSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}