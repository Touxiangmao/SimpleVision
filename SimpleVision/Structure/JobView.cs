using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleVision.Base;
using SimpleVision.Tool;

namespace SimpleVision.Structure
{
    public static class JobView
    {
        public class MyTreeView : TreeView
        {
            private bool _preventExpand = false;
            private DateTime _lastMouseDown = DateTime.Now;

            protected override void OnMouseDown(MouseEventArgs e)
            {
                int delta = (int)DateTime.Now.Subtract(_lastMouseDown).TotalMilliseconds;
                _preventExpand = (delta < SystemInformation.DoubleClickTime);
                _lastMouseDown = DateTime.Now;
                base.OnMouseDown(e);
            }

            protected override void OnBeforeCollapse(TreeViewCancelEventArgs e)
            {
                e.Cancel = _preventExpand;
                _preventExpand = false;
                base.OnBeforeCollapse(e);
            }

            protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
            {
                e.Cancel = _preventExpand;
                _preventExpand = false;
                base.OnBeforeExpand(e);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x0014) // 禁掉清除背景消息
                    return;
                base.WndProc(ref m);
            }

        }


        #region 绘制节点连线

        /// <summary>
        /// Graphics对象
        /// </summary>
        private static Graphics _graphics;
        /// <summary>
        /// 正在绘制输入输出指向线
        /// </summary>
        private static bool _isDrawing = false;
        /// <summary>
        /// 流程树中节点的最大长度
        /// </summary>
        private static int _maxLength = 130;
        /// <summary>
        /// 记录起始节点和此节点的列坐标值
        /// </summary>
        private static readonly Dictionary<TreeNode, Color> StartNodeAndColor = new Dictionary<TreeNode, Color>();
        /// <summary>
        /// 记录前面的划线所跨越的列段，
        /// </summary>
        private static readonly Dictionary<int, Dictionary<TreeNode, TreeNode>> Dictionary = new Dictionary<int, Dictionary<TreeNode, TreeNode>>();
        /// <summary>
        /// 每一个列坐标值对应一种颜色
        /// </summary>
        private static readonly Dictionary<int, Color> ColValueAndColor = new Dictionary<int, Color>();
        /// <summary>
        /// 输入输出指向线的颜色数组
        /// </summary>
        private static readonly Color[] Color = { System.Drawing.Color.Blue, System.Drawing.Color.Orange, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Brown, System.Drawing.Color.Tomato, System.Drawing.Color.Pink, System.Drawing.Color.Chocolate, System.Drawing.Color.Green, System.Drawing.Color.Orange, System.Drawing.Color.Brown, System.Drawing.Color.Blue, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Orange, System.Drawing.Color.Brown, System.Drawing.Color.Blue, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Orange, System.Drawing.Color.Brown, System.Drawing.Color.Blue, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Orange, System.Drawing.Color.Brown };
        /// <summary>
        /// 需要连线的节点对，不停的画连线，注意键值对中第一个为连线的结束节点，第二个为起始节点，一个输出可能连接多个输入，而键值对中的键不能重复，所以把源作为值，输入作为键
        /// </summary>
        public static readonly Dictionary<string, Dictionary<TreeNode, TreeNode>> DItemAndSource = new Dictionary<string, Dictionary<TreeNode, TreeNode>>();

        /// <summary>
        /// 绘制输入输出指向线
        /// </summary>
        /// <param name="treeView"></param>
        internal static void DrawLine(TreeView treeView)
        {

            if (_isDrawing) return;
            if (DItemAndSource.Count == 0) return;
            if (DItemAndSource[treeView.Name].Count == 0) return;
            if (treeView.Name != Project.CurrrentJobName) return;
            _isDrawing = true;
            var task = new Task(() =>
                    {
                        treeView.BeginInvoke((Action)delegate
                   {
                       treeView.MouseWheel += numericUpDown1_MouseWheel; //划线的时候不能滚动，否则画好了线，结果已经滚到其它地方了
                       _maxLength = 150;
                       ColValueAndColor.Clear();
                       StartNodeAndColor.Clear();
                       Dictionary.Clear();

                       _graphics = treeView.CreateGraphics();
                       treeView.CreateGraphics().Dispose();

                       foreach (var item in DItemAndSource[treeView.Name])
                       {
                           CreateLine(treeView, item.Key, item.Value);
                       }

                       Application.DoEvents();

                       treeView.MouseWheel -= numericUpDown1_MouseWheel;

                       _isDrawing = false;
                   });
                    }
            );
            task.Start();


        }



