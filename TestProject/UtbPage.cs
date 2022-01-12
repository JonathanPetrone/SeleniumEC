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
    public class UtbPage

    {
        private ChromeDriver driver;
        private WebDriverWait wait;

        public UtbPage(ChromeDriver driver)

        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement cookiesButton()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable
            (By.LinkText("Tillåt alla cookies")));
        }

        public IWebElement mvtCard()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable
            (By.XPath("//*[@href='https://ecutbildning.se/utbildningar/mjukvarutestare/' and @class='card-link']")));
        }

        public IWebElement ortButton()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable
            (By.CssSelector("#dropdownMenuLink > span")));
        }

        public IWebElement malmoLnk()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable
            (By.LinkText("Malmö")));
        }

        public IWebElement omfUtb()
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable
            (By.XPath("/html/body/div[4]/div[3]/div[2]/div/div/div/div[2]/div/div/div/div[2]/p[4]/span[2]")));
        }
    }
}

