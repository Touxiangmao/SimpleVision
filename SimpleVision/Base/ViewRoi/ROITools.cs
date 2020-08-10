using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewROI;

namespace ViewROI
{
    class ROITools
    {
        public static void GetAllRois(List<string> roiList)
        {
            var baseType = typeof(ROI);

            var types = (from assembly in AppDomain.CurrentDomain.GetAssemblies() 
                from type in assembly.GetTypes() 
                where baseType.IsAssignableFrom(type) 
                where type.IsClass && !type.IsAbstract && type != baseType 
                select type).ToList();
            //查询基类的所有子类
            types.ForEach((t) =>
            {
                //用接口调用子类
                //var _roiInstance = Activator.CreateInstance(t) as RoiInterfac;
                roiList.Add(t.ToString()); ;
            });
        }
    }
}
