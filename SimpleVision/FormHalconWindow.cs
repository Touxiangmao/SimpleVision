using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleVision.Base;
using WeifenLuo.WinFormsUI.Docking;
using HalconDotNet;
using ViewROI;

namespace SimpleVision
{

    public  partial class FormHalconWindow : FormDockFormBase
    {

        public HWindow HWindow => halconWindow1.hWindowControl1.HalconWindow;

        public HWndCtrl ViewController => halconWindow1.ViewController;

        public FormHalconWindow(string windowName)
        {
            InitializeComponent();
            DockAreas = DockAreas.Document | DockAreas.Float;
            this.Text = windowName;

        }

    }

    public static class FormHalconWindowDictionary
    {
        /// <summary>
        /// 图像窗体集合
        /// </summary>
        public static readonly Dictionary<string, FormHalconWindow> Dictionary = new Dictionary<string, FormHalconWindow>();

        public static void Add(string windowName, FormHalconWindow formHalconWindow)
        {
            if (Dictionary.Keys.Contains(windowName))
            {
                MessageBox.Show(@"不能重复添加相同名称的窗体");
                return;
            }
            Dictionary.Add(windowName, formHalconWindow);
        }

        public static void Add(string windowName)
        {
            if (Dictionary.Keys.Contains(windowName))
            {
                MessageBox.Show(@"不能重复添加相同名称的窗体");
                return;
            }
            Dictionary.Add(windowName, new FormHalconWindow(windowName));
          
        }


    }

}
