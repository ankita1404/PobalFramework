using Automation_Suite.Utility_Tier;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Automation_Suite.TestUtils
{
    public class TestBase :ReportsGeneration
    {
        readonly string baseURL;
        readonly string browser;
        IWebDriver webDriver;
       
       


        public IWebDriver Init()
        {
            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver(@"C:\Pobal_AutomationProject\Pobal_Test_Project\Automation_Suite\chromedriver_win32");
                    _driver.Url = "https://www.google.com/";
                    _driver.Manage().Cookies.DeleteAllCookies();

                    break;
                case "Firefox":
                    FirefoxDriverService FFservice = FirefoxDriverService.CreateDefaultService(@"C:\Pobal_AutomationProject\Pobal_Test_Project\Automation_Suite", "geckodriver.exe");

                    //Give the path of the Firefox Browser        
                    FFservice.FirefoxBinaryPath = @"C:\Mozilla\Firefox.exe";

                    _driver = new FirefoxDriver(FFservice);
                    _driver.Navigate().GoToUrl("https://www.google.com");
                    break;
                default:

                    // KILL_ALL("Chrome");
                    //webDriver = new InternetExplorerDriver();

                    // Chrome Driver copied on startup path
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService("webdriver.chrome.driver", @"C:\Pobal_AutomationProject\Pobal_Test_Project\Automation_Suite\chromedriver_win32\chromedriver.exe");

                    //hide driver service command prompt window

                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;

                    ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("disable-infobars");
                    options.AddArgument("--start-maximized");
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    //options.AddExcludedArgument("disable-infobars");
                    //options.AddAdditionalCapability("excludeSwitches", "disable-default-apps");
                    _driver = new ChromeDriver(service, options);

                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();

                    break;
            }
            
            //Goto(baseURL);
            return _driver;
        }
        
        public string Title
        {
            get { return _driver.Title; }
        }
       
        public void Goto(string url)
        {
            _driver.Url = url;
        }


        public static void KILL_ALL(string strProcess)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName(strProcess))
                {
                    proc.Kill();
                    Console.WriteLine("Killed " + strProcess);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex +"process.exe is running in the backend which leads to fail browser initialisation");
            }
        }
            public void Close()
        {
            _driver.Quit();
        }
    }
}
        

    

