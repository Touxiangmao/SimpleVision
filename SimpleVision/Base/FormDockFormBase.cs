using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision.Base
{
 
    public partial class FormDockFormBase : DockContent
    {
     
        public FormDockFormBase()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
          
        }
        public DockState _dd = DockState.Float;
        private void FormDockFormBase_DockStateChanged(object sender, EventArgs e)
        {
            if (DockState != DockState.Unknown)
                _dd = DockState;
        }
        public void ShowForm(DockPanel dockPanel)
        {

            if (_dd == DockState.Unknown || _dd == DockState.Hidden)
            {
                Show(dockPanel, DockState.Float);
            }
            else
            {
                Show(dockPanel, _dd);
            }
        }
        private void FormDockFormBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DockPanel = null;
         //   form.Focus();
        }
    }
}