        /// <summary>
        /// 画Treeview控件两个节点之间的连线
        /// </summary>
        /// <param name="treeView">要画连线的Treeview</param>
        /// <param name="startNode">结束节点</param>
        /// <param name="endNode">开始节点</param>
        private static void CreateLine(TreeView treeView, TreeNode endNode, TreeNode startNode)
        {
            treeView.BeginInvoke((Action)delegate
            {
                //得到起始与结束节点之间所有节点的最大长度  ，保证画线不穿过节点
                var startNodeParantIndex = startNode.Parent.Index;
                var endNodeParantIndex = endNode.Parent.Index;
                var startNodeIndex = startNode.Index;
                var max = 0;

                if (!startNode.Parent.IsExpanded)
                {
                    max = startNode.Parent.Bounds.X + startNode.Parent.Bounds.Width;
                }
                else
                {
                    for (var i = startNodeIndex; i < startNode.Parent.Nodes.Count - 1; i++)
                    {
                        if (max < treeView.Nodes[startNodeParantIndex].Nodes[i].Bounds.X + treeView.Nodes[startNodeParantIndex].Nodes[i].Bounds.Width)
                            max = treeView.Nodes[startNodeParantIndex].Nodes[i].Bounds.X + treeView.Nodes[startNodeParantIndex].Nodes[i].Bounds.Width;
                    }
                }
                for (var i = startNodeParantIndex + 1; i < endNodeParantIndex; i++)
                {
                    if (!treeView.Nodes[i].IsExpanded)
                    {
                        if (max < treeView.Nodes[i].Bounds.X + treeView.Nodes[i].Bounds.Width)
                            max = treeView.Nodes[i].Bounds.X + treeView.Nodes[i].Bounds.Width;
                    }
                    else
                    {
                        for (var j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                        {
                            if (max < treeView.Nodes[i].Nodes[j].Bounds.X + treeView.Nodes[i].Nodes[j].Bounds.Width)
                                max = treeView.Nodes[i].Nodes[j].Bounds.X + treeView.Nodes[i].Nodes[j].Bounds.Width;
                        }
                    }
                }
                if (!endNode.Parent.IsExpanded)
                {
                    if (max < endNode.Parent.Bounds.X + endNode.Parent.Bounds.Width)
                        max = endNode.Parent.Bounds.X + endNode.Parent.Bounds.Width;
                }
                else
                {
                    for (var i = 0; i < endNode.Index; i++)
                    {
                        if (max < treeView.Nodes[endNodeParantIndex].Nodes[i].Bounds.X + treeView.Nodes[endNodeParantIndex].Nodes[i].Bounds.Width)
                            max = treeView.Nodes[endNodeParantIndex].Nodes[i].Bounds.X + treeView.Nodes[endNodeParantIndex].Nodes[i].Bounds.Width;
                    }
                }
                max += 20;        //箭头不能连着 节点，

                if (!startNode.Parent.IsExpanded)
                    startNode = startNode.Parent;
                if (!endNode.Parent.IsExpanded)
                    endNode = endNode.Parent;

                if (endNode.Bounds.X + endNode.Bounds.Width + 20 > max)
                    max = endNode.Bounds.X + endNode.Bounds.Width + 20;
                if (startNode.Bounds.X + startNode.Bounds.Width + 20 > max)
                    max = startNode.Bounds.X + startNode.Bounds.Width + 20;

                //判断是否可以在当前处划线
                foreach (var item in from item in Dictionary
                                     where Math.Abs(max - item.Key) < 15
                                     from item1 in item.Value
                                     where startNode != item1.Value
                                     where (item1.Value.Bounds.X < _maxLength && item1.Key.Bounds.X < _maxLength) || (item1.Value.Bounds.X < _maxLength && item1.Key.Bounds.X < _maxLength)
                                     select item)
                {
                    max += (15 - Math.Abs(max - item.Key));
                }

                var temp = new Dictionary<TreeNode, TreeNode> { { endNode, startNode } };
                if (Dictionary.ContainsKey(max))
                    if (Dictionary[max].ContainsKey(endNode))
                        Dictionary[max][endNode] = startNode;
                    else
                        Dictionary[max].Add(endNode, startNode);

                else
                    Dictionary.Add(max, temp);

                if (!StartNodeAndColor.ContainsKey(startNode))
                    StartNodeAndColor.Add(startNode, Color[StartNodeAndColor.Count]);

                var pen = new Pen(StartNodeAndColor[startNode], 1);
                //如果选中就边粗
                if (endNode == treeView.SelectedNode || startNode == treeView.SelectedNode)
                {
                    pen.Width = 2;
                }
                Brush brush = new SolidBrush(StartNodeAndColor[startNode]);


           


                _graphics.DrawLine(pen, startNode.Bounds.X + startNode.Bounds.Width,
                    startNode.Bounds.Y + startNode.Bounds.Height / 2,
                max,
                  startNode.Bounds.Y + startNode.Bounds.Height / 2);
                _graphics.DrawLine(pen, max,
                   startNode.Bounds.Y + startNode.Bounds.Height / 2,
                   max,
                  endNode.Bounds.Y + endNode.Bounds.Height / 2);
                _graphics.DrawLine(pen, max,
                   endNode.Bounds.Y + endNode.Bounds.Height / 2,
                   endNode.Bounds.X + endNode.Bounds.Width,
                     endNode.Bounds.Y + endNode.Bounds.Height / 2);
                _graphics.DrawString("<", new Font("微软雅黑", 12F), brush, endNode.Bounds.X + endNode.Bounds.Width - 5,
                     endNode.Bounds.Y + endNode.Bounds.Height / 2 - 12);



               

            });
        }

        /// <summary>
        /// 取消滚轮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void numericUpDown1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e is HandledMouseEventArgs h)
                {
                    h.Handled = true;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        #endregion
        /// <summary>
        /// 将流程以树形图显示
        /// </summary>
        /// <param name="jobName">流程名字</param>
        /// <param name="job">输入流程</param>
        /// <returns></returns>
        private static TreeView JobToTreeView(string jobName, Job job)
        {
            var treeView = new MyTreeView
            {
                Name = jobName,
                Dock = DockStyle.Fill,
                Font = new Font("微软雅黑", 10),
                ShowNodeToolTips = true,
                AllowDrop = true,
                Scrollable = true

            };


            treeView.AfterSelect += TreeView_AfterSelect;
            treeView.AfterLabelEdit += TreeView_AfterLabelEdit;

            treeView.MouseDoubleClick += TreeView_MouseDoubleClick;
            treeView.MouseClick += TreeView_MouseClick;
            treeView.ItemDrag += TreeView_ItemDrag;
            treeView.DragDrop += TreeView_DragDrop;
            treeView.DragEnter += TreeView_DragEnter;

            DItemAndSource.Add(jobName, new Dictionary<TreeNode, TreeNode>());
            foreach (var _ in job.Items)
            {
                AddToolToTreeView(treeView, _);
            }

            foreach (var node in treeView.Nodes)
            {
                foreach (var _ in ((TreeNode)node).Nodes)
                {
                    if (!((TreeNode)_).Text.Contains("<")) continue;
                    var source = Regex.Split(((TreeNode)_).Text, "<-")[1];
                    var sourceTool = Regex.Split(source, "->")[0];
                    var sourceIo = Regex.Split(source, "->")[1];
                    var ioNode = FindToolIoNodeByName(treeView, sourceTool, sourceIo);
                    DItemAndSource[jobName].Add((TreeNode)_, ioNode);
                }
            }

            treeView.AfterExpand += TreeView_AfterExpand;
            treeView.AfterCollapse += TreeView_AfterCollapse;

            return treeView;
        }

        private static void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;
            var test = treeView.HitTest(e.X, e.Y);
            if (test.Node == null || test.Location != TreeViewHitTestLocations.Label) return;
            var toolName = test.Node.Level switch
            {
                0 => test.Node.Text,
                1 => test.Node.Parent.Text,
                _ => ""
            };

            if (toolName == "") return;

            var tool = Job.GetToolByName(toolName);
            if (tool.Form == null)
            {
                MessageBox.Show(@"没有窗体");
                return;
            }


            if (tool.Form.IsDisposed)
            {
                tool.InitializeComponent(treeView.Name);
            }
            //todo 这里可能常要改
            tool.Form?.ShowForm(FormMain.Instance.dockPanel1);
        }

        private static void TreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;
            if (e.Button == MouseButtons.Right)
            {
                var test = treeView.HitTest(e.X, e.Y);
                if (test.Node == null || test.Location != TreeViewHitTestLocations.Label && e.Button == MouseButtons.Right)       //单击空白
                {

                    return;
                }
                else
                {
                    var toolName = test.Node.Level switch
                    {
                        0 => test.Node.Text,
                        1 => test.Node.Parent.Text,
                        _ => ""
                    };


                    if (toolName == "") return;
                    var tool = Job.GetToolByName(toolName);

                    var contextMenu = new ContextMenu();

                    treeView.ContextMenu = contextMenu;
                    contextMenu.MenuItems.Add("运行");
                    contextMenu.MenuItems[0].Click += MenuItems_Click;
                    return;
                }
            }
            treeView.Refresh();
            FormJobs.needRefresh = true;
        }

