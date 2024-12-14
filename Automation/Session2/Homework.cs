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
    public class Homework
    {
        /*
        Stergeti toate elementele din tabel inainte de a adauga un rand nou 
        - folosind pasi similari cu cei din curs.
        Sa identificati textul afisat atunci cand nu mai exista elemente in tabel.
        EXTRA:  Editati un rand existent si salvati-l.*/




        public IWebDriver Driver;
        public const string BaseUrl = "https://demoqa.com/";


        public const string firstName = "Noemi";
        public const string lastName = "Sz";
        public const string email = "ns-test@email.com";
        public const string age = "99";
        public const string salary = "999999";
        public const string department = "Software dev";



        [SetUp]

        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
        }

        [Test]

        public void DeletAllElementsFromTable()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,500)");

            IWebElement elementButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementButton.Click();

            IWebElement webTableButton = Driver.FindElement(By.XPath("//span[text()='Web Tables']"));
            webTableButton.Click();

            IWebElement deleteButton1 = Driver.FindElement(By.Id("delete-record-1"));
            deleteButton1.Click();

            IWebElement deleteButton2 = Driver.FindElement(By.Id("delete-record-2"));
            deleteButton2.Click();

            IWebElement deleteButton3 = Driver.FindElement(By.Id("delete-record-3"));
            deleteButton3.Click();

            //
            //WebElement deleteButtonOtherWay = Driver.FindElement(By.XPath("(//span[@title='Delete'])[1] | (//span[@title='Delete'])[2] | (//span[@title='Delete'])[3]"));
            //deleteButtonOtherWay.Click();   


            //identify the text 
            IWebElement noRowsFound = Driver.FindElement(By.XPath("//div[@class='rt-noData']"));


            IWebElement addButton = Driver.FindElement(By.Id("addNewRecordButton"));
            addButton.Click();

            IWebElement FirstName = Driver.FindElement(By.Id("firstName"));
            FirstName.SendKeys(firstName);

            IWebElement LastName = Driver.FindElement(By.Id("lastName"));
            LastName.SendKeys(lastName);

            IWebElement Email = Driver.FindElement(By.Id("userEmail"));
            Email.SendKeys(email);

            IWebElement Age = Driver.FindElement(By.Id("age"));
            Age.SendKeys(age);

            IWebElement Salary = Driver.FindElement(By.Id("salary"));
            Salary.SendKeys(salary);

            IWebElement Department = Driver.FindElement(By.Id("department"));
            Department.SendKeys(department);

            IWebElement SubmitButton = Driver.FindElement(By.Id("submit"));
            SubmitButton.Click();

            // edit the first row -BasicScenario

            IWebElement editRow = Driver.FindElement(By.Id("edit-record-1"));
            editRow.Click();

            IWebElement FirstNameEdited = Driver.FindElement(By.Id("firstName"));
            FirstNameEdited.SendKeys("_blabla");

            IWebElement SubmitButton2 = Driver.FindElement(By.Id("submit"));
            SubmitButton2.Click();


            //edit the row where FirstName is Noemi

            //IWebElement editRowBasedOnColumn = Driver.FindElement(By.XPath("//div[@class='rt-td'][1][contains(text(),'Noemi')]"));
            //need help :)

   

        }





    }
}
