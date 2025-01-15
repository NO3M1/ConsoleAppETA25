using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static NUnit.Framework.Constraints.Tolerance;

namespace ConsoleAppETA25.Automation.Session3
{
    internal class Homework
    {


        public IWebDriver Driver;
        public const string BaseUrl = "https://demoqa.com/";
        IJavaScriptExecutor js;


        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
            js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,500)");
        }

        [TestCase("Ion","A","test1@test.com","0745698898", "Romania", "Male", "Reading")]
        [TestCase("Ana","M", "test2@test.com", "0785996689", "USA", "Female", "Sports")]
        [TestCase("Noemi", "Sz", "test3@test.com", "0746625489", "Australia", "Other", "Music")]


        public void PracticeFormTest(string FirstNameInput, string LastNameInput, string EmailInput, string MobileInput, string currentAddressInput, string userInputGender, string HobbiesInput)
        {
       
           
            IWebElement formsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
            formsButton.Click();

            IWebElement precticeForm = Driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            precticeForm.Click();

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
            //subjectElement.SendKeys(subjectInput);
            //subjectElement.SendKeys(Keys.Enter);


            //other way
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


            jsScroll.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            submitButton.Click();

            // ASSERT

            ////studentEmail
            //string expectedEmailValue = EmailInput;
            //var wait0 = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            //string actualEmailValue = Driver.FindElement(By.XPath("//*[@class='table table-dark table-striped table-bordered table-hover']//tr[2]//td[2]")).Text;
            ////Assert.That(expectedValue, Is.EqualTo(actualValue));
            //Assert.That(actualEmailValue, Is.EqualTo(expectedEmailValue));


            ////Gender
            ////string expectedGender = userInputGender;
            ////string actualGender = Driver.FindElement(By.XPath("//*[@class='table table-dark table-striped table-bordered table-hover']//tr[3]//td[2]")).Text;
            ////Assert.That(expectedGender, Is.EqualTo(actualGender));

            //// Gender
            //string expectedGender = userInputGender;
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            //string actualGender = Driver.FindElement(By.XPath("//table[contains(@class, 'table-dark')]//tr[3]//td[2]")).Text;
            //Assert.That(actualGender, Is.EqualTo(expectedGender),
            //$"Gender mismatch: Expected '{expectedGender}', but was '{actualGender}'.");
       
            ////Mobile
            //string expectedValueMobile = MobileInput;
            //string actualValueMobile = Driver.FindElement(By.XPath("//*[@class='table table-dark table-striped table-bordered table-hover']//tr[4]//td[2]")).Text;
            //Assert.That(expectedValueMobile, Is.EqualTo(actualValueMobile));

            ////Hobbies 
            //string expectedValueHobbies = HobbiesInput;
            //string actualValueHobbies = Driver.FindElement(By.XPath("//*[@class='table table-dark table-striped table-bordered table-hover']//tr[7]//td[2]")).Text;
            //Assert.That(expectedValueHobbies, Is.EqualTo(actualValueHobbies));

            ////Address
            //string expectedValueAddress = currentAddressInput;
            //string actualValueAddress = Driver.FindElement(By.XPath("//*[@class='table table-dark table-striped table-bordered table-hover']//tr[9]//td[2]")).Text;
            //Assert.That(expectedValueAddress, Is.EqualTo(actualValueAddress));



            Thread.Sleep(1000);

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
