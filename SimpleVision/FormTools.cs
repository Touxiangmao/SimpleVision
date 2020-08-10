using SimpleVision.Properties;
using SimpleVision.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleVision.Base;
using SimpleVision.Structure;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision
{
    public partial class FormTools : FormDockFormBase
    {
        /// <summary>
        /// 主窗口静态变量
        /// </summary>
        private static FormTools _instance;
        public static FormTools Instance => _instance ??= new FormTools();
        private FormTools()
        {
            InitializeComponent();
            ToolHelper.GetAllToolInfoToTreeView(this.tvw_tools);
        }
        private void FormTools_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        private void tvw_job_DoubleClick(object sender, EventArgs e)
        {
            if (tvw_tools.SelectedNode.Level==0)         //如果双击的是文件夹节点，返回
                    return;
            Job.AddTool(tvw_tools.SelectedNode.Name);


        }

    }
}
