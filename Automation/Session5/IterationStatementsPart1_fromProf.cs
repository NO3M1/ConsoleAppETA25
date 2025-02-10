using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace ConsoleAppETA25.Automation.Session5
{
    internal class IterationStatementsPart1_fromProf
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

        [TestCase("Accounting, Maths, English, Chemistry, Commerce, Computer Science")]
        [TestCase("Maths, Computer Science, Accounting, Arts, Social Studies")]
        [TestCase("Biology, Hindi, History, Civics")]
        public void AddRemoveSubjectLoopTest(string subjectsString)
        {
            var subjects = subjectsString.Split(", ").ToList();
            AccessPracticeForm();

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 200);");

            // Initializam webElement-ul pentru Subjects input
            IWebElement subjectsInput = Driver.FindElement(By.Id("subjectsInput"));

            //Trimitem si selectam pe baza criteriilor in camp  
            AddSubjects(subjectsInput, subjects);

            //Identificare buton de delete subiect din input field
            //IWebElement subjectDeleteButtonV1 = Driver.FindElement(By.XPath($"//div[contains(@class,\"multiValue\")][./div[text()=\"{userInputSubject1}\"]]/div[2]"));
            //IWebElement subjectDeleteButtonV2 = Driver.FindElement(By.XPath("//div[contains(@class,\"multiValue\")][./div[text()=\"English\"]]/div[contains(@class, \"__remove\")]"));
            //IWebElement subjectDeleteButtonV3 = Driver.FindElement(By.XPath("//div[text()=\"English\"]/following-sibling::div"));
            //IWebElement subjectDeleteButtonV4 = Driver.FindElement(By.XPath("//div[text()=\"English\"]/parent::div/div[2]"));

            //IWebElement subjectDeleteButtonV5 = Driver.FindElement(By.XPath($"//div[contains(@class,\"multiValue\")][./div[text()=\"{userInputSubject2}\"]]/div[2]"));

            RemoveSubjects(subjects);

            // Assert
            Assert.That(SubjectExists(subjects[0]) == true);

            // Sleep
            Thread.Sleep(5000);
        }

        [Test]
        public void SelectOnlyOddNumberedGridItemsTest()
        {
            AccessInteractionsSelectableGridTab();

            // Selector for rows
            By rowsSelector = By.XPath("//div[starts-with(@id,'row')]");

            // List to store the rows
            List<IWebElement> rowsList = Driver.FindElements(rowsSelector).ToList();

            // We iterate the rows list
            for (int i = 0; i < rowsList.Count; i++)
            {
                // List to store the cells for each row
                List<IWebElement> rowCellsList = rowsList[i].FindElements(By.XPath("./li")).ToList();

                // We iterate the cells list
                for (int j = 0; j < rowCellsList.Count; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            rowCellsList[j].Click();
                            Console.WriteLine($"Clicked on '{rowCellsList[j].Text}' cell!");
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            rowCellsList[j].Click();
                            Console.WriteLine($"Clicked on '{rowCellsList[j].Text}' cell!");
                        }
                    }
                }
            }

            // Define selector for assert selected rowCell
            By rowCellSelector = By.XPath("//div/li[contains(@class,'active')]");

            // List to store the active cells
            List<IWebElement> activeCells = Driver.FindElements(rowCellSelector).ToList();

            List<string> selectedCellsTextList = new List<string>() { "One", "Three", "Five", "Seven", "Nine" };

            // Iterating the lists to assert active cells
            foreach (IWebElement rowCell in activeCells)
            {
                var cellText = rowCell.Text;
                Assert.That(selectedCellsTextList.Contains(cellText), Is.True);
            }
        }


        [Test]
        public void SelectOnlyOddNumberedGridItemsShortTest()
        {
            AccessInteractionsSelectableGridTab();

            // Selector for rows
            By rowsCellsSelector = By.XPath("//div[starts-with(@id,'row')]/li");

            // Define selector for assert selected rowCell
            By rowActiveCellSelector = By.XPath("//div/li[contains(@class,'active')]");

            // List to store the cells
            List<IWebElement> cellsList = Driver.FindElements(rowsCellsSelector).ToList();

            for (int i = 0; i < cellsList.Count; i += 2)
            {
                cellsList[i].Click();
                Console.WriteLine($"Clicked on '{cellsList[i].Text}' cell!");
            }

            // List to store the active cells
            List<string> activeCellsText = Driver.FindElements(rowActiveCellSelector)
                .Select(cell => cell.Text)
                .ToList();

            // Criteria list for assertion
            List<string> selectedCellsTextList = new List<string>() { "One", "Three", "Five", "Seven", "Nine" };

            activeCellsText.ForEach(cell => Assert.That(selectedCellsTextList.Contains(cell), Is.True));

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

        public void AddSubjects(IWebElement inputField, List<string> subjects)
        {
            foreach (string subject in subjects)
            {
                inputField.SendKeys(subject);
                inputField.SendKeys(Keys.Enter);

                Console.WriteLine($"Added the following item to subjects: {subject}");
            }
        }

        public void RemoveSubjects(List<string> subjects)
        {
            for (int i = subjects.Count - 1; i > 0; i--)
            {
                RemoveSubject(subjects[i]);

                Console.WriteLine($"Removed the following item from the list: {subjects[i]}");
            }
        }

        public bool SubjectExists(string subjectName)
        {
            var startingXpath = "//div[contains(@class,\"multiValue\")]";
            var subjectWebElements = Driver.FindElements(By.XPath(startingXpath));
            List<string> subjectsText = new List<string>();

            foreach (var subject in subjectWebElements)
            {
                subjectsText.Add(subject.Text);
            }

            foreach (var text in subjectsText)
            {
                if (text.Trim() == subjectName)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveSubject(string subjectName)
        {
            var startingXpath = "//div[contains(@class,\"multiValue\")][./div[text()=\"";
            var endingXpath = "\"]]/div[2]";
            IWebElement subjectButton = Driver.FindElement(By.XPath($"{startingXpath}{subjectName}{endingXpath}"));

            subjectButton.Click();
        }

        public void AccessPracticeForm()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By formsSelector = By.XPath("//h5[text()='Forms']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement formsButton = Driver.FindElement(formsSelector);

            // Dam click pe element
            formsButton.Click();

            // Definim si initializam selector-ul pentru "Practice Form" side menu option
            By practiceFormSelector = By.XPath("//span[text()='Practice Form']");

            // Initialiam webElement-ul pentru Practice Form
            IWebElement practiceFormOption = Driver.FindElement(practiceFormSelector);

            // Dam click pe Practice Form option
            practiceFormOption.Click();
        }

        public void AccessInteractionsSelectableGridTab()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By interactionsSelector = By.XPath("//h5[text()='Interactions']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement interactionsButton = Driver.FindElement(interactionsSelector);

            // Dam click pe element
            interactionsButton.Click();

            // Definim si initializam selector-ul pentru "Selectable" side menu option
            By selectableSelector = By.XPath("//span[text()='Selectable']");

            // Initializam webElement-ul pentru Selectable
            IWebElement selectableOption = Driver.FindElement(selectableSelector);

            // Dam click pe Selectable option
            selectableOption.Click();

            // Definim si initializam selector-ul pentru "Grid" tab
            By gridTabSelector = By.Id("demo-tab-grid");

            // Initializam webElement-ul pentru Grid tab
            IWebElement gridTab = Driver.FindElement(gridTabSelector);

            // Dam click pe Grid tab
            gridTab.Click();

            // Scroll
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
        }

        public void SelectDateFromCalendar(string currentYear, string currentMonthName, string currentMonthDay)
        {
            // Identificam si initializam dateOfBirth input
            IWebElement dateOfBirthInput = Driver.FindElement(By.Id("dateOfBirthInput"));

            // Deschidem calendarul
            dateOfBirthInput.Click();

            // Initializam un Select element pentru year dropown
            IWebElement yearDropdownWe = Driver.FindElement(By.XPath("//select[contains(@class, \"year-select\")]"));
            var yearDropdown = new SelectElement(yearDropdownWe);

            // Selectam luna
            yearDropdown.SelectByValue(currentYear);

            // Initializam un Select element pentru month dropown
            IWebElement monthDropdownWe = Driver.FindElement(By.XPath("//select[contains(@class, \"month-select\")]"));
            var monthDropdown = new SelectElement(monthDropdownWe);

            // Selectam luna
            monthDropdown.SelectByText(currentMonthName);

            // Selectam ziua
            IWebElement dayOfCurrentMonth = Driver.FindElement(By.XPath($"//div[text()=\"{currentMonthDay}\" and not(contains(@class, \"--outside-month\"))]"));
            dayOfCurrentMonth.Click();
        }

        public void AccessWidgets()
        {
            // Definim si initializam un selector (pentru a identifica unic un nod in DOM-ul paginii)
            By widgetsSelector = By.XPath("//h5[text()='Widgets']");

            // Initializam un webElement care ne permite interactiunea cu elementul din pagina
            IWebElement widgetsButton = Driver.FindElement(widgetsSelector);

            // Dam click pe element
            widgetsButton.Click();

            // Definim si initializam selector-ul pentru "Select Menu" side menu option
            By selectMenuSelector = By.XPath("//span[text()='Select Menu']");

            // Initialiam webElement-ul pentru Select Menu
            IWebElement selectMenuOption = Driver.FindElement(selectMenuSelector);

            // Dam click pe Select Menu option
            jsExecutor.ExecuteScript("window.scrollTo(0, 500);");
            selectMenuOption.Click();
        }

        [Test]
        public void WidgetMenuTest()
        {
            AccessWidgets();

            By firstDropdownSelector = By.Id("withOptGroup");
            IWebElement firstDropdown = Driver.FindElement(firstDropdownSelector);

            firstDropdown.Click();

            By fdHiddenMenuSelector = By.XPath(".//div[contains(@class, '-menu')]");
            IWebElement fbHiddenMenu = firstDropdown.FindElement(fdHiddenMenuSelector);
            Console.WriteLine(fbHiddenMenu.Text);

            SelectDropdownOption(fbHiddenMenu, groupName: "Group 2", optionName: "Group 2, option 2");




            Thread.Sleep(5000);
        }

        public void SelectDropdownOption(IWebElement parentElem, string optionName, string? groupName = null)
        {
            By groupSelector = By.XPath(".//div[contains(@class, '-group')]");
            By optionParentSelector = By.XPath("./parent::div//div[contains(@class, '-option')]");
            By optionSelector = By.XPath(".//div[contains(@class, '-option')]");
            if (string.IsNullOrEmpty(optionName) || string.IsNullOrWhiteSpace(optionName))
                throw new Exception("Please define the option!");

            if (!string.IsNullOrEmpty(groupName) || !string.IsNullOrWhiteSpace(groupName))
            {
                IEnumerable<IWebElement> groups = parentElem.FindElements(groupSelector);

                IWebElement group = groups.First(group => group.Text.Trim().ToLower() == groupName.ToLower());
                Console.WriteLine("Group name: " + group.Text);

                IEnumerable<IWebElement> options = group.FindElements(optionSelector);
                IWebElement option = options.First(option => option.Text.Trim().ToLower() == optionName.ToLower());
                Console.WriteLine("Option name: " + option.Text);

                option.Click();
                return;
            }

            IWebElement option2 = parentElem.FindElements(optionSelector).First(option => option.Text == optionName);
            option2.Click();
        }
    }
}
