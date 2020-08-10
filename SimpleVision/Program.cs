using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleVision
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //保证主窗口静态变量是最开始new的这个
            Application.Run(FormMain.Instance);
        }
    }
}
