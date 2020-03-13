using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Tests.HelpMethods;

namespace Tests.PageObjects
{
    class BrokenImages
    {
        HTTPMethods httpHelpMethods = new HTTPMethods();
        IWebDriver driver;
        List<IWebElement> Images => new List<IWebElement>(driver.FindElements(By.CssSelector(".example > img")));

        public BrokenImages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public (bool, List<string>) AllImagesShouldHaveBeenLoaded()
        {
            bool haveBeenLoaded = true;
            List<string> brokenImages = new List<string>();

            foreach (IWebElement image in Images)
            {
                if ((int)httpHelpMethods.GetStatusCode(image.GetAttribute("src")) == 404)
                {
                    haveBeenLoaded = false;
                    brokenImages.Add(image.GetAttribute("src"));
                    Logging.logger.Info("Broken Image: " + image.GetAttribute("src"));
                }
            }

            return (haveBeenLoaded, brokenImages);
        }
    }
}
