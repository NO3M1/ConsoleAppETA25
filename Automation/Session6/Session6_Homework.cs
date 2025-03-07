using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ConsoleAppETA25.Automation.Session6
{
    internal class Session6_Homework
    {

        /*Similar cu ce am facut astazi, tema va necesita interactiunea cu mecanismele disponibile din SeleniumWebDriver:
        Pentru pagina de "Alerts, Frame & Windows > Alerts":
        Creati 4 teste in care sa:

        Interactionati cu fiecare dintre cele 4 tipuri de alerte. 

        Assertul va include:
        Verificarea vizibilitatii popup-urilor simple.
        Verificarea inputului pentru popup-uri complexe:
        Click pe buton (vezi text verde din main page langa buton)
        Input field value (vezi text verde din main page langa buton)

        TIPS & TICKS:
        Bazat pe sesiunea de azi, mecanismul este asemanator:
        Initializare variabila de tip IAlert la schimbarea de context cu Driver.SwitchTo().Alert();
        Vezi output "Alert()" function.
        Interfata IAlert ne ofera access la urmatoarele mecanisme:
        Accept()
        Dismiss()
        SendKeys()
        Text*/

        public class AtertsTests
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

            [TearDown]
            public void CleanUp()
            {
                if (Driver != null)
                {
                    Driver.Quit();
                    Driver.Dispose();
                }
            }


            public void AccessAlertsPage()
            {
                // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
                By pageSelector = By.XPath("//h5[text()='Alerts, Frame & Windows']");

                // Initializam un webElement care ne permite interactiunea cu elementul din pagina
                IWebElement pageButton = Driver.FindElement(pageSelector);

                // Dam click pe element
                pageButton.Click();

                // Definim si initializam selector-ul pentru "Alerts" side menu option
                By alertsSelector = By.XPath("//span[text()='Alerts']");

                // Initializam webElement-ul pentru Alerts
                IWebElement alertsButton = Driver.FindElement(alertsSelector);

                // Dam click pe Frame
                alertsButton.Click();

                // Scroll
                //jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
            }

            [Test]
            public void FirstSimpleAlertTest()
            {
                AccessAlertsPage();

                By alertButtonSelector = By.Id("alertButton");
                IWebElement alertsButton = Driver.FindElement(alertButtonSelector);
                alertsButton.Click();

                var alert = Driver.SwitchTo().Alert();

                Thread.Sleep(1000);

                string alertText = alert.Text;
                string validationText = "You clicked a button";

                Assert.That(alertText, Is.EqualTo(validationText));

                alert.Dismiss();

                Thread.Sleep(5000);
            }

            [Test]
            public void Second5SecAlert()
            {
                AccessAlertsPage();
                By fiveSecButtonSelector = By.Id("timerAlertButton");
                IWebElement fiveSecButton = Driver.FindElement(fiveSecButtonSelector);  
                fiveSecButton.Click();

                Thread.Sleep(5000);

                var fiveSecAlert = Driver.SwitchTo().Alert();   

                string fiveSecAlertText = fiveSecAlert.Text;
                string validationText = "This alert appeared after 5 seconds";

                Assert.That(fiveSecAlertText, Is.EqualTo(validationText));

                Thread.Sleep(1000);

                fiveSecAlert.Dismiss();

                Thread.Sleep(1000);

            }

            [Test]
            public void ThirdConfirmAlert()
            {
                AccessAlertsPage();

                By confirmButtonSelector = By.Id("confirmButton");
                IWebElement confirmButton = Driver.FindElement(confirmButtonSelector);
                confirmButton.Click();

                var confirmAlert = Driver.SwitchTo().Alert();

                string confirmAlertText = confirmAlert.Text;
                string validationText = "Do you confirm action?";

                Assert.That(confirmAlertText, Is.EqualTo(validationText));

                Thread.Sleep(1000);

                confirmAlert.Accept();

                Thread.Sleep(1000);

                By actionConfirmSelector = By.Id("confirmResult");
                IWebElement confirmAction = Driver.FindElement(actionConfirmSelector);

                string actionCondirmText = confirmAction.Text;
                string validationActionText = "You selected Ok";

                Assert.That(actionCondirmText, Is.EqualTo(validationActionText));

                Thread.Sleep(5000);

            }

            [Test]
            public void ForthPromptAlert()
            {
                AccessAlertsPage();

                By promptButtonSelector = By.Id("promtButton");
                IWebElement promptButton = Driver.FindElement(promptButtonSelector);
                promptButton.Click();

                var promptAlert = Driver.SwitchTo().Alert();

                string promptAlertText = promptAlert.Text;
                string validationText = "Please enter your name";

                Assert.That(promptAlertText, Is.EqualTo(validationText));

                promptAlert.SendKeys("Noemi");
                Thread.Sleep(1000);

                promptAlert.Accept();
                Thread.Sleep(1000);

                By confirmActionSelector = By.Id("promptResult");
                IWebElement confirmAction = Driver.FindElement(confirmActionSelector);

                string confirmActionText = confirmAction.Text;
                string validationActionText = "You entered Noemi";
                Assert.That(confirmActionText, Is.EqualTo(validationActionText));

                Thread.Sleep(5000);
            }

        }
    }
}

