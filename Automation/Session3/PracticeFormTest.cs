using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ConsoleAppETA25.Automation.Session3
{
    internal class PracticeFormTest
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

        [TestCase("Male")]
        [TestCase("Female")]
        [TestCase("Other")]
        [TestCase("OtherBullshit")]

        public void GenderTest(string userInputGender)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            jsExecutor.ExecuteScript("window.scrollTo(0,500);");


            By formsSelector = By.XPath("//h5[text()='Forms']");
            IWebElement formsButton = Driver.FindElement(formsSelector);
            formsButton.Click();

            By practiceFormSelector = By.XPath("//span[text()='Practice Form']");
            IWebElement practiceFormOption = Driver.FindElement(practiceFormSelector);

            By genderMaleSelector = By.Id("gender-radio-1");
            IWebElement genderMaleInput = Driver.FindElement(genderMaleSelector);

            By genderFemaleSelector = By.Id("gender-radio-2");
            IWebElement genderFemaleInput = Driver.FindElement(genderFemaleSelector);

            By genderOtherSelector = By.Id("gender-radio-3");
            IWebElement genderOtherInput = Driver.FindElement(genderOtherSelector);

           

            //if (genderMaleInput.GetDomAttribute("value") == userInputGender)
            //{
            //    jsExecutor.ExecuteScript("arguments[0].click();", genderMaleInput);
            //}
            //else if (genderFemaleInput.GetDomAttribute("value") == userInputGender)
            //{
            //    jsExecutor.ExecuteScript("arguments[0].click();", genderFemaleInput); 
            //}
            //else
            //{
            //    jsExecutor.ExecuteScript("arguments[0].click();", genderOtherInput);
            //}

            //IF & SWITHCH STATEMENT

            By genderMaleLabelSelector = By.XPath("//*[@for=\"gender-radio-1\"]");
            IWebElement genderMaleLabel = Driver.FindElement(genderMaleLabelSelector);

            By genderFemaleLabelSelector = By.XPath("//*[@for=\"gender-radio-2\"]");
            IWebElement genderFemaleLabel = Driver.FindElement(genderFemaleLabelSelector);

            By genderOtherLabelSelector = By.XPath("//*[@for=\"gender-radio-3\"]");
            IWebElement genderOtherLabel= Driver.FindElement(genderOtherLabelSelector);

         
            //if (genderMaleLabel.Text == userInputGender )
            //{
            //    genderMaleLabel.Click();
            //}
            //else if (genderFemaleLabel.Text == userInputGender)
            //{
            //    genderFemaleLabel.Click();
            //}
            //else
            //{
            //    genderOtherLabel.Click();
            //}


            switch (userInputGender)
            {
                case "Male":
                    genderMaleLabel.Click(); break;
                case "Female":
                    genderFemaleLabel.Click(); break;
                default:
                    genderOtherLabel.Click(); break;    
            }

            Thread.Sleep(5000);
        }




        [TestCase("Sport")]
        [TestCase("Sports")]
        [TestCase("Reading")]
        [TestCase("Books")]
        [TestCase("Music")]

        public void HobbiesTest(string userInputHobby)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            jsExecutor.ExecuteScript("window.scrollTo(0,500);");


            By formsSelector = By.XPath("//h5[text()='Forms']");
            IWebElement formsButton = Driver.FindElement(formsSelector);
            formsButton.Click();

            By practiceFormSelector = By.XPath("//span[text()='Practice Form']");
            IWebElement practiceFormOption = Driver.FindElement(practiceFormSelector);
            practiceFormOption.Click();

            By hobbySportsSelector = By.XPath("//*[@for=\"hobbies-checkbox-1\"]");
            IWebElement hobbySportsLabel = Driver.FindElement(hobbySportsSelector);

            By hobbyReadingSelector = By.XPath("//*[@for=\"hobbies-checkbox-2\"]");
            IWebElement hobbyReadingLabel = Driver.FindElement(hobbyReadingSelector);

            By hobbyMusicSelector = By.XPath("//*[@for=\"hobbies-checkbox-3\"]");
            IWebElement hobbyMusicLabel = Driver.FindElement(hobbyMusicSelector);

            switch (userInputHobby)
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
