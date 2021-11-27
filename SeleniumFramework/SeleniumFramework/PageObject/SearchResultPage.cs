using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SeleniumTask.PageObjects
{
    class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// The following selector will return the first item match the passed locater
        /// Please note the advanced and the right approach is to implement general item selection by Index
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "[data-component-type='s-search-result'] [data-component-type='s-product-image'] a")]
        private IWebElement firstItemDetailsBtn;


        public ProductDetailsPage ClickOnShowProductDetailsbtn()
        {
            // Wait for the page to complete load
            ClickOn(firstItemDetailsBtn);

            return new ProductDetailsPage(driver);
        }
    }
}
