using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
   public  class Host
    {
        //４.编写事件处理程序，参数中包含着numberOfThief信息
        void HostHandleAlarm(object sender, NumberOfThiefEventArgs e)
        {
            if (e.numberOfThief <= 1)
            {
                Console.WriteLine("主  人: 抓住了小偷！");
            }
            else
            {
                Console.WriteLine("主 人:打110报警，我家来了{0}个小偷！", e.numberOfThief);
            }
        }
        //５.注册事件处理程序
        public Host(Dog dog)
        {
            dog.Alarm += new Dog.AlarmEventHandler(HostHandleAlarm);
        }
    }
}
