using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;

namespace ConsoleAppETA25
{
    internal class PersonTest2
    {

        public static string FirstName;
        public static string LastName;
        public static int Age;
        public static string Gender;

        //reading from console

        public static void ConsoleDetails()
        {
            Console.WriteLine("Please input your First name:");
             FirstName = Console.ReadLine();

            Console.WriteLine("Please input your Last name:");
             LastName = Console.ReadLine();

            Console.WriteLine("Please input your Age:");
             Age = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Please input your Gender:");
             Gender = Console.ReadLine();

        }

      

        public static int DisplayUserAgeAfterX(int x)
        {
            var result = Age + x;
            Console.WriteLine($"The user will be {result} after {x} years");
            return result;
        }

        public static void DisplayUserDetails()
        {

            Console.WriteLine(" ");
            Console.WriteLine("Your details are as follows:");
            Console.WriteLine("\t-First name:" + FirstName);
            Console.WriteLine($"\t-Last name: {LastName}");
            Console.WriteLine($"\t-Gender: {Gender}");
            Console.WriteLine($"\t-Age: {Age}");
            DisplayUserAgeAfterX(19);

        }

      
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
            else if (Age <50)
            {
                Console.WriteLine("You are still young!");
            }
            else
            {
                Console.WriteLine("Unspecified category");
            }
            
        }

        [Test]
        public static void Testing()
        {
            ConsoleDetails();
            DisplayUserDetails();
            IsOld();

        }

        /*i need help how to execute the code*/

    }
}
