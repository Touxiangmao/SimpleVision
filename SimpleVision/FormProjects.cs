using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleVision.Structure;

namespace SimpleVision
{
    public partial class FormProjects : Form
    {
        /// <summary>
        /// 主窗口静态变量
        /// </summary>
        private static FormProjects _instance;
        public static FormProjects Instance => _instance ??= new FormProjects();
        public FormProjects()
        {
            InitializeComponent();
            loadProjectsToDataGridView(dataGridView1);
        }

        private void FormProjects_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void btn_AddProject_Click(object sender, EventArgs e)
        {
            Solution.AddProject();
            loadProjectsToDataGridView(dataGridView1);
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (Solution.SolutionProperty.Items.Count < 1)
            {
                MessageBox.Show(@"没有项目,请新建项目");

                return;
            }
            Solution.CurrrentProjectName = dataGridView1.SelectedCells[0].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void loadProjectsToDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            if (Solution.SolutionProperty.Items == null) return;
            if (Solution.SolutionProperty.Items.Count > 0)
            {
                dataGridView.Rows.Add(Solution.SolutionProperty.Items.Count);
                for (int i = 0; i < Solution.SolutionProperty.Items.Count; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = Solution.SolutionProperty.Items[i].Name; ;
                }
            }
           

        }
    }
}
