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
        public static string LastName = "Szoke";
        public static int Age = 32;
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













    }
}
