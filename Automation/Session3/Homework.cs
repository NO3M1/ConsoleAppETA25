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
    internal class Homework
    {


        public IWebDriver Driver;
        public const string BaseUrl = "https://demoqa.com/";

        //public const string FirstName = "Noemi";
        //public const string LastName = "Szzzz";
        //public const string Email = "ns-test@email.com";
        //public const string Mobile = "0725698798";
        //public const string CurrentAddress = "Romania";

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
        }

        [TestCase("Ion","A","test1@test.com","07456988", "Romania", "Male", "Reading")]
        [TestCase("Ana","M", "test2@test.com", "07859966", "USA", "Female", "Sports")]
        [TestCase("Noemi", "Sz", "test3@test.com", "07466254", "Australia", "Other", "Music")]


        public void PracticeFormTest(string FirstNameInput, string LastNameInput, string EmailInput, string MobileInput, string currentAddressInput, string userInputGender, string HobbiesInput)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,500)");


            IWebElement formsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
            formsButton.Click();

            IWebElement elementForms = Driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            elementForms.Click();

            IWebElement firstName = Driver.FindElement(By.Id("firstName"));
            firstName.SendKeys(FirstNameInput);

            IWebElement lastName = Driver.FindElement(By.Id("lastName"));
            lastName.SendKeys(LastNameInput);

            IWebElement email = Driver.FindElement(By.Id("userEmail"));
            email.SendKeys(EmailInput);

            IWebElement mobileNumber = Driver.FindElement(By.Id("userNumber"));
            mobileNumber.SendKeys(MobileInput);

            IWebElement currentAddress = Driver.FindElement(By.Id("currentAddress"));
            currentAddress.SendKeys(currentAddressInput);

            IWebElement genderlabelMale = Driver.FindElement(By.Id("gender-radio-1"));
            IWebElement genderlabelFemale = Driver.FindElement(By.Id("gender-radio-2"));
            IWebElement genderlabelOther = Driver.FindElement(By.Id("gender-radio-3"));

            IWebElement hobbySportsLabel = Driver.FindElement(By.XPath("//*[@for='hobbies-checkbox-1']"));

            IWebElement hobbyReadingLabel = Driver.FindElement(By.XPath("//*[@for='hobbies-checkbox-2']"));

            IWebElement hobbyMusicLabel = Driver.FindElement(By.XPath("//*[@for='hobbies-checkbox-3']"));



            


            if (genderlabelMale.GetDomAttribute("value") == userInputGender)
            {
                js.ExecuteScript("arguments[0].click();", genderlabelMale);
            }
            else if (genderlabelFemale.GetDomAttribute("value") == userInputGender)
            {
                js.ExecuteScript("arguments[0].click();", genderlabelFemale);
            }
            else
            {
                js.ExecuteScript("arguments[0].click();", genderlabelOther);
            }


            IWebElement subjectElement = Driver.FindElement(By.Id("subjectsInput"));
            subjectElement.SendKeys("English");
            subjectElement.SendKeys(Keys.Enter);
            subjectElement.SendKeys("C");
            subjectElement.SendKeys(Keys.ArrowDown);
            subjectElement.SendKeys(Keys.Enter);

            IJavaScriptExecutor jsScroll = (IJavaScriptExecutor)Driver;
            jsScroll.ExecuteScript("window.scrollTo(0,500)");


            switch (HobbiesInput)
            {
                case "Sport":
                case "Sports":
                    hobbySportsLabel.Click(); break;
                case "Reading":
                case "Books":
                    hobbyReadingLabel.Click(); break;
                case "Music":
                    hobbyMusicLabel.Click(); break;
                default:
                    break;



            }

            //delete the first subject option

            IWebElement filledSubjectOptionsDelete = Driver.FindElement(By.XPath("//*[@class='css-19bqh2r']"));
            filledSubjectOptionsDelete.Click();

           /* HOW To remove option Chemistry

            IWebElement userOption = Driver.FindElement(By.XPath("//*[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']"));

            if (userOption != null) 
               {
                userOption.Click();
               }
           */ 










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






    }
}
