
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace SeleniumTask.Tests
{
    class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            var driverPath= ConfigurationManager.AppSettings["WebDriverPath"];
            driver = new ChromeDriver(driverPath);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("ApplicationUrl"));
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TestEnding()
        {
            driver.Quit();
        }
    }
}
