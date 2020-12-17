using System;
using System.Collections.Generic;
using System.Text;

namespace TestingLb1
{
    public class Product
    {
        public string count { get; set; }
        public string price { get; set; }
        public string name { get; set; }

        public Product(string _name,string _count,string _price)
        {
            count = _count;
            price = _price;
            name = _name;
        }
    }
}
