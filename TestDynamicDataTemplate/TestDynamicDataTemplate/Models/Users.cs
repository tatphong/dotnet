using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDynamicDataTemplate.Models
{
    public class Users
    {
        public string username { get; set; }
        public string userid { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime expire { get; set; }
        public string activated { get; set; }

        public Users(OracleDataReader dr)
        {
            this.username = dr["user_name"].ToString();
            this.userid = dr["user_id"].ToString();
            this.email = dr["user_email"].ToString();
            this.phone = dr["phone_number"].ToString();
            this.expire = DateTime.Parse(dr["expired_date"].ToString());
            this.activated = dr["activated"].ToString();
        }
        public Users()
        { }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string ToStringJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
