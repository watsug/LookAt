using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAt
{
    public class Item
    {
        private string _str;
        public Item(string str)
        {
            _str = str;
        }

        public string Str => _str;
        public int Length => _str.Length;
    }
}
