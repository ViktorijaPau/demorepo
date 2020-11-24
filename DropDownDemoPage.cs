using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.Page
{
    public class DropDownDemoPage :BasePage
    {

        private const string pageAddress = " https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement ButtonFirstSelected => Driver.FindElement(By.Id("printMe"));
        private IWebElement ButtonAllSelected => Driver.FindElement(By.Id("printAll"));
        private IWebElement MultiResultText => Driver.FindElement(By.CssSelector(".getall-selected"));

        public DropDownDemoPage(IWebDriver webDriver):base (webDriver)
        {
           
        }
        public DropDownDemoPage NavigateToDefaultPage()
        {
            if (Driver.Url != pageAddress)
                Driver.Url = pageAddress;
            return this;

        }
        
        public DropDownDemoPage SelectFromDropDownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }
        public DropDownDemoPage SelectFromDropDownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }
        public DropDownDemoPage VerifyResult (string selectedDay)
        {
            GetWait(10);
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }
        
        public DropDownDemoPage SelectMultipleDropDownByText(List<string>listOfStates)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(MultiResultText);
            action.KeyDown(Keys.Control);
            foreach ( string state in listOfStates)
            {
                MultiDropDown.SelectByText(state);
                GetWait();
            }
            
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            action.Click(ButtonFirstSelected);
            action.Build().Perform();
            return this;
        }
        
        public DropDownDemoPage SelectFromMultipleDropDownByValue(List<string> listOfStates)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(MultiResultText);
            action.KeyDown(Keys.Control);
            foreach (IWebElement option in MultiDropDown.Options)
            {
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    action.Click(option);
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            
            return this;
        }
        public DropDownDemoPage ClickFirstSelected()
        {
            GetWait();
            ButtonFirstSelected.Click();
            return this;
        }
        public DropDownDemoPage ClickAllSelected()
        {
            ButtonAllSelected.Click();
            return this;
        }
        public DropDownDemoPage CheckFirstSelected(List<string>listOfStates)
        {
            
            Assert.IsTrue(MultiResultText.Text.Contains(listOfStates[0]));
            return this;
        }
        public DropDownDemoPage CheckAllselected(List<string> listOfStates)
        {
            foreach (string state in listOfStates)
            {
                Assert.IsTrue(MultiResultText.Text.Contains(state));
            }
            return this;
        }
    }
}
