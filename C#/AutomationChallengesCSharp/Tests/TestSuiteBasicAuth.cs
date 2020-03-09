using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Tests.PageObjects;

namespace Tests
{
    [TestClass]
    public class TestSuiteBasicAuth : ITestTemplate
    {
        public IWebDriver driver;
        public static string user = "admin";
        public static string password = "admin";
        public string credentials = user + ":" + password;

        public string mainURL = "the-internet.herokuapp.com";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Url = "https://" + credentials + "@" + mainURL + "/basic_auth";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void AddNoElements()
        {
            BasicAuth page = new BasicAuth(driver);

            Assert.IsTrue(page.TextShouldBeVisibleAfterBasicAuth());
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
