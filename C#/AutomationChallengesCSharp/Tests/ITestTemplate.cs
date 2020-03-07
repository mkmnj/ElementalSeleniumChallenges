using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Tests
{
    interface ITestTemplate
    {
        [TestInitialize]
        public void Setup();

        [TestCleanup]
        public void Teardown();
    }
}
