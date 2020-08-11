using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using HalconDotNet;
using SimpleVision.Base;
using SimpleVision.Tool.ImageTool;
using System.Windows.Forms;
using SimpleVision.Structure;

namespace SimpleVision.Tool.SSZN
{
    public class SSZNAcquisitionData
    {
        public string Name;
        public string Type;
        public string Belong;
        public bool AllowRepeat;
        public SR7IF_ETHERNET_CONFIG EthernetConfig;
        public double HeightRange;
        public int DeviceId;

        /// <summary>
        /// 取像频率
        /// </summary>
        public uint dwProfileCnt = 10;
    }

    public class SSZNAcquisition : ToolBase
    {
        private bool _bIoTrigger = false;       //触发方式标志位
        private bool _bStop = false;            //循环终止标志位
        private bool _bCall = false;                    //回调函数调用标志位 

        private SR7IF_ETHERNET_CONFIG EthernetConfig;
        private double HeightRange;
        private bool Connected;
        private int DeviceId;
        /// <summary>
        /// 取像频率
        /// </summary>
        private uint dwProfileCnt = 10;
        private int _mDataWidth = 3200;         //轮廓宽度
        private double _mXPitch = 0.02;         //X方向间距
        private int _mBatchWidth = 0;                   //回调中轮廓宽度
        private int _batchCallBackPoint = 0;             //回调中当前批处理总行数
        private int _mCurBatchNo = 0;                   //回调函数中用到--当前批处理行数编号

        private int[] _heightData = null;        //高度数据缓存


        private Thread _batchCallBack;       //回调显示线程
        private HighSpeedDataCallBack _callback;       //回调

        public SSZNAcquisition() 
        {
           
          
            Form = new FormSSZNAcquisitio(this);

            var outputImage = new ToolOutput("输出图片", this.Name) { Item = new HObject() };
            Output.Add(outputImage);

            _heightData = new int[15000 * 6400];
            for (var i = 0; i < _heightData.Length; i++)
            {
                _heightData[i] = -1000000;
            }
            _callback = ReceiveHighSpeedData;

        }

        public override void InitializeComponent(string blongJob)
        {
            
            if (Form.IsDisposed)
            {
                
                Form = new FormSSZNAcquisitio(this);
            }
            base.InitializeComponent(blongJob);
        }

        public override void Run()
        {
            base.Run();
        }

        public override void Serialize(string path)
        {
            var data = new SSZNAcquisitionData()
            {
                Name = Name,
                Type = Type,
                Belong = Belong,
                AllowRepeat = AllowRepeat,
                HeightRange = HeightRange,
                EthernetConfig = EthernetConfig,
                DeviceId = DeviceId,
                dwProfileCnt = dwProfileCnt

            };
            Solution.Serialize(path, data);
        }

        public override void Deserialize(string path)
        {
            var data = Solution.Deserialize<SSZNAcquisitionData>(path);
            Name = data.Name;
            Type = data.Type;
            Belong = data.Belong;
            AllowRepeat = data.AllowRepeat;
            HeightRange = data.HeightRange;
            EthernetConfig = data.EthernetConfig;
            DeviceId = data.DeviceId;
            dwProfileCnt = data.dwProfileCnt;
            InitializeComponent(Belong);
            Connect(DeviceId, EthernetConfig);
        }

        public int Connect(string ip1, string ip2, string ip3, string ip4)
        {
            return Connect(DeviceId, ip1, ip2, ip3, ip4);
        }

        public int Connect(int deviceId, string ip1, string ip2, string ip3, string ip4)
        {
            SR7IF_ETHERNET_CONFIG sr7IfEthernetConfig;
            sr7IfEthernetConfig.abyIpAddress = new byte[]
            {
                Convert.ToByte(ip1),
                Convert.ToByte(ip2),
                Convert.ToByte(ip3),
                Convert.ToByte(ip4)
            };
            return Connect(deviceId, sr7IfEthernetConfig);
        }

