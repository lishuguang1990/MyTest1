using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
   public    class Rank
    {
        //public List<T> Rank<T>(List<T> list,Func)
        //{

        //}
        public List<int> GetRanKList(List<int> list,int type)
        {
            list.Sort((x, y) =>
            {
                return y.CompareTo(x);
            });
            int rank = 0;
            List<int> listrank = new List<int>();
            int index1 = 1;
            List<int> finshlist = new List<int>();
            if (type == 1)
            {
                foreach (var item in list)
                {
                    //int index = list.IndexOf(item)+1;
                    if (!finshlist.Contains(item))
                    {
                      
                        var count = list.Where(a => a == item).Count();
                        for (int i = 0; i < count; i++)
                        {
                            listrank.Add(index1);
                        }
                        index1++;
                        finshlist.Add(item);
                    }

                }
            }
            else
            {
                foreach (var item in list)
                {
                    if (!finshlist.Contains(item))
                    {
                     
                        var count = list.Where(a => a == item).Count();
                        for (int i = 0; i < count; i++)
                        {
                            listrank.Add(index1);
                        }
                        index1 += count;
                        finshlist.Add(item);
                    }
                }
            }
         
            return listrank;
        }

    }
}
