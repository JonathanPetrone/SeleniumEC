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
            driver.Manage().Window.Maximize(); // maximerar Fönstret
            driver.Navigate().GoToUrl("http://ecutbildning.se"); // går till vår URL
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
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // gör så att vi använder oss av JavaScriptExecutor

            IWebElement tillutb = landingPage.utbElement();
            tillutb.Click();

            IWebElement cookiesElement = utbPage.cookiesButton(); // hittar länken "tillåt alla cookies"
            cookiesElement.Click(); // klickar på länken "tillåt alla cookies"
            
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som låter oss vänta till elementet upptäcks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som låter oss vänta till elementet upptäcks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            IWebElement mvtElement = utbPage.mvtCard();
            mvtElement.Click(); // klickar länken till utbildningen

            IWebElement ortElement = utbPage.ortButton();
            ortElement.Click(); // klickar på ort-knappen

            IWebElement malmoElement = utbPage.malmoLnk();
            malmoElement.Click(); // klickar på Malmö

            IWebElement omfElement = utbPage.omfUtb();
            Assert.AreEqual("1,5 år", omfElement.Text); // frågar om det stämmer att texten säger 1,5 år

        }

        [TestMethod]
        public void TestMethod2()
        {

            var landingPage = new LandingPage(driver);
            var utbPage = new UtbPage(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // gör så att vi använder oss av JavaScriptExecutor

            IWebElement tillutb = landingPage.utbElement();
            tillutb.Click();

            IWebElement cookiesElement = utbPage.cookiesButton(); // hittar länken "tillåt alla cookies"
            cookiesElement.Click(); // klickar på länken "tillåt alla cookies"

            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som låter oss vänta till elementet upptäcks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som låter oss vänta till elementet upptäcks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            IWebElement mvtElement = utbPage.mvtCard();
            mvtElement.Click(); // klickar länken till utbildningen

            IWebElement ortElement = utbPage.ortButton();
            ortElement.Click(); // klickar på ort-knappen

            IWebElement malmoElement = utbPage.malmoLnk();
            malmoElement.Click(); // klickar på Malmö

            IWebElement omfElement = utbPage.omfUtb();
            Assert.AreEqual("3,5 år", omfElement.Text); // frågar om det stämmer att texten säger 3,5 år
        }
    }
}