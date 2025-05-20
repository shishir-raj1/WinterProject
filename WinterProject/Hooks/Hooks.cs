using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WinterProject.Utilities;


namespace WinterProject.Hooks
{
    [Binding]
    public class Hooks : ReportGeneration
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInitialize();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if(!_scenarioContext.ScenarioInfo.Tags.Contains("Api"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
                _scenarioContext["WebDriver"] = driver;
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
    }
}
