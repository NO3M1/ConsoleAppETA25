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
    internal class PersonTest
    {
        // person details hardcoded

        public static string FirstName = "Noemi";
        public static string LastName = "Sz";
        public static int Age = 1582;
        public static string Gender = "female";

   
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


        public static void TestTheAbove()
        {
            DisplayUserDetails();
            IsOld();
            ShowGender();
        }

    }

}
