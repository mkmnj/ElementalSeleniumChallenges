using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Tests.PageObjects;

namespace Tests
{
    [TestClass]
    public class TestSuiteAddRemoveElements : ITestTemplate
    {
        public IWebDriver driver;
        public string mainURL = "https://the-internet.herokuapp.com";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Url = mainURL + "/add_remove_elements/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void AddNoElements()
        {
            AddRemoveElements page = new AddRemoveElements(driver);

            Assert.IsTrue(page.DeletedElementsShouldNotBeVisible());
        }

        [TestMethod]
        public void AddOneElement()
        {
            AddRemoveElements page = new AddRemoveElements(driver);

            page.ClickOnAddElementButton();

            Assert.IsTrue(page.AddedElementShouldBeVisible());
        }

        [TestMethod]
        public void DeleteOneElement()
        {
            AddRemoveElements page = new AddRemoveElements(driver);

            page.ClickOnAddElementButton();
            page.ClickOnDeleteElementButton();

            Assert.IsTrue(page.DeletedElementsShouldNotBeVisible());
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
