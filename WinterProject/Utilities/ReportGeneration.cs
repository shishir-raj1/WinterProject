using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;


namespace WinterProject.Utilities
{
    public class ReportGeneration
    {
        public static ExtentReports extent;
        private static ExtentTest scenario;
        private static ExtentTest featureName;
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInitialize() {

            var htmlReporter = new ExtentSparkReporter(@"C:\Users\DELL\source\repos\WinterProject\WinterProject\ExtentReport.html");
            htmlReporter.Config.Theme = Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            var test = extent.CreateTest("Login Test").Info("Test Started");
            test.Pass("Login successful");
            
        }

        public static void ExtentReportCleanup()
        {
            extent.Flush();
        }

        public static String addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }

            public static string Capture(IWebDriver driver, string scenarioName)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filePath = $"TestResults/Screenshots/{scenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                screenshot.SaveAsFile(filePath);
                return filePath;
            }
        


    }
}
