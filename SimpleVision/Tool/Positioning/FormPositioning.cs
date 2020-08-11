using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleVision.Base;

namespace SimpleVision.Tool.Positioning
{
    public partial class FormPositioning :  FormDockFormBase
    {
        public FormPositioning()
        {
            InitializeComponent();
        }
        private readonly Positioning _positioning;
        public FormPositioning(Positioning positioning)
        {
            _positioning = positioning;
            InitializeComponent();
        }
    }
}
