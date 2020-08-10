using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using SimpleVision.Base;
using WeifenLuo.WinFormsUI.Docking;

namespace SimpleVision.Tool.ImageTool
{
    public partial class FormReadImage : FormDockFormBase
    {
        private readonly ReadImage _readImageTool;
        public FormReadImage(ReadImage readImageTool)
        {
            _readImageTool = readImageTool;
            InitializeComponent();
        }

        private void btn_selectImageDirectory_Click(object sender, EventArgs e)
        {
            listBox_image.Items.Clear();
            _readImageTool.OpenImagePaths();
            if (_readImageTool.ImagePaths != null)
            {
                listBox_image.Items.AddRange(_readImageTool.ImagePaths);
                lbl_imageNum.Text = _readImageTool.ImagePaths.Length.ToString();
            }

            listBox_image.SelectedIndex = -1;
            _readImageTool.ImageIndex = -1;
        }
        private void btn_MoveUp_Click(object sender, EventArgs e)
        {
            if (listBox_image.SelectedIndex == -1)
            {
            }
            else
            {
                _readImageTool.ImageIndex--;
            }
            _readImageTool.ReadHobjectByIndex(_readImageTool.ImageIndex);
            _readImageTool.Run();
            listBox_image.SelectedIndex = _readImageTool.ImageIndex;
          
        }
        private void btn_nextImage_Click(object sender, EventArgs e)
        {
            _readImageTool.ImageIndex++;
            _readImageTool.ReadHobjectByIndex(_readImageTool.ImageIndex);
            _readImageTool.Run();
            listBox_image.SelectedIndex = _readImageTool.ImageIndex;
         
        }

        private void listBox_image_SelectedIndexChanged(object sender, EventArgs e)
        {
            _readImageTool.ImageIndex = listBox_image.SelectedIndex;
        }

        private void btn_RunSelect_Click(object sender, EventArgs e)
        {
            listBox_image.SelectedIndex = _readImageTool.ImageIndex;
            _readImageTool.ReadHobjectByIndex(listBox_image.SelectedIndex);
            _readImageTool.Run();

        }

        private void FormReadImage_Load(object sender, EventArgs e)
        {
            if (_readImageTool.ImagePaths != null)
            {
                listBox_image.Items.AddRange(_readImageTool.ImagePaths);
                listBox_image.SelectedIndex = _readImageTool.ImageIndex;
                lbl_imageNum.Text = _readImageTool.ImagePaths.Length.ToString();
            }
          
        }
    }
}
