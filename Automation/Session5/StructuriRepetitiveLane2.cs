using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleAppETA25.Automation.Session5
{
    public class StructuriRepetitivelane2

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

        [Test]
        public void ISortableList()
        {
            IWebElement InteractionButton = Driver.FindElement(By.XPath("//*[text()=\"Interactions\"]"));
            InteractionButton.Click();

            List<IWebElement> ListInteractions = Driver.FindElements(By.XPath("//div[@class=\"element-list collapse show\"]/ul[@class=\"menu-list\"]/li[@class=\"btn btn-light \"]")).ToList();
            ListInteractions[0].Click();

            List<IWebElement> FirstListElements = Driver.FindElements(By.XPath("//div[@class=\"vertical-list-container mt-4\"]/div")).ToList();
            //Console.WriteLine(FirstListElements[0].Text);

            for (int i = 0; i < FirstListElements.Count; i++)
            {
                Console.WriteLine(FirstListElements[i].Text);
            }

        }



    }

 }
