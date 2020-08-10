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

namespace SimpleVision.Tool.SSZN
{
    public partial class FormSSZNAcquisitio : FormDockFormBase
    {
        private readonly SSZNAcquisition _SSZNAcquisitionTool;
        public FormSSZNAcquisitio(SSZNAcquisition SSZNAcquisitionTool)
        {
            _SSZNAcquisitionTool = SSZNAcquisitionTool;
            InitializeComponent();
        }
        public FormSSZNAcquisitio()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            _SSZNAcquisitionTool.Connect(0,textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }

        private void DisConnectBtn_Click(object sender, EventArgs e)
        {
            _SSZNAcquisitionTool.DisConnect(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _SSZNAcquisitionTool.DataCallBackReceiveFun();
        }
    }
}
