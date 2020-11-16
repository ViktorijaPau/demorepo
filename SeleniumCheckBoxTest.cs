using ClassLibrary1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Test
{
    class SeleniumCheckBoxTest
    {
        private static IWebDriver _driver;
        private static SeleniumCheckBoxPage page;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
             page = new SeleniumCheckBoxPage(_driver);
        }
        [OneTimeTearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }
        
        [Test]
        public static void TestIfFirstSelected()
        {
            page.CheckFirstBox();
        }

        [Test]
        public static void TestIfMultipleSelected()
        {
            page.CheckMultipleBoxes()
                .CheckIfAllSelected("Uncheck All");
        }
    
        [Test]
        public static void TestIfAllUnselectedAfterButtonPress()
        {
            page.ClickUncheckButton()
                .CheckIfAllUnselected();
        }
    }
}
