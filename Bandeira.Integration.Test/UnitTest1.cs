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
            driver.FindElement(By.Id("DirID")).SendKeys("C:/TestaArquivosOnline");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.FindElementByCssSelector("#URLRepo:invalid").Should().NotBeNull();
        }

        [TestMethod]
        public void ExceçaoDoID()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Id("DirID")).SendKeys("asdsd");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.FindElementByClassName("field-validation-error").Should().NotBeNull();
        }

        [TestMethod]
        public void ExceçaoDaURLeID()
        {
            var driver = TestEnvironment.driver;
                driver.Navigate().GoToUrl("http://localhost:8080/");
                driver.FindElement(By.Name("btnExecutar")).Click();

            var listaErros = driver.FindElementsByClassName("field-validation-error");
                listaErros[0].Text.Should().Be("Favor, insira uma URL");
                listaErros[1].Text.Should().Be("Favor, insira um diretório onde salvar os dados");
        }

        [TestMethod]
        public void AcessarDetalhesDeArquivoZero()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Id("DirID")).SendKeys("C:/TestaArquivosOnline");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/0");
        }

        [TestMethod]
        public void BotaoAnteriorNaoApareceNaprimeiraPagina()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Id("DirID")).SendKeys("C:/TestaArquivosOnline");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.FindElementByCssSelector(".voltar a").Should().BeNull();
        }

        [TestMethod]
        public void NavegarParaPaginaI()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Id("DirID")).SendKeys("C:/TestaArquivosOnline");
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
            driver.FindElement(By.Id("DirID")).SendKeys("C:/TestaArquivosOnline");
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


    }
}
