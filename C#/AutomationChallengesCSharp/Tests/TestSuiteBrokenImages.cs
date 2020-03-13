using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.PageObjects;
using Tests.HelpMethods;

namespace Tests
{
    [TestClass]
    public class TestSuiteBrokenImages : ITestTemplate
    {
        private IWebDriver driver;
        public string mainURL = "https://the-internet.herokuapp.com";
        private BrokenImages page;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Url = mainURL + "/broken_images";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void CheckBrokenImages()
        {
            page = new BrokenImages(driver);
            bool allImagesLoaded = page.AllImagesShouldHaveBeenLoaded().Item1;

            Assert.IsTrue(allImagesLoaded);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
