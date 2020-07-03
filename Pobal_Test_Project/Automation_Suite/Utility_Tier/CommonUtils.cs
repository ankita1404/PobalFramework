using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Suite.Utility_Tier
{
    class CommonUtils
    {
        public static string strExecSummaryHTMLFilePath;
        public static string strTestResHTMLFilePath;
        public static string strCurrentApplication;
        public static string strCurrentEnvironment;
        public static string strOnError;


        public static string strCurrentUserID;
        public static string strCurrentPassword;
        public static string strCurrentURL;
        public static string strCurrentBrowser;

        public static string strCurrentModule;
        public static string strCurrentScenarioID;
        public static string strCurrentScenarioDesc;

        public static string strCurrentTestID;
        public static string strCurrentTestIterationList;
        public static string strCurrentTestDesc;
        public static string strTCStatus;

        public static int intScreenshotCount = 0;
        public static int intCurrentIteration = 1;
        public static string strCurrentBusFlowKeyword = "";
        public static int intStepNumber = 1;
        public static int intPassStepCount = 0;
        public static int intFailStepCount = 0;
        public static int intPassTCCount = 0;
        public static int intFailTCCount = 0;

    }
}
