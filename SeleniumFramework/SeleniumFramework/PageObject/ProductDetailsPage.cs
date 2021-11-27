using OpenQA.Selenium;
using System;
using System.Globalization;

namespace SeleniumTask.PageObjects
{
    class ProductDetailsPage : BasePage
    {

        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
            productPriceTxt = driver.FindElement(priceTextLocator);
        }

        /// <summary>
        ///  find element by partial id because for price label locater
        ///  have two different values for the second substring of id if the item in sale
        /// </summary>
        private static By priceTextLocator = By.CssSelector("span[id^='priceblock_']");
        private IWebElement productPriceTxt;

        /// <summary>
        /// Return the selected item Price label value in the search list result
        /// </summary>
        /// <returns></returns>
        public decimal GetProductPrice()
        {
            string priceText = productPriceTxt.GetAttribute("innerHTML");
            decimal priceInDecimal = 0;
            Decimal.TryParse(priceText,
               NumberStyles.Currency,
               CultureInfo.CurrentCulture,
               out priceInDecimal);
            return priceInDecimal;
        }

    }
}
