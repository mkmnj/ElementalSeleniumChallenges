using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Tests.PageObjects
{
    class BasicAuth
    {
        private IWebDriver driver;
        private IWebElement CongratulationsText => driver.FindElement(By.CssSelector("p"));

        public BasicAuth(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool TextShouldBeVisibleAfterBasicAuth()
        {
            return CongratulationsText.Displayed;
        }
    }
}
