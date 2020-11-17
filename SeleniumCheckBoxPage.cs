using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.Page
{
    class SeleniumCheckBoxPage
    {
        private static IWebDriver _driver;
        private IWebElement firstcheckbox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement text => _driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> multipleCheckboxList => _driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement button => _driver.FindElement(By.Id("check1"));

        public SeleniumCheckBoxPage(IWebDriver webDriver) 
        {
            _driver = webDriver;
        }
        public SeleniumCheckBoxPage CheckFirstBox()
        {
            firstcheckbox.Click();
            return this;
        }
        public SeleniumCheckBoxPage AssertIfFirstSelected(string buttonText)
        {
            Assert.IsTrue(text.Text.Equals(buttonText));
            return this;
        }
        public SeleniumCheckBoxPage CheckMultipleBoxes()
        {
            IfFirstCheckboxSelected();
            foreach (IWebElement element in multipleCheckboxList)
            {
                element.Click();
            }
            return this;
        }
        public SeleniumCheckBoxPage CheckIfAllSelected(string expectedResult)
        {
            Wait();
            Assert.AreEqual(expectedResult, button.GetAttribute("value"), "The button does not say Uncheck all");
            return this;
        }
        public SeleniumCheckBoxPage ClickUncheckButton()
        {
            button.Click();
            return this;
        }
        
        public SeleniumCheckBoxPage CheckIfAllUnselected()
        {
            foreach (IWebElement element in multipleCheckboxList)
            {
                Assert.IsTrue(element.Selected, "Not all checkboxes unselected");
            }
            return this;
        }
        private void IfFirstCheckboxSelected()
        {
            if (firstcheckbox.Selected)
            {
                firstcheckbox.Click();
            }
        }
        private void Wait()
        {
            Thread.Sleep(100);
        }
    }
}
