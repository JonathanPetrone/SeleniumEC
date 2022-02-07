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
        [TestMethod]
        public void TestMethod1()
        {
        ChromeDriver driver = new ChromeDriver(); // startar en ny driver
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        driver.Manage().Window.Maximize(); // maximerar Fönstret
        driver.Navigate().GoToUrl("http://ecutbildning.se"); // går till vår URL

            IWebElement utbElement = driver.FindElement(By.LinkText("Våra utbildningar")); // hittar länken "till utbildningarna"
            utbElement.Click(); // klickar på länken "till utbildningarna"

            IWebElement cookiesElement = driver.FindElement(By.LinkText("Tillåt alla cookies")); // hittar länken "tillåt alla cookies"
            cookiesElement.Click(); // klickar på länken "tillåt alla cookies"

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; // gör så att vi använder oss av JavaScriptExecutor
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som låter oss vänta till elementet upptäcks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']"))); // en wait som låter oss vänta till elementet upptäcks
            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            IWebElement mvtElement = driver.FindElement(By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']")); // hittar länken till utbildningen
            mvtElement.Click(); // klickar länken till utbildningen

            js.ExecuteScript("window.scrollTo(0, 2000)"); // scrollar nedåt

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='page']/div[3]/div[4]/div/div/div/div[2]/div[2]/div/div/div/p[5]/span[2]"))); // en wait som låter oss vänta till elementet upptäcks

            IWebElement omfElement = driver.FindElement(By.XPath("//*[@id='page']/div[3]/div[4]/div/div/div/div[2]/div[2]/div/div/div/p[5]/span[2]")); // hittar texten under omfattning
            Assert.AreEqual("1,5 år", omfElement.Text); // frågar om det stämmer att texten säger 1,5 år

            IWebElement LIA = driver.FindElement(By.LinkText("LIA (lärande-i-arbete)")); // hittar länken "tillåt alla cookies"
            LIA.Click(); // klickar på länken "tillåt alla cookies"

            driver.Close();
        
        driver.Quit();

        }
    }
}
