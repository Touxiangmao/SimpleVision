namespace SimpleVision
{
    partial class FormProjects
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_AddProject = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(401, 319);
            this.dataGridView1.TabIndex = 9;
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(12, 347);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 35);
            this.btn_select.TabIndex = 10;
            this.btn_select.Text = "选择项目";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_AddProject
            // 
            this.btn_AddProject.Location = new System.Drawing.Point(338, 347);
            this.btn_AddProject.Name = "btn_AddProject";
            this.btn_AddProject.Size = new System.Drawing.Size(75, 35);
            this.btn_AddProject.TabIndex = 11;
            this.btn_AddProject.Text = "新建项目";
            this.btn_AddProject.UseVisualStyleBackColor = true;
            this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "数值";
            this.Column2.Name = "Column2";
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 390);
            this.Controls.Add(this.btn_AddProject);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormProjects";
            this.Text = "FormProjects";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProjects_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_AddProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}