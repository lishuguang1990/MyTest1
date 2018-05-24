using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForeach
{
    public class DataItem
    {
        public DataItem Next { get; set; }

        public object Data { get; set; }

        public DataItem(object data)
        {
            this.Data = data;
        }
     }
}
