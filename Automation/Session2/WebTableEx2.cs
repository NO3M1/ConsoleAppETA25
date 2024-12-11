using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppETA25.Automation.Session2
{
    

    public class WebTableEx2

    {
        IWebDriver Driver;

      [Test]

      public void TestMethod()
        {

            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,500)");


            IWebElement elementButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementButton.Click();

            IWebElement webTableButton = Driver.FindElement(By.XPath("//span[text()='Web Tables']"));
            webTableButton.Click();

            IWebElement addButton = Driver.FindElement(By.Id("addNewRecordButton"));
            addButton.Click();

            IWebElement firstName = Driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Noe");

            IWebElement lastName = Driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Szzok");


            IWebElement email = Driver.FindElement(By.Id("userEmail"));
            email.SendKeys("test@test.com");

            IWebElement age = Driver.FindElement(By.Id("age"));
            age.SendKeys("99");

            IWebElement salary = Driver.FindElement(By.Id("salary"));
            salary.SendKeys("10000");

            IWebElement department = Driver.FindElement(By.Id("department"));
            department.SendKeys("IT");


            //IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            submitButton.Click();
            //submitButton.Submit();
            //jse.ExecuteScript("arguments[0].click();," submitButton);

            IWebElement newRowWebTable = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]"));

            Console.WriteLine(newRowWebTable.Text);

            //Assert.That(newRowWebTable.Text.Contains("Noe"));
            //Assert.That(newRowWebTable.Text.Contains("Szzok"));
            //Assert.That(newRowWebTable.Text.Contains("test@test.com"));
            //Assert.That(newRowWebTable.Text.Contains("99"));
            //Assert.That(newRowWebTable.Text.Contains("10000"));
            //Assert.That(newRowWebTable.Text.Contains("IT"));

            IWebElement firstname1 = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][1]"));
            IWebElement lastname1 = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][2]"));
            IWebElement age1 = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][3]"));
            IWebElement email1 = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][4]"));
            IWebElement salary1 = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][5]"));
            IWebElement department1 = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][6]"));

            Assert.That(firstname1.Text.Equals("Noe"));
            Assert.That(lastname1.Text.Equals("Szzok"));
            Assert.That(email1.Text.Equals("test@test.com"));
            Assert.That(age1.Text.Equals("99"));
            Assert.That(salary1.Text.Equals("10000"));
            Assert.That(department1.Text.Equals("IT"));







        }

        /* [TearDown]

         public void TearDown()
         {
             if (Driver != null)
             {

                 Driver.Dispose();
                 Driver.Quit();
             }
         }

         */


    }
}
