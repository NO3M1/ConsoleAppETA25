using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ConsoleAppETA25.Automation.Session5
{
    public class SelectMenuTest
    {

        IWebDriver Driver;

        [TestCase("Group 1, option 1")]
        public void testSelectMenu(String userInput)
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = Driver.FindElement(By.XPath("//h5[text()='Widgets']"));
            widgetsButton.Click();

            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver;
            js1.ExecuteScript("window.scrollTo(0,2000)");

            IWebElement selectMenuButton = Driver.FindElement(By.XPath("//*[text()='Select Menu']"));
            selectMenuButton.Click();


            //IWebElement selectValueButton = Driver.FindElement(By.Id("withOptGroup"));
            //selectValueButton.Click();
            //selectValueButton.SendKeys(userInput);
            

           
     

            

            Thread.Sleep(2000);


        }
    }
}
