using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

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
            driver.FindElement(By.XPath("//div[contains(text(),'Sauce Labs Bike Light')]")).Click();
            driver.FindElement(By.Id("add-to-cart")).Click();
            driver.FindElement(By.Id("shopping_cart_container")).Click();
        }

        [When("user goes to the cart page and clicks on the checkout button")]
        public void WhenUserGoesToTheCartPageAndClicksOnTheCheckoutButton()
        {
            driver.FindElement(By.Id("checkout")).Click();
        }

        [When("user fills in the personal details on the checkout page and clicks on the continue button")]
        public void WhenUserFillsInThePersonalDetailsOnTheCheckoutPageAndClicksOnTheContinueButton(DataTable dataTable)
        {
            var details = new Dictionary<string, string>();
            foreach (var row in dataTable.Rows)
            {
                details.Add(row["key"], row["value"]);
            }

            driver.FindElement(By.Id("first-name")).SendKeys(details["First Name"]);
            driver.FindElement(By.Id("last-name")).SendKeys(details["Last Name"]);
            driver.FindElement(By.Id("postal-code")).SendKeys(details["Postal Code"]);

            driver.FindElement(By.Id("continue")).Click();
        }

        [When("user visits the checkout summary page and clicks on the Finish button")]
        public void WhenUserVisitsTheCheckoutSummaryPageAndClicksOnTheFinishButton()
        {
            driver.FindElement(By.Id("finish")).Click();
        }

        [Then("user validates the success message {string}")]
        public void ThenUserValidatesTheSuccessMessage(string p0)
        {
            var actualMessage = driver.FindElement(By.ClassName("complete-header")).Text;
            Assert.AreEqual(p0, actualMessage, "Success message did not match.");
        }

    }
}
