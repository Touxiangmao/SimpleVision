using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using HalconDotNet;
using SimpleVision.Base;

namespace SimpleVision.Tool
{

    public class ToolIO: INterfaceItem
    {
        /// <summary>
        /// IO的名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// IO的类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// IO属于哪个工具
        /// </summary>
        public string Belong { get; set; }
        /// <summary>
        /// 是不是要显示
        /// </summary>
        public bool Show = false;

        private object item;

        public object Item
        {
            get => item;
            set
            {
                Type = value.GetType().ToString();
                item = value;
            }
        }
    }

    public  class ToolInput : ToolIO
    {
        public ToolInput(string name, string belong)
        {
            Show = true;
            Name = name;
            Belong = belong;
        }
        /// <summary>
        /// 引用的情况:  它的名字+引用工具名+引用的输出名
        /// </summary>
        public string ComeFrom="";
    }

    public class ToolOutput : ToolIO
    {
        public ToolOutput(string name, string belong)
        {
            Show = true;
            Name = name;
            Belong = belong;
        }
    }

}
