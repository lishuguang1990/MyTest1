using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = typeof(Class2).GetProperties().Select(p => p.getName());

            //Console.WriteLine(string.Join(",",list));
            //Console.Read();

            NameValueCollection markStatus = new NameValueCollection();
            string[] values = null;
            markStatus.Add("Very High", "80");
            markStatus.Add("High", "60");
            markStatus.Add("medium", "50");
            markStatus.Add("Pass", "40");
            foreach (string key in markStatus.Keys)
            {
                values = markStatus.GetValues(key);
                foreach (string value in values)
                {
                    Console.WriteLine(key + " - " + value);
                }
            }
            string abc = "333";
            var abcd = abc.Split(',').ToList();
            Console.WriteLine(abcd);

            Rank Rank = new Rank();
            List<Score> listscore = new List<Score>();
            listscore.Add(new Score { ScoreNumber = 100 });
            listscore.Add(new Score { ScoreNumber = 99 });
            listscore.Add(new Score { ScoreNumber = 101 });
            listscore.Add(new Score { ScoreNumber = 89 });

            List<int> listint = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
              

                listint.Add(rnd.Next(0, 100));
            }
            var list = Rank.GetRanKList(listint,2);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]+","+ listint[i]);
            }
         
            Console.Read();
        }
    }
}
