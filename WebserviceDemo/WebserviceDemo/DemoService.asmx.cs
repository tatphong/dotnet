using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Windows.Forms;

namespace WebserviceDemo
{
    /// <summary>
    /// Summary description for DemoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DemoService : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private bool CleanData(string name)
        {
            if (Regex.IsMatch(name, "[a-zA-Z]"))
                return true;
            return false;
        }

        [WebMethod]
        public string HelloWorld(string name)
        {
            XmlConfigurator.Configure();
            log.Info("DemoService started");
            log.Info("Get name: "+ name);

            return ProcessHello(name);
        }

        public string ProcessHello(string name)
        {
            log.Info("ProcessHello");
            if (!CleanData(name))
            {
                MessageBox.Show(" please enter valid name");
                log.Warn("User have invalid name");
                return "";
            }

            DBConnector db = new DBConnector();
            db.saveDB(name);

            string res = "Hello " + name;
            log.Info("ProcessHello return: "+ res);
            return res;
        }
    }
}
