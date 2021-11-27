using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTask.PageObjects
{
    /// <summary>
    /// Page object for Amazon home page.
    /// </summary>
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        [CacheLookup]
        private IWebElement searchTxtBox;

        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        [CacheLookup]
        private IWebElement searchSubmitBtn;

        /// <summary>
        /// Enter the search keywords into the search text box
        /// In real case, I will also cover the select word from auto-complete list
        /// </summary>
        /// <param name="searchKeyWord"></param>
        public void EnterSearchKeyWord(string searchKeyWord)
        {
            EnterText(searchTxtBox, searchKeyWord);
        }

        /// <summary>
        /// Click on the search button
        /// 
        /// In real scenario, I will be testing the search by clicking on the search button 
        /// or by clicking "Enter" button on the keyboard 
        /// </summary>
        /// <returns></returns>
        public SearchResultPage ClickOnSearchBtn()
        {
            ClickOn(searchSubmitBtn);
            return new SearchResultPage(driver);
        }
    }

}

