using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForeach
{
   public  class MyList
    {
        private int[] arr = { 15, 55, 88, 77, 88, 99, 44, 77 };
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }
    }
}
