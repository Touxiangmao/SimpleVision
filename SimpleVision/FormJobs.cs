using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SimpleVision.Base;
using SimpleVision.Structure;
using SimpleVision.Tool;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision
{
    /// <summary>
    /// 流程窗口
    /// </summary>
    public partial class FormJobs : FormDockFormBase
    {
        /// <summary>
        /// 主窗口静态变量
        /// </summary>
        private static FormJobs _instance;
        public static FormJobs Instance => _instance ??= new FormJobs();
        /// <summary>
        /// 进行部分操作后窗体进行刷新
        /// </summary>
        public static bool needRefresh = false;
        public FormJobs()
        {
            InitializeComponent();

            Job.EventAddTool += AddTool;
            timer1.Start();
        }
        public void InitializeJobView()
        {
            tabControl1.SelectedIndexChanged -= tabControl1_SelectedIndexChanged;

            tabControl1.TabPages.Clear();
            if (Solution.CurrentProject == null)
            {
                return;
            }
            var itemItems = Solution.CurrentProject.Items;

            if (itemItems == null) return;
            if (itemItems.Count < 1) return;
            JobView.DItemAndSource.Clear();
            foreach (var _ in itemItems)
            {
                JobView.AddJobTreeViewToControl(tabControl1, _);
            }
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages.Cast<TabPage>()
                .FirstOrDefault(page => page.Text == Project.CurrrentJobName)!);
            needRefresh = true;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }



        private void FormJobs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        /// <summary>
        /// 显示流程窗口
        /// </summary>
        /// <param name="dockPanel"></param>
        public new void ShowForm(DockPanel dockPanel)
        {
            //todo 这里可能常要改
            if (_dd == DockState.Unknown || _dd == DockState.Hidden)
            {
                Show(dockPanel, DockState.Float);

            }
            else
            {
                Show(dockPanel, _dd);
            }
            InitializeJobView();
        }

        private void tStBtn_AddJob_Click(object sender, EventArgs e)
        {
            JobView.AddNewJobTreeViewToControl(tabControl1);


        }
        /// <summary>
        /// 切换页面时,切换方案的当前流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 1) return;
            Project.CurrrentJobName = tabControl1.SelectedTab.Text;
            needRefresh = true;
        }
        private void AddTool(INterfaceTool tool)
        {
            JobView.AddToolToControl(tabControl1, tool);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (needRefresh)
            {
                Line_Paint();
            }

        }
        /// <summary>
        /// 窗体重绘时要重新画线
        /// </summary>
        public void Line_Paint()
        {
            if (tabControl1.TabPages.Count < 1)
            {
                return;
            }
            //todo :using 会释放掉赋值给var的对象
            var _ = JobView.FindTreeViewByName(tabControl1, Project.CurrrentJobName);

            if (_ == null)
            {
                return;
            }
            _.Update();
            JobView.DrawLine(_);

            needRefresh = false;

        }
        private void FormJobs_SizeChanged(object sender, EventArgs e)
        {
            needRefresh = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Solution.CurrentProject[Project.CurrrentJobName].Run();
        }
    }
}
