using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberOfThiefEventArgs NumberOfThiefEventArgs = new NumberOfThiefEventArgs(1);
            Dog dog = new Dog();
            Host host = new Host(dog);
                 
              //当前时间，从2008年12月31日23:59:50开始计时
              DateTime now = new DateTime(2008, 12, 31, 23, 59, 50);
            DateTime midnight = new DateTime(2009, 1, 1, 0, 0, 0);

            //等待午夜的到来
            Console.WriteLine("时间一秒一秒地流逝... ");
            while (now < midnight)
            {
                Console.WriteLine("当前时间: " + now);
                System.Threading.Thread.Sleep(1000); //程序暂停一秒
                now = now.AddSeconds(1);                //时间增加一秒
            }

            //午夜零点小偷到达,看门狗引发Alarm事件
            Console.WriteLine("/n月黑风高的午夜: " + now);
            Console.WriteLine("小偷悄悄地摸进了主人的屋内... ");

            //创建事件参数
            NumberOfThiefEventArgs e = new NumberOfThiefEventArgs(3);
            dog.OnAlarm(e);

            var class1 = typeof(Class1);
            // var assembly = Assembly.Load();
            //  assembly.CreateInstance
            //  class1.a
       
            Console.Read();
        }
    }
}
