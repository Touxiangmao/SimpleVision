using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleVision.Base
{
    public  interface INterfaceItem
    {
        /// <summary>
        /// 项目名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// 项目所属类型
        /// </summary>
        string Belong { get; set; }
    }

}



