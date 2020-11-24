using ClassLibrary1.Drivers;
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
    public class DropDownDemoTest:BaseTest
    {
        [TestCase("Monday", TestName = "Monday")]

        public void TestDropDown(string dayOfWeek)
        {
            _dropdownDemoPage.NavigateToDefaultPage().SelectFromDropDownByText(dayOfWeek)
                .VerifyResult(dayOfWeek);

        }

        [TestCase("Florida", "Texas", TestName = "Two options, check first selected")]
        [TestCase("Washington", "Texas", "New York", TestName = "Three options, check first selected")]
        [TestCase("Washington", "Texas", "New York","Ohio", TestName = "Four options, check first selected")]

        public void TestDropDownWithMultipleSelectionsAndGetFirst(params string[] selectedStates)

        {
            _dropdownDemoPage.NavigateToDefaultPage().SelectMultipleDropDownByText(selectedStates.ToList())
                .ClickFirstSelected()
                .CheckFirstSelected(selectedStates.ToList());


        }
        [TestCase("California", "New Jersey", TestName = "Two options, check all selected")]
        [TestCase("Texas", "Florida", "Ohio", "Pennsylvania", TestName = "Four options, check all selected")]

        public void TestDropDownWithMultipleSelectionsAndgetAll(params string[] selectedStates)

        {
            _dropdownDemoPage.NavigateToDefaultPage().SelectFromMultipleDropDownByValue(selectedStates.ToList())
                .ClickAllSelected()
                .CheckAllselected(selectedStates.ToList());

        }
        

    }
}
