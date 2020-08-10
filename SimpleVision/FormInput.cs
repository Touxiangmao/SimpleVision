using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleVision
{
    /// <summary>
    /// 用于输入信息的窗口
    /// </summary>
    public  partial class FormInput : Form
    {
        /// <summary>
        /// 信息输入窗体输入的信息
        /// </summary>
        internal static string Input = string.Empty;

        public FormInput(string text)
        {
            InitializeComponent();
            label1.Text = text;
            Text = text;
        }

        private void btn_input_Click(object sender, EventArgs e)
        {

            if (tb_input.Text+"" != "")
            {
                Input = tb_input.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
              
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Input = "";
            this.Close();
        }
    }



}
    