        public int Connect(int deviceId, SR7IF_ETHERNET_CONFIG ethernetConfig)
        {
            var rc = SR7LinkFunc.SR7IF_EthernetOpen(deviceId, ref ethernetConfig);
            EthernetConfig = ethernetConfig;
            DeviceId = deviceId;
            if (rc < 0)
            {
                MessageBox.Show(@"设备连接失败！");
                Connected = false;
            }
            else
            {
                MessageBox.Show(@"设备连接成功！");
                Connected = true;
                //获取型号判断高度范围
                var strModel = SR7LinkFunc.SR7IF_GetModels(deviceId);
                var sModel = Marshal.PtrToStringAnsi(strModel);
                HeightRange = sModel switch
                {
                    "SR7050" => 2.5,
                    "SR7080" => 6,
                    "SR7140" => 12,
                    "SR7240" => 20,
                    "SR7400" => 50,
                    _ => 8.4
                };


                var reT = SR7LinkFunc.SR7IF_HighSpeedDataEthernetCommunicationInitalize(deviceId,
                    ref ethernetConfig,
                    0,
                    _callback,
                    dwProfileCnt,
                    0);


            }

            return rc;
        }

        public int DisConnect()
        {
            return DisConnect(DeviceId);
        }

        public int DisConnect(int deviceId)
        {
            if (Connected)
            {
                var rc = SR7LinkFunc.SR7IF_CommClose(deviceId);
                if (rc < 0)
                {
                    MessageBox.Show(@"设备断开失败！");
                    return rc;
                }

                Connected = false;
                return rc;


            }

            MessageBox.Show(@"未连接该设备！");
            return -1;

        }

        /// <summary>
        /// 回调方式获取数据
        /// </summary>
        public void DataCallBackReceiveFun()
        {
         
            if (!Connected)
                return;

            if (_heightData != null)
            {
                for (var i = 0; i < _heightData.Length; i++)
                {
                    _heightData[i] = -1000000;
                }
            }

            //开始批处理
            var _currentDeviceId = 0;
            var rc = -1;
            var dataObject = new IntPtr();
            rc = _bIoTrigger ? SR7LinkFunc.SR7IF_StartIOTriggerMeasure(_currentDeviceId, 20000, 0) : SR7LinkFunc.SR7IF_StartMeasure(_currentDeviceId, 20000);

            if (rc < 0)
            {
                var t3X1 = "批处理操作失败,返回值：" + rc.ToString();
                MessageBox.Show(t3X1, @"提示", MessageBoxButtons.OK);
                return;
            }

            // 获取批处理总行数
            var tempBatchPoint = SR7LinkFunc.SR7IF_ProfilePointSetCount(_currentDeviceId, dataObject);

            // 获取轮廓宽度
            _mDataWidth = SR7LinkFunc.SR7IF_ProfileDataWidth(_currentDeviceId, dataObject);

            // 数据x方向间距(mm)
            _mXPitch = SR7LinkFunc.SR7IF_ProfileData_XPitch(_currentDeviceId, dataObject);

            var tmt = "";
            var tx1 = "批处理行数：" + tempBatchPoint;
            var tx2 = "轮廓宽度：" + _mDataWidth;
            var tx3 = "数据x方向间距(mm)：" + _mXPitch;
            tmt = tx1 + "\r\n" + tx2 + "\r\n" + tx3;
        }
        
        /// <summary>
        /// 回调接受数据
        /// </summary>
        /// <param name="buffer"></param>         指向储存概要数据的缓冲区的指针.
        /// <param name="size"></param>           每个单元(行)的字节数量.
        /// <param name="count"></param>          存储在pBuffer中的内存的单元数量.
        /// <param name="notify"></param>         中断或批量结束等中断的通知.
        /// <param name="user"></param>           用户自定义信息.
        public void ReceiveHighSpeedData(IntPtr buffer, uint size, uint count, uint notify, uint user)
        {
            if (notify != 0)
            {
                if (Convert.ToBoolean(notify & 0x08))
                {
                    SR7LinkFunc.SR7IF_StopMeasure(0);
                    System.Console.Write(@"批处理超时!\n");
                    MessageBox.Show(@"批处理超时", @"提示", MessageBoxButtons.OK);
                    _mCurBatchNo = 0;

                }
            }

            if (count == 0 || size == 0)
                return;
            var profileSize = (uint)(size / Marshal.SizeOf(typeof(int))); //轮廓宽度
            // 获取批处理总行数
            var dataObject = new IntPtr();
            var tempBatchPoint = SR7LinkFunc.SR7IF_ProfilePointSetCount(0, dataObject);
            _batchCallBackPoint = tempBatchPoint;
            _mBatchWidth = Convert.ToInt32(profileSize);

            //数据拷贝
            var bufferArray = new int[profileSize * count];
            Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));
            var tmpNum = Convert.ToInt32(_mCurBatchNo * profileSize);
            if (_mCurBatchNo >= _batchCallBackPoint) return;
            if (_mCurBatchNo + count > _batchCallBackPoint)
            {
                var tmpCount = _batchCallBackPoint - _mCurBatchNo;
                Array.Copy(bufferArray, 0, _heightData, tmpNum, count * tmpCount);
                GC.Collect();
            }
            else
            {
                Array.Copy(bufferArray, 0, _heightData, tmpNum, profileSize * Convert.ToInt32(count));
                GC.Collect();
            }
            _mCurBatchNo += Convert.ToInt32(count);

