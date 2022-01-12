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

            IWebElement utbElement = driver.FindElement(By.LinkText("Till utbildningarna")); // hittar l�nken "till utbildningarna"
            utbElement.Click(); // klickar p� l�nken "till utbildningarna"

            IWebElement cookiesElement = driver.FindElement(By.LinkText("Till�t alla cookies")); // hittar l�nken "till�t alla cookies"
            cookiesElement.Click(); // klickar p� l�nken "till�t alla cookies"

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // g�r s� att vi anv�nder oss av JavaScriptExecutor
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            IWebElement mvtElement = driver.FindElement(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']")); // hittar l�nken till utbildningen
            mvtElement.Click(); // klickar l�nken till utbildningen

            IWebElement ortElement = driver.FindElement(By.CssSelector("#dropdownMenuLink > span")); // hittar CSS-selectorn med "v�lj en studieort"
            ortElement.Click(); // klickar p� den
            IWebElement malmoElement = driver.FindElement(By.LinkText("Malm�")); // hittar "Malm�" i listan
            malmoElement.Click(); // klickar p� Malm�

            IWebElement omfElement = driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/div/div/div/div[2]/div/div/div/div[2]/p[4]/span[2]")); // hittar texten under omfattning
            Assert.AreEqual("1,5 �r", omfElement.Text); // fr�gar om det st�mmer att texten s�ger 1,5 �r

        }

        [TestMethod]
        public void TestMethod2()
        {

            IWebElement utbElement = driver.FindElement(By.LinkText("Till utbildningarna")); // hittar l�nken "till utbildningarna"
            utbElement.Click(); // klickar p� l�nken "till utbildningarna"

            IWebElement cookiesElement = driver.FindElement(By.LinkText("Till�t alla cookies")); // hittar l�nken "till�t alla cookies"
            cookiesElement.Click(); // klickar p� l�nken "till�t alla cookies"

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // g�r s� att vi anv�nder oss av JavaScriptExecutor
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som l�ter oss v�nta till elementet uppt�cks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar ned�t

            IWebElement mvtElement = driver.FindElement(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']")); // hittar l�nken till utbildningen
            mvtElement.Click(); // klickar l�nken till utbildningen

            IWebElement ortElement = driver.FindElement(By.CssSelector("#dropdownMenuLink > span")); // hittar CSS-selectorn med "v�lj en studieort"
            ortElement.Click(); // klickar p� den
            IWebElement malmoElement = driver.FindElement(By.LinkText("Malm�")); // hittar "Malm�" i listan
            malmoElement.Click(); // klickar p� Malm�

            IWebElement omfElement = driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/div/div/div/div[2]/div/div/div/div[2]/p[4]/span[2]")); // hittar texten under omfattning
            Assert.AreEqual("3,5 �r", omfElement.Text); // fr�gar om det st�mmer att texten s�ger 1,5 �r

        }
    }
}