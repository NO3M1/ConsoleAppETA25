﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ConsoleAppETA25
{
    public static class ConditionalStatements
    {

        [Test]
        public static void IfStatementTest()
        {

            int x = 20;
            int y = 15;

            if (x > y)
            {

                Console.WriteLine("x is greater then y");
            }
            else if (x < y)
            {
                Console.WriteLine("x is smaller than y");
            }
            else 
            {
                Console.WriteLine("x is equal to y");
            }


            Console.WriteLine("Last test output line");

        
        }

        [Test]
        
        public static void SwitchStatementTest()
        {
            int dayOfWeek = 9;

            switch(dayOfWeek)
            {
                case 1:
                    Console.WriteLine("Today is Monday");
                    break;
                case 2:
                    Console.WriteLine("Today is Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Today is Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Today is Thursday");
                    break;

                case 5:
                    Console.WriteLine("Today is Friday");
                    break;

                case 6:
                    Console.WriteLine("Today is Saturday");
                    break;

                case 7:
                    Console.WriteLine("Today is Sunday");
                    break;
                default:
                    Console.WriteLine("invalid day number. A week only has 7 days");
                    break;


            }

            Console.WriteLine("Last output line of code");

        }

        [Test]
        public static void MetodaIf()
        {
            IfVerificareNumar(5, 12);
            IfVerificareNumar(21, 5);
            ElseIFCompareDigits(5);
            SwitchVerificareMasina("BMW");




        }

        public static void IfVerificareNumar(int x, int y)
        {
            if (x < y)
            {
                Console.WriteLine($"Numarul {x} este mai mic decat {y}");
            }
            else
            {
                Console.WriteLine($"Numarul {x} este mai mare decat {y}");
            }
        }


        public static void ElseIFCompareDigits (int x)
        {
            if (x < 5)
            {
                Console.WriteLine($"Numarul {x} este mai mic decat 5"); 
            }
            else if (x > 5)
            {
                Console.WriteLine($"Numarul {x} este mai mare decat 5");
            }
            else //if (x == 5)
            {
                Console.WriteLine($"Numarul {x} este egal cu 5");
            }

        }

        public static void SwitchVerificareMasina(string masina)
        {
           switch (masina)
            {
                case "Mercedes":
                    Console.WriteLine("Este disponibil Mercedes");
                        break;
                case "Opel":
                    Console.WriteLine("Este disponibil Opel");
                        break;
                case "BMW":
                    Console.WriteLine("Este disponibil BWM");
                    break;
                default:
                    Console.WriteLine("Masina nu este disponibila");
                    break;
            }
        }




    }
}
