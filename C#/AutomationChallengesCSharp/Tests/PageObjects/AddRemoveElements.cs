using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading;

namespace Tests.PageObjects
{
    class AddRemoveElements
    {
        private IWebDriver driver;

        private IWebElement AddButton => driver.FindElement(By.XPath("//button[@onclick='addElement()']"));
        private List<IWebElement> DeleteButtonList => new List<IWebElement>(driver.FindElements(By.XPath("//button[@onclick='deleteElement()']")));
        protected int elementsToBeRemoved { get; set; }

        public AddRemoveElements(IWebDriver driver)
        {
            this.driver = driver;
            elementsToBeRemoved = 0;
        }

        public virtual void ClickOnAddElementButton()
        {
            AddButton.Click();
        }

        public virtual void ClickOnAddElementButton(int times)
        {
            if (times > 0)
            {
                for (int i = 1; i <= times; i++)
                {
                    AddButton.Click();
                    elementsToBeRemoved++;
                }
            }

            else
            {
                throw new ArgumentException("Invalid argument: value must be greater than zero.");
            }
        }

        public void ClickOnDeleteElementButton()
        {
            IWebElement elementToBeDeleted = DeleteButtonList[0];

            if (DeleteButtonList.Count > 0)
            {
                elementToBeDeleted.Click();
            }

            else
            {
                throw new NoSuchElementException("No elements have been found.");
            }
        }

        public void DeleteAllButtons()
        {
            for (int i = elementsToBeRemoved - 1; i >= 0; i--)
            {
                DeleteButtonList[i].Click();
            }

            elementsToBeRemoved = DeleteButtonList.Count == 0 ? 0 : elementsToBeRemoved;
        }

        public bool AddedElementShouldBeVisible()
        {
            return DeleteButtonList[0].Displayed;
        }

        public bool AddedElementsShouldBeVisible()
        {
            bool everyElementVisible = false;

            for (int i = 0; i < elementsToBeRemoved; i++)
            {
                everyElementVisible = DeleteButtonList[i].Displayed ? true : false;
            }

            return everyElementVisible;
        }

        public bool DeletedElementsShouldNotBeVisible()
        {
            return DeleteButtonList?.Count == 0 && elementsToBeRemoved == 0;
        }
    }
}
