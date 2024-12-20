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

    public class PracticeFormTests_v3

    {
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
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
        }

        [TestCase("Accounting", "Maths")]
        [TestCase("Maths", "Computer Science")]
        [TestCase("English", "Biology")]
        public void SubjectTest(string userInputSubject1, string userInputSubject2)
        {
            AccessPracticeForm();

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 200);");

            // Initializam webElement-ul pentru Subjects input
            IWebElement subjectsInput = Driver.FindElement(By.Id("subjectsInput"));

            //Trimitem si selectam pe baza criteriilor in camp  
            subjectsInput.SendKeys(userInputSubject1);
            subjectsInput.SendKeys(Keys.Enter);

            subjectsInput.SendKeys(userInputSubject2);
            subjectsInput.SendKeys(Keys.Enter);

            //Identificare buton de delete subiect din input field

            //IWebElement subjectDeleteButtonV1 = Driver.FindElement(By.XPath($"//div[contains(@class,\"multiValue\")][./div[text()=\"{userInputSubject1}\"]]/div[2]"));
            //IWebElement subjectDeleteButtonV2 = Driver.FindElement(By.XPath("//div[contains(@class,\"multiValue\")][./div[text()=\"English\"]]/div[contains(@class, \"__remove\")]"));
            //IWebElement subjectDeleteButtonV3 = Driver.FindElement(By.XPath("//div[text()=\"English\"]/following-sibling::div"));
            //IWebElement subjectDeleteButtonV4 = Driver.FindElement(By.XPath("//div[text()=\"English\"]/parent::div/div[2]"));

            //IWebElement subjectDeleteButtonV5 = Driver.FindElement(By.XPath($"//div[contains(@class,\"multiValue\")][./div[text()=\"{userInputSubject2}\"]]/div[2]"));

            RemoveSubject(userInputSubject1);

            // Sleep
            Thread.Sleep(5000);
        }

        [TestCase("NCR", "Delhi")]
        public void StateAndCityTest(string userInputState, string userInputCity)
        {
            AccessPracticeForm();
            // identificam si initializam web-element-ul pt State dropdow

            IWebElement stateDropdown = Driver.FindElement(By.Id("react-select-3-input"));
            stateDropdown.SendKeys(userInputState);
            stateDropdown.SendKeys(Keys.Enter);


            IWebElement cityDropdown = Driver.FindElement(By.Id("react-select-4-input"));
            cityDropdown.SendKeys(userInputCity);
            cityDropdown.SendKeys(Keys.Enter);


            //sleep
            Thread.Sleep(5000);

        }

        [TestCase("2023","November", "29")]
        public void DateOfBirthTest(string currentYear, string currentMonthName, string currentMonthDay)
        {
            AccessPracticeForm();

            SelectDateFromCalendar(currentYear, currentMonthName, currentMonthDay);

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


        public void RemoveSubject(string subjectName)
        {
            var startingXpath = "//div[contains(@class,\"multiValue\")][./div[text()=\"";
            var endingXpath = "\"]]/div[2]";
            IWebElement subjectButton = Driver.FindElement(By.XPath($"{startingXpath}{subjectName}{endingXpath}"));

            subjectButton.Click();
        }

        public void AccessPracticeForm()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By formsSelector = By.XPath("//h5[text()='Forms']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement formsButton = Driver.FindElement(formsSelector);

            // Dam click pe element
            formsButton.Click();

            // Definim si initializam selector-ul pentru "Practice Form" side menu option
            By practiceFormSelector = By.XPath("//span[text()='Practice Form']");

            // Initialiam webElement-ul pentru Practice Form
            IWebElement practiceFormOption = Driver.FindElement(practiceFormSelector);

            // Dam click pe Practice Form option
            practiceFormOption.Click();
        }

        public void SelectDateFromCalendar(string currentYear, string currentMonthName, string currentMonthDay)
        {

            //identificam si initailizam dateOfBirth webelement input
            IWebElement dateOfBirtInput = Driver.FindElement(By.Id("dateOfBirthInput"));

            //deschidem calendarul
            dateOfBirtInput.Click();

            //initializam select element pentru year
            IWebElement yearDropdownWe = Driver.FindElement(By.XPath("//select[contains(@class, \"year-select\")]"));
            var yearDropdown = new SelectElement(yearDropdownWe);

            //selectam anul
            yearDropdown.SelectByValue(currentYear); 

            //Initializam un select element pentru month
            IWebElement monthDropDownWe = Driver.FindElement(By.XPath("//select[contains(@class, \"month-select\")]"));
            var monthDropdown = new SelectElement(monthDropDownWe);

            //selectam luna 
            monthDropdown.SelectByText(currentMonthName);

            //selectam ziua
            IWebElement dayOfCurrentMonth = Driver.FindElement(By.XPath($"//div[text()=\"{currentMonthDay}\" and not(contains(@class, \"--outside-month\"))]"));
            dayOfCurrentMonth.Click();


        }
        
    }

}