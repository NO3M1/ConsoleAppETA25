using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppETA25.Automation.Session3
{
    public class PracticeForm_v2

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


            IWebElement formsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
            formsButton.Click();

            IWebElement elementForms = Driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            elementForms.Click();

            IWebElement labelMale = Driver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
            IWebElement labelFemale = Driver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
            IWebElement labelOther = Driver.FindElement(By.XPath("//label[@for='gender-radio-3']"));

            String gender = "Female";

            //if (gender.Equals("Male"))
            //{
            //    labelMale.Click();
            //}
            //else if (gender.Equals("Female"))
            //{
            //    labelFemale.Click();
            //}
            //else
            //{
            //    labelOther.Click();
            //}

            switch (gender)
            {
                case "Male":
                    labelMale.Click();
                    break;
                case "Female":
                    labelFemale.Click();
                    break;
                case "Other":
                    labelOther.Click();
                    break;
            }

            //SUBJECT FIELD

            IWebElement subjectElement = Driver.FindElement(By.Id("subjectsInput"));
            subjectElement.SendKeys("English");
            subjectElement.SendKeys(Keys.Enter);

            //arrow down
            subjectElement.SendKeys("C");
            subjectElement.SendKeys(Keys.ArrowDown);
            subjectElement.SendKeys(Keys.ArrowDown);
            subjectElement.SendKeys(Keys.ArrowDown);
            subjectElement.SendKeys(Keys.Enter);







            Thread.Sleep(5000);

        }

       [TearDown]

         public void TearDown()
         {
             if (Driver != null)
             {

                 Driver.Dispose();
                 Driver.Quit();
             }
         }


    }
}
