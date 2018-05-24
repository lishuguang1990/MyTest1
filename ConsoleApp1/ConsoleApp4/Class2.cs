using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
   
     public  class Class2
    {
        public int Id { get; set; }
        [LiAttribute("productname")]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
