using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using SimpleVision.Tool;
using SimpleVision;
using SimpleVision.Base;
using ViewROI;

namespace SimpleVision.Structure
{
    public class Job : LList<INterfaceTool>
    {


        public List<HImage> HImages=new List<HImage>( 10);

        public void Run()
        {
            Items[0].Run();
        }

        public Job(string name, string type, string belong):base (name,type,belong)
        {
            Type = type;
            Belong = belong;
            Name = name;
        }
        /// <summary>
        /// 移动工具在job中的位置
        /// </summary>
        /// <param name="toolName">工具名</param>
        /// <param name="oldID">工具以前位置</param>
        /// <param name="newID">工具现在位置</param>
        public static void MoveTool(String toolName, int oldID, int newID)
        {
            var currentJobName = Project.CurrrentJobName;

            Solution.CurrentProject[currentJobName]
                .Move(oldID, newID);
        }
        /// <summary>
        /// 用工具名找到工具
        /// </summary>
        /// <param name="toolName">工具名</param>
        /// <returns></returns>
        public static INterfaceTool GetToolByName(string toolName)
        {
            var currentJobName = Project.CurrrentJobName;
            return Solution.CurrentProject[currentJobName][toolName];
        }

        /// <summary>
        /// 往指定流程中添加工具,如果指定流程不存在就跳出
        /// </summary>
        /// <param name="jobName">流程名称</param>
        /// <param name="tool">工具</param>
        public static void AddTool(string jobName, INterfaceTool tool)
        {
            if (Solution.CurrentProject == null)
            {
                MessageBox.Show(@"项目不存在");
                return;
            }

            if (Solution.CurrentProject[jobName] == null)
            {
                MessageBox.Show(@"流程不存在");
                return;
            }
            Solution.CurrentProject[jobName].Add(tool, tool.AllowRepeat);
            tool.InitializeComponent(jobName);
        }

        /// <summary>
        /// 往指定流程中添加工具,如果指定流程不存在就新建
        /// </summary>
        /// <param name="tool">工具</param>
        public static bool AddTool(INterfaceTool tool)
        {
            if (Solution.CurrentProject.Name == "")
            {
                MessageBox.Show(@"没有选择项目,请先选择项目");
                FormProjects.Instance.ShowDialog();
                return false;
            }
            else
            {
                if (Project.CurrrentJobName == "")
                {
                    MessageBox.Show(@"没有选择流程,请先选择流程");
                    FormJobs.Instance.ShowForm(FormMain.Instance.dockPanel1);
                    return false;
                }
                else
                {
                    AddTool(Project.CurrrentJobName, tool);
                    return true;
                }
            }
        }

        public delegate void DelegateAddTool(INterfaceTool tool);
        /// <summary>
        /// 有工具被添加的事件
        /// </summary>
        public static event DelegateAddTool EventAddTool;
        /// <summary>
        /// 以工具类型向流程中添加工具
        /// </summary>
        /// <param name="toolType"></param>
        public static void AddTool(string toolType)
        {
            var newtool = (INterfaceTool)Activator.CreateInstance(System.Type.GetType(toolType) ?? throw new InvalidOperationException());//typeof(ToolBase).Namespace+"."+

            if (AddTool(newtool))
            {
                EventAddTool?.Invoke(newtool);
            }
        }

    }
}
