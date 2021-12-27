using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AuthorizationTask.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AuthorizationTask
{
    [TestFixture]
    public class FirstTask
    {
        IWebDriver driver = new ChromeDriver();


        public void Setup()
        {
            driver = new ChromeDriver();
        }

       [Test]
      
       public void Test1()
        {

            driver.Navigate().GoToUrl("https://mail.ru/");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("kristkalight");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebElement element = (WebElement)wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@data-testid='password-input']")));

            PasswordPage passwordPage = new PasswordPage(driver);
            passwordPage.Password("kR23ViTter28");

            WebDriverWait waitAssert = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebElement elementAssert = (WebElement)wait.Until(ExpectedConditions.ElementIsVisible(By.Id("sideBarContent")));

            NUnit.Framework.Assert.IsTrue(driver.FindElement(By.Id("sideBarContent")).Displayed);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}