using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthorizationTask.Pages
{
    public class PasswordPage
    {
        IWebDriver _driver;

        const string passwordBox = ("//input[@name = 'password']");
        const string passwordSubmitButton = ("//button[@data-testid='login-to-mail']");
        IWebElement PasswordBox { get; set; }
        IWebElement PasswordSubmitButton { get; set; }
        public PasswordPage(IWebDriver driver)
        {
            _driver = driver;
            PasswordBox = _driver.FindElement(By.XPath(passwordBox));
            PasswordSubmitButton = _driver.FindElement(By.XPath(passwordSubmitButton));
        }

        public void Password(string password)
        {
            PasswordBox.SendKeys(password);
            PasswordSubmitButton.Click();
        }
    }
}
