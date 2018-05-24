using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForeach
{
    public class ColorEnumerator : IEnumerator
    {
        private string[] list;
        private int index = -1;
        public ColorEnumerator(string [] arr)
        {
            list = arr;
            for (int i = 0; i < arr.Length; i++)
            {
                list[i] = arr[i];
            }
           
        }
        public object Current
        {
            get {

               return list[index];
            }
        }

        public bool MoveNext()
        {
            if (list.Length - 1 > index)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
