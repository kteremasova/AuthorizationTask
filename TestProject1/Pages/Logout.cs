using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace AuthorizationTask.Pages
{
    class Logout
    {
        IWebDriver _driver;

        const string dropdownIcon = (".ph-project__user-name");
        const string logoutLink = ("//a[contains(@href, 'logout')]");
        IWebElement DropdownIcon { get; set; }
        //IWebElement LogoutButton { get; set; }
        IWebElement LogoutLink { get; set; }
        public Logout(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LogOut()
        {
            _driver.FindElement(By.CssSelector(dropdownIcon)).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(logoutLink)).Click();
        }
    }
}
