using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WinterProject.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Reqnroll.BoDi;


namespace WinterProject.Hooks
{
    [Binding]
    public class Hooks : ReportGeneration
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private static ExtentTest scenario;
        private static ExtentTest featureName;
        private readonly IObjectContainer _objectContainer;

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInitialize();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if(!_scenarioContext.ScenarioInfo.Tags.Contains("Api"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
                _scenarioContext["WebDriver"] = driver;
                scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
            else
            {
                Console.WriteLine("API Test - Skipping browser initiation");
            }

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportCleanup();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (!_scenarioContext.ScenarioInfo.Tags.Contains("Api"))
            {
                driver.Quit();
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine($"{featureName}");
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {


            //Console.WriteLine("Running after step....");
            //string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            //string stepName = scenarioContext.StepContext.StepInfo.Text;

            //var driver = _objectContainer.Resolve<IWebDriver>();

            ////When scenario passed
            //if (scenarioContext.TestError == null)
            //{
            //    if (stepType == "Given")
            //    {
            //        scenario.CreateNode<Given>(stepName);
            //    }
            //    else if (stepType == "When")
            //    {
            //        scenario.CreateNode<When>(stepName);
            //    }
            //    else if (stepType == "Then")
            //    {
            //        scenario.CreateNode<Then>(stepName);
            //    }
            //    else if (stepType == "And")
            //    {
            //        scenario.CreateNode<And>(stepName);
            //    }
            //}

            ////When scenario fails
            //if (scenarioContext.TestError != null)
            //{

            //    if (stepType == "Given")
            //    {
            //        scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
            //            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
            //    }
            //    else if (stepType == "When")
            //    {
            //        scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
            //            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
            //    }
            //    else if (stepType == "Then")
            //    {
            //        scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
            //            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
            //    }
            //    else if (stepType == "And")
            //    {
            //        scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
            //            MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
            //    }
            //}
        }

    }
    
}
