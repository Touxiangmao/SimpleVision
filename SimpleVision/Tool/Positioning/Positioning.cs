using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleVision.Tool.Positioning
{
    public class Positioning : ToolBase
    {

        public Positioning()
        {


            Form = new FormPositioning(this);

            var inputImage = new ToolInput("输入图片", this.Name) { Item = new HImage() };
            Input.Add(inputImage);
            var outputImage = new ToolOutput("输出图片", this.Name) { Item = new HImage() };
            Output.Add(outputImage);
        }
        public override void InitializeComponent(string blongJob)
        {

            if (Form.IsDisposed)
            {

                Form = new FormPositioning(this);
            }
            base.InitializeComponent(blongJob);
        }
        public override void Run()
        {

            //必须用DispObj不然图像不是彩色
          
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
