using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SimpleVision.Base;
using SimpleVision.Tool;

namespace SimpleVision.Structure
{

    /// <summary>
    /// 解决方案的操作 
    /// </summary>
    public static class Solution
    {
        public static Property SolutionProperty = new Property() { Name = "Solution", Type = "solution", Belong = "solution", CurrentItemName = "" };
        /// <summary>
        /// 当前项目
        /// </summary>
        public static Project CurrentProject;

        /// <summary>
        /// 解决方案的选择项目
        /// </summary>
        public static string CurrrentProjectName
        {
            get => SolutionProperty.CurrentItemName;
            set => SolutionProperty .CurrentItemName= value;
        }
      

        public static string HalfPath = Application.StartupPath + @"\Data\";
        /// <summary>
        /// 导入解决方案
        /// </summary>
        public static void Import()
        {

        }
        /// <summary>
        /// 导出解决方案
        /// </summary>
        public static void Export()
        {

        }
        /// <summary>
        /// 序列化当前project 同时存储所有project的信息到Solution.json
        /// </summary>
        public static void SerializeProject()
        {
            //当前Project的属性
            var projectPropertys = new Property() { Name = CurrentProject.Name, Type = CurrentProject.Type, Belong = CurrentProject.Belong, CurrentItemName = Project.CurrrentJobName };
            //在解决方案信息中更新当前项目的信息 并保存
            SolutionProperty.Items[ SolutionProperty.Items.FindIndex(a=>a.Name == CurrentProject.Name)]= projectPropertys;
            Serialize(HalfPath + $@"{SolutionProperty.Name}\{SolutionProperty.Name}.json", SolutionProperty);

            foreach (var job in CurrentProject.Items)
            {
                var jobPropertys = new Property() { Name = job.Name, Type = job.Type, Belong = job.Belong, CurrentItemName = job.CurrentItemName };
                foreach (var tool in job.Items)
                {
                    var toolProperty = new Property() { Name = tool.Name, Type = tool.Type, Belong = tool.Belong, CurrentItemName = "" };
                    jobPropertys.Items.Add(toolProperty);
                    //分开序列化
                    tool.Serialize(HalfPath + $@"{SolutionProperty.Name}\{CurrentProject.Name}\{job.Name}\{tool.Name}\data.json");
                }
                //job 里头只包含tool信息 
                Serialize(HalfPath + $@"{SolutionProperty.Name}\{CurrentProject.Name}\{job.Name}\{job.Name}.json", jobPropertys);
                var jobProperty = new Property() { Name = job.Name, Type = job.Type, Belong = job.Belong, CurrentItemName = job.CurrentItemName };
                projectPropertys.Items.Add(jobProperty);
            }
            //project 里头只包含job信息
            Serialize(HalfPath + $@"{SolutionProperty.Name}\{CurrentProject.Name}\{CurrentProject.Name}.json", projectPropertys);
        }

        /// <summary>
        /// 读取所有project信息 反序列化指定的project
        /// </summary>
        /// <param name="projectName">要反序列化的项目</param>
        public static void DeserializeProject(string projectName)
        {
            var currentItemName = "";
            foreach (var projectProperty in SolutionProperty.Items.Where(projectProperty => projectName == projectProperty.Name))
            {
                 currentItemName = projectProperty.CurrentItemName;
                CurrentProject = new Project(projectProperty.Name,projectProperty.Type,projectProperty.Belong) { CurrentItemName = projectProperty.CurrentItemName };
                CurrrentProjectName = CurrentProject.Name;
                var currentProjectProperty = Deserialize<Property>(HalfPath + $@"{projectProperty.Belong}\{projectProperty.Name}\{projectProperty.Name}.json");
                if (currentProjectProperty == null)
                {
                    return;
                }
                foreach (var jobProperty in currentProjectProperty.Items)
                {
                    var currentJobProperty = Deserialize<Property>(HalfPath + $@"{currentProjectProperty.Belong}\{jobProperty.Belong}\{jobProperty.Name}\{jobProperty.Name}.json");
                    Project.AddJob(currentJobProperty.Name, false);
                    foreach (var toolProperty in currentJobProperty.Items)
                    {
                        var _ = (INterfaceTool)Activator.CreateInstance(Type.GetType(toolProperty.Type) ?? throw new InvalidOperationException());
                        _.Deserialize(
                            HalfPath +
                            $@"{currentProjectProperty.Belong}\{jobProperty.Belong}\{toolProperty.Belong}\{toolProperty.Name}\data.json");
                       Job. AddTool(_);
                    }
                }
            }
            Project.CurrrentJobName = currentItemName;
        }
        /// <summary>
        /// 读取解决方案基本信息 (包含的project的信息)
        /// </summary>
        public static void DeserializeSolutionProperty()
        {
            var solutionProperty = Deserialize<Property>(HalfPath + $@"{SolutionProperty.Name}\{SolutionProperty.Name}.json");

            if (solutionProperty == null) return;
            SolutionProperty = solutionProperty;

        }

        /// <summary>
        /// 序列化一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">路径</param>
        /// <param name="item">项目</param>
        public static void Serialize<T>(string path, T item)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
            using var file1 = File.CreateText(path);
            var serializer1 = new JsonSerializer
            {
                Formatting = Formatting.Indented,
            };
            serializer1.Serialize(file1, item);
        }
        /// <summary>
        /// 反序列化一个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">路径</param>
        /// <returns>对象</returns>
        public static T Deserialize<T>(string path)
        {
            if (!File.Exists(path))
            {
                return default;
            }
            using var file = File.OpenText(path);
            var serializer = new JsonSerializer();
            var _ = (T)serializer.Deserialize(file, typeof(T));
            return _;
        }

        /// <summary>
        /// 添加一个新的项目
        /// </summary>
        /// <param name="projectName">项目名称</param>
        public static void AddProject(string projectName)
        {
            var projectProperty = new Property() { Name = projectName, Type = "project", Belong = SolutionProperty.Name };
            SolutionProperty.Items.Add(projectProperty);
        }
        /// <summary>
        /// 添加新项目 使用输入的名称
        /// </summary>
        public static void AddProject()
        {
            using var formInput = new FormInput(@"输入新项目名")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            formInput.ShowDialog();
            if (formInput.DialogResult != DialogResult.OK) return;
            AddProject(FormInput.Input);
        }


    }

}
