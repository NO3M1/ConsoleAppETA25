using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppETA25.Automation.Session2
{
    public class WebTableTests
    {
        public IWebDriver Driver;
        public const string BaseUrl = "https://demoqa.com/";

        public const string FirstName = "Noemi";
        public const string LastName = "Szzzz";
        public const string Email = "ns-test@email.com";
        public const string Age = "12";
        public const string Salary = "78552";
        public const string Department = "Software dev";



        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
        }



        [Test]
        public void AddNewRowInTableTest()  //la APITesting apel+endpoint+rezultat
        {
            
            // Define jsExecutor
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");

            
            By elementSelector = By.XPath("//h5[text()='Elements']");

            /*or
            IWebElement elementsSelector = Driver.FindElement(By.XPath("//h5[text()='Elements']"));
            */

            IWebElement elementButton = Driver.FindElement(elementSelector);
            elementButton.Click();


            By webTableSelector = By.XPath("//span[text()='Web Tables']");
            IWebElement webTableOption = Driver.FindElement(webTableSelector);
            webTableOption.Click();

            By addButtonSelector = By.Id("addNewRecordButton");
            IWebElement addButton = Driver.FindElement(addButtonSelector);
            addButton.Click();  

            By firstNameSelector = By.Id("firstName");
            IWebElement firstName = Driver.FindElement(firstNameSelector);
            firstName.SendKeys(FirstName);

            By lastNameSelector = By.Id("lastName");
            IWebElement lastName = Driver.FindElement(lastNameSelector);
            lastName.SendKeys(LastName);

            By emailSelector = By.Id("userEmail");
            IWebElement email = Driver.FindElement(emailSelector);
            email.SendKeys(Email);

            By ageSelector = By.Id("age");
            IWebElement age = Driver.FindElement(ageSelector);
            age.SendKeys(Age);

            By salarySelector = By.Id("salary");
            IWebElement salary = Driver.FindElement(salarySelector);
            salary.SendKeys(Salary);

            By departmentSelector = By.Id("department");
            IWebElement department = Driver.FindElement(departmentSelector);
            department.SendKeys(Department);

            By submitButtonSelector = By.Id("submit");
            IWebElement subtmiButton = Driver.FindElement(submitButtonSelector);    
            subtmiButton.Click();


            Thread.Sleep(5000);

            //Output

            
            var nonEmptyRowsSelector = Driver.FindElements(By.XPath("//div[@class='rt-tbody']//div[@role='rowgroup'][.//div[@class='action-buttons']]"));
            var nonEmptyRowsSelector2 = Driver.FindElements(By.XPath("//div[@class='rt-tbody']//div[@role='row' and contains(@class,'-padRow') = false]"));

            By outputRowSelector = By.XPath("//div[@class='rt-tbody']//div[@role='rowgroup'][.//div[@class='action-buttons']][4]");
            IWebElement outputRow = Driver.FindElement(outputRowSelector);
            String outputRowText = outputRow.Text;



            // Assert
            Assert.That(nonEmptyRowsSelector.Count == 4);
            Assert.That(nonEmptyRowsSelector2.Count == 4);  
            Assert.That(outputRowText.Contains(FirstName));
            Assert.That(outputRowText.Contains(LastName));
            Assert.That(outputRowText.Contains(Email));
            Assert.That(outputRowText.Contains(Age));
            Assert.That(outputRowText.Contains(Salary));
            Assert.That(outputRowText.Contains(Department));


            //AAA - Arrange,Act, Assert
          
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


    }






}
