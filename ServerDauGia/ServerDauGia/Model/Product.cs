using System;
using System.Collections.Generic;
using System.Text;

namespace ServerDauGia.Model
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int org_price { get; set; }
        public int final_price { get; set; }
        public string username { get; set; } = string.Empty;
        public DateTime sold_time { get; set; }
        public bool sold { get; set; } = false;

        public Product() { }

        public Product(int id, string name, int org_price, int final_price, bool sold, 
                        string username, DateTime sold_time)
        {
            this.id = id;
            this.name = name;
            this.org_price = org_price;
            this.final_price = final_price;
            this.sold = sold;
            this.username = username;
            this.sold_time = sold_time;
        }

        public Product(string name, int org_price)
        {
            this.name = name;
            this.org_price = org_price;
        }
    }
}
