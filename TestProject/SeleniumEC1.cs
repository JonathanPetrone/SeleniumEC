using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;



namespace SeleniumTestProject
{
    [TestClass]
    public class SeleniumTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        ChromeDriver driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://ecutbildning.se");

        driver.Close();
		driver.Quit();

        }
    }
}