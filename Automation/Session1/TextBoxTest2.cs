using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppETA25.Automation.Session1
{
    public class TextBoxTest2
    {

        IWebDriver driver;



        [Test]
        public void Test() 
        
        { 
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demoqa.com");
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementButton = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementButton.Click();

            IWebElement textBoxButton = driver.FindElement(By.XPath("//*[text()='Text Box']"));
            textBoxButton.Click();

            IWebElement firstName = driver.FindElement(By.Id("userName"));
            firstName.SendKeys("Noemi Sz");

            IWebElement email = driver.FindElement(By.Id("userEmail"));
            email.SendKeys("test@test.com");

            IWebElement currentAddress = driver.FindElement(By.Id("currentAddress"));
            currentAddress.SendKeys("address1");

            IWebElement permanentAddress = driver.FindElement(By.Id("permanentAddress"));
            permanentAddress.SendKeys("address2");

            js.ExecuteScript("window.scrollTo(0, 1000);");

            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();   





            Thread.Sleep(50000);


        }


        [TearDown]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }


    }
}
