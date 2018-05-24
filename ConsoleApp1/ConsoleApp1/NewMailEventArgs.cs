using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class NewMailEventArgs
    {
        private string from;
        private string to;
        private string content;

        public string From { get { return from; } }
        public string To { get { return to; } }
        public string Content { get { return content; } }

        public NewMailEventArgs(string from, string to, string content)
        {
            this.from = from;
            this.to = to;
            this.content = content;
        }
    }
}
