using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleAppETA25.Automation.Session4
{
    internal class SelectMenuTest
    {
        public IWebDriver Driver;
        public const string BaseUrl = "https://demoqa.com/";

 
        IJavaScriptExecutor jsExecutor;

        [SetUp]
        public void Setup()
        {
            // Initializare driver Chrome & pornire instanta browser
            Driver = new ChromeDriver();

            // Navigam la pagina de HOME: https://demoqa.com/
            Driver.Navigate().GoToUrl(BaseUrl);

            // Maximizare instanta browser
            Driver.Manage().Window.Maximize();

            // Initializare jsExecutor
            jsExecutor = (IJavaScriptExecutor)Driver;

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
        }
        [Test]
        public void AccessSelectMenu()
        {
            IWebElement widgetsButton = Driver.FindElement(By.XPath("//h5[text()='Widgets']"));
            widgetsButton.Click();


            IWebElement selectMenu = Driver.FindElement(By.XPath("//span[text()='Select Menu']"));
            selectMenu.Click();


        }

        [TestCase("A root option", "Prof.", "7", "Green", "Black", "volvo", "audi")]
       


        public void SelectMenu(string selectValueInput, string oneValueInput, string oldStyleDropDownInput, string multiSelectInput, string multiSelectInput2, string standardMultiInput, string standardMultiInput2)
        {
            AccessSelectMenu();

            //OldStyleSelectMenu
            SelectElement selectElement = new SelectElement(Driver.FindElement(By.Id("oldSelectMenu")));
            selectElement.SelectByValue(oldStyleDropDownInput);

            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");

            //multiSelectDropDown
            IWebElement multiselect = Driver.FindElement(By.Id("react-select-4-input"));
            multiselect.SendKeys(multiSelectInput);
            multiselect.SendKeys(Keys.Enter);
            multiselect.SendKeys(multiSelectInput2);
            multiselect.SendKeys(Keys.Enter);


            DeleteFromMultiSelect();

        
            //SelectValueDropDown
            IWebElement dropdownInputSelectValue = Driver.FindElement(By.Id("react-select-2-input"));
            dropdownInputSelectValue.SendKeys(selectValueInput);
            dropdownInputSelectValue.SendKeys(Keys.Enter);

            //SelectOneValueDropDown
            IWebElement selectOneValue = Driver.FindElement(By.Id("react-select-3-input"));
            selectOneValue.SendKeys(oneValueInput);
            selectOneValue.SendKeys(Keys.Enter);

            //StandardMultiSelect
            SelectElement multiSelect = new SelectElement(Driver.FindElement(By.Id("cars")));
            multiSelect.SelectByValue(standardMultiInput);
            multiSelect.SelectByValue(standardMultiInput2);

            //deselectAllValues
            //multiSelect.DeselectAll();

            //deselectByValue
            multiSelect.DeselectByValue(standardMultiInput2);

        }

        public void DeleteFromMultiSelect()
        {
            //DeleteTheSecondOption - deletes only the first option
            IWebElement deleteOptions = Driver.FindElement(By.XPath("//div[contains(@class, 'css-xb97g8')][1]"));
            deleteOptions.Click();
        }

    }
}