            _bCall = true;

            if (notify == 0) return;
            if (notify == 0x10000)
            {
                SR7LinkFunc.SR7IF_StopMeasure(0);
                System.Console.Write(@"数据接收完成!\n");
                _bCall = false;
                _mCurBatchNo = 0;
                var tmpys = (int)(Convert.ToDouble(_batchCallBackPoint) / 560); //Y方向缩放倍数
                var tmpxs = (int)(Convert.ToDouble(_mBatchWidth) / 800); //X方向缩放倍数
                if (_batchCallBackPoint < 560)
                    tmpys = 1;
                if (_mBatchWidth < 800)
                    tmpxs = 1;

                _bCall = false;
                _bStop = false;
                BatchDataRollShow(_heightData, HeightRange, -HeightRange, 255, _mBatchWidth, _batchCallBackPoint,
                    tmpxs, tmpys); //显示高度数据
            

            }
            if (Convert.ToBoolean(notify & 0x80000000))
            {
                System.Console.Write(@"批处理重新开始!\n");
                _mCurBatchNo = 0;
            }

            if (Convert.ToBoolean(notify & 0x04))
            {
                System.Console.Write(@"新批处理!\n");
            }
        }


        /// <summary>
        /// 有限循环高度图像显示
        /// </summary>
        /// <param name="_BatchData"></param>
        /// <param name="max_height"></param>
        /// <param name="min_height"></param>
        /// <param name="_ColorMax"></param>
        /// <param name="img_w"></param>
        /// <param name="img_h"></param>
        /// <param name="_scaleW"></param>
        /// <param name="_scaleH"></param>
        private void BatchDataRollShow(int[] _BatchData, double max_height, double min_height, int _ColorMax, int img_w, int img_h, int _scaleW, int _scaleH)
        {

            var realData = new float[img_w * img_h];
            PointToRealData(_BatchData, img_w, img_h, ref realData);
            using var pinRealData = new PinnedObject(realData);
            //var himg=new HImage(pinRealData.Pointer,true);
            HOperatorSet.GenImage1(out var hoImage, "real", img_w, img_h, pinRealData.Pointer);
          
            Output["输出图片"].Item = hoImage;
            // HOperatorSet.WriteImage(hoImage, "tiff", 0, "D:/Image/1.tiff");
        }

        private int PointToRealData(int[] data, int width, int height, ref float[] realData)
        {
            if (data.Length < 1)
            {
                return -1;
            }

            if (height < 1 || width < 1)
            {
                return -1;
            }

            var upper = 0;
            var lower = 0;
            CalUpperAndLower(data, height, width, ref upper, ref lower);

            for (var i = 0; i < height; ++i)
            {
                for (var j = 0; j < width; ++j)
                {
                    if (data[i * width + j] >= lower && data[i * width + j] <= upper)
                    {
                        realData[i * width + j] = Convert.ToSingle(data[i * width + j]) / 100000;
                    }
                    else
                    {
                        realData[i * width + j] = -10000;
                    }
                }
            }
            return 0;
        }

        private void CalUpperAndLower(int[] data, int height, int width, ref int upper, ref int lower)
        {
            var radio = 100000;
            lower = 100 * radio;
            upper = -100 * radio;
            for (var i = 0; i < height * width; ++i)
            {
                if (data[i] <= -99 * radio || data[i] >= 99 * radio) continue;
                if (data[i] < lower)
                {
                    lower = data[i];
                }
                if (data[i] > upper)
                {
                    upper = data[i];
                }
            }
        }

    }
}
