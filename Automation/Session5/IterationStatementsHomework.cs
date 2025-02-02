using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Runtime.ConstrainedExecution;
using OpenQA.Selenium.DevTools.V129.Debugger;

namespace ConsoleAppETA25.Automation.Session5
{

    /*Similar cu ce am facut astazi, tema va necesita folosirea structurilor repetitive de tip "FOR" / "FOREACH":
    In pagina de "Interactions > Selectable", in tabul "Grid":
    Identificati elementele din matrice si folosind structurile repetitive mentionate mai sus:
    Parcurgeti randurile si coloanele matricii ( nested FOR )
    Selectati doar elementele impare din matrice (fara a va folosi de textul din interiorul celulelor)
    Selectarea elementelor se va face pe baza de index.
    erificati la finalul testului daca elementele impare din matrice au fost selectate*/


    public class IterationStatementsHomework
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

        public void AccesSortableGrid()
        {
            IWebElement InteractionButton = Driver.FindElement(By.XPath("//*[text()=\"Interactions\"]"));
            InteractionButton.Click();

            List<IWebElement> ListInteractions = Driver.FindElements(By.XPath("//div[@class=\"element-list collapse show\"]/ul[@class=\"menu-list\"]/li[@class=\"btn btn-light \"]")).ToList();
            ListInteractions[0].Click();

            IWebElement GridButton = Driver.FindElement(By.Id("demo-tab-grid"));
            GridButton.Click();

        }

        [Test]
    public void SortableList()

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


        [Test]
        public void SelectOnlyOddNumbers()
        {
            AccesSortableGrid();

            //select the rows
            By rowSelector = By.XPath("//div[starts-with(@id,'row')]");

            //List to store the rowlist
            List<IWebElement> rowList = Driver.FindElements(rowSelector).ToList();

            //iterate the ROW list
            for (int i = 0; i < rowList.Count; i++)
            {
                //List to store the cells for each row 
                List<IWebElement> rowCellList = rowList[i].FindElements(By.XPath("./li")).ToList();

                //iterate the CELL list
                for (int j = 0; j < rowCellList.Count; j++)
                {
                    if (i % 2 == 0)
                        if (j % 2 == 0)
                        {
                            rowCellList[j].Click();
                            Console.WriteLine($"Clicked on {rowCellList[j].Text} cell");
                        }
                        else
                        {
                            if (j % 2 != 0)
                            {
                                rowCellList[j].Click();
                                Console.WriteLine($"Clicked on {rowCellList[j].Text}");
                            }
                        }
                }
            }

            //ASSERT for selected ROWCELL
            By rowCellSelector = By.XPath("//div/li[contains(@class,'active')]");

            //List to store the active cells
            List<IWebElement> activeCells  =Driver.FindElements(rowCellSelector).ToList();

            List<string> selectedCellsTextList = new List<string>() {"One", "Three", "Five", "Seven", "Nine" };

            //iterating the list to assert the active cells
            foreach (IWebElement rowCell in activeCells)
            { 
                var cellText = rowCell.Text;
                Assert.That(selectedCellsTextList.Contains(cellText), Is.True);

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
