using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = Class1.GetList1(100, 50);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            //Console.WriteLine(list.Sum() + "UUUU" + list.Count());
            //Console.Read();
            double totalAmount = 20;
            int num = 10;
            double minAmount = 0.01;
            Random r = new Random();
            for (int i = 1; i < num; i++)
            {
                double safeAmount = (totalAmount - (num - i) * minAmount) / (num - i);
                //double money = new Random().Next(Convert.ToInt32(minAmount * 100), Convert.ToInt32(safeAmount * 100)) / 100; 
                double money = NextDouble(r, minAmount * 100, safeAmount * 100) / 100;
                money = Math.Round(money, 2, MidpointRounding.AwayFromZero);
                totalAmount = totalAmount - money;
                totalAmount = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine("第" + i + "个红包：" + money + " 元，余额：" + totalAmount + " 元");
            }
            Console.WriteLine("第" + num + "个红包：" + totalAmount + " 元，余额：0 元");

            Console.ReadKey();

        }
        /// <summary>
         /// 生成设置范围内的Double的随机数
         /// eg:_random.NextDouble(1.5, 2.5)
         /// </summary>
         /// <param name="random">Random</param>
         /// <param name="miniDouble">生成随机数的最大值</param>
         /// <param name="maxiDouble">生成随机数的最小值</param>
         /// <returns>当Random等于NULL的时候返回0;</returns>
         protected static double NextDouble(Random random, double miniDouble, double maxiDouble)
         {
             if (random != null)
             {
                 return random.NextDouble() * (maxiDouble - miniDouble) + miniDouble;
             }
             else
             {
                 return 0.0d;
             }
         }
    }
}
