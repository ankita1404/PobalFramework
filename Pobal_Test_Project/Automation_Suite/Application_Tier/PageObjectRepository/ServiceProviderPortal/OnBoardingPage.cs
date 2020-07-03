using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_Suite.Application_Tier.PageObjectRepository
{
    class OnBoardingPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.PartialLinkText, Using = "Start On-Boarding Process")]
        public IWebElement OnBoardingLink { get; set; }


        [FindsBy(How = How.Id, Using = "NextButton")]
        public IWebElement NextButton { get; set; }



        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement Onboarding { get; set; }



        [FindsBy(How = How.CssSelector, Using = "text")]
        public IWebElement Name { get; set; }



    }
}
