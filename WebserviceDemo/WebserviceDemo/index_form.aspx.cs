using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebserviceDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            log.Info("Form submitted, Event started");

            WebserviceDemo.DemoService serv = new WebserviceDemo.DemoService();
            string name = txtName.Text;
            txtName.Text = "";
            string res = serv.HelloWorld(name);
            lblHello.Text += res != ""?"</br>" + res:"";
        }
    }
}