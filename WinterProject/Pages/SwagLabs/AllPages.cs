using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WinterProject.Pages.SwagLabs.LoginPage;

namespace WinterProject.Pages.SwagLabs
{
    public class AllPages
    {
       
        private readonly IWebDriver driver;
        //private readonly LoginPage loginPage;

        public AllPages(ScenarioContext scenarioContext)
        {
            driver = scenarioContext["WebDriver"] as IWebDriver;
            //loginPage = new LoginPage(driver);
        }

       

        


    }
}
