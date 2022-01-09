using System;
using System.Collections.Generic;
using System.Text;

namespace DauGia
{
    public class Product
    {
        public string name  { get; set; }
        public int org_price { get; set; }

        public Product(string name, int org_price)
        {
            this.name = name;
            this.org_price = org_price;
        }
    }
}
