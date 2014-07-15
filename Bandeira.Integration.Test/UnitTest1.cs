using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using FluentAssertions;

namespace Bandeira.Integration.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:49892/");

            driver.FindElement(By.Id("URLRepo")).SendKeys("asdf");
            driver.FindElement(By.Id("DirID")).SendKeys("asdf");

            driver.FindElement(By.Name("btnExecutar")).Click();

            driver.Url.Should().Be("asdasdasd");




        }
    }
}
