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
    public class LoginPage
    {
        IWebDriver _driver;

        const string loginBox = ("//input[@name = 'login']");
        const string loginSubmitButton = ("//button[@data-testid='enter-password']");

        IWebElement LoginBox { get; set; }
        IWebElement LoginSubmitButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            LoginBox = _driver.FindElement(By.XPath(loginBox));
            LoginSubmitButton = _driver.FindElement(By.XPath(loginSubmitButton));
        }

        public void Login(string login)
        {
            LoginBox.SendKeys(login);
            LoginSubmitButton.Click();
        }
    }
}
