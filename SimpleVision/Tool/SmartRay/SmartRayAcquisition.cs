using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HalconDotNet;
using SimpleVision.Base;
using SimpleVision.Structure;
using ViewROI;

namespace SimpleVision.Tool.SmartRay
{
 public  class SmartRayAcquisition:ToolBase
    { 
        public SmartRayAcquisition()
        {
           
            
            Form = new FormSmartRayAcquisition(this);

            var inputInt = new ToolInput("输入整数", this.Name) { Item = 15 };
            Input.Add(inputInt);
            var inputImage = new ToolInput("输入图片", this.Name) { Item = new HImage() };
            Input.Add(inputImage);
            var outputImage = new ToolOutput("输出图片", this.Name) { Item = new HImage() };
            Output.Add(outputImage);
        }
        public override void InitializeComponent(string blongJob)
        {

            if (Form.IsDisposed)
            {
               
                Form = new FormSmartRayAcquisition(this);
            }
            base.InitializeComponent(blongJob);
        }
        public override void Run()
        {

            //必须用DispObj不然图像不是彩色
            ViewController.addIconicVar((HImage)Input["输入图片"].Item);
            ViewController.addIconicVar(new HRegion(100.0, 100, 200, 200));
            base.Run();
        }
        public override void Serialize(string path)
        {
            
        }
        public override void Deserialize(string path)
        {
           
        }


    }
}
