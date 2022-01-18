using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AuthorizationTask.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace AuthorizationTask
{
    [TestFixture]
    public class FirstTask
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.ru/");
        }

       [Test]
       [TestCase("kristkalight", "kR23ViTter28")]
       [TestCase("testdata01", "26sov30@Ket")]
      
       public void Test1(string login, string password)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); //implicit Waiter
            driver.Manage().Window.Maximize();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(login);


            /*
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebElement element = (WebElement)wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@data-testid='password-input']")));
            */
            PasswordPage passwordPage = new PasswordPage(driver);
            passwordPage.Password(password);
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //WebElement name = (WebElement)wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='kristkalight@mail.ru']")));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDispalyed = driver.FindElement(By.XPath("//span[text()='kristkalight@mail.ru']"));
                    return elementToBeDispalyed.Displayed;
                }
                catch (ResultStateException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            );
            
            Thread.Sleep(1000); //Sleep() method does not release the lock on object during Synchronization.
            NUnit.Framework.Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='kristkalight@mail.ru']")).Displayed);

            driver.Close();

        }
        [TestCleanup]
        public void Cleanup()

        {
            driver.Close();
        }
    }
}