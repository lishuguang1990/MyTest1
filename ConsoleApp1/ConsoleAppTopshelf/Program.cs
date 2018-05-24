﻿using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ConsoleAppTopshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlConfigurator.ConfigureAndWatch(new FileInfo(".\\log4net.config"));

            //var rc = HostFactory.Run(x =>                                   //1
            //{
            //    x.Service<TownCrier>(s =>                                   //2
            //    {
            //        s.ConstructUsing(name => new TownCrier());                //3
            //        s.WhenStarted(tc => tc.Start());                         //4
            //        s.WhenStopped(tc => tc.Stop());                          //5
            //    });
            //    x.RunAsLocalSystem();                                       //6

            //    x.SetDescription("Sample Topshelf Host");                   //7
            //    x.SetDisplayName("Stuff");                                  //8
            //    x.SetServiceName("Stuff");                                  //9
            //});                                                             //10

            //var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            //Environment.ExitCode = exitCode;

          
            //要添加log4net.config到项目中

            var host = HostFactory.New(x =>
            {
                
              //  x.EnableDashboard(); //有问题则注释掉该行
                x.Service<SampleService>(s =>
                {
                  //  s.SetServiceName("SampleService");//有问题则注释掉该行
                    s.ConstructUsing(name => new SampleService());
                    
                    s.WhenStarted(tc =>
                    {
                        tc.Start();
                    });
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("SampleService Description");
                x.SetDisplayName("SampleService");
                x.SetServiceName("SampleService");
            });

            host.Run();
        }
    }
    public class TownCrier
    {
        readonly Timer _timer;
        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
            
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
