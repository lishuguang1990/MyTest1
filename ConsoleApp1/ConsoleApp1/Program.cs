using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //EventTest e = new EventTest(); /* 实例化对象,第一次没有触发事件 */
            //subscribEvent v = new subscribEvent(); /* 实例化对象 */
            //e.ChangeNum += new EventTest.NumManipulationHandler(v.printf); /* 注册 */
            //e.SetValue(7);
            //e.SetValue(11);
            //Console.Read();
            //PTest p = new PTest();
            ////p.GreetPeople((a, b) => Console.WriteLine(a + b), "早上好", "夏明");
            ////Action<string, string> act = p.ChineseGreeting;
            ////act += p.ChineseGreeting1;
            ////p.GreetPeople(act, "goodmorning", "夏明");
            ////PTest PTest = new PTest();
            ////PTest.MakeGreet += (a, b) => Console.WriteLine(a+b);
            ////PTest.GetTest("小明", "你好");
            //Heater heater = new Heater();
            //Alarm alarm = new Alarm();

            //heater.BoilEvent += alarm.MakeAlert;    //注册方法
            ////heater.BoilEvent += (new Alarm()).MakeAlert;   //给匿名对象注册方法
            //heater.BoilEvent += Display.ShowMsg;       //注册静态方法

            //heater.BoilWater();   //烧水，会

            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.Boiled += alarm.MakeAlert;   //注册方法
            heater.Boiled += (new Alarm()).MakeAlert;      //给匿名对象注册方法
            heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);    //也可以这么注册
            heater.Boiled += Display.ShowMsg;       //注册静态方法

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法
            Console.Read();
        }


    }
    public class Heater
    {
        private int temperature;
        public string type = "RealFire 001";       // 添加型号作为演示
        public string area = "China Xian";         // 添加产地作为演示
                                                   //声明委托
        public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
        public event BoiledEventHandler Boiled; //声明事件

        // 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null)
            { // 如果有对象注册
                Boiled(this, e);  // 调用所有注册对象的方法
            }
        }

        // 烧水。
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //建立BoiledEventArgs 对象。
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);  // 调用 OnBolied方法
                }
            }
        }
    }

    // 警报器
    public class Alarm
    {
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
                                                //访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }
    }

    // 显示器
    public class Display
    {
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        {   //静态方法
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }
        //public class Heater
        //{
        //    private int temperature;
        //    public delegate void BoilHandler(int param);   //声明委托
        //    public event BoilHandler BoilEvent;        //声明事件

        //    // 烧水
        //    public void BoilWater()
        //    {
        //        for (int i = 0; i <= 100; i++)
        //        {
        //            temperature = i;

        //            if (temperature > 95)
        //            {
        //                BoilEvent?.Invoke(temperature);  //调用所有注册对象的方法
        //            }
        //        }
        //    }
        //}

        //// 警报器
        //public class Alarm
        //{
        //    public void MakeAlert(int param)
        //    {
        //        Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        //    }
        //}

        //// 显示器
        //public class Display
        //{
        //    public static void ShowMsg(int param)
        //    { //静态方法
        //        Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", param);
        //    }
        //}


        public class PTest
        {
            public event Action<string, string> MakeGreet;

            public void GetTest(string a, string b)
            {
                if (MakeGreet != null)
                {
                    MakeGreet(a, "ceshi");
                }
            }

            public void GreetPeople(string name)
            {
                MakeGreet(name, "ceshi");
            }
            public void GreetPeople(Action<string, string> act, string name, string hello)
            {
                act(name, hello);
            }
            public void ChineseGreeting(string name, string b)
            {
                Console.WriteLine(name + b);
            }
            public void ChineseGreeting1(string name, string b)
            {
                Console.WriteLine(name + b);
            }
        }

        /***********发布器类***********/
        public class EventTest
        {
            private int value;

            public delegate void NumManipulationHandler();


            public event NumManipulationHandler ChangeNum;
            protected virtual void OnNumChanged()
            {
                if (ChangeNum != null)
                {
                    ChangeNum(); /* 事件被触发 */
                }
                else
                {
                    Console.WriteLine("event not fire");
                    Console.ReadKey(); /* 回车继续 */
                }
            }
            public EventTest()
            {
                int n = 5;
                SetValue(n);
            }


            public void SetValue(int n)
            {
                if (value != n)
                {
                    value = n;
                    OnNumChanged();
                }
            }
        }
        /***********订阅器类***********/
        public class subscribEvent
        {
            public void printf()
            {
                Console.WriteLine("event fire");
                Console.ReadKey(); /* 回车继续 */
            }
        }

        class Boiler
        {
            private int temp;
            private int pressure;
            public Boiler(int t, int p)
            {
                temp = t;
                pressure = p;
            }

            public int getTemp()
            {
                return temp;
            }
            public int getPressure()
            {
                return pressure;
            }
        }


        /// <summary>
        /// ///////////////////////////////////////////////
        /// 本实例提供一个简单的用于热水锅炉系统故障排除的应用程序。当维修工程师检查锅炉时，
        /// 锅炉的温度和压力会随着维修工程师的备注自动记录到日志文件中。
        /// </summary>
        // 事件发布器
        class DelegateBoilerEvent
        {
            public delegate void BoilerLogHandler(string status);

            // 基于上面的委托定义事件
            public event BoilerLogHandler BoilerEventLog;

            public void LogProcess()
            {
                string remarks = "O. K";
                Boiler b = new Boiler(100, 12);
                int t = b.getTemp();
                int p = b.getPressure();
                if (t > 150 || t < 80 || p < 12 || p > 15)
                {
                    remarks = "Need Maintenance";
                }
                OnBoilerEventLog("Logging Info:\n");
                OnBoilerEventLog("Temparature " + t + "\nPressure: " + p);
                OnBoilerEventLog("\nMessage: " + remarks);
            }

            protected void OnBoilerEventLog(string message)
            {
                if (BoilerEventLog != null)
                {
                    BoilerEventLog(message);
                }
            }
        }
        // 该类保留写入日志文件的条款
        class BoilerInfoLogger
        {
            FileStream fs;
            StreamWriter sw;
            public BoilerInfoLogger(string filename)
            {
                fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
            }
            public void Logger(string info)
            {
                sw.WriteLine(info);
            }
            public void Close()
            {
                sw.Close();
                fs.Close();
            }

        }
        // 事件订阅器
        public class RecordBoilerInfo
        {
            static void Logger(string info)
            {
                Console.WriteLine(info);
            }//end of Logger

            //static void Main(string[] args)
            //{
            //    BoilerInfoLogger filelog = new BoilerInfoLogger("e:\\boiler.txt");
            //    DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            //    boilerEvent.BoilerEventLog += new
            //    DelegateBoilerEvent.BoilerLogHandler(Logger);
            //    boilerEvent.BoilerEventLog += new
            //    DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);
            //    boilerEvent.LogProcess();
            //    Console.ReadLine();
            //    filelog.Close();
            //}//end of main

        }//end of RecordBoilerInfo
    
}
