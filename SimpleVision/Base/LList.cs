using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SimpleVision.Tool;


namespace SimpleVision.Base
{
    /// <summary>
    /// 项目属性
    /// </summary>
    public class Property
    {
        public string Name;
        public string Type;
        public string Belong;
        public string CurrentItemName = "";

        public  List<Property> Items = new List<Property>();
    }

    /// <summary>
    /// 增加了查找等功能的list类,存储的对象需要实现INterfaceItem接口
    /// </summary>
    /// <typeparam name="T">这里的T只能是继承Item的类</typeparam>

    public class LList<T> : INterfaceItem where T : INterfaceItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Belong { get; set; }

        public string CurrentItemName = "";
      
        /// <summary>
        /// 数组
        /// </summary>
        public List<T> Items = new List<T>();

        public T CurrentItem => this[CurrentItemName];

        /// <summary>
        /// 初始化时需要传入项目名称
        /// </summary>
        /// <param name="name">项目名称</param>
        /// <param name="type">项目类型</param>
        /// <param name="belong">项目归属</param>
        /// <param name="items">包含的子项</param>
        public LList(string name, string type, string belong, List<T> items)
        {
            Type = type;
            Belong = belong;
            Name = name;
            Items = items;
        }

        public LList(string name, string type, string belong)
        {
            Type = type;
            Belong = belong;
            Name = name;
        }
        public LList()
        {
           
        }

        /// <summary>
        /// 根据名字返回相应的LItem
        /// </summary>
        /// <param name="name">LItem的名称</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public T this[string name]
        {
            get => FindByName(name);
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this[name] = value;
            }
        }
        /// <summary>
        /// 根据索引返回相应的LItem
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get => Items.Count > 0 ? Items[index] : default;
            set => Items[index] = value;
        }

        public bool Add(T item, bool repeatable = false)
        {
            
            var lItem = item;
            var sameItemCount = Items.Count(_ => _.GetType() == lItem.GetType());
            if (sameItemCount != 0)
            {
                var hasSameName = false;
                foreach (var _ in Items.Where(_ => _.Name == lItem.Name))
                {
                    if (!repeatable) return false;
                    hasSameName = true;
                }

                var a = item.GetType();
                if (hasSameName) item.Name += sameItemCount;
                Items.Add(item);
                return true;
            }
            Items.Add(item);
            return true;
        }

        public void ReMove(string name)
        {
            Items.Remove(FindByName(name));
        }

        private T FindByName(string name)
        {
            if (string.IsNullOrEmpty( name))
            {
                return default;
            }
            foreach (var _ in Items.Where(_ => _.Name == name))
            {
                return _;
            }
            return default;
        }

        public int FindIndexByName(string name)
        {
            foreach (var _ in Items.Where(_ => _.Name == name))
            {
                return Items.IndexOf(_);
            }
            return -1;
        }

        public void MoveUp(T item)
        {
            Items.MoveUp(Items.IndexOf(item));
        }
        public void MoveDown(T item)
        {
            Items.MoveDown(Items.IndexOf(item));
        }

        public void Move(int oldID, int newID)
        {
            Items.Move(oldID, newID);
        }
    }

    public static class ListMove
    {
        /// <summary>
        /// list移动操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList">The 数据列表 list.</param>
        /// <param name="id">需要Move的下标（当前被移动元素所在的位置），如：1,2,4,5,6...</param>
        /// <param name="Step">Move的 Step. 默认为1</param>
        /// <returns></returns>
        public static bool MoveUp<T>(this IList<T> dataList, int id, int Step = 1)
        {
            return dataList.Move(id, id - Step);
        }

        public static bool MoveDown<T>(this IList<T> dataList, int id, int Step = 1)
        {
            return dataList.Move(id, id + Step);
        }

        public static bool MoveTop<T>(this IList<T> dataList, int id)
        {
            return dataList.Move(id, 0);
        }

        public static bool MoveBottom<T>(this IList<T> dataList, int id)
        {
            return dataList.Move(id, dataList.Count - 1);
        }

        public static bool Move<T>(this IList<T> dataList, int OldID, int NewID)
        {
            if (OldID >= dataList.Count || NewID >= dataList.Count || OldID < 0 || NewID < 0 || OldID == NewID)
                return false;
            try
            {
                var sel = dataList[OldID];
                dataList.RemoveAt(OldID);
                dataList.Insert(NewID, sel);
                return true;
            }
            catch (Exception)
            {
                return false;
                ;
            }
        }
        public static bool Exchange<T>(this IList<T> list, int OldID, int NewID)
        {
            if (OldID >= list.Count || NewID >= list.Count || OldID < 0 || NewID < 0 || OldID == NewID) { return false; }

            try
            {
                var sel = list[OldID];
                list[OldID] = list[NewID];
                list[NewID] = sel;
                return true;
            }
            catch (Exception)
            {
                return false; ;
            }
        }
    }
}



