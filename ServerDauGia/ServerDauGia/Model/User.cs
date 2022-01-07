using System;
using System.Collections.Generic;
using System.Text;

namespace ServerDauGia.Model
{
    public class User
    {
        public string username { get; set; }
        public string hashpass { get; set; }
        public int balance { get; set; }
        public bool block { get; set; }

        public User(string username, string hashpass, int balance, bool block)
        {
            this.username = username;
            this.hashpass = hashpass;
            this.balance = balance;
            this.block = block;
        }
    }
}
