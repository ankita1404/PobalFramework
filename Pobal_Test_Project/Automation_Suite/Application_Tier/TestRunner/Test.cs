using Automation_Suite.Application_Tier.PageObjectRepository;
using Automation_Suite.Utility_Tier;
using NUnit.Framework;

namespace Automation_Suite.Application_Tier.TestRunner
{
    [TestFixture]

    [Category("RegressionTest")]
    public class Test : ReportsGeneration

    {


    [Test]
    public void URLTest()
        {
           /* Console.WriteLine("Create Customer");
            ReporterUtil Rep = new ReporterUtil();
            ReporterUtil.startTest("Create_Cutomer", "Creating new customer scenario");
            ReporterUtil.AssignCategory("Create_Cutomer", "Customer");
            ReporterUtil.strCurrentTestID = "TS001";
            //*******************************************************************************************************
            string dataFileToRefer = null; string dataSheetToRefer = null; string RunFlag = null;
            Helper.getTestDataDetails("'TS001'", out dataFileToRefer, out dataSheetToRefer, out RunFlag);
            DataTable oDTable = ExcelUtil.ExcelToTable(Env.strRelativePath + Env.strApplicationFd + dataFileToRefer + ".xlsx", dataSheetToRefer);
            DataRow[] oDataRows = oDTable.Select("Iteration_Run = 'Y'"); */


            LoginPage loginpage = new LoginPage(GetDriver());
            loginpage.goToPage();
            //ReportsGeneration.Capture(GetDriver(), "screenshotq1");
           _test = _extent.CreateTest("Pass", "login");

           _test.Log(AventStack.ExtentReports.Status.Pass, "login test pass");


           //ReporterUtil.ReportEvent("Pass", _driver.Url , "");
            //ReporterUtil.AssignCategory("", "");

        }
    
    }
}
