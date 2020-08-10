using System.Diagnostics;
using HalconDotNet;
using SimpleVision.Base;
using SimpleVision.Structure;
using System.Text.RegularExpressions;
using ViewROI;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision.Tool
{

    public abstract class ToolBase : INterfaceTool
    {
        public  ToolBase()
        {
            Type = this.GetType().ToString();
            var typeList = Type.Split('.');
            Name = typeList[typeList.Length - 1];
            Belong = "";
            AllowRepeat = true;
            Input = new LList<ToolInput>();
            Output = new LList<ToolOutput>();
        }

       
        public string Name { get; set; }
        public string Type { get; set; }
        public string Belong { get; set; }

        public bool AllowRepeat { get; set; }

        public HWindow HWindow => FormHalconWindowDictionary.Dictionary[Belong].HWindow;

        public HWndCtrl ViewController => FormHalconWindowDictionary.Dictionary[Belong].ViewController;

        public Job BelongJob => Solution.CurrentProject[Belong];
        //todo 这里可能常要改
        public FormDockFormBase Form { get; set; }

        public virtual void InitializeComponent(string blongJob)
        {
            Belong = blongJob;
            //工具窗口重命名
            if (Form != null)
            {
                Form.Text = Name + $@"   来自:{blongJob}";
            }
            foreach (var _ in Input.Items)
            {
                //初始化io时工具名是初始名 在这里改掉它
                _.Belong = Name;
            }
            foreach (var _ in Output.Items)
            {
                //初始化io时工具名是初始名 在这里改掉它
                _.Belong = Name;
            }
        }


        public void RefreshInput()
        {
            foreach (var input in Input.Items)
            {
                if (!input.ComeFrom.Contains("<")) continue;
                var source = Regex.Split(input.ComeFrom, "<-")[1];
                var sourceTool = Regex.Split(source, "->")[0];
                var sourceIo = Regex.Split(source, "->")[1];
                input.Item = Job.GetToolByName(sourceTool).Output[sourceIo].Item;
            }
        }

        public virtual void RunNextTool()
        {
           var nextIndex= BelongJob.FindIndexByName(Name)+1;
           if (nextIndex>=BelongJob.Items.Count)
           {
               Debug.WriteLine("运行一次完成");
           }
           else
           {
               BelongJob[nextIndex].RefreshInput(); 
               BelongJob[nextIndex].Run();
           }

        }

        public virtual void Run()
        {
            RunNextTool();
        }
        public abstract void Serialize(string path);


        public abstract void Deserialize(string path);


        public LList<ToolInput> Input { get; set; }
        public LList<ToolOutput> Output { get; set; }

    }
}
