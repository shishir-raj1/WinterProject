using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WinterProject.StepDefinitions
{
    [Binding]
    public class PlaceOrderFlowStepDefinations
    {

        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public PlaceOrderFlowStepDefinations(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext["WebDriver"] as IWebDriver;  // Retrieve WebDriver from Hooks
        }


        [Given("user visits the e-commerce site, enters {string} and {string}, and clicks on the login button")]
        public void GivenUserVisitsTheE_CommerceSiteEntersAndAndClicksOnTheLoginButton(string p0, string p1)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            driver.FindElement(By.Id("user-name")).SendKeys(p0);
            driver.FindElement(By.Id("password")).SendKeys(p1);
            driver.FindElement(By.Id("login-button")).Click();

            Assert.AreEqual("Swag Labs", driver.Title);
        }

        [When("user selects the {string} and clicks on the add to cart button")]
        public void WhenUserSelectsTheAndClicksOnTheAddToCartButton(string p0)
        {
            throw new PendingStepException();
        }

        [When("user goes to the cart page and clicks on the checkout button")]
        public void WhenUserGoesToTheCartPageAndClicksOnTheCheckoutButton()
        {
            throw new PendingStepException();
        }

        [When("user fills in the personal details on the checkout page and clicks on the continue button")]
        public void WhenUserFillsInThePersonalDetailsOnTheCheckoutPageAndClicksOnTheContinueButton(DataTable dataTable)
        {
            throw new PendingStepException();
        }

        [When("user visits the checkout summary page and clicks on the Finish button")]
        public void WhenUserVisitsTheCheckoutSummaryPageAndClicksOnTheFinishButton()
        {
            throw new PendingStepException();
        }

        [Then("user validates the success message {string}")]
        public void ThenUserValidatesTheSuccessMessage(string p0)
        {
            throw new PendingStepException();
        }

    }
}
