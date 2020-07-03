using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Automation_Suite._01_Configuration_Tier.EnvironmentFiles;
using OpenQA.Selenium.IE;
using System.Globalization;

namespace Automation_Suite.Utility_Tier
{
    [SetUpFixture]
    public abstract class ReportsGeneration 
    {
        public ExtentReports _extent;
        public ExtentTest _test;
        public IWebDriver _driver;

        public string browser;
        

        [OneTimeSetUp]
        public void ExtentReportStart()
        {
            DateTime currentDate = new DateTime();

            // currentDate.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                             CultureInfo.InvariantCulture);
            string ReportTime = DateTime.Now.Millisecond.ToString();


            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Result_Tier");

            var reportPath = projectPath + @"Result_Tier\Reports\"+"Pobal"+ ReportTime + ".html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            _extent = new ExtentReports();
            
                htmlReporter = new ExtentHtmlReporter(reportPath);


                _extent.AttachReporter(htmlReporter);
                _extent.AddSystemInfo("Host Name", "LocalHost");
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("UserName", "TestUser");
            


           

        }


        [OneTimeTearDown]
        public void ReportClose()
        {
            _extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {   

            try
            {
                string browser = Env.strCurrentBrowser;  //Get browser name from the config
                switch (browser)
                {
                    case "Chrome":
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

                        
                    case "Firefox":
                        FirefoxDriverService FFservice = FirefoxDriverService.CreateDefaultService(@"C:\Pobal_AutomationProject\Pobal_Test_Project\Automation_Suite", "geckodriver.exe");

                        //Give the path of the Firefox Browser        
                        FFservice.FirefoxBinaryPath = @"C:\Users\asrivastava\AppData\Local\Mozilla Firefox\firefox.exe";

                        _driver = new FirefoxDriver(FFservice);
                        _driver.Navigate().GoToUrl("https://www.google.com");


                        _driver.Manage().Cookies.DeleteAllCookies();
                        _driver.Manage().Window.Maximize();
                        break;

                    default:

                        // KILL_ALL("Chrome");
                        //webDriver = new InternetExplorerDriver();
                        InternetExplorerOptions IEoptions = new InternetExplorerOptions();
                        IEoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        IEoptions.IgnoreZoomLevel = true;
                        _driver = new
                            InternetExplorerDriver(@"C:\Pobal_AutomationProject\Pobal_Test_Project\Automation_Suite\IEDriverServer_x64_3.150.1\", IEoptions);


                        _driver.Manage().Cookies.DeleteAllCookies();
                        _driver.Manage().Window.Maximize();

                        break;
                }
            }
            catch (Exception Ex)
            {
                  Console.WriteLine("Browser invoke Fail " + Ex.Message);
            }
        
        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);



        }


        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    string fileName = "Screenshot_" +time.ToString("h_mm_ss") + ".png";
                    string screenShotPath = Capture(GetDriver(), fileName);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " +_test.AddScreenCaptureFromPath("Screenshots\\" +fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default: //after test pass , here it is failing
                    logstatus = Status.Pass;
                    
                    time = DateTime.Now;
                    fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    //fileName = "Screenshot_1_49_50.png";
                    screenShotPath = Capture(GetDriver(), fileName);
                    _test.Log(Status.Pass, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath + "\\Result_Tier\\Screenshots\\" + fileName));
                    break;
            }
            _test.Log(logstatus, "Test ended with " +logstatus + stacktrace);
            _extent.Flush();
            _driver.Quit();
        }
        public IWebDriver GetDriver()
        {
            return _driver;
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;


            var DirLocation = Directory.CreateDirectory(reportPath + "\\Result_Tier\\" + "Screenshots");

            if(! DirLocation.Exists)
            { 
                DirLocation = Directory.CreateDirectory(reportPath + "\\Result_Tier\\" + "Screenshots");

            
                var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Result_Tier\\Screenshots\\" + screenShotName;
                var localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            }
             
            else
            {

                var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Result_Tier\\Screenshots\\" + screenShotName;
                var localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            }
            

            return reportPath;
        }
    }
}