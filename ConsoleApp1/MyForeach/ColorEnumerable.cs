using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForeach
{
    public class ColorEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            string[] abc = { "1", "44", "44", "77" };
            return new ColorEnumerator(abc);
        }
    }
}
