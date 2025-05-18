using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace WinterProject.Pages.SwagLabs.LoginPage
{
    public class LoginPage
    {
        private IWebDriver driver;
        private readonly string _userNameId = "user-name";
        private readonly string _passwordId = "password";
        private readonly string _loginId = "login-button";


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void enterUsername(string username)
        {
            IWebElement userName = driver.FindElement(By.Id(_userNameId));
            userName.SendKeys(username);
        }

        public void enterPassword(string password)
        {
            IWebElement passWord = driver.FindElement(By.Id(_passwordId));
            passWord.SendKeys(password);
        }

        public void clickLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.Id(_loginId));
            loginButton.Click();
        }
    }
}
