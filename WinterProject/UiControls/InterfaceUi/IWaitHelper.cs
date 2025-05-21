using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WinterProject.UiControls.InterfaceUi
{
    public interface IWaitHelper
    {
        IWebElement WaitUntilVisible(By locator, int timeoutInSeconds = 10);
        IWebElement WaitUntilClickable(By locator, int timeoutInSeconds = 10);
    }

}
