using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Tests.PageObjects
{
    class AddRemoveElements
    {
        private IWebDriver driver;

        private IWebElement AddButton => driver.FindElement(By.XPath("//button[@onclick='addElement()']"));
        private List<IWebElement> DeleteButtonList => new List<IWebElement>(driver.FindElements(By.XPath("//button[@onclick='deleteElement()']")));
        private int elementsToBeRemoved;

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

        public bool AddedElementShouldBeVisible()
        {
            return DeleteButtonList[0].Displayed;
        }

        public bool DeletedElementsShouldNotBeVisible()
        {
            return DeleteButtonList?.Count == 0;
        }
    }
}
