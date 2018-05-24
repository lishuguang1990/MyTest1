using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class Class1
    {
        public static string getName(this PropertyInfo model)
        {
            if (model.IsDefined(typeof(LiAttribute), true))
            {
                var model1 = model.GetCustomAttribute(typeof(LiAttribute)) as LiAttribute;
                return model1.Name;
            }
            else
            {
                return model.Name;
            }

        }
    }
    public class LiAttribute : Attribute
    {
        public string Name { get; set; }
        public LiAttribute(string name)
        {
            Name = name;
        }
    }
}
