using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace ConsoleAppETA25.Automation.Session7
{
    public class ActionsClassTests
    {
        public IWebDriver Driver;
        public Actions Actions;
        public const string BaseUrl = "https://demoqa.com/";

        // Define jsExecutor
        IJavaScriptExecutor jsExecutor;

        [SetUp]
        public void Setup()
        {
            // Initializare driver Chrome & pornire instanta browser
            Driver = new ChromeDriver();

            //Initailizare Driver Actions
            Actions = new Actions(Driver);

            // Navigam la pagina de HOME: https://demoqa.com/
            Driver.Navigate().GoToUrl(BaseUrl);

            // Maximizare instanta browser
            Driver.Manage().Window.Maximize();

            // Initializare jsExecutor
            jsExecutor = (IJavaScriptExecutor)Driver;

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
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

        [Test]

        public void HowerTest()
        {
            AccessSpecificPage("Widgets", "Tool Tips", true);

            IWebElement button = Driver.FindElement(By.Id("toolTipButton"));
            Actions.MoveToElement(button).Build().Perform();

            Thread.Sleep(3000);

        }

        [Test]
        public void MenuHoverTest()
        {
            AccessSpecificPage("Widgets", "Menu", true);

            IWebElement mainMenu2 = Driver.FindElement(By.XPath("//li/a[text()=\"Main Item 2\"]"));
            IWebElement subMenu3 = Driver.FindElement(By.XPath("//li/a[text()=\"SUB SUB LIST »\"]"));
            IWebElement subSubMenu2 = Driver.FindElement(By.XPath("//li/a[text()=\"Sub Sub Item 2\"]"));

            Actions.MoveToElement(mainMenu2)
                .MoveToElement(subMenu3)
                .MoveToElement(subSubMenu2)
                .Click()
                .Build().Perform();


            Thread.Sleep(3000);

        }

        [Test]
        public void MoveSliderTest()
        {
            AccessSpecificPage("Widgets", "Slider");

            IWebElement slider = Driver.FindElement(By.XPath("//input[@type=\"range\"]"));

         /*   Actions.MoveToElement(slider)
                .MoveByOffset(5,0) //every 6 pixels should equal to 1 value
                .Click()
                .Build().Perform();*/

            //in stanga de la centrul elementului
            Actions.MoveToElement(slider)
           .MoveByOffset(-120, 0) //every 6 pixels should equal to 1 value aprox
           .Click()
           .Build().Perform();

            Thread.Sleep(3000);

            Assert.That(slider.GetDomAttribute("value") == "31");
        }
            


        public void AccessSpecificPage(string cardName, string menuOptionName, bool shouldIntermediateScroll = false )
        {
            By cardSelector = By.XPath($"//h5[text()='{cardName}']");
            IWebElement card = Driver.FindElement(cardSelector);
            card.Click();

            //Intermediate scroll
            if (shouldIntermediateScroll)  // true
            {
                Actions.ScrollByAmount(0,1000).Build().Perform();    
            }

            By menuOptionSelector = By.XPath($"//span[text()='{menuOptionName}']");
            IWebElement menuoption = Driver.FindElement(menuOptionSelector);
            menuoption.Click();

            // Scroll
            //jsExecutor.ExecuteScript("window.scrollTo(0, 500);");

            // scroll using Actions class
            //var actionDriver = new Actions(Driver); //mod prin care controlam pagina dar avem deja clasa facuta mai sus
            //actionDriver

            Actions
                .ScrollByAmount(0, 300)
                .Build()
                .Perform();

            Thread.Sleep(3000);

        }



        
    }

}
