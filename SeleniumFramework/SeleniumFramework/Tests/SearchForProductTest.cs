using NUnit.Framework;
using SeleniumTask.PageObjects;

namespace SeleniumTask.Tests

{
    [TestFixture]
    class SearchForProductTest : BaseTest
    {
        /// <summary>
        /// Parametrized test to verify the search functionality for any item in amazon by the passed keyword ${searchStringKeyWords}
        /// Then verify the first Item price in the search result list is more than defined amount price ${price}
        /// Please note I used  the best practice test naming convention "UnitOfWork_StateUnderTest_ExpectedBehavior"
        /// </summary>
        /// <param name="searchStringKeyWords"></param>
        /// <param name="price"></param>
        [TestCase("laptop", 100), Description("Verify first Laptop price in the search result is greater than 100$")]
        public void SearchForProduct_WhenCustomerClickFirstProductInTheResultList_ThenProductPriceShouldBeGreaterThanDefinedValue(string searchStringKeyWords, decimal price)
        {
            HomePage homePage = new HomePage(driver);
            homePage.EnterSearchKeyWord(searchStringKeyWords);
            SearchResultPage searchResultPage = homePage.ClickOnSearchBtn();
            ProductDetailsPage itemDetailsPage = searchResultPage.ClickOnShowProductDetailsbtn();

            //Page load timeout worth to be added in a configuration file
            itemDetailsPage.PageLoadComplete(10000);
            Assert.Greater(itemDetailsPage.GetProductPrice(), price);
        }
    }
}
