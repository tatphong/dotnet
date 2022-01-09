using System;
using System.Collections.Generic;
using System.Text;

namespace DauGia
{
    public class User
    {
        public string username { get; set; }
        public string hashpass { get; set; }
        public int balance { get; set; }

        public User(string username, string hashpass, int balance)
        {
            this.username = username;
            this.hashpass = hashpass;
            this.balance = balance;
        }
    }
}
