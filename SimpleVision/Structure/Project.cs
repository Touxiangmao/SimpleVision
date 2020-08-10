using System.Windows.Forms;
using SimpleVision.Base;
using SimpleVision.Tool;

namespace SimpleVision.Structure
{
    public class Project : LList<Job>
    {
        public Project(string name, string type, string belong) : base(name, type, belong)
        {
            Type = type;
            Belong = belong;
            Name = name;
        }


        public void Run()
        {
            foreach (var job in Items)
            {
                job.Run();
            }
        }

        /// <summary>
        /// 项目的选择流程j
        /// </summary>
        public static string CurrrentJobName
        {
            get => Solution.CurrentProject.CurrentItemName;
            set => Solution.CurrentProject.CurrentItemName = value;
        }

        public delegate void DelegateAddJob(Job job, bool showHalconWindow);
        /// <summary>
        /// 有流程被添加的事件
        /// </summary>
        public static event DelegateAddJob EventAddJob;

        /// <summary>
        /// 往项目中添加流程
        /// </summary>
        /// <param name="jobName">流程名称</param>
        public static bool AddJob(string jobName, bool showHalconWindow)
        {
            if (Solution.CurrentProject == null)
            {
                MessageBox.Show(@",没有选择项目,请先选择项目");
                FormProjects.Instance.ShowDialog();
                return false;
            }
            CurrrentJobName = jobName;
            var job = new Job(jobName, "job", Solution.CurrentProject.Name);
            EventAddJob?.Invoke(job, showHalconWindow);
            return Solution.CurrentProject.Add(job);
        }
        /// <summary>
        /// 往已经选定的项目添加流程  使用输入的名称
        /// </summary>
        public static bool AddJob()
        {
            if (Solution.CurrentProject.Name == "")
            {
                MessageBox.Show(@"没有选择项目,请先选择项目");
                FormProjects.Instance.ShowDialog();
                return false;
            }
            using var formInput = new FormInput(@"输入新流程名") { StartPosition = FormStartPosition.CenterScreen };
            formInput.ShowDialog();
            return formInput.DialogResult == DialogResult.OK && AddJob(FormInput.Input, true);
        }
    }
}
