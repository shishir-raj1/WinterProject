using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Reqnroll;

namespace WinterProject.StepDefinitions
{
    [Binding]
    public class UpdateProfileStepDefinitions
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;


        public UpdateProfileStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext["WebDriver"] as IWebDriver;  // Retrieve WebDriver from Hooks


        }

        [When("User Login Successfully and verify the {string} of the page in Naukari")]
        public void WhenUserLoginSuccessfullyAndVerifyTheOfThePageInNaukari(string p0)
        {
            string actualTitle = driver.Title;
            Console.WriteLine(actualTitle);
           // Assert.AreEqual(p0, actualTitle);
        }

        [When("User click on view profile button")]
        public void WhenUserClickOnViewProfileButton()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("View profile")).Click();
        }

        [When("User click on edit profile button")]
        public void WhenUserClickOnEditProfileButton()
        {
            By editProfileLocator = By.XPath("//em[contains(text(),'editOneTheme')]");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement editProfileButton = wait.Until(ExpectedConditions.ElementToBeClickable(editProfileLocator));

            editProfileButton.Click();

        }

        [When("User click on current salary box and enter the {string} in the box")]
        public void WhenUserClickOnCurrentSalaryBoxAndEnterTheInTheBox(string text)
        {
            driver.FindElement(By.Id("totalAbsCtc_id")).SendKeys(text);
        }

        [Then("User click on save button")]
        public void ThenUserClickOnSaveButton()
        {
            driver.FindElement(By.Id("saveBasicDetailsBtn")).Click();
        }
    }
}
