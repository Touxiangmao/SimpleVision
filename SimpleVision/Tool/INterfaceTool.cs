using System.Collections.Generic;
using System.Windows.Forms;
using HalconDotNet;
using SimpleVision.Base;
using SimpleVision.Structure;
using ViewROI;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision.Tool
{
  public  interface INterfaceTool:INterfaceItem
    {

        /// <summary>
        /// 工具输入
        /// Name =  名字
        /// Belong =所属工具的名字
        /// Type =  类型
        /// Show =  是不是要出现在树形图中
        /// comeFrom =引用自
        /// </summary>
        public LList<ToolInput> Input { get; set; }
        /// <summary>
        /// 工具输出
        /// Name =  名字
        /// Belong =所属工具的名字
        /// Type =  类型
        /// Show =  是不是要出现在树形图中
        /// </summary>
        public LList<ToolOutput> Output { get; set; }

        /// <summary>
        /// 是否可以重复添加
        /// </summary>
        bool AllowRepeat { get; set; }

        /// <summary>
        /// 图形显示窗口
        /// </summary>
        public HWindow HWindow { get; }

        /// <summary>
        /// 图形显示工具
        /// </summary>
        public HWndCtrl ViewController { get; }

        public Job BelongJob { get; }

        //todo 这里可能常要改
        /// <summary>
        /// 工具的窗口
        /// </summary>
        public FormDockFormBase Form { get; set; }

        public void InitializeComponent(string blongJob);

        public void RefreshInput();
        public void Run();
        public void RunNextTool();
        public void Serialize(string path);

        public void Deserialize(string path);


    }


}
