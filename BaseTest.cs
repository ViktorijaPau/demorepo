using ClassLibrary1.Drivers;
using ClassLibrary1.Page;
using ClassLibrary1.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static DropDownDemoPage _dropdownDemoPage;
        public static VartuTechnikaPage vartuTechnikaPage;
        //public static PostLtIndexSearchPage postLtPage;
        //public static PostLtTrackShipmentPage trackShipmentPage;
        public static SenukaiPage senukaiPage;

        [OneTimeSetUp]

        public static void SetUp()
        {
            driver = CustomDriver.GetIncognitoChrome();
            

            _dropdownDemoPage = new DropDownDemoPage(driver);
            vartuTechnikaPage = new VartuTechnikaPage(driver);
            //postLtPage = new PostLtIndexSearchPage(driver);
            //trackShipmentPage = new PostLtTrackShipmentPage(driver);
            senukaiPage = new SenukaiPage(driver);
        }
        [TearDown]
        public static void TakeSchreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.MakeScreenshot(driver);
            }
        }
        [OneTimeTearDown]

        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
