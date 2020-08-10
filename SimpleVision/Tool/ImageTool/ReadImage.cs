using System;
using System.Windows.Forms;
using SimpleVision.Base;
using HalconDotNet;
using SimpleVision.Structure;

namespace SimpleVision.Tool.ImageTool
{
    public class ReadImage : ToolBase
    {
        public string[] ImagePaths;
        private int _imageIndex;
        public int ImageIndex
        {
            get
            {
                if (ImagePaths == null)
                {
                    _imageIndex = 0;
                    return _imageIndex;
                }
                if (_imageIndex >= ImagePaths.Length)
                    _imageIndex = 0;
                if (_imageIndex < 0)
                {
                    _imageIndex = ImagePaths.Length - 1;
                }
                return _imageIndex;
            }
            set => _imageIndex = value;
        }
        public ReadImage()
        {
            
            Form = new FormReadImage(this);

            var inputImage = new ToolInput("输入图片", this.Name) { Item = new HImage() };
            Input.Add(inputImage);

            var outputImage = new ToolOutput("输出图片", this.Name) { Item = new HImage() };
            Output.Add(outputImage);

            var outputInt = new ToolOutput("输出整数", this.Name) { Item = 0 };
            Output.Add(outputInt);
        }
        /// <summary>
        /// 初始化工具  这里不太需要工具名 流程添加工具名字会自动生成
        /// </summary>
        /// <param name="blongJob"></param>
        public override void InitializeComponent(string blongJob)
        {
          
       
            if (Form.IsDisposed)
            {
              
                Form = new FormReadImage(this);
            }
            base.InitializeComponent(blongJob);
        }
        public string[] OpenImagePaths()
        {
            using var open = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                Filter = @"图片文件|*.jpg;*.png;*.bmp;*.tif"
            };
            ImagePaths = open.ShowDialog() == DialogResult.OK ? open.FileNames : ImagePaths;
            return ImagePaths;
        }
        public HImage ReadHImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return null;
            }
            var hImage = new HImage(imagePath);
            return hImage;
        }
        public void CheckImagePaths()
        {
            if (ImagePaths.Length != 0) return;
            MessageBox.Show(@"图像列表为空,请重新加载图像");
            OpenImagePaths();
        }
        public void ReadHobjectByIndex(int currentIndex)
        {
            ImageIndex = currentIndex;
            Output["输出图片"].Item = ReadHImage(ImagePaths[ImageIndex]);
            Output["输出整数"].Item = currentIndex;
        }
        public override void Run()
        {
            base.Run();
            //必须用DispObj不然图像不是彩色
            // HOperatorSet.DispObj((HObject)Output["输出图片"].Item,HalconWindowId);
        }
        public override void Serialize(string path)
        {
            var data = new ReadImageData() { Name = Name, Type = Type, Belong = Belong, AllowRepeat = AllowRepeat, ImagePaths = ImagePaths, ImageIndex = ImageIndex };
            Solution.Serialize(path, data);
        }
        public override void Deserialize(string path)
        {
            var data = Solution.Deserialize<ReadImageData>(path);
            Name = data.Name;
            Type = data.Type;
            Belong = data.Belong;
            AllowRepeat = data.AllowRepeat;
            ImagePaths = data.ImagePaths;
            ImageIndex = data.ImageIndex;
            InitializeComponent(Belong);
        }
    }
    public class ReadImageData
    {
        public string Name;
        public string Type;
        public string Belong;
        public bool AllowRepeat;
        public string[] ImagePaths;
        public int ImageIndex;
    }
}
