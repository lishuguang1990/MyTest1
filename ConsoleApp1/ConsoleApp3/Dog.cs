using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //事件发送者
    public class Dog
    {
        //1.声明关于事件的委托；
        public delegate void AlarmEventHandler(object sender, NumberOfThiefEventArgs e);

        //2.声明事件；
        public event AlarmEventHandler Alarm;

        //3.编写引发事件的函数，注意多了个参数；
        public void OnAlarm(NumberOfThiefEventArgs e)
        {
            if (this.Alarm != null)
            {
                Console.WriteLine("/n狗报警: 有小偷进来了,汪汪~~~~~~~/n");
                this.Alarm(this, e);
            }
        }
    }
}
