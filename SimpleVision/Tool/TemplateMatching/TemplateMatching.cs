using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using SimpleVision.Base;
using ViewROI;

namespace SimpleVision.Tool.TemplateMatching
{

    public class ModelParameter
    {

        public HTuple numLevels = new HTuple("auto");
        public double angleStart = -0.39;
        public double angleExtent = 0.79;
        public HTuple angleStep = new HTuple("auto");
        public double scaleMin = 0.9;
        public double scaleMax = 1.1;
        public HTuple scaleStep = new HTuple("auto");
        public HTuple optimization = new HTuple("auto");
        public string metric = "use_polarity";
        public HTuple contrast = new HTuple("auto");
        public HTuple minContrast = new HTuple("auto");

    }
    public class FindModelParameter
    {
        public double angleStart;
        public double angleExtent;
        public double scaleMin;
        public double scaleMax;
        public double minScore;
        public int numMatches;
        public double maxOverlap;
        public string subPixel;
        public int numLevels;
        public double greediness;
    }

    public class FindModelResult
    {
        public HTuple row = 0,
            column = 0,
            angle = 0,
            scale = 0,
            score = 0;
    }

    public class TemplateMatching : ToolBase
    {
        public TemplateMatching()
        {
            var inputImage = new ToolInput("输入图片", this.Name) { Item = new HImage() };
            Input.Add(inputImage);

            var outputImage = new ToolOutput("输出结果", this.Name) { Item = new FindModelResult() };
            Output.Add(outputImage);


            Form = new FormModel(this);
        }

        public ModelParameter ModelParameter;
        public FindModelParameter FindModelParameter;
        public FindModelResult FindModelResult;


        HRegion ModelRegion;
        HRegion SearchRegion;
        HShapeModel Model;


        bool had_ModelRegion = false;
        bool had_SearchRegion = false;
        bool had_Model = false;
        public void CreateModelRegion(HRegion region)
        {
            ModelRegion = region;
            had_ModelRegion = true;

        }

        public void CreateFindModelRegion(HRegion region)
        {
            SearchRegion = region;
            had_SearchRegion = true;
        }

        public override void InitializeComponent(string blongJob)
        {
            if (Form.IsDisposed)
            {
                Form = new FormModel(this);
            }
            base.InitializeComponent(blongJob);
        }


        public override void Run()
        {
            HWindow.SetColor("red");
            ViewController.addIconicVar((HImage)Input["输入图片"].Item);
            ViewController.addIconicVar(FindShapeModel());
            if (had_Model)
            {
                if (FindModelResult.score.Length > 0)
                {
                    HWindow.SetColor("yellow");
                    HWindow.SetTposition(Convert.ToInt32(FindModelResult.row.D), Convert.ToInt32(FindModelResult.column.D));
                    HWindow.WriteString("" + FindModelResult.score.D);


                }
            }


            //+FindModelResult.scale + FindModelResult.column + FindModelResult.row + FindModelResult.angle
            base.Run();
        }


    
        public HXLDCont CreateShapeModel()
        {
            had_Model = true;
            ModelRegion.AreaCenter(out row, out col);
            return CreateShapeModel(((HImage)Input["输入图片"].Item).ReduceDomain(ModelRegion), ModelParameter, out Model);
        }


        public HXLDCont CreateShapeModel(HRegion modelRegion, HImage img, ModelParameter modelParameter, out HShapeModel model)
        {
            return CreateShapeModel(img.ReduceDomain(modelRegion), modelParameter, out model);
        }

     
        public HXLDCont CreateShapeModel(HImage img, ModelParameter modelParameter, out HShapeModel model)
        {


            model = new HShapeModel(
                img,
                modelParameter.numLevels,
                modelParameter.angleStart,
                modelParameter.angleExtent,
                modelParameter.angleStep,
                modelParameter.scaleMin,
                modelParameter.scaleMax,
                modelParameter.scaleStep,
                modelParameter.optimization,
                modelParameter.metric,
                modelParameter.contrast,
                modelParameter.minContrast);



            var modelContours = Model.GetShapeModelContours(1);
        
            var homMat2D = new HHomMat2D();


            homMat2D.VectorAngleToRigid(0, 0, 0, ModelRegion.Row, ModelRegion.Column, 0);
            var contoursAffinTrans = modelContours.AffineTransContourXld(homMat2D);
            return contoursAffinTrans;
        }
     
        public HXLDCont FindShapeModel()
        {
            if (!had_Model) return null;
            return FindShapeModel(((HImage)Input["输入图片"]
                    .Item).ReduceDomain(SearchRegion),
                Model,
                FindModelParameter,
                out FindModelResult.row,
                out FindModelResult.column,
                out FindModelResult.angle,
                out FindModelResult.score,
                out FindModelResult.scale);
        }

      
        public HXLDCont FindShapeModel(HImage img,
            HShapeModel model,
            FindModelParameter findModelParameter,
            out HTuple row,
            out HTuple column,
            out HTuple angle,
            out HTuple scale,
            out HTuple score)
        {
            var t1 = HSystem.CountSeconds();
            model.SetShapeModelParam("timeout", 10000);
            try
            {
            
                img.FindScaledShapeModel(
                    model,
                    findModelParameter.angleStart,
                    findModelParameter.angleExtent,
                    findModelParameter.scaleMin,
                    findModelParameter.scaleMax,
                    findModelParameter.minScore,
                    findModelParameter.numMatches,
                    findModelParameter.maxOverlap,
                    findModelParameter.subPixel,
                    findModelParameter.numLevels,
                    findModelParameter.greediness,
                    out row,
                    out column,
                    out angle,
                    out scale,
                    out score);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                row =
                    column =
                        angle =
                            scale =
                                score = new HTuple();
            }

            var t2 = HSystem.CountSeconds();
            var mTime = 1000.0 * (t2 - t1);

            System.Diagnostics.Debug.WriteLine(mTime.ToString());

            var modelContours = Model.GetShapeModelContours(1);
            var homMat2D = new HHomMat2D();

            //HTuple Width, Height;
            //Img.GetImageSize(out Width, out Height);

            if (score.Length <= 0) return null;
            homMat2D.VectorAngleToRigid(0, 0, 0, row, column, angle);

            var contoursAffinTrans = modelContours.AffineTransContourXld(homMat2D);
            return contoursAffinTrans;
        }

        public override void Serialize(string path)
        {

        }

        public override void Deserialize(string path)
        {

        }


    }
}
