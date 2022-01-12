using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    public class LandingPage

    {
        private ChromeDriver driver;
        private WebDriverWait wait;

        public LandingPage(ChromeDriver driver)

        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement utbElement()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable
            (By.LinkText("Till utbildningarna")));
        }

    }
}

