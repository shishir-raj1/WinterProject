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
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportCleanup();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
