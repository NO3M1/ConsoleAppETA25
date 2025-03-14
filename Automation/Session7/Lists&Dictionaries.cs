using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleAppETA25.Automation.Session7
{
    internal class Lists_Dictionaries
    {
        [Test]
        public void TestDictionary()
        {
            Dictionary<string, string> objects = new Dictionary<string, string>
            {
                {"object1", "laptop"},
                {"object2", "apple"},
                {"object3", "ski" }
            };

            foreach (var obj in objects)
            {
                Console.WriteLine($"The key is: {obj.Key}");
                Console.WriteLine($"The value is: {obj.Value}");
            }
        }

        [Test]
        public void TestList() 
        { 
            Dictionary<string, List<string>> classifications = new Dictionary<string, List<string>>();
            List<string> citiesofRomania = new List<string> { "Cluj", "Huedin" };
            List<string> citiesofItaly = new List<string> { "Rome", "Fiumicino" };
            List<string> citiesofGermany = new List<string> { "Berlin", "Kol" };

            //adaugare 
            //classifications.Add("Romania", citiesofRomania);
            //or
            classifications["Romania"] = citiesofItaly;
            classifications["Italy"] = citiesofItaly;
            classifications["Germany"] = citiesofGermany;

            foreach (var key in  classifications.Keys)
            {
                Console.WriteLine($"The country is: {key}");
                Console.WriteLine("The cities are:" + string.Join(", ", classifications[key]));
            }

        }




    }
}
