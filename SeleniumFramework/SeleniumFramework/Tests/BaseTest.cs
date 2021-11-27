
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
            string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;

            var drivere= ConfigurationManager.AppSettings["WebDriverPath"];
            driver = new ChromeDriver(drivere);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("ApplicationUrl"));
        }

        [TearDown]
        public void TestEnding()
        {
            driver.Quit();
        }
    }
}
