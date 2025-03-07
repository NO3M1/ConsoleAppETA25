using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppETA25.Programing_Session6
{
    public class IterationStatements_Homework_WIP
    {
        /*Similar cu ce am facut astazi, tema va necesita folosirea structurilor repetitive de tip "WHILE" / "DO-WHILE":
        Pentru pagina de "Widgets > Date Picker", campul "Select Date":
        
        Creati un test care sa:
        Primeasca drept parametru un INT "X"  (parametru ce poate fi numit cum vreti voi) 
        ce va fi folosit pentru a determina urmatorii "X" ani bisecti. 
        Testul va include deschiderea calendarului si parcurgerea lui pana cand
        se intalnesc toti anii bisecti specificati in parametrul de intrare "X".
        Assertul va include verificarea ca data de 29 Februarie sa existe 
        pentru fiecare din urmatorii "X" ani bisecti.*/

        public IWebDriver Driver;
        public const string BaseUrl = "https://demoqa.com/";

        // Define jsExecutor
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
            jsExecutor.ExecuteScript("window.scrollTo(0, 900);");
        }

        [TestCase(4)]
        public void AnBisect(int x)
        {


            AccesWidgetCalendar();

            Thread.Sleep(5000);

        }

        [TearDown]
        public void CleanUp()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        public void AccesWidgetCalendar()
        {

            jsExecutor.ExecuteScript("window.scrollTo(0, 900);");

            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By widgetsSelector = By.XPath("//h5[text()='Widgets']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement widgetsButton = Driver.FindElement(widgetsSelector);

            // Dam click pe element
            widgetsButton.Click();

            //Definim si intializam selectorul pentru DatePicker
            By datepickerSelector = By.XPath("//span[text()='Date Picker']");

            // Initializam WebElementul
            IWebElement datePickerOption = Driver.FindElement(datepickerSelector);

            //Dam click
            datePickerOption.Click();

            //Definim si initializam dateInput-ul
            var dateInput = Driver.FindElement(By.Id("datePickerMonthYearInput"));
            dateInput.Click();

        }

        public void MonthSelect(string nameOfMonth)
        {
            var monthDropDown = Driver.FindElement(By.XPath("//select[contains(@class, \"month-select\")]"));
            monthDropDown.Click();

            var monthOptionSelector = By.XPath("//select[contains(@class, \"month-select\")]/option");
            List<IWebElement> monthOptions = Driver.FindElements(monthOptionSelector).ToList();

            foreach (var option in monthOptions)
                if (option.Text == nameOfMonth)
                {
                    option.Click();
                    Thread.Sleep(1000);
                    return;
                }
        }

        public void YearSelect (int year)
        {
            var yearDropdownWe = Driver.FindElement(By.XPath("//select[contains(@class, \"year-select\")]"));
            yearDropdownWe.Click();

            var yearOptionSelector = By.XPath("//select[contains(@class, \"year-select\")]/option");
            List<IWebElement> yearOptions = Driver.FindElements(yearOptionSelector).ToList();

            foreach (var option in yearOptions)
                if (option.Text == year.ToString())
                {
                    option.Click();
                    Thread.Sleep(1000);
                    return;
                }
        }

    }
}
