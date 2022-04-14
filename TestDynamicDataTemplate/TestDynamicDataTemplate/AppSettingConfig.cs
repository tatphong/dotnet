using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDynamicDataTemplate
{
    public class AppSetting
    {
        public AppSettings appSettings { get; set; }
        public AppSetting()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            appSettings = config.GetSection("AppSettings").Get<AppSettings>();
        }
        public string GetDBHost()
        {
            return appSettings.dbHost;
        }

        public string GetDbPass()
        {
            return appSettings.dbPass;
        }

        public string GetDbSID()
        {
            return appSettings.dbSID;
        }

        public string GetDbUser()
        {
            return appSettings.dbUser;
        }

        public string GetDbPort()
        {
            return appSettings.dbPort;
        }

        public string GetMail()
        {
            return appSettings.mail;
        }

        public string GetPassMail()
        {
            return appSettings.passMail;
        }
        public string GetConnectionStringDB()
        {
            return appSettings.connectionStringDB;
        }
        public string GetSchema()
        {
            return appSettings.schema;
        }

        public class AppSettings
        {
            public string dbHost { get; set; }
            public string dbPort { get; set; }
            public string dbSID { get; set; }
            public string dbUser { get; set; }
            public string dbPass { get; set; }

            public string mail { get; set; }
            public string passMail { get; set; }

            public string connectionStringDB { get; set; }
            public string schema { get; set; }

        }
    }
}
