using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bandeira.Integration.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://www.google.com.br");


        }
    }
}
