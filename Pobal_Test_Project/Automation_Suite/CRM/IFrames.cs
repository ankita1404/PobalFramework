using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Suite.CRM
{
    class IFrames
    {

        private IWebDriver driver;
       
        public void frameId(string FrameId) {
            driver.SwitchTo().Frame(FrameId);

        }

        public void frameName(string FrameName) {
            driver.SwitchTo().Frame(FrameName);

        }
        /* weblocator can be XPath, CssSelector, Id, Name, etc. */

        public void FrameInspectByWeblocatorId(string id)
        {
            

            
            driver.SwitchTo().Frame(driver.FindElement(By.Id("web-locator-property")));

        }

        public void FrameInspectByWeblocatorName(string Name)
        {
           


            driver.SwitchTo().Frame(driver.FindElement(By.Name("web-locator-property")));

        }

        public void FrameInspectByWeblocatorCssSelect(string CssSelector)
        {
            


            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("web-locator-property")));

        }

        public void FrameInspectByWeblocatorXpath(string Xpath)
        {



            driver.SwitchTo().Frame(driver.FindElement(By.XPath("web-locator-property")));

        }
    }
}
