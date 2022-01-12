using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTestProject
{
    [TestClass]
    public class SeleniumTest1
    {

        static ChromeDriver driver;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver(); // startar en ny driver
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestInitialize]
        public void Initialize()
        {
            // Code to run before each test goes here
            driver.Manage().Window.Maximize(); // maximerar F�nstret
            driver.Navigate().GoToUrl("http://ecutbildning.se"); // g�r till v�r URL
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Manage().Cookies.DeleteAllCookies(); // efter varje test

        }

        [AssemblyCleanup]
        public static void TearDown()

        {
            driver.Quit(); // efter alla tester
        }


        [TestMethod]
        public void TestMethod1()
        {
            var landingPage = new LandingPage(driver);
            var utbPage = new UtbPage(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // g�r s� att vi anv�nder oss av JavaScriptExecutor

            IWebElement tillutb = landingPage.utbElement();
            tillutb.Click();

            IWebElement cookiesElement = utbPage.cookiesButton(); // hittar l�nken "till�t alla cookies"
            cookiesElement.Click(); // klickar p� l�nken "till�t alla cookies"
            
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            IWebElement mvtElement = utbPage.mvtCard();
            mvtElement.Click(); // klickar l�nken till utbildningen

            IWebElement ortElement = utbPage.ortButton();
            ortElement.Click(); // klickar p� ort-knappen

            IWebElement malmoElement = utbPage.malmoLnk();
            malmoElement.Click(); // klickar p� Malm�

            IWebElement omfElement = utbPage.omfUtb();
            Assert.AreEqual("1,5 �r", omfElement.Text); // fr�gar om det st�mmer att texten s�ger 1,5 �r

        }

        [TestMethod]
        public void TestMethod2()
        {

            var landingPage = new LandingPage(driver);
            var utbPage = new UtbPage(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // g�r s� att vi anv�nder oss av JavaScriptExecutor

            IWebElement tillutb = landingPage.utbElement();
            tillutb.Click();

            IWebElement cookiesElement = utbPage.cookiesButton(); // hittar l�nken "till�t alla cookies"
            cookiesElement.Click(); // klickar p� l�nken "till�t alla cookies"

            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            IWebElement mvtElement = utbPage.mvtCard();
            mvtElement.Click(); // klickar l�nken till utbildningen

            IWebElement ortElement = utbPage.ortButton();
            ortElement.Click(); // klickar p� ort-knappen

            IWebElement malmoElement = utbPage.malmoLnk();
            malmoElement.Click(); // klickar p� Malm�

            IWebElement omfElement = utbPage.omfUtb();
            Assert.AreEqual("3,5 �r", omfElement.Text); // fr�gar om det st�mmer att texten s�ger 3,5 �r
        }
    }
}