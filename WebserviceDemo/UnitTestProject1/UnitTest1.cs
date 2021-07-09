using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext tc;

        public TestContext TestContext
        {
            get { return tc; }
            set { tc = value; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            String input = "abc3";
            String expected = "Hello abc3";

            WebserviceDemo.DemoService ser = new WebserviceDemo.DemoService();
            String res = ser.ProcessHello(input);

            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"./Data/data.csv", "data#csv", DataAccessMethod.Sequential)]
        public void TestMethodCSV()
        {
            WebserviceDemo.DemoService ser = new WebserviceDemo.DemoService();
            String input = TestContext.DataRow[0].ToString();
            String expected = TestContext.DataRow["expected"].ToString();


            String res = ser.ProcessHello(input);

            Assert.AreEqual(expected, res);
        }
    }
}
