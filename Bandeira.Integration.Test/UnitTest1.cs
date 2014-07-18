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
        public void ExceçaoDeURL()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("asdf");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.FindElementByCssSelector("#URLRepo:invalid").Should().NotBeNull();
        }


        [TestMethod]
        public void AcessarDetalhesDeArquivoZero()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/0");
        }

        [TestMethod]
        public void NavegarParaPaginaI()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();
            
            for(int i = 0; i <= 5; i++)
            {
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + i);
                driver.FindElement(By.CssSelector(".proximo a")).Click();
            }
        }

        [TestMethod]
        public void NavegarParaIEVoltarParaIMenos1()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();
            int i;

            for (i = 0; i <= 3; i++)
            {
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + i);
                driver.FindElement(By.CssSelector(".proximo a")).Click();
            }
            driver.FindElement(By.CssSelector(".voltar a")).Click();
            driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + (i - 1));
        }

        [TestMethod]
        public void VerificarSePrettyFyEstaFuncionando()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();

            driver.FindElementByCssSelector("pre.prettyprinted").Should().NotBeNull();
        }
    }
}
