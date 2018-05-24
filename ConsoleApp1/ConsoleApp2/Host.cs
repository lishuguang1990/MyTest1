using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //事件接收者
    public class Host
    {
        //４.编写事件处理程序
       public  void HostHandleAlarm(object sender, EventArgs e)
        {
            Console.WriteLine("主  人: 抓住了小偷！");
        }

        //５.注册事件处理程序
        public Host(Dog dog)
        {
            dog.Alarm += new Dog.AlarmEventHandler(HostHandleAlarm);
        }
    }
}
