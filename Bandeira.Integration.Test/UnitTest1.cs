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
                driver.FindElement(By.CssSelector(".btnProximo")).Click();
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
                driver.FindElement(By.CssSelector(".btnProximo")).Click();
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

        [TestMethod]
        public void EnvioDeDadosDoFormularioEstaFuncionando()
        {
            string texto = "Testando o formulario ";
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();

            for (int i = 0; i < 12; i++)
            {
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + i);
                driver.FindElement(By.ClassName("textFormAnot")).SendKeys(texto + i);
                driver.FindElement(By.Name("btnSalvar")).Click();
            }
        }

        [TestMethod]
        public void PaginaAnotacoesEhCriada()
        {
            string texto = "Testando o formulario ";
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();

            for (int i = 0; i < 12; i++)
            {
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + i);
                driver.FindElement(By.ClassName("textFormAnot")).SendKeys(texto + i);
                driver.FindElement(By.Name("btnSalvar")).Click();
            }
                driver.FindElement(By.Name("btnAnotacoes")).Click();
                driver.Url.Should().Be("http://localhost:8080/Home/Anotacoes");
                driver.FindElementsByClassName("conteuArq").Should().NotBeNull();  
        }

        [TestMethod]
        public void InsereDuasVezesNoFormulario()
        {
            string texto = "Testando o formulario ";
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();

            for (int i = 0; i < 10; i++)
            {
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + i);
                driver.FindElement(By.ClassName("textFormAnot")).SendKeys(texto + i);
                driver.FindElement(By.Name("btnSalvar")).Click();
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + (i +1));
                driver.FindElement(By.CssSelector(".voltar a")).Click();
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/" + i);
                driver.FindElement(By.ClassName("textFormAnot")).SendKeys("huehuehuehue" + i);
                driver.FindElement(By.Name("btnSalvar")).Click();
            }
        }


        [TestMethod]
        public void PreenchimentoDoAnotacoes()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/0");
                driver.FindElement(By.ClassName("textFormAnot")).SendKeys("Testando o formulario 0");
                driver.FindElement(By.Name("btnSalvar")).Click();
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/1");
                driver.FindElement(By.CssSelector(".voltar a")).Click();
                driver.FindElement(By.ClassName("textFormAnot")).SendKeys("huehuehuehue");
                driver.FindElement(By.Name("btnSalvar")).Click();
                driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/1");
        }

        [TestMethod]
        public void VerificaSeNaoRecuperouArquivosGit()
        {
            var driver = TestEnvironment.driver;
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.FindElement(By.Id("URLRepo")).SendKeys("https://github.com/jonasabreu/leis-site.git");
            driver.FindElement(By.Name("btnExecutar")).Click();
            driver.Url.Should().Be("http://localhost:8080/Home/Detalhes/0");

            driver.FindElement(By.Name("nome")).Text.Should().NotMatchRegex("\\.git\\[.]+");



        }
    }
}
