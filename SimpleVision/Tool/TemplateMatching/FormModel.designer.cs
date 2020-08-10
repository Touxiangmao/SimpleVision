namespace SimpleVision.Tool.TemplateMatching
{
    partial class FormModel
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
            this.button_CreateShapeModel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Optimization = new System.Windows.Forms.ComboBox();
            this.label_Optimization = new System.Windows.Forms.Label();
            this.comboBox_scaleStep = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label_scaleMax = new System.Windows.Forms.Label();
            this.textBox_scaleMax = new System.Windows.Forms.TextBox();
            this.textBox_scaleMin = new System.Windows.Forms.TextBox();
            this.label_scaleMin = new System.Windows.Forms.Label();
            this.comboBox_MinContrast = new System.Windows.Forms.ComboBox();
            this.comboBox_Contrast = new System.Windows.Forms.ComboBox();
            this.comboBox_Metric = new System.Windows.Forms.ComboBox();
            this.comboBox_AngleStep = new System.Windows.Forms.ComboBox();
            this.comboBox_NumLevels = new System.Windows.Forms.ComboBox();
            this.label_MinContrast = new System.Windows.Forms.Label();
            this.label_Metric = new System.Windows.Forms.Label();
            this.label_Contrast = new System.Windows.Forms.Label();
            this.label_AngleExtent = new System.Windows.Forms.Label();
            this.label_AngleStep = new System.Windows.Forms.Label();
            this.textBox_AngleExtent = new System.Windows.Forms.TextBox();
            this.label_NumLevels = new System.Windows.Forms.Label();
            this.textBox_AngleStart = new System.Windows.Forms.TextBox();
            this.label_AngleStart = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.roiCreator1 = new SimpleVision.Base.ViewRoi.RoiCreator();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.roiCreator2 = new SimpleVision.Base.ViewRoi.RoiCreator();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_FindScaleMax = new System.Windows.Forms.TextBox();
            this.textBox_FindScaleMin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_Greediness = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_NumLevels = new System.Windows.Forms.TextBox();
            this.textBox_MaxOverlap = new System.Windows.Forms.TextBox();
            this.textBox_NumMatches = new System.Windows.Forms.TextBox();
            this.textBox_MinScore = new System.Windows.Forms.TextBox();
            this.comboBox_SubPixel = new System.Windows.Forms.ComboBox();
            this.button_FindShapeModel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_FindAngleExtent = new System.Windows.Forms.TextBox();
            this.textBox_FindAngleStart = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.halconWindow1 = new SimpleVision.Base.ViewRoi.HalconWindow();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_CreateShapeModel
            // 
            this.button_CreateShapeModel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_CreateShapeModel.Location = new System.Drawing.Point(72, 305);
            this.button_CreateShapeModel.Name = "button_CreateShapeModel";
            this.button_CreateShapeModel.Size = new System.Drawing.Size(97, 33);
            this.button_CreateShapeModel.TabIndex = 1;
            this.button_CreateShapeModel.Text = "创建模板";
            this.button_CreateShapeModel.UseVisualStyleBackColor = true;
            this.button_CreateShapeModel.Click += new System.EventHandler(this.button_CreateShapeModel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Optimization);
            this.groupBox2.Controls.Add(this.label_Optimization);
            this.groupBox2.Controls.Add(this.comboBox_scaleStep);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label_scaleMax);
            this.groupBox2.Controls.Add(this.textBox_scaleMax);
            this.groupBox2.Controls.Add(this.textBox_scaleMin);
            this.groupBox2.Controls.Add(this.label_scaleMin);
            this.groupBox2.Controls.Add(this.button_CreateShapeModel);
            this.groupBox2.Controls.Add(this.comboBox_MinContrast);
            this.groupBox2.Controls.Add(this.comboBox_Contrast);
            this.groupBox2.Controls.Add(this.comboBox_Metric);
            this.groupBox2.Controls.Add(this.comboBox_AngleStep);
            this.groupBox2.Controls.Add(this.comboBox_NumLevels);
            this.groupBox2.Controls.Add(this.label_MinContrast);
            this.groupBox2.Controls.Add(this.label_Metric);
            this.groupBox2.Controls.Add(this.label_Contrast);
            this.groupBox2.Controls.Add(this.label_AngleExtent);
            this.groupBox2.Controls.Add(this.label_AngleStep);
            this.groupBox2.Controls.Add(this.textBox_AngleExtent);
            this.groupBox2.Controls.Add(this.label_NumLevels);
            this.groupBox2.Controls.Add(this.textBox_AngleStart);
            this.groupBox2.Controls.Add(this.label_AngleStart);
            this.groupBox2.Location = new System.Drawing.Point(8, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 341);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模板参数";
            // 
            // comboBox_Optimization
            // 
            this.comboBox_Optimization.FormattingEnabled = true;
            this.comboBox_Optimization.Items.AddRange(new object[] {
            "auto",
            "no_pregeneration",
            "none",
            "point_reduction_high",
            "point_reduction_low",
            "point_reduction_medium",
            "pregeneration"});
            this.comboBox_Optimization.Location = new System.Drawing.Point(99, 201);
            this.comboBox_Optimization.Name = "comboBox_Optimization";
            this.comboBox_Optimization.Size = new System.Drawing.Size(95, 20);
            this.comboBox_Optimization.TabIndex = 45;
            this.comboBox_Optimization.Text = "auto";
            // 
            // label_Optimization
            // 
            this.label_Optimization.AutoSize = true;
            this.label_Optimization.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Optimization.Location = new System.Drawing.Point(29, 201);
            this.label_Optimization.Name = "label_Optimization";
            this.label_Optimization.Size = new System.Drawing.Size(65, 20);
            this.label_Optimization.TabIndex = 44;
            this.label_Optimization.Text = "优化方法";
            // 
            // comboBox_scaleStep
            // 
            this.comboBox_scaleStep.FormattingEnabled = true;
            this.comboBox_scaleStep.Items.AddRange(new object[] {
            "auto",
            "0.1",
            "0.2",
            "0.3"});
            this.comboBox_scaleStep.Location = new System.Drawing.Point(99, 172);
            this.comboBox_scaleStep.Name = "comboBox_scaleStep";
            this.comboBox_scaleStep.Size = new System.Drawing.Size(95, 20);
            this.comboBox_scaleStep.TabIndex = 43;
            this.comboBox_scaleStep.Text = "auto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(29, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "缩放步长";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(29, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.TabIndex = 40;
            this.label15.Text = "优化方法";
            // 
            // label_scaleMax
            // 
            this.label_scaleMax.AutoSize = true;
            this.label_scaleMax.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_scaleMax.Location = new System.Drawing.Point(29, 145);
            this.label_scaleMax.Name = "label_scaleMax";
            this.label_scaleMax.Size = new System.Drawing.Size(65, 20);
            this.label_scaleMax.TabIndex = 28;
            this.label_scaleMax.Text = "最大缩放";
            // 
            // textBox_scaleMax
            // 
            this.textBox_scaleMax.Location = new System.Drawing.Point(99, 145);
            this.textBox_scaleMax.Name = "textBox_scaleMax";
            this.textBox_scaleMax.Size = new System.Drawing.Size(95, 21);
            this.textBox_scaleMax.TabIndex = 30;
            this.textBox_scaleMax.Text = "1";
            // 
            // textBox_scaleMin
            // 
            this.textBox_scaleMin.Location = new System.Drawing.Point(99, 119);
            this.textBox_scaleMin.Name = "textBox_scaleMin";
            this.textBox_scaleMin.Size = new System.Drawing.Size(95, 21);
            this.textBox_scaleMin.TabIndex = 27;
            this.textBox_scaleMin.Text = "0.5";
            // 
            // label_scaleMin
            // 
            this.label_scaleMin.AutoSize = true;
            this.label_scaleMin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_scaleMin.Location = new System.Drawing.Point(29, 120);
            this.label_scaleMin.Name = "label_scaleMin";
            this.label_scaleMin.Size = new System.Drawing.Size(65, 20);
            this.label_scaleMin.TabIndex = 26;
            this.label_scaleMin.Text = "最小缩放";
            // 
            // comboBox_MinContrast
            // 
            this.comboBox_MinContrast.FormattingEnabled = true;
            this.comboBox_MinContrast.Items.AddRange(new object[] {
            "auto",
            "1",
            "2",
            "3",
            "5",
            "7",
            "10",
            "20",
            "30",
            "40"});
            this.comboBox_MinContrast.Location = new System.Drawing.Point(99, 283);
            this.comboBox_MinContrast.Name = "comboBox_MinContrast";
            this.comboBox_MinContrast.Size = new System.Drawing.Size(95, 20);
            this.comboBox_MinContrast.TabIndex = 25;
            this.comboBox_MinContrast.Text = "auto";
            // 
            // comboBox_Contrast
            // 
            this.comboBox_Contrast.FormattingEnabled = true;
            this.comboBox_Contrast.Items.AddRange(new object[] {
            "auto",
            "auto_contrast",
            "auto_contrast_hyst",
            "auto_min_size",
            "10",
            "20",
            "30",
            "40",
            "60",
            "80",
            "100",
            "120",
            "140",
            "160"});
            this.comboBox_Contrast.Location = new System.Drawing.Point(99, 257);
            this.comboBox_Contrast.Name = "comboBox_Contrast";
            this.comboBox_Contrast.Size = new System.Drawing.Size(95, 20);
            this.comboBox_Contrast.TabIndex = 24;
            this.comboBox_Contrast.Text = "auto";
            // 
            // comboBox_Metric
            // 
            this.comboBox_Metric.FormattingEnabled = true;
            this.comboBox_Metric.Items.AddRange(new object[] {
            "ignore_color_polarity",
            "ignore_global_polarity",
            "ignore_local_polarity",
            "use_polarity"});
            this.comboBox_Metric.Location = new System.Drawing.Point(99, 231);
            this.comboBox_Metric.Name = "comboBox_Metric";
            this.comboBox_Metric.Size = new System.Drawing.Size(95, 20);
            this.comboBox_Metric.TabIndex = 23;
            this.comboBox_Metric.Text = "use_polarity";
            // 
            // comboBox_AngleStep
            // 
            this.comboBox_AngleStep.FormattingEnabled = true;
            this.comboBox_AngleStep.Items.AddRange(new object[] {
            "auto",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_AngleStep.Location = new System.Drawing.Point(99, 93);
            this.comboBox_AngleStep.Name = "comboBox_AngleStep";
            this.comboBox_AngleStep.Size = new System.Drawing.Size(95, 20);
            this.comboBox_AngleStep.TabIndex = 21;
            this.comboBox_AngleStep.Text = "auto";
            // 
            // comboBox_NumLevels
            // 
            this.comboBox_NumLevels.FormattingEnabled = true;
            this.comboBox_NumLevels.Items.AddRange(new object[] {
            "auto",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox_NumLevels.Location = new System.Drawing.Point(99, 13);
            this.comboBox_NumLevels.Name = "comboBox_NumLevels";
            this.comboBox_NumLevels.Size = new System.Drawing.Size(95, 20);
            this.comboBox_NumLevels.TabIndex = 20;
            this.comboBox_NumLevels.Text = "auto";
            // 
            // label_MinContrast
            // 
            this.label_MinContrast.AutoSize = true;
            this.label_MinContrast.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MinContrast.Location = new System.Drawing.Point(35, 283);
            this.label_MinContrast.Name = "label_MinContrast";
            this.label_MinContrast.Size = new System.Drawing.Size(51, 20);
            this.label_MinContrast.TabIndex = 17;
            this.label_MinContrast.Text = "对比度";
            // 
            // label_Metric
            // 
            this.label_Metric.AutoSize = true;
            this.label_Metric.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Metric.Location = new System.Drawing.Point(29, 231);
            this.label_Metric.Name = "label_Metric";
            this.label_Metric.Size = new System.Drawing.Size(65, 20);
            this.label_Metric.TabIndex = 13;
            this.label_Metric.Text = "匹配制度";
            // 
            // label_Contrast
            // 
            this.label_Contrast.AutoSize = true;
            this.label_Contrast.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Contrast.Location = new System.Drawing.Point(29, 257);
            this.label_Contrast.Name = "label_Contrast";
            this.label_Contrast.Size = new System.Drawing.Size(65, 20);
            this.label_Contrast.TabIndex = 14;
            this.label_Contrast.Text = "最小尺寸";
            // 
            // label_AngleExtent
            // 
            this.label_AngleExtent.AutoSize = true;
            this.label_AngleExtent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_AngleExtent.Location = new System.Drawing.Point(29, 66);
            this.label_AngleExtent.Name = "label_AngleExtent";
            this.label_AngleExtent.Size = new System.Drawing.Size(65, 20);
            this.label_AngleExtent.TabIndex = 6;
            this.label_AngleExtent.Text = "角度范围";
            // 
            // label_AngleStep
            // 
            this.label_AngleStep.AutoSize = true;
            this.label_AngleStep.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_AngleStep.Location = new System.Drawing.Point(29, 93);
            this.label_AngleStep.Name = "label_AngleStep";
            this.label_AngleStep.Size = new System.Drawing.Size(65, 20);
            this.label_AngleStep.TabIndex = 7;
            this.label_AngleStep.Text = "角度步长";
            // 
            // textBox_AngleExtent
            // 
            this.textBox_AngleExtent.Location = new System.Drawing.Point(99, 66);
            this.textBox_AngleExtent.Name = "textBox_AngleExtent";
            this.textBox_AngleExtent.Size = new System.Drawing.Size(95, 21);
            this.textBox_AngleExtent.TabIndex = 8;
            this.textBox_AngleExtent.Text = "45";
            // 
            // label_NumLevels
            // 
            this.label_NumLevels.AutoSize = true;
            this.label_NumLevels.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_NumLevels.Location = new System.Drawing.Point(43, 13);
            this.label_NumLevels.Name = "label_NumLevels";
            this.label_NumLevels.Size = new System.Drawing.Size(37, 20);
            this.label_NumLevels.TabIndex = 2;
            this.label_NumLevels.Text = "等级";
            // 
            // textBox_AngleStart
            // 
            this.textBox_AngleStart.Location = new System.Drawing.Point(99, 39);
            this.textBox_AngleStart.Name = "textBox_AngleStart";
            this.textBox_AngleStart.Size = new System.Drawing.Size(95, 21);
            this.textBox_AngleStart.TabIndex = 5;
            this.textBox_AngleStart.Text = "0";
            // 
            // label_AngleStart
            // 
            this.label_AngleStart.AutoSize = true;
            this.label_AngleStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_AngleStart.Location = new System.Drawing.Point(29, 40);
            this.label_AngleStart.Name = "label_AngleStart";
            this.label_AngleStart.Size = new System.Drawing.Size(65, 20);
            this.label_AngleStart.TabIndex = 3;
            this.label_AngleStart.Text = "开始角度";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(825, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 636);
            this.tabControl1.TabIndex = 14;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.roiCreator1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 610);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "模板创建";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // roiCreator1
            // 
            this.roiCreator1.Location = new System.Drawing.Point(3, 0);
            this.roiCreator1.Name = "roiCreator1";
            this.roiCreator1.Size = new System.Drawing.Size(241, 260);
            this.roiCreator1.TabIndex = 14;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.roiCreator2);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 610);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模板搜寻";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // roiCreator2
            // 
            this.roiCreator2.Location = new System.Drawing.Point(3, 17);
            this.roiCreator2.Name = "roiCreator2";
            this.roiCreator2.Size = new System.Drawing.Size(241, 251);
            this.roiCreator2.TabIndex = 17;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBox_FindScaleMax);
            this.groupBox4.Controls.Add(this.textBox_FindScaleMin);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox_Greediness);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.textBox_NumLevels);
            this.groupBox4.Controls.Add(this.textBox_MaxOverlap);
            this.groupBox4.Controls.Add(this.textBox_NumMatches);
            this.groupBox4.Controls.Add(this.textBox_MinScore);
            this.groupBox4.Controls.Add(this.comboBox_SubPixel);
            this.groupBox4.Controls.Add(this.button_FindShapeModel);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textBox_FindAngleExtent);
            this.groupBox4.Controls.Add(this.textBox_FindAngleStart);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(9, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 333);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "模板参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(36, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "最大缩放";
            // 
            // textBox_FindScaleMax
            // 
            this.textBox_FindScaleMax.Location = new System.Drawing.Point(106, 94);
            this.textBox_FindScaleMax.Name = "textBox_FindScaleMax";
            this.textBox_FindScaleMax.Size = new System.Drawing.Size(95, 21);
            this.textBox_FindScaleMax.TabIndex = 38;
            this.textBox_FindScaleMax.Text = "1";
            // 
            // textBox_FindScaleMin
            // 
            this.textBox_FindScaleMin.Location = new System.Drawing.Point(106, 67);
            this.textBox_FindScaleMin.Name = "textBox_FindScaleMin";
            this.textBox_FindScaleMin.Size = new System.Drawing.Size(95, 21);
            this.textBox_FindScaleMin.TabIndex = 35;
            this.textBox_FindScaleMin.Text = "0.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(36, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 34;
            this.label14.Text = "最小缩放";
            // 
            // textBox_Greediness
            // 
            this.textBox_Greediness.Location = new System.Drawing.Point(106, 255);
            this.textBox_Greediness.Name = "textBox_Greediness";
            this.textBox_Greediness.Size = new System.Drawing.Size(95, 21);
            this.textBox_Greediness.TabIndex = 31;
            this.textBox_Greediness.Text = "0.9";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(36, 256);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "贪婪度";
            // 
            // textBox_NumLevels
            // 
            this.textBox_NumLevels.Location = new System.Drawing.Point(106, 228);
            this.textBox_NumLevels.Name = "textBox_NumLevels";
            this.textBox_NumLevels.Size = new System.Drawing.Size(95, 21);
            this.textBox_NumLevels.TabIndex = 29;
            this.textBox_NumLevels.Text = "1";
            // 
            // textBox_MaxOverlap
            // 
            this.textBox_MaxOverlap.Location = new System.Drawing.Point(106, 175);
            this.textBox_MaxOverlap.Name = "textBox_MaxOverlap";
            this.textBox_MaxOverlap.Size = new System.Drawing.Size(95, 21);
            this.textBox_MaxOverlap.TabIndex = 28;
            this.textBox_MaxOverlap.Text = "0.5";
            // 
            // textBox_NumMatches
            // 
            this.textBox_NumMatches.Location = new System.Drawing.Point(106, 148);
            this.textBox_NumMatches.Name = "textBox_NumMatches";
            this.textBox_NumMatches.Size = new System.Drawing.Size(95, 21);
            this.textBox_NumMatches.TabIndex = 27;
            this.textBox_NumMatches.Text = "1";
            // 
            // textBox_MinScore
            // 
            this.textBox_MinScore.Location = new System.Drawing.Point(106, 121);
            this.textBox_MinScore.Name = "textBox_MinScore";
            this.textBox_MinScore.Size = new System.Drawing.Size(95, 21);
            this.textBox_MinScore.TabIndex = 26;
            this.textBox_MinScore.Text = "0.5";
            // 
            // comboBox_SubPixel
            // 
            this.comboBox_SubPixel.FormattingEnabled = true;
            this.comboBox_SubPixel.Items.AddRange(new object[] {
            "interpolation",
            "least_squares",
            "least_squares_high",
            "least_squares_very_high",
            "max_deformation 1",
            "max_deformation 2",
            "max_deformation 3",
            "max_deformation 4",
            "max_deformation 5",
            "max_deformation 6",
            "none"});
            this.comboBox_SubPixel.Location = new System.Drawing.Point(106, 202);
            this.comboBox_SubPixel.Name = "comboBox_SubPixel";
            this.comboBox_SubPixel.Size = new System.Drawing.Size(95, 20);
            this.comboBox_SubPixel.TabIndex = 25;
            this.comboBox_SubPixel.Text = "least_squares";
            // 
            // button_FindShapeModel
            // 
            this.button_FindShapeModel.Location = new System.Drawing.Point(73, 282);
            this.button_FindShapeModel.Name = "button_FindShapeModel";
            this.button_FindShapeModel.Size = new System.Drawing.Size(89, 30);
            this.button_FindShapeModel.TabIndex = 0;
            this.button_FindShapeModel.Text = "搜寻模板";
            this.button_FindShapeModel.UseVisualStyleBackColor = true;
            this.button_FindShapeModel.Click += new System.EventHandler(this.button_FindShapeModel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(25, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "金字塔等级";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(36, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "最大重叠";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(25, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "亚像素精度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(36, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "结果个数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(36, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "角度范围";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(36, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "最低分数";
            // 
            // textBox_FindAngleExtent
            // 
            this.textBox_FindAngleExtent.Location = new System.Drawing.Point(106, 40);
            this.textBox_FindAngleExtent.Name = "textBox_FindAngleExtent";
            this.textBox_FindAngleExtent.Size = new System.Drawing.Size(95, 21);
            this.textBox_FindAngleExtent.TabIndex = 8;
            this.textBox_FindAngleExtent.Text = "45";
            // 
            // textBox_FindAngleStart
            // 
            this.textBox_FindAngleStart.Location = new System.Drawing.Point(106, 13);
            this.textBox_FindAngleStart.Name = "textBox_FindAngleStart";
            this.textBox_FindAngleStart.Size = new System.Drawing.Size(95, 21);
            this.textBox_FindAngleStart.TabIndex = 5;
            this.textBox_FindAngleStart.Text = "-22";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(36, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 3;
            this.label13.Text = "开始角度";
            // 
            // halconWindow1
            // 
            this.halconWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindow1.Location = new System.Drawing.Point(0, 0);
            this.halconWindow1.Name = "halconWindow1";
            this.halconWindow1.Size = new System.Drawing.Size(825, 636);
            this.halconWindow1.TabIndex = 15;
            // 
            // FormModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 636);
            this.Controls.Add(this.halconWindow1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormModel";
            this.Text = "FormModel";
            this.Load += new System.EventHandler(this.FormModel_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_CreateShapeModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_MinContrast;
        private System.Windows.Forms.Label label_Metric;
        private System.Windows.Forms.Label label_Contrast;
        private System.Windows.Forms.Label label_AngleExtent;
        private System.Windows.Forms.Label label_AngleStep;
        private System.Windows.Forms.TextBox textBox_AngleExtent;
        private System.Windows.Forms.Label label_NumLevels;
        private System.Windows.Forms.TextBox textBox_AngleStart;
        private System.Windows.Forms.Label label_AngleStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox_NumLevels;
        private System.Windows.Forms.ComboBox comboBox_AngleStep;
        private System.Windows.Forms.ComboBox comboBox_Metric;
        private System.Windows.Forms.ComboBox comboBox_MinContrast;
        private System.Windows.Forms.ComboBox comboBox_Contrast;
        private System.Windows.Forms.Button button_FindShapeModel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_SubPixel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_FindAngleExtent;
        private System.Windows.Forms.TextBox textBox_FindAngleStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_NumMatches;
        private System.Windows.Forms.TextBox textBox_MinScore;
        private System.Windows.Forms.TextBox textBox_MaxOverlap;
        private System.Windows.Forms.TextBox textBox_Greediness;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_NumLevels;
        private SimpleVision.Base.ViewRoi.HalconWindow halconWindow1;
        private Base.ViewRoi.RoiCreator roiCreator1;
        private Base.ViewRoi.RoiCreator roiCreator2;
        private System.Windows.Forms.Label label_scaleMax;
        private System.Windows.Forms.TextBox textBox_scaleMax;
        private System.Windows.Forms.TextBox textBox_scaleMin;
        private System.Windows.Forms.Label label_scaleMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_FindScaleMax;
        private System.Windows.Forms.TextBox textBox_FindScaleMin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_scaleStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_Optimization;
        private System.Windows.Forms.Label label_Optimization;
    }
}