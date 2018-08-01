using Huach.Admin.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Huach.Admin.Test
{
    public class ModelsTool
    {
        public ModelsTool(string @namespace = "Huach.Admin.Models")
        {
            var classes = Assembly.LoadFrom(@"E:\Project\huach.admin.api\Huach.Admin.Api\Huach.Admin.Api.Other\bin\Debug\Huach.Admin.Models.dll").GetTypes();
            //var classes = Assembly.Load(@namespace).GetTypes();
            foreach (var item in classes)
            {
                if (item.BaseType.Name== "ModelBase" && item.Name != nameof(ModelBase))
                {
                    var spaceJies = item.FullName.Split('.');
                    string space;
                    try
                    {
                        space = spaceJies[@namespace.Split('.').Length];
                    }
                    catch (Exception)
                    {
                        throw new Exception("谁命名空间不规范，来，我们谈谈！！");
                    }
                    if (space == item.Name)
                    {
                        space = "";
                    }
                    _infos.Add(new ModelsInfo
                    {
                        Name = item.Name,
                        Space = space,
                    });
                }
            }
        }
        const string space = "Huach.Admin.{0}";
        static List<ModelsInfo> _infos = new List<ModelsInfo>();
        public List<ModelsInfo> Infos => _infos;
    }
    public class ModelsInfo
    {
        public string Name { get; set; }
        public string Space { get; set; }
        public List<string> Propertys { get; set; }

    }
}
