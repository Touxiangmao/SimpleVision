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

namespace SimpleVision.Tool.SmartRay
{
    public partial class FormSmartRayAcquisition : FormDockFormBase
    {
        private readonly SmartRayAcquisition _smartRayAcquisitionTool;
        public FormSmartRayAcquisition(SmartRayAcquisition smartRayAcquisitionTool)
        {
            _smartRayAcquisitionTool = smartRayAcquisitionTool;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _smartRayAcquisitionTool.Run();
        }
    }
}
