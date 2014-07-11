using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace Bandeira.Integration.Test
{
    [TestClass]
    public static class TestEnvironment
    {
        public static RemoteWebDriver driver;
        private static IISExpressDriver iisDriver;

        [AssemblyInitialize]
        public static void PreparingEnvironment(TestContext t)
        {
            try
            {
                WebBindingBase.IsTFSBuild = IsTfsBuild();
                if (IsTfsBuild()) { driver = WebBindingBase.PhantomJSDriver; }
                else { driver = WebBindingBase.FirefoxDriver; }
                InicializeServer();
            }
            catch(Exception e)
            {
                ClosingEnvironment();
                throw;
            }
        }

        [AssemblyCleanup]
        public static void ClosingEnvironment()
        {
            WebBindingBase.CloseAll();
            iisDriver.Dispose();
        }

        private static void InicializeServer()
        {
            iisDriver = new IISExpressDriver();
            var appHost = CreateApphost();
            iisDriver.Start(appHost);
            driver.Navigate().GoToUrl("http://localhost:8080/");
        }
        private static string CreateApphost()
        {
            var projectPath = "Bandeira";
            var path = IsTfsBuild() ? @"_PublishedWebSites\" : "..\\..\\..\\";
            var binaryPath = Path.GetDirectoryName(Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath));
            var sitePath = Path.GetFullPath(Path.Combine(binaryPath, path + projectPath));
            var applicationhost = File.ReadAllText(Path.Combine(binaryPath, "applicationhost.config"));
            var processedAppconfig = applicationhost.Replace("{path to website}", sitePath);
            var apphostPath = Path.Combine(binaryPath, "applicationhost.config");
            File.WriteAllText(apphostPath, processedAppconfig);
            return apphostPath;
        }

        private static bool IsTfsBuild()
        {
            return Directory.Exists("_PublishedWebSites");
        }
    }
    public static class Functions
    {
        public static void TriesHideException(Action action)
        {
            try { action(); }
            catch { }
        }
    }
}

