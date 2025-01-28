using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Runtime.ConstrainedExecution;

namespace ConsoleAppETA25.Automation.Session5
{
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
        public void SortableGrid()
        {
            IWebElement InteractionButton = Driver.FindElement(By.XPath("//*[text()=\"Interactions\"]"));
            InteractionButton.Click();

            List<IWebElement> ListInteractions = Driver.FindElements(By.XPath("//div[@class=\"element-list collapse show\"]/ul[@class=\"menu-list\"]/li[@class=\"btn btn-light \"]")).ToList();
            ListInteractions[0].Click();

            IWebElement gridButton = Driver.FindElement(By.Id("demo-tab-grid"));
            gridButton.Click();

            // //*[@class="create-grid"] - tabel
            //*[@class=\"grid-container mt-4\"]/div/div"

            List<IWebElement> gridValues = Driver.FindElements(By.XPath("//*[@class=\"create-grid\"]")).ToList();

            //afisare lista 
            for (int i = 0; i <= gridValues.Count; i++)
            {
                Console.WriteLine($"Elementul cu nr i este {i}");
                Console.WriteLine(gridValues[i].Text);
            }


            string[,] matrix = new string[3, 3];

            int index2 = 0;
            for (int i = 0; i <= 2; i++)
            {
                //Console.WriteLine(gridValues[i].Text);

                
                Console.WriteLine($"The count is : {gridValues.Count}");
               


                for(int j = 0; j <=2; j++)
                {
                    matrix[i, j] = gridValues[index2].Text;

                    Console.WriteLine(matrix[i,j]);
                }
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
/*public static void NestedLoopTest()
       {
           var personList = new List<string>() { "Radu", "Marius", "Iulian", "Noemi", "Romana" };

           var favoriteFoods = new List<string>() { "Chicken", "Shaorma", "Pizza", "Fried Potatoes", "Sarmale", "Mici" };

           for (int i = 0; i < personList.Count; i++)
           {
               var person = personList[i];

               if (person == "Marius")
               {
                   Console.Write($"{person}'s favorite foods are: ");
                   for (int j = 0; j < favoriteFoods.Count; j++)
                   {
                       var food = favoriteFoods[j];
                       if (food == "Pizza")
                       {
                           Console.Write($"{food}; ");
                           break;
                       }
                       Console.WriteLine($"The current food is: {food} ");
                   }
                   Console.WriteLine();
                   break;
               }

               Console.WriteLine($"The current person is: {person}");*/