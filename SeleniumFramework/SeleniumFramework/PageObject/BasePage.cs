using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTask.PageObjects
{
    class BasePage
    {
        /// <summary>
        /// Shared webDriver instance for all test pages
        /// </summary>        
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// The following method implement the wait for load page event to be completed  
        /// </summary>
        /// <param name="timeout"></param>
        public void PageLoadComplete(int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page load event to be complete 
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Shared method to enter text in element by locater 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void EnterText(IWebElement element, String text)
        {
            element.SendKeys(text);
        }

        /// <summary>
        /// Shared method to click on an element by locater 
        /// </summary>
        /// <param name="element"></param>
        public void ClickOn(IWebElement element)
        {
            element.Click();
        }
    }
}
