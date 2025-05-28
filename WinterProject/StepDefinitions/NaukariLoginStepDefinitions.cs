using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using WinterProject.Pages.SwagLabs.LoginPage;

namespace WinterProject.StepDefinitions
{
    [Binding]
    public class NaukariLoginStepDefinitions
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        

        public NaukariLoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext["WebDriver"] as IWebDriver;  // Retrieve WebDriver from Hooks
            

        }
        [Given("User enter {string} and open the login Page")]
        public void GivenUserEnterAndOpenTheLoginPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [When("User click on Login Button")]
        public void WhenUserClickOnLoginButton()
        {
            driver.FindElement(By.Id("login_Layer")).Click();
        }

        [When("User enter the credential {string} and {string} and click on Login Button")]
        public void WhenUserEnterTheCredentialAndAndClickOnLoginButton(string Username, string password)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder=\"Enter your active Email ID / Username\"]")).SendKeys(Username);
            driver.FindElement(By.XPath("//input[@placeholder=\"Enter your password\"]")).SendKeys(password);
            driver.FindElement(By.XPath("//button[starts-with(text(),'Login')]")).Click();
        }

        [Then("User Login Successfully and verify the {string} of the page")]
        public void ThenUserLoginSuccessfullyAndVerifyTheOfThePage(string naukari)
        {
            string actualTitle = driver.Title;
            Console.WriteLine(actualTitle);
            Assert.AreEqual(naukari, actualTitle);
        }
    }
}
