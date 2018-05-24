using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
   public  class NumberOfThiefEventArgs: EventArgs
    {
        public int numberOfThief;

        //构造函数
        public NumberOfThiefEventArgs(int number)
        {
            numberOfThief = number;
        }
    }

}
