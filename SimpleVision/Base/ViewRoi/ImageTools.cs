using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace ViewROI
{
    class ImageTools
    {

        public static void dispImage(HWindowControl hWC, HObject HImage)
        {
            HTuple hv_Width = null, hv_Height = null, hv_picWHRatio = null;
            HTuple hv_winWHRatio = null, hv_dispWidth = new HTuple();
            HTuple hv_dispHeight = new HTuple();
            // Initialize local and output iconic variables 

            HTuple hv_winWidth = hWC.Width; HTuple hv_winHeight = hWC.Height;

            HOperatorSet.SetSystem("int_zooming", "true");
            HOperatorSet.GetImageSize(HImage, out hv_Width, out hv_Height);
            hv_picWHRatio = (1.0 * hv_Width) / hv_Height;
            hv_winWHRatio = (1.0 * hv_winWidth) / hv_winHeight;
            if (new HTuple(hv_Width.TupleGreater(hv_winWidth)).TupleOr(new HTuple(hv_Height.TupleGreater(
                hv_winHeight))) != 0)
            {
                //如果图片宽高比 大于 窗口宽高比
                //则宽度方向顶格
                if (new HTuple(hv_picWHRatio.TupleGreaterEqual(hv_winWHRatio)) != 0)
                {
                    hv_dispWidth = hv_Width.Clone();
                    hv_dispHeight = hv_Width / hv_winWHRatio;
                    HOperatorSet.SetPart(hWC.HalconWindow, 0, 0, hv_dispHeight, hv_dispWidth);
                    HOperatorSet.DispObj(HImage, hWC.HalconWindow);
                }

                //如果图片宽高比 小于 窗口宽高比
                //则高度方向顶格
                if (new HTuple(hv_picWHRatio.TupleLess(hv_winWHRatio)) == 0) return;
                hv_dispWidth = hv_Height * hv_winWHRatio;
                hv_dispHeight = hv_Height.Clone();
                HOperatorSet.SetPart(hWC.HalconWindow, 0, 0, hv_dispHeight, hv_dispWidth);
                HOperatorSet.DispObj(HImage, hWC.HalconWindow);

            }
            else
            {
                //如果图片的长和宽都小于窗口，则以图片的原真实尺寸显示
                HOperatorSet.SetPart(hWC.HalconWindow, 0, 0, hv_winWidth, hv_winHeight);
                HOperatorSet.DispObj(HImage, hWC.HalconWindow);
            }

            return;
            ////////////////////////////////////////////////////////////////////////////test-end
        }

        public static void ReadImage(out HObject ho_Image,string str_FilePath)
        {
            if (File.Exists(str_FilePath))
            {
                HOperatorSet.GenEmptyObj(out ho_Image);
                ho_Image.Dispose();
                HOperatorSet.ReadImage(out ho_Image, str_FilePath);
            }
            {
                HOperatorSet.GenEmptyObj(out ho_Image);
            }      
          
        }
        public static void GetImageSize(HObject ho_Image,out HTuple hv_Width, out HTuple hv_Height)
        {    
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);        
        }

        public static void HobjectToHimage(HObject hobject, ref HImage image)
        {
            HTuple pointer, type, width, height;
            HOperatorSet.GetImagePointer1(hobject, out pointer, out type, out width, out height);
            image.GenImage1(type, width, height, pointer);
        }

        //新增的另一个转换彩色图像的方法 
        public static void HobjectToRGBHimage(HObject hobject, ref HImage image)
        {
            HTuple pointerRed, pointerGreen, pointerBlue, type, width, height;
            HOperatorSet.GetImagePointer3(hobject, out pointerRed, out pointerGreen, out pointerBlue, out type, out width, out height);
            image.GenImage3(type, width, height, pointerRed, pointerGreen, pointerBlue);
        }

    }
}
