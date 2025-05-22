using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WinterProject.UiControls
{
    public class CustomUiControls
    {
        public static void Click(IWebElement element)
        {
            element.Click();
        }

        public static void Submit(IWebElement element)
        {
            element.Submit();
        }

        public static void EnterText(IWebElement element, string Text)
        {
            element.Clear();
            element.SendKeys(Text);
        }

        public static void SelectDropdownByText(IWebElement element, string Text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(Text);
        }

        public static void SelectDropdownByText(IWebElement element, string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }



    }
}
