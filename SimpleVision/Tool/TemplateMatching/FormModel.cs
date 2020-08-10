using System;
using HalconDotNet;
using SimpleVision.Base;
using ViewROI;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision.Tool.TemplateMatching
{
    public partial class FormModel : FormDockFormBase
    {

        public ROIController RoiController1 = new ROIController();

        public ROIController RoiController2 = new ROIController();
        public FormModel()
        {
            InitializeComponent();
        }

        private readonly TemplateMatching _templateMatching;
        public FormModel(TemplateMatching templateMatching)
        {
            _templateMatching = templateMatching;
            InitializeComponent();
        }
        public HTuple CheckValue(string str, bool isInt)
        {
            switch (str)
            {

                case "auto_contrast":
                    return new HTuple(str);
                case "auto_contrast_hyst":
                    return new HTuple(str);
                case "auto_min_size":
                    return new HTuple(str);
                case "auto":
                    return new HTuple(str);
                default:
                    if (isInt)
                        return new HTuple(Convert.ToInt32(str));
                    else
                        return new HTuple(Convert.ToDouble(str));

            }
        }

        public HTuple TupleRad(string str)
        {
            if (str == "auto")
                return new HTuple(str);
            else
                return new HTuple(Convert.ToDouble(str)).TupleRad();
        }


        private void button_CreateShapeModel_Click(object sender, EventArgs e)
        {
            _templateMatching.CreateModelRegion(roiCreator1.CurRegion);
            _templateMatching.ModelParameter = new ModelParameter();
            _templateMatching.ModelParameter.numLevels = CheckValue(comboBox_NumLevels.Text, true);
            _templateMatching.ModelParameter.angleStart = TupleRad(textBox_AngleStart.Text).D;
            _templateMatching.ModelParameter.angleExtent = TupleRad(textBox_AngleExtent.Text).D;
            _templateMatching.ModelParameter.angleStep = TupleRad(comboBox_AngleStep.Text);
            _templateMatching.ModelParameter.scaleMin = Convert.ToDouble(textBox_scaleMin.Text);
            _templateMatching.ModelParameter.scaleMax = Convert.ToDouble(textBox_scaleMax.Text);
            _templateMatching.ModelParameter.scaleStep = comboBox_scaleStep.Text == @"auto" ? new HTuple("auto") : new HTuple(Convert.ToDouble(comboBox_scaleStep.Text));
            _templateMatching.ModelParameter.optimization = new HTuple(comboBox_Optimization.Text);
            _templateMatching.ModelParameter.metric = comboBox_Metric.Text;
            _templateMatching.ModelParameter.contrast = CheckValue(comboBox_Contrast.Text, true);
            _templateMatching.ModelParameter.minContrast = CheckValue(comboBox_MinContrast.Text, true);

            halconWindow1.ViewController.resetWindow();
            halconWindow1.ViewController.addIconicVar(_templateMatching.CreateShapeModel());
        }

        private void FormModel_Load(object sender, EventArgs e)
        {
            halconWindow1.ViewController.useROIController(RoiController1);
            roiCreator1.SetRoiCreator(RoiController1);

            halconWindow1.ViewController.addIconicVar((HImage)_templateMatching.Input["输入图片"].Item);
        }

        private void button_FindShapeModel_Click(object sender, EventArgs e)
        {
            
            _templateMatching.CreateFindModelRegion(roiCreator2.CurRegion);

            _templateMatching.FindModelParameter = new FindModelParameter();
            _templateMatching.FindModelResult=new FindModelResult();

            _templateMatching.FindModelParameter.numLevels = Convert.ToInt32(textBox_NumLevels.Text);
            _templateMatching.FindModelParameter.angleStart = TupleRad(textBox_FindAngleStart.Text).D;
            _templateMatching.FindModelParameter.angleExtent = TupleRad(textBox_FindAngleExtent.Text).D;
            _templateMatching.FindModelParameter.scaleMin = Convert.ToDouble(textBox_FindScaleMin.Text);
            _templateMatching.FindModelParameter.scaleMax = Convert.ToDouble(textBox_FindScaleMax.Text);
            _templateMatching.FindModelParameter.greediness = Convert.ToDouble(textBox_Greediness.Text);
            _templateMatching.FindModelParameter.numMatches = Convert.ToInt32(textBox_NumMatches.Text);
            _templateMatching.FindModelParameter.minScore = Convert.ToDouble(textBox_MinScore.Text);
            _templateMatching.FindModelParameter.subPixel = comboBox_SubPixel.Text;

            _templateMatching.FindModelParameter.maxOverlap = Convert.ToDouble(textBox_MaxOverlap.Text);
            halconWindow1.ViewController.resetWindow();
            halconWindow1.ViewController.addIconicVar(_templateMatching.FindShapeModel());

        }
      
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
            
                    halconWindow1.ViewController.useROIController(RoiController1);
                    roiCreator1.SetRoiCreator(RoiController1);
                    halconWindow1.ViewController.resetImage();
                    break;
                case 1:
                  
                    halconWindow1.ViewController.useROIController(RoiController2);
                    roiCreator2.SetRoiCreator(RoiController2);
                    halconWindow1.ViewController.resetImage();
                    break;
            }
        }
    }
}
