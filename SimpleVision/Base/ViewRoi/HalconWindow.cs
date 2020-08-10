using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using ViewROI;

namespace SimpleVision.Base.ViewRoi
{
    public partial class HalconWindow : UserControl
    {
        public HWndCtrl ViewController;
        public HTuple HwId => this.hWindowControl1.HalconWindow;
        public HalconWindow()
        {
            InitializeComponent();
            ViewController = new HWndCtrl(hWindowControl1);
            ViewController.setViewState(HWndCtrl.MODE_VIEW_ZOOM_Wheel);
            无动作ToolStripMenuItem.Checked = !无动作ToolStripMenuItem.Checked;
            if (!IsDesignMode())
                hWindowControl1.HMouseMove += GetImgMessage;
        }

        private void 无动作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.setViewState(HWndCtrl.MODE_VIEW_NONE);
            无动作ToolStripMenuItem.Checked = !无动作ToolStripMenuItem.Checked;
            缩放ToolStripMenuItem.Checked = false;
            移动ToolStripMenuItem.Checked = false;
        }

        private void 移动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.setViewState(HWndCtrl.MODE_VIEW_MOVE);
            移动ToolStripMenuItem.Checked = !移动ToolStripMenuItem.Checked;
            无动作ToolStripMenuItem.Checked = false;
            缩放ToolStripMenuItem.Checked = false;
        }

        private void 缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.setViewState(HWndCtrl.MODE_VIEW_ZOOM_Wheel);
            缩放ToolStripMenuItem.Checked = !缩放ToolStripMenuItem.Checked;
            无动作ToolStripMenuItem.Checked = false;
            移动ToolStripMenuItem.Checked = false;
        }
        private void 复位窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsDesignMode())
                ViewController.resetAll();
        }
        private void hWindowControl1_SizeChanged(object sender, EventArgs e)
        {
            if (!IsDesignMode())
                ViewController.resetImage();
        }
        public static bool IsDesignMode()
        {
            bool returnFlag = false;

#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnFlag = true;
            }
#endif

            return returnFlag;
        }

        void GetImgMessage(object sender, HalconDotNet.HMouseEventArgs e)
        {


            if (ViewController.Image != null)
            {
                HTuple row, col, grayValue, imageWidth, imageHeight;
                //int button_state;
                //double mouse_post_row, mouse_pose_col;
                //viewPort.HalconWindow.GetMpositionSubPix(out mouse_post_row, out mouse_pose_col, out button_state);

                row = e.Y;
                col = e.X;
                HOperatorSet.GetImageSize(ViewController.Image, out imageWidth, out imageHeight);
                if (col > 0 && row > 0 && col < imageWidth && row < imageHeight)
                {
                    HOperatorSet.GetGrayval(ViewController.Image, row, col, out grayValue);
                }
                else
                {
                    grayValue = 0;
                }

                toolStripStatusLabel1.Text = row.D.ToString("0.00");
                toolStripStatusLabel2.Text = col.D.ToString("0.00");
                toolStripStatusLabel3.Text = grayValue.ToString();
            }
            else
            {
                toolStripStatusLabel1.Text = null;
                toolStripStatusLabel2.Text = null;
                toolStripStatusLabel3.Text = null;
            }



        }

    }
}
