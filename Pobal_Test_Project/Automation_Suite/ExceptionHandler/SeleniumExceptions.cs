using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Suite.ExceptionHandler
{
    class SeleniumExceptions
    {
        private IWebDriver driver;
        SeleniumExceptions(IWebDriver driver)
        {
            

        }
        public IWebElement FindElement(By selector)
        {
            // Return null by default
            IWebElement elementToReturn = null;

            try
            {
                // Use the selenium driver to find the element
                elementToReturn = driver.FindElement(selector);
            }
            catch (NoSuchElementException)
            {
                // Do something if the exception occurs, I am just logging
                //Logs(No such element: {selector.ToString()} could be found.");
            }
            catch (Exception e)
            {
                // Throw any error we didn't account for
                throw e;
            }

            // return either the element or null
            return elementToReturn;
        }
    }
}
