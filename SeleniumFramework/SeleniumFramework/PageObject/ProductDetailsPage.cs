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
        private static By priceTextLocator = By.ClassName("a-offscreen");
        private IWebElement productPriceTxt;

        /// <summary>
        /// Return the selected item Price label value in the search list result
        /// </summary>
        /// <returns></returns>
        public decimal GetProductPrice()
        {
            NumberStyles style;
            decimal priceInDecimal;
            CultureInfo culture;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            string priceText = productPriceTxt.GetAttribute("innerHTML");

            Decimal.TryParse(priceText, style, culture, out priceInDecimal);
            return priceInDecimal;
        }

    }
}
