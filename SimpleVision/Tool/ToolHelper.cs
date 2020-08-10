using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SimpleVision.Base;
using SimpleVision.Properties;

namespace SimpleVision.Tool
{
   /// <summary>
   /// 工具的一些操作
   /// </summary>
    public static class ToolHelper
    {


        /// <summary>
        /// 将所有工具显示在TreeView中
        /// </summary>
        /// <param name="tvwTools">输入TreeView控件</param>
        public static void GetAllToolInfoToTreeView(TreeView tvwTools)
        {
            tvwTools.ImageList = new ImageList();
            foreach (var _ in from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly =>
                    assembly.GetTypes().Where(type => typeof(ToolBase).IsAssignableFrom(type)).Where(type =>
                        type.IsClass && !type.IsAbstract && type != typeof(ToolBase)))
                let _ = Activator.CreateInstance(type) as INterfaceTool
                select _)
            {
                 var typeList= _.Type.Split('.');
                 var type = typeList[typeList.Length - 2];
                if (!tvwTools.Nodes.ContainsKey(type))
                {
                    tvwTools.ImageList.Images.Add((Bitmap)Resources.ResourceManager.GetObject(type, Resources.Culture) ?? Resources.Empty);
                    TreeNode treeNode = tvwTools.Nodes.Add(type, type, tvwTools.ImageList.Images.Count - 1, tvwTools.ImageList.Images.Count - 1);
                    {
                        tvwTools.ImageList.Images.Add((Bitmap)Resources.ResourceManager.GetObject(_.Name, Resources.Culture) ?? Resources.Empty);
                        treeNode.Nodes.Add(_.Type, _.Name, tvwTools.ImageList.Images.Count - 1, tvwTools.ImageList.Images.Count - 1);
                    }
                }
                else
                {
                    tvwTools.ImageList.Images.Add((Bitmap)Resources.ResourceManager.GetObject(_.Name, Resources.Culture) ?? Resources.Empty);
                    tvwTools.Nodes.Find(type, false)[0].Nodes.Add(_.Type, _.Name, tvwTools.ImageList.Images.Count - 1, tvwTools.ImageList.Images.Count - 1);

                }
                //默认展开第一个图像采集节点
                tvwTools.Nodes[0].Expand();
            }
        }


    }
}