using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
   public static class Class1
    {
        public static List<double> GetList(int money,int count)
        {
            var list = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                var listsum = list.Sum();
                var rndnumber = 0.0;
       
                if (i == count - 1)
                {
                    rndnumber = Math.Round(Convert.ToDouble(money) - listsum,2);
                }
                else
                {
                    while (true)
                    {
                        rndnumber =Math.Round(Convert.ToDouble(rnd.Next(100, 999)) * 0.01,2);

                        if (money - listsum - rndnumber > count - list.Count && rndnumber < 10)
                        {
                            break;
                        }
                    }
                }
                list.Add(rndnumber);
            }
            return list;
             
        }

        //public static List<double> GetList1(double money, int count)
        //{
        //    var list = new List<double>();
        //    for (int i = 0; i < count-1; i++)
        //    {
        //        int j = i + 1;
        //        double safe_money = (money - (count - j) * 0.01) / (count - j);
        //        double tmp_money = new Random().Next(0,100) * (safe_money * 100 - 0.01 * 100) + 0.01 * 100;
        //        money = money - tmp_money;
        //        list.Add(money);
        //    }
        //    return list;
        //}
    }
}
