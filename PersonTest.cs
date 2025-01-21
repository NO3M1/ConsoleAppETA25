using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleAppETA25
{

    /*PRACTICE
       In the “Person” class add the following:
       •
       A class attribute “List<string> Skills“ – to store the list of skills for the person.
       •
       A parameterized method to add a skill to the person.
           •
       This method also outputs to the console the name of the newly added skill.
       •
       A method to output to console all the skills of the person:
       •
       Use either for or foreach statements to output the list to console.
       •
       If the currently output skill is “Ninja” DO NOT display it.
       •
       If the currently output skill is “CIA” then exit the loop and output “Classified information, no further skills are displayed!”.*/

    public static class PersonTest
    {
        // person details hardcoded

        public static string FirstName = "Noemi";
        public static string LastName = "Sz";
        public static int Age = 15;
        public static string Gender = "Female";



        public static List<string> Skills = new List<string>();

        public static int UserAgeAfterX(int x)

        {
            var result = Age + x;
            Console.WriteLine($"The user will be {result} after {x} years");
            return result;
        }

        //display the user details

        [Test]
        public static void DisplayUserDetails()

        {
            Console.WriteLine();
            Console.WriteLine(" ");
            Console.WriteLine("Your details are as follows:");
            Console.WriteLine($"\t-First name: {FirstName}");
            Console.WriteLine($"\t-Last name: {LastName}");
            Console.WriteLine($"\t-Gender : {Gender}");
            UserAgeAfterX(55);

        }

        [Test]
        public static void IsOld()
        {
            if (Age >= 100)
            {
                Console.WriteLine("You are ancient!");
            }
            else if (Age >= 50)
            {
                Console.WriteLine("You are old!");

            }
            else if (Age < 50)
            {
                Console.WriteLine("You are still young!");
            }
            else
            {
                Console.WriteLine("Unspecified category");
            }

        }

        [Test]

        public static void ShowGender()
        {
            switch (Gender)
            {
                case "male":
                    Console.WriteLine("You are a male");
                    break;
                case "female":
                    Console.WriteLine("You are a female");
                    break;
                default:
                    Console.WriteLine("You haven`t specified your gender");
                    break;
            }

        }

        [Test]
        public static void TestTheAbove()
        {

            DisplayUserDetails();
            IsOld();
            ShowGender();

        }


        public static void AddSkills(string skill)
        {
            Skills.Add(skill);
            Console.WriteLine($"The added new skill of {FirstName} is: {skill}");
        }



        public static void DisplaySkills()
        {

            Console.WriteLine($"{FirstName} has the following skills: " );


            foreach (string skill in Skills)
            {
                if (skill == "Ninja")
                {
                    continue;
                }
                Console.WriteLine(skill);

                if (skill == "CIA")
                {
                    Console.WriteLine("Classified information, no further skills are displayed!");
                    
                    break;
                }
               
            }


        }

        [Test]
        public static void AddAndDisplaySkills()
        {
            AddSkills("Ninja");
            AddSkills("Reading");
            AddSkills("Testing"); 
            AddSkills("CIA");

            DisplaySkills();
        }




        /*In the “Person” class add the following:
        •
        A “CountTo” parameterized method that receives a number and prints to console all the numbers up to that number:
        •
        Use while or do-while statements to output the numbers to console.
        •
        If the currently output number is 10 DO NOT display it, instead output “Number skipped!” message.
        •
        If the currently output number is 99 then exit the loop and output “Cannot count past 99!”);
        
         */


        [TestCase(100)]
        public static void CountToTest(int numbers)
        {
            var currentNumber = 0;
           
            while (currentNumber <= numbers)
            {
              

                currentNumber++;
                if (currentNumber == 10)
                {
                    Console.WriteLine($"Number skipped {currentNumber}");
                    continue;
                }

                else if (currentNumber == 99)
                {
                    Console.WriteLine("Cannot past 99");
                    break;
                }
                else
                {
                    Console.WriteLine($"{currentNumber}");
                }
                
            }
            Console.WriteLine("Exited the WHILE loop");
        }

    }
}
