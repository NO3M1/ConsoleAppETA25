using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleAppETA25
{
    public static class IterationStatements
    {
        [Test]
        public static void ForLoopTest()
        {
            var x = 10;
            for (var i = 0; i < x; i++)
            {
                Console.WriteLine($"For output when 'i' is : {i}"); // 0-9
            }

        }

        [TestCase(15)]
        public static void ForLoopTestParameter(int inputVal)
        {

            for (var i = 0; i < inputVal; i++)
            {
                Console.WriteLine($"For output when '{nameof(inputVal)}'  is : {i}"); //0-14
            }

            for (var i = inputVal; i > 0; i--)
            {
                Console.WriteLine($"Descending for output when '{nameof(inputVal)}'  is : {i}"); //15-1

            }
        }


        [Test]
        public static void ForEachLoopTest()
        {
            var letterList = new List<string>() { "ABC", "BCD", "CDE", "DEF", "A", "B", "C"};
            for (var i = 0; i < letterList.Count; i++)
            {
                Console.WriteLine($"The current list element is : {letterList[i]} ");
                //Console.WriteLine($"The cyrrent list element is (ByElementAt()) : {numberList.ElementAt(i)}\n ");
            }
            Console.WriteLine("Exited");

            foreach (var letter in letterList)
            {
                Console.WriteLine($"The current list element is (using foreach): {letter}");
            }
            Console.WriteLine( "Exited");

        }

        [Test]
        public static void ForEachLoopReversedTest()
        {
            var numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 6, 7, 8, 8, 9 };
            for (var i = numberList.Count-1; i >= 0;  i--)
            {
                Console.WriteLine($"The current element in the reversed list order is : {numberList[i]} ");
                //Console.WriteLine($"The cyrrent list element is (ByElementAt()) : {numberList.ElementAt(i)}\n ");
            }
            Console.WriteLine("Exited");

            var numberListRev = numberList;
            numberListRev.Reverse();
            //numberListRev.ForEach(number => Console.WriteLine($"The current element in the reversed list order is (using foreach) : {number}"));


            foreach (var number in numberListRev)
            {
                Console.WriteLine($"The current element in the reversed list order is (using foreach) : {number}");
            }
            Console.WriteLine("Exited");

        }

        [Test]

        public static void NestedLoopTest()
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

                Console.WriteLine($"The current person is: {person}");

                //Console.Write($"{person}'s favorite foods are: ");
                //for (int j = 0; j < favoriteFoods.Count; j++)
                //{
                //    var food = favoriteFoods[j];
                //    Console.Write($"{food}; ");
                //}
                //Console.WriteLine();
            }
        }

        [Test]

        public static void ContinueTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    continue;
                }
                Console.WriteLine("The current number is: " + i);
            }

            

        }



    }

}
