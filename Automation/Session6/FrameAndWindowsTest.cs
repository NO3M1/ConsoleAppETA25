using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ConsoleAppETA25.Automation.Session6
{
    public class FrameAndWindowsTest
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
        public void framesTest()
        {
            AccessFramesPage();

            // Definim un selector pentru Iframe
            By iframeSelector = By.Id("frame1");

            // Initalizam un WebElement pentru Iframe
            IWebElement iFrame1 = Driver.FindElement(iframeSelector);

            // Switch context to correct window/tab/iframe
            Driver.SwitchTo().Frame(iFrame1);

            // Definimm un selector pentru identificarea Iframe Headingului
            By headingSelector = By.Id("sampleHeading");

            // Initializam un IWebelement 
            IWebElement iFrameHeading = Driver.FindElement(headingSelector);
            string IFrameHeadingText = iFrameHeading.Text;
            string validationText = "This is a sample page";

            Assert.That(IFrameHeadingText, Is.EqualTo(validationText));

            Thread.Sleep(5000);

        }

        [Test]
        public void framesSwitchBackTest()
        {
            AccessNestedFramesPage();

            // Definim un selector general care sa ne gaseasca toate elementele din pagina

            By iframeSelector = By.Id("frame1");

            // Initalizam  WebElement pentru Iframe
            IWebElement iFrameParent = Driver.FindElement(iframeSelector); 

            // Switch context to correct window/tab/iframe
            // Parent iFrame
            Driver.SwitchTo().Frame(iFrameParent);

            //Definim un selector pentru body
            By bodySelector = By.TagName("body");

            //Definim o variabila pentru Text
            string bodyText = Driver.FindElement(bodySelector).Text;

            //Assert 
            Assert.That(bodyText, Is.EqualTo("Parent frame"));

            //Definim un selector pentru Iframe child 
            By iFrameChildSelector = By.TagName("iframe");

            //Initializam un Webelement pentru iFrame
            IWebElement iFrameChild = Driver .FindElement(iFrameChildSelector);

            //Child iFrame
            Driver.SwitchTo().Frame(iFrameChild);

            // Definimm un selector pentru identificarea Iframe paragraph 
            By paragraphSelector = By.TagName("p");

            // Initializam un IWebelement 
            IWebElement iFrameParagraph = Driver.FindElement(paragraphSelector);
            string IFrameParagraphText = iFrameParagraph.Text;
            string childValidationText = "Child Iframe";

            Assert.That(IFrameParagraphText, Is.EqualTo(childValidationText));

            //Return to main page/window
            Driver.SwitchTo().DefaultContent();

            By h1Seletor = By.TagName("h1");

            string h1Text = Driver.FindElement(h1Seletor).Text;

            Assert.That(h1Text, Is.EqualTo("Nested Frames"));

            Thread.Sleep(5000);

        }

        [Test]
        public void BrowserWindowsTest()
        {
            AccessBrowserWindowsPage();

            By tabButtonSelector = By.Id("tabButton");

            //Open a new tab
            IWebElement tabButton = Driver.FindElement(tabButtonSelector); 
            tabButton.Click();

            //Create a new list for tabs/windows  
            List<string> tabsList = new List<string>(Driver.WindowHandles); //ne da lista de taburi deschise

            //Swith to newly opened tab
            Driver.SwitchTo().Window(tabsList[1]);
            //Driver.SwitchTo().Window("https://demoqa.com/sample");

            //New tab - heading
            IWebElement newTabHeading = Driver.FindElement(By.TagName("h1"));

            Assert.That(newTabHeading.Text, Is.EqualTo("This is a sample page"));

            //Initial Tab Name
            string initialTabHandle = tabsList[0];
            string newTabName = Driver.Title; 

            //Switch to Initial tab
            Driver.SwitchTo().Window(initialTabHandle);
            string initialTabName = Driver.Title;


            Thread.Sleep(5000);


        }

        [Test]
        public void BrowserWindowsTest2()
        {
            AccessBrowserWindowsPage();

            By windowButtonSelector = By.Id("windowButton");

            //Open a new window
            IWebElement windowButton = Driver.FindElement(windowButtonSelector);
            windowButton.Click();

            //Create a new list for tabs/windows  
            List<string> tabsList = new List<string>(Driver.WindowHandles); //ne da lista de taburi deschise

            //Swith to newly opened tab
            Driver.SwitchTo().Window(tabsList[1]);

            //New Window - heading
            IWebElement newWindowHeading = Driver.FindElement(By.TagName("h1"));

            Assert.That(newWindowHeading.Text, Is.EqualTo("This is a sample page"));

            //Close window
            Driver.Close();
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
        public void AccessFramesPage()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By frameWindowsSelector = By.XPath("//h5[text()='Alerts, Frame & Windows']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement frameWindowsButton = Driver.FindElement(frameWindowsSelector);

            // Dam click pe element
            frameWindowsButton.Click();

            // Definim si initializam selector-ul pentru "Frames" side menu option
            By framesSelector = By.XPath("//span[text()='Frames']");

            // Initializam webElement-ul pentru Frames
            IWebElement framesOption = Driver.FindElement(framesSelector);

            // Dam click pe Frames option
            framesOption.Click();

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
        }

        public void AccessNestedFramesPage()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By frameWindowsSelector = By.XPath("//h5[text()='Alerts, Frame & Windows']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement frameWindowsButton = Driver.FindElement(frameWindowsSelector);

            // Dam click pe element
            frameWindowsButton.Click();

            // Definim si initializam selector-ul pentru "Nested Frames" side menu option
            By framesSelector = By.XPath("//span[text()='Nested Frames']");

            // Initializam webElement-ul pentru Nested Frames
            IWebElement framesOption = Driver.FindElement(framesSelector);

            // Dam click pe Frames option
            framesOption.Click();

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
        }

        public void AccessBrowserWindowsPage()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By frameWindowsSelector = By.XPath("//h5[text()='Alerts, Frame & Windows']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement frameWindowsButton = Driver.FindElement(frameWindowsSelector);

            // Dam click pe element
            frameWindowsButton.Click();

            // Definim si initializam selector-ul pentru "Browser Windows" side menu option
            By browserWindowsSelector = By.XPath("//span[text()='Browser Windows']");

            // Initializam webElement-ul pentru Browser Windows
            IWebElement browserWindowsOption = Driver.FindElement(browserWindowsSelector);

            // Dam click pe Browser Windows option
            browserWindowsOption.Click();

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
        }
    }

}
