using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventTest
{
      
   
    class Program
    {
        public delegate void PrintName(string name);
        public event PrintName PrintNameEvent;
        //static void Main(string[] args)
        //{
        //   //通过lambda表达式可以访问表达式块外部的变量
        //    var PrintName = new PrintName(GetName);
        //    PrintName += delegate (string name)
        //      {
        //          Console.WriteLine("你好呀小明"+name);
        //      };
        //    PrintName.Invoke("小明");

        //    int a = 5;
        //    Func<int, int> f = x => x + a;
        //    a = 7;
        //    Console.WriteLine(f(3)); 
        //    Console.Read();
        //    //Program Program = new Program();
        //    //Program.PrintNameEvent += new PrintName(GetName);
        //    //Program.PrintNameEvent += new PrintName(GetName1);
        //    //Program.PrintNameEvent("xiaoming");
        //    //Console.Read();
        //}

        public static void GetName(string name)
        {
            Console.WriteLine(name);
        }
        public static void GetName1(string name)
        {
            Console.WriteLine(name+"很好");
        }
    }
}
