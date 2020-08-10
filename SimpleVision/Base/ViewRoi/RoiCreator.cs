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
using SimpleVision.Tool;
using ViewROI;

namespace SimpleVision.Base.ViewRoi
{
    public partial class RoiCreator : UserControl
    {
        public ROIController RoiController;

        public HRegion CurRegion
        {
            get
            {
                if (RoiController.activeROIidx != -1)
                    return RoiController.getActiveROI().getRegion();
                else if(RoiController.ROIList.Count>0) return RoiController.ROIList[0].getRegion();
                return null;
            }
        }

        public RoiCreator()
        {
            InitializeComponent();

        }
        public void SetRoiCreator(ROIController roiController)
        {

            RoiController = roiController;

            if (RoiController.viewController != null)
            {
                RoiController.viewController.viewPort.HMouseMove += GetActiveRoiParameters;
            }

            RoiController.NotifyRCObserver += dummyI;
            GetAllRoiInfo();
        }
        public void dummyI(int v)
        {
            if (v == ROIController.EVENT_CREATED_ROI)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(RoiController.ROIList.Count);
                for (var i = 0; i < RoiController.ROIList.Count; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = i;
                    dataGridView2.Rows[i].Cells[1].Value = RoiController.ROIList[i].RoiName;
                }

                BtnTestClick?.Invoke();
            }
        }

        private List<int> _sameTypeList = new List<int>();
        public void GetAllRoiInfo()
        {
            comboBox1.Items.Clear();
            foreach (var _ in from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly =>
                    assembly.GetTypes().Where(type => typeof(ROI).IsAssignableFrom(type)).Where(type =>
                        type.IsClass && !type.IsAbstract && type != typeof(ROI)))
                              let _ = Activator.CreateInstance(type) as RoiInterfac
                              select _)
            {

                comboBox1.Items.Add(_.RoiType);
                _sameTypeList.Add(0);
            }

        }

        private void AddRoiToRoiController(string roiType, string roiName, ROIController roiController)
        {
            var newRoi = (ROI)Activator.CreateInstance(Type.GetType(roiType)!);
            newRoi.RoiName = roiName;
            roiController.setROIShape(newRoi);

        }
        /// <summary>
        /// 事件
        /// </summary>
        public event Action BtnTestClick;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

          
            _sameTypeList[comboBox1.SelectedIndex]++;
            var roiType = comboBox1.SelectedItem.ToString();
            var roiName = comboBox1.SelectedText + _sameTypeList[comboBox1.SelectedIndex];
            AddRoiToRoiController(roiType, roiName, RoiController);

          
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var roi = RoiController.getActiveROI();
            if (roi == null) return;
            var roiParameters = new HTuple();
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        roiParameters[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    }
                    else
                    {
                        roiParameters[i] = 100;
                    }
                }

            }
            roi.createROI(roiParameters);
            RoiController.viewController.repaint();
        }

        void GetActiveRoiParameters(object sender, HalconDotNet.HMouseEventArgs e)
        {
            var roi = RoiController.getActiveROI();
            if (roi == null) return;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(roi.getModelDataName().Length);
            for (var i = 0; i < roi.getModelDataName().Length; i++)
            {

                dataGridView1.Rows[i].Cells[0].Value = roi.getModelDataName()[i].S;
                dataGridView1.Rows[i].Cells[1].Value = roi.getModelData()[i].D;
            }
        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                RoiController.setActiveROIIdx(dataGridView2.CurrentRow.Index);
                RoiController.removeActive();
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                dataGridView1.Rows.Clear();
            }
        }
    }
}