        private static void MenuItems_Click(object sender, EventArgs e)
        {

        }

        private static void TreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;
            if (treeView.Name != Project.CurrrentJobName) return;
            treeView.Refresh();
            FormJobs.needRefresh = true;
        }

        private static void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;
            if (treeView.Name != Project.CurrrentJobName) return;
            treeView.Refresh();
            FormJobs.needRefresh = true;

        }
        private static void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //
        }
        private static void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //
        }
        private static void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;

            if (e.Button == MouseButtons.Left)
            {
                treeView.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }
        private static void TreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(TreeNode)) ? DragDropEffects.Move : DragDropEffects.None;
        }
        private static void TreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;
            //被移动的节点
            var moveNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            //要移动到的节点
            var targetNode = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));

            if (moveNode == targetNode)       //若是把自己拖放到自己，不可，返回
                return;
            if (targetNode == null)       //目标节点为null，就是把节点拖到了空白区域，不可，直接返回
                return;
            switch (moveNode.Level)
            {
                //都是输入输出节点，内部拖动排序
                case 1 when targetNode.Level == 1 && moveNode.Parent == targetNode.Parent:
                    moveNode.Remove();
                    targetNode.Parent.Nodes.Insert(targetNode.Index, moveNode);
                    return;
                //被拖动的是子节点，也就是工具节点
                case 0:
                    {
                        var index = targetNode.Level == 0 ? targetNode.Index : targetNode.Parent.Index;
                        moveNode.Remove();
                        Job.MoveTool(moveNode.Text, moveNode.Index, index);
                        treeView.Nodes.Insert(index, moveNode);

                        //被移动节点移动后在目标节点上面  要移除输入输出
                        index = targetNode.Level == 0 ? targetNode.Index : targetNode.Parent.Index;
                        if (moveNode.Index < index)
                        {
                            foreach (var _ in moveNode.Nodes)
                            {
                                var inputNode = (TreeNode)_;
                                var input = inputNode.Text;

                                if (!input.Contains("<")) continue;
                                //移除连线
                                DItemAndSource[treeView.Name].Remove(inputNode);
                                input = Regex.Split(inputNode.Text, "<")[0];

                                var inputTool = Job.GetToolByName(moveNode.Text).Input[input];
                                //移除io的引用
                                inputTool.ComeFrom = input;

                                inputNode.Text = input;
                                inputNode.ToolTipText = inputTool.Type + " 属于:" + inputTool.Belong + " 引用自:" + inputTool.ComeFrom; ;
                            }
                        }

                        break;
                    }
                //被拖动的是输入输出
                default:
                    {
                        switch (targetNode.Level)
                        {
                            case 0 when targetNode.Name == "输出工具"://准备给输出工具使用
                                break;
                            case 0://普通工具
                                return;
                        }
                        if (moveNode.Name != "输出" || targetNode.Name != "输入")
                        {
                            MessageBox.Show(@"被拖动节点和目标节点输入输出不匹配，不可关联");
                            return;
                        }
                        //连线前要判断被拖动节点和目标节点的数据类型是否一致
                        if (moveNode.Tag.ToString() != targetNode.Tag.ToString())
                        {
                            MessageBox.Show($@"源节点类型为{moveNode.Tag},目标节点类型为{targetNode.Tag}，数据类型不匹配，不可关联");
                            return;
                        }

                        if (targetNode.Parent.Index < moveNode.Parent.Index)
                        {
                            MessageBox.Show(@"被拖动节点处于目标节点下方，不可关联");
                            return;
                        }

                        var input = targetNode.Text;
                        if (input.Contains("<"))       //表示已经连接了源
                        {
                            //获取输入的名字
                            input = Regex.Split(targetNode.Text, "<")[0];
                            //移除旧的连线
                            DItemAndSource[treeView.Name].Remove(targetNode);
                            //添加新连线
                            DItemAndSource[treeView.Name].Add(targetNode, moveNode);

                        }
                        else  //第一次连接源就需要添加到输入输出集合
                        {
                            DItemAndSource[treeView.Name].Add(targetNode, moveNode);
                        }
                        targetNode.Text = input + @"<-" + moveNode.Parent.Text + @"->" + moveNode.Text;
                        FormJobs.needRefresh = true;

                        var targetIo = Job.GetToolByName(targetNode.Parent.Text).Input[input];
                        var moveIo = Job.GetToolByName(moveNode.Parent.Text).Output[moveNode.Text];
                        targetIo.ComeFrom = targetNode.Text;
                        targetIo.Item = moveIo.Item;
                        targetNode.ToolTipText = targetIo.Type + " 属于: " + targetIo.Belong + " 引用: " + targetIo.ComeFrom;

                        //移除拖放的节点  
                        if (moveNode.Level == 0)
                            moveNode.Remove();
                        break;
                    }
            }
            //更新当前拖动的节点选择  
            treeView.SelectedNode = moveNode;
            //展开目标节点,便于显示拖放效果  
            targetNode.Expand();
        }

        //以工具名和工具io名找到io所对应的节点
        private static TreeNode FindToolIoNodeByName(TreeView treeView, string toolName, string ioName)
        {
            return treeView.Nodes.Cast<TreeNode>().FirstOrDefault(node => node.Text == toolName)?.Nodes.Cast<TreeNode>().FirstOrDefault(node => node.Text == ioName);
        }

        /// <summary>
        /// 往树形图节点添加工具 
        /// 工具节点 | =======key(treeNode名字)是工具类型(工具的工具类型是直接用的GetType的方法类似于XXX.XXX.ToolClassName)  name是工具名默认是工具类名+编号
        ///          | 
        ///          |--input节点  ========key(treeNode名字)是输入 text如果节点有引用那么就是它的名字+引用工具名+引用的输出名
        ///          |
        ///          |--output节点 ========key(treeNode名字)是输出 text是输出的名字
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="tool"></param>
        private static void AddToolToTreeView(TreeView treeView, INterfaceTool tool)
        {

            var treeNode = treeView.Nodes.Add(tool.Type, tool.Name);
            {

                foreach (var _ in tool.Input.Items)
                {
                    if (!_.Show) continue;
                    var inputNodes = _.ComeFrom == "" ? treeNode.Nodes.Add("输入", _.Name) : treeNode.Nodes.Add("输入", _.ComeFrom);
                    inputNodes.Tag = _.Type;
                    inputNodes.ForeColor = System.Drawing.Color.Blue;
                    inputNodes.ToolTipText = _.Type + " 属于:" + _.Belong + " 引用自:" + _.ComeFrom;

                }
                foreach (var _ in tool.Output.Items)
                {
                    if (!_.Show) continue;
                    var inputNodes = treeNode.Nodes.Add("输出", _.Name);
                    inputNodes.Tag = _.Type;
                    inputNodes.ForeColor = System.Drawing.Color.Orange;
                    inputNodes.ToolTipText = _.Type + " 属于:" + _.Belong;
                }
            }
            treeNode.Expand();
        }
        /// <summary>
        /// 往控件里添加工具节点
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="tool"></param>
        public static void AddToolToControl(TabControl tabControl, INterfaceTool tool)
        {
            AddToolToTreeView(FindTreeViewByName(tabControl, Project.CurrrentJobName), tool);
        }
        /// <summary>
        /// 往控件添加流程的树形图
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="job"></param>
        public static void AddJobTreeViewToControl(TabControl tabControl, Job job)
        {
            tabControl.TabPages.Add(job.Name);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls
                .Add(JobToTreeView(job.Name, Solution.CurrentProject[job.Name]));


        }
        /// <summary>
        /// 往项目中添加一个新流程 并且把它的TreeView添加到控件里
        /// </summary>
        /// <param name="tabControl"></param>
        public static void AddNewJobTreeViewToControl(TabControl tabControl)
        {
            if (!Project.AddJob()) return;
            tabControl.TabPages.Add(Project.CurrrentJobName);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls
                .Add(JobToTreeView(Project.CurrrentJobName, Solution.CurrentProject.CurrentItem));
            tabControl.SelectedIndex = tabControl.TabCount - 1;
        }
        /// <summary>
        /// 用流程名找到控件里对应的treeview
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public static TreeView FindTreeViewByName(TabControl tabControl, string jobName)
        {
            if (tabControl == null) return null;
            foreach (var page in tabControl.TabPages)
            {
                if (page == null || !(page is TabPage tabPage)) continue;
                if (tabPage.Text != jobName) continue;
                //if (tabPage.cou != jobName) continue;
                if (tabPage.Controls[0] is TreeView treeView)
                {
                    return treeView;
                }
            }
            return null;
        }
    }
}
