using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_Suite.Application_Tier.PageObjectRepository
{
    class LoginPage
    {
        private IWebDriver driver;


        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement MyAccount { get; set; }
       

        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement SSP { get; set; }



        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement Onboarding { get; set; }



        [FindsBy(How = How.CssSelector, Using = "text")]
        public IWebElement Name { get; set; }
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://demoaut.katalon.com/");
        }

    }
}



    






    

