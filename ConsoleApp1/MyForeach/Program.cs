using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForeach
{
    class Program
    {
        /*什么是可枚举类
         答：可枚举类是指实现了IEnumerable接口的类；IEnumerable接口只有一个成员GetEnumerator方法，它返回对象的枚举器
         什么是枚举器
         实现了IEnumerator接口的枚举器包含三个函数成员：Current，MoveNext，Reset
             */
        static void Main(string[] args)
        {
          //  IEnumerable
            string[] color = { "read", "yellow", "blue" };
            //获取枚举器
            IEnumerator enumerator = color.GetEnumerator();
           //将枚举器前进到下个位置
            while (enumerator.MoveNext())
            {
                object obj = enumerator.Current;
                string item = obj.ToString();
                Console.WriteLine(item);
            }
            ColorEnumerable ColorEnumerablen= new ColorEnumerable();
            //var test = ColorEnumerablen.GetEnumerator();
            foreach (var item in ColorEnumerablen)
            {
              //  Console.WriteLine(item);
            }
            MyList MyList = new MyList();
            foreach (var item in MyList)
            {
                Console.WriteLine(item);

            }
            Console.Read();
        }
    }
}
