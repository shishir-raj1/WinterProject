using NUnit.Framework;
using OpenQA.Selenium;
using WinterProject.Pages.SwagLabs.LoginPage;


namespace WinterProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefination
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage loginPage;

        public LoginStepDefination(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext["WebDriver"] as IWebDriver;  // Retrieve WebDriver from Hooks
            loginPage = new LoginPage(driver);

        }

        [Given("User provide the Web Url")]
        public void GivenUserProvideTheWebUrl()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        [When("User enter the credentials username and password")]
        public void WhenUserEnterTheCredentialsUsernameAndPassword()
        {
            loginPage.enterUsername("standard_user");
            loginPage.enterPassword("secret_sauce");
           // driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
           // driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        }

        [Then("user verify login")]
        public void ThenUserVerifyLogin()
        {
            loginPage.clickLoginButton();
           // driver.FindElement(By.Id("login-button")).Click();

            Assert.AreEqual("Swag Labs", driver.Title);  // Fix assertion issue
        }
    }
}
