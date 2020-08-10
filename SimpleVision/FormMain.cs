using SimpleVision.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleVision.Base;
using SimpleVision.Structure;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// job计数 用于显示job的图形显示窗口 每个job默认带一个图像窗口
        /// </summary>
        int _jobCount = 0; 
        /// <summary>
        /// 图像显示窗口的个数
        /// </summary>
        int _haclonWindowCount = 0;
        /// <summary>
        /// 主窗口静态变量
        /// </summary>
        private static FormMain _instance;
        public static FormMain Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormMain();
                return _instance;
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //主窗体颜色适应主题
            ChangeColor(this.Controls);
            //有流程被添加时主界面动作
            Project.EventAddJob += SolutionHelper_EventAddJob;
            //加载解决方案基本信息 包含的项目信息
            Solution.DeserializeSolutionProperty();

            LoadProject();
        }


        public void LoadProject()
        {
            if (FormProjects.Instance.ShowDialog() != DialogResult.OK) return;
            CloseAllContents();//关掉所有窗口
            _jobCount = 0; //job计数清零
            FormHalconWindowDictionary.Dictionary.Clear(); //图像窗口清空
            toolStripMenuItem_HaclonWindows.DropDownItems.Clear();//图像窗口下拉菜单清空
            Solution.DeserializeProject(Solution.CurrrentProjectName); //加载选择的项目
            LoadDockPanelData();   //项目加载完成后再加载窗体(窗体需要项目的job信息来加载图像窗口)
            FormJobs.Instance.InitializeJobView();  //窗体加载后加载窗体显示内容  这里tool窗体不用后加载 因为tools窗体和项目无关,固定加载tools
        }
        /// <summary>
        /// 添加job后主界面窗体下拉菜单添加按钮
        /// </summary>
        /// <param name="job">新添加的流程</param>
        /// <param name="showHalconWindow">是不是要显示窗口,程序加载时不用显示,新添加要显示</param>
        private void SolutionHelper_EventAddJob(Job job,bool showHalconWindow)
        {
            
            FormHalconWindowDictionary.Add(job.Name);
            //todo 这里可能常要改
            if (showHalconWindow) FormHalconWindowDictionary.Dictionary[job.Name].ShowForm(dockPanel1);
            toolStripMenuItem_HaclonWindows.DropDownItems.Add(job.Name);
            toolStripMenuItem_HaclonWindows.DropDownItems[_jobCount].Click += toolStripMenuItem_HaclonWindowsDropDownItems_Click;
            _jobCount++;
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var window in FormHalconWindowDictionary.Dictionary.Values)
            {
                window.Close();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (MessageBox.Show(@"保存所有更改么?",@"提示",MessageBoxButtons.OKCancel) == DialogResult.OK)
              
        }

        #region Dock窗体
        /// <summary>
        /// dock窗体状态保存
        /// </summary>
        private void SaveDockPanelData()
        {
            try
            {
                var path = $@"{ Application.StartupPath}\Data\{Solution.CurrentProject.Belong}\{Solution.CurrentProject.Name}\PanelData.xml";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
                dockPanel1.SaveAsXml(path);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"保存Dockpanel配置文件失败，" + ex.Message);
                return;
            }
        }

        /// <summary>
        ///  dock窗体状态读取
        /// </summary>
        public void LoadDockPanelData()
        {
            
            try
            {
                var path = $@"{ Application.StartupPath}\Data\{Solution.CurrentProject.Belong}\{Solution.CurrentProject.Name}\PanelData.xml";
                if (!File.Exists (path))
                {
                    MessageBox.Show(@"没有窗体文件");
                    return;
                }
                _haclonWindowCount = 0;
                dockPanel1.LoadFromXml(path, GetContentFromPersistString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            var jobs = Solution.CurrentProject.Items;
            if (persistString == typeof(FormJobs).ToString())
            {
                return FormJobs.Instance;
            }
            if (persistString == typeof(FormTools).ToString())
            {
                return FormTools.Instance;
            }
            if (persistString == typeof(FormHalconWindow).ToString())
            {
                if (FormHalconWindowDictionary.Dictionary.Count< _jobCount)
                {
                    FormHalconWindowDictionary.Add(jobs[_haclonWindowCount].Name);
                    toolStripMenuItem_HaclonWindows.DropDownItems.Add(jobs[_jobCount].Name);
                    toolStripMenuItem_HaclonWindows.DropDownItems[_jobCount].Click += toolStripMenuItem_HaclonWindowsDropDownItems_Click;
                }
                _haclonWindowCount++;
                return FormHalconWindowDictionary.Dictionary[jobs[_haclonWindowCount - 1].Name];
            }
            //主框架之外的窗体不显示
            return null;
        }

        private void toolStripMenuItem_HaclonWindowsDropDownItems_Click(object sender, EventArgs e)
        {
           
            var hwName = ((ToolStripItem) sender).Text;
            var hw = FormHalconWindowDictionary.Dictionary[hwName];
            //todo 这里可能常要改
            var ds = hw._dd;
            if (hw.IsDisposed)
            {
                hw = new FormHalconWindow(hwName); 
                hw._dd = ds;
            }
            FormHalconWindowDictionary.Dictionary[hwName] = hw; 
            FormHalconWindowDictionary.Dictionary[hwName].ShowForm(dockPanel1);
        }

        /// <summary>
        /// 根据dock窗体颜色反色所有窗体控件
        /// </summary>
        void ChangeColor(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.GetType() == dockPanel1.GetType()) continue;
                var r = 255 - dockPanel1.DockBackColor.R;
                var g = 255 - dockPanel1.DockBackColor.G;
                var b = 255 - dockPanel1.DockBackColor.B;

                control.BackColor = dockPanel1.DockBackColor;
                control.ForeColor = Color.FromArgb(((int)(((byte)(r)))), ((int)(((byte)(g)))), ((int)(((byte)(b)))));
                if (control.Controls.Count <= 0) continue;
                ChangeColor(control.Controls);
            }
        }
        /// <summary>
        /// 关闭所有窗体
        /// </summary>
        public void CloseAllContents()
        {
            // we don't want to create another instance of tool window, set DockPanel to null
            FormTools.Instance.DockPanel = null;
            FormJobs.Instance.DockPanel = null;
          

            // Close all other document windows
            CloseAllDocuments();

            // IMPORTANT: dispose all float windows.
            foreach (var window in dockPanel1.FloatWindows.ToList())
                window.Dispose();

            System.Diagnostics.Debug.Assert(dockPanel1.Panes.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel1.Contents.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel1.FloatWindows.Count == 0);
        }
        private void CloseAllDocuments()
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                foreach (IDockContent document in dockPanel1.DocumentsToArray())
                {
                    // IMPORANT: dispose all panes.
                    document.DockHandler.DockPanel = null;
                    document.DockHandler.Close();
                }
            }
        }

        #endregion

        #region 窗体拖动

        private int _enterX;
        private int _enterY;
        private static bool IsDrag = false;
        private void setForm_MouseDown(object sender, MouseEventArgs e)
        {
            IsDrag = true;
            _enterX = e.Location.X;
            _enterY = e.Location.Y;
        }
        private void setForm_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrag = false;
            _enterX = 0;
            _enterY = 0;
        }
        private void setForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrag)
            {
                Left += e.Location.X - _enterX;
                Top += e.Location.Y - _enterY;
            }
        }
        private void FrmState()
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
                this.WindowState = FormWindowState.Maximized;

            }
            else if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;

            }
        }
        private void lbl_title_MouseDoubleClick(object sender, MouseEventArgs e) => FrmState();

        #region toolstrip重绘
        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            if (((ToolStrip)sender).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width, this.toolStrip1.Height - 2);
                e.Graphics.SetClip(rect);
            }
        }
        #endregion
        //最大最小关闭
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.FrmState();
        }


        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int) m.LParam & 0xFFFF,
                        (int) m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr) Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr) Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr) Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr) Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr) Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr) Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr) Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr) Guying_HTBOTTOM;
                    break;
                case 0x0201: //鼠标左键按下的消息 
                    m.Msg = 0x00A1; //更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero; //默认值 
                    m.WParam = new IntPtr(2); //鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
            private void ToolStripMenuItem_ToolBox_Click(object sender, EventArgs e)
        {
            //todo 这里可能常要改
            FormTools.Instance.ShowForm(dockPanel1);
        }
        private void toolStripMenuItem_Job_Click(object sender, EventArgs e)
        {
            FormJobs.Instance.ShowForm(dockPanel1);
        }

        private void toolStripMenuItem_EngineEditor_Click(object sender, EventArgs e)
        {

            LoadProject();
          
        }
        private void tSMItemNewJob_Click(object sender, EventArgs e)
        {

        }
        private void tSMItemOpenJob_Click(object sender, EventArgs e)
        {

        }

        private void tSMItemOpenPrjt_Click(object sender, EventArgs e)
        {
        }

        private void tSMItemSaveAll_Click(object sender, EventArgs e)
        {
            Solution.SerializeProject();
            SaveDockPanelData();
        }

        private void tSMItemSaveAs_Click(object sender, EventArgs e)
        {
           
        }

        //刷新连线
        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {
            FormJobs.needRefresh = true;
        }
        //刷新连线
        private void dockPanel1_DocumentDragged(object sender, EventArgs e)
        {
            FormJobs.needRefresh = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Solution.CurrentProject.Run();
        }
    }
}
