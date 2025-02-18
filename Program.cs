using System.Threading.Channels;
using ConsoleAppETA25;


#region Older Sessions






// Console.WriteLine("Hello, World!");+

/*       int number = 10;
       const double Pi = 3.14159;
       Console.WriteLine(number);  
       Console.WriteLine(Pi);

       int i = default;
       float f = default;*/

//Console.WriteLine(i);

//Console.WriteLine("Ce varsta ai?");
//int varsta = Convert.ToInt16(Console.ReadLine());

//Console.WriteLine("Din ce oras esti?");
//string oras = Console.ReadLine();

//Console.WriteLine("Ai fost la vot?");
//bool aVotat = Convert.ToBoolean(Console.ReadLine());



//Console.WriteLine("Varsta introdusa de tine este: " + varsta);
//Console.WriteLine("Orasul introdus de tine: " + oras);

//Console.WriteLine("Varsta si orasul introduse de tine este: {0},{1}", varsta, oras);
//Console.WriteLine($"Varsta introdusa de tine este: {varsta}");

//Console.WriteLine($"Varsta si Orasul si votul introduse de tine sunt: {varsta}, {oras}, {aVotat}");



//Session - C# BAsics - Operators

Console.WriteLine($"The result of ADDITION is: {1 + 1} ");
            Console.WriteLine($"The result of SUBSTRACTION is: {3 - 1} ");
            Console.WriteLine($"The result of MULTIPLICATION is: {3 * 3} ");
            Console.WriteLine($"The result of DIVISION is: {5 / 5} ");
            Console.WriteLine($"The result of MODULUS is: {7 % 5} ");

            var x = 10;
            var y = x;
            /* Console.WriteLine($"The var 'x' has a value: {x} ");
             Console.WriteLine();
             Console.WriteLine($"After PRE INCREMENTTION var 'x' has a value: {x++} "); //10
             Console.WriteLine($"After POST INCREMENTTION var 'x' has a value: {++x} "); //11
             Console.WriteLine();
             Console.WriteLine($"After PREDECREMENTATION var 'x' has a value: {--x} ");
             Console.WriteLine($"After POST DECREMENTATION var 'x' has a value: {x--} ");
             Console.WriteLine($"The var 'x' has a value: {x} ");*/

            /*onsole.WriteLine($"The initial value of 'y' is: {y} ");  //10
            y += 5;
            Console.WriteLine($"The result of ADDITION is: {y} ");  //15

            y -=3;
            Console.WriteLine($"The result of SUBSTRACTION is: {y} "); //12

            y *= 2;
            Console.WriteLine($"The result of SUBSTRACTION is: {y} ");  //24

            y /= 2;
            Console.WriteLine($"The result of SUBSTRACTION is: {y} "); //12

            y %= 5;
            Console.WriteLine($"The result of SUBSTRACTION is: {y} ");  //2



            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"The result of '==' between '{x}' and '{y}' is: {x == y} "); 
            Console.WriteLine($"The result of '!=' between '{x}' and '{y}' is: {x != y} "); 
            Console.WriteLine($"The result of '>' between '{x}' and ' {y} ' is: {x > y} "); 
            Console.WriteLine($"The result of '<' between '{x}' and ' {y} ' is: {x < y} "); 
            Console.WriteLine($"The result of '>=' between '{x}' and ' {y} ' is: {x >= y} "); 
            Console.WriteLine($"The result of '<=' between '{x}' and '{y}' is: {x <= y} "); */

            bool raspuns = false;
            bool raspuns2 = true;


            Console.WriteLine($"The NEGATION of raspuns is : {!raspuns}");  //TRUE
            Console.WriteLine($"The && operation output is : {raspuns && raspuns2}");  //si - FALSE
            Console.WriteLine($"The ||  operation output is : {raspuns ||  raspuns2}"); //sau   - TRUE



            Console.WriteLine($"The value of 'x' from Session5 is: {Session5.x}");
            Console.WriteLine($"The value of 'y' from Session5 is: {Session5.y}");
            Session5.AddXAndY();  //apel al clasei
                                  //Console.WriteLine($"The result of heading x and y is: {Session5.AddTwoIntegers(9, 15)}"); //24



Console.WriteLine( " ");


//PERSONTEST

//PersonTest.StoreDetails();
//PersonTest.DisplayDetails();    
//PersonTest.UserAgeAfter20();
//PersonTest.DisplayUserDetails();

Console.WriteLine(" ");

//PERSONTEST2

//PersonTest2.ConsoleDetails();
//PersonTest2.DisplayUserDetails();    

#endregion

#region ETA - Session 16 

//ARRAYS

//int[] numbers = new int[2] { 1, 2 };
int[] numbers = [1, 2, 3, 4, 5];
string[] words = { "one", "two", "tree", "ten" };

string[] letters = { "A", "R", "R", "A", "Y", "S" };
string firstItem = letters[0];
string secondItem = letters[1];

Console.WriteLine($"The first item is: {firstItem}");
Console.WriteLine($"The second item is: {secondItem}");

string thridItem = letters[2];
Console.WriteLine($"The third item is: {thridItem}");
letters[2] = "X";
Console.WriteLine($"The updated third item is: {letters[2]}");

Console.Write("The 'letters' array consist of ");
for (int i =0; i < letters.Length; i++)
{
    Console.Write($"{letters[i]}; ");  //ARXAYS
}
Console.WriteLine();
Console.WriteLine("Multidimensional arrays (2D)");

//MULTIDIMIENSIONAL ARRAY (2D)

int[,] numbersMultiDim = new int[3, 4] { { 1, 2, 3, 4 }, {5, 6, 7, 8 }, {9, 10, 11, 12 } };
Console.WriteLine($"The second row - third cell is: {numbersMultiDim[1,2]}\n");
Console.WriteLine("The elements in the 2D are:");

//i = rand (3)
//j = coloana (4) 

/*for (int i =0; i < 3; i++) // or i<numbersmultidim.lenght 
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write($"Array[{i},{j}]: {numbersMultiDim[i, j]}   ");
    }
    Console.WriteLine("\n");
}*/

for (int i = 0; i < numbersMultiDim.GetLength(0); i++)
{
    Console.WriteLine("The size ofthe rows is: " + numbersMultiDim.GetLength(1));

    for (int j = 0; j < numbersMultiDim.GetLength(1); j++)
    {
        Console.Write($"Array[{i},{j}]: {numbersMultiDim[i, j]}   ");
    }
    Console.WriteLine("\n");
}

//JAGGED ARRAY

/*int[][] jaggedArray = new int[4][]
{
   new int[] { 1, 2, 3 },
   new int[] { 4, 5},
   new int[] { 6, 7, 8, 9},
   new int[] { 10 }

}*/

int[][] jaggedArray =
    [
        [1, 2, 3],
        [4, 5],
        [6, 7, 8, 9],
        [10]
    ];

Console.WriteLine("The contents of the jagged array");
for (int i = 0; i< jaggedArray.Length; i ++)
{
    Console.WriteLine($"The current row size is {jaggedArray[i].GetLength(0)}");
    for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
    {
        Console.WriteLine($"array[{i}][{j}]: {jaggedArray[i][j]}  ");
    }
    Console.WriteLine("\n");
}


// LISTS
/*
List<string> letterList = new List<string>() { "L", "I", "S", "T"};

Console.WriteLine($"First item in the list: {letterList[0]}");
Console.WriteLine($"Third item in the list: {letterList.ElementAt(2)}");
letterList[2] = "Z";
Console.WriteLine($"Third item in the list: {letterList.ElementAt(2)}");

Console.WriteLine("\n The list contains the following items: ");
foreach(string letter in letterList)
{
    Console.WriteLine($"{letter}; ");
}

Console.WriteLine();
Console.WriteLine($"The list size and capacity are: {letterList.Count} / {letterList.Capacity}");
letterList.Add("B");
foreach (string letter in letterList)
{
    Console.WriteLine($"{letter}; ");
}

Console.WriteLine($"The list size and capacity are: {letterList.Count} / { letterList.Capacity}");
letterList.Add("C");
foreach (string letter in letterList)
{
    Console.WriteLine($"{letter}; ");
}

Console.WriteLine($"The list size and capacity are: {letterList.Count} / {letterList.Capacity}");
letterList.Remove("I");

foreach (string letter in letterList)
{
    Console.WriteLine($"{letter}; ");
}
Console.WriteLine($"The list size and capacity are: {letterList.Count} / {letterList.Capacity}");

*/
#endregion



#region Homework

/*Write a C# console app that reads from the user a list of N numbers and then prints the following:
•
The list of items
•
The list of even items and then the list of odd items (as separate lists)
•
Calculates the sum of all the even numbers
•
Calculates the sum of all the odd numbers*/

//Get the size of the list

Console.Write("Please input the size of the list (N):");
int size = int.Parse(Console.ReadLine());

//List to store the numbers

List<int> numbersList = new List<int>();

for (int i = 0; i < size; i++)
{
    Console.Write($"Please input a number for list [{i}]: ");
    int num = int.Parse(Console.ReadLine());
    numbersList.Add(num);
}

// Display the list
Console.Write($"Your list contains the following items/numbers: "); 
foreach (int num in numbersList)
{
    Console.Write($"{num}" + "; ");
}

// List of even and odd numbers
List<int> evenNumbers = new List<int>();
List<int> oddNumbers = new List<int>();

foreach (int num in numbersList)
{
    if ( num % 2 == 0 ) // ex 2,4,6,8
    {
        evenNumbers.Add(num);
    }
    else
    {
        oddNumbers.Add(num);
    }
}

//Display the even and odd numbers list
Console.WriteLine("\nThe list of even number is: ");
foreach (int num in evenNumbers)
{
    Console.Write($"{num}" + "; ");
}

Console.WriteLine("\nThe list of odd number is: ");
foreach (int num in oddNumbers)
{
    Console.Write(($"{num}" + "; "));
}

//Calculates tge sum of even numbers
int sumEvenNumbers = evenNumbers.Sum();
Console.WriteLine($"\n The sum of the Even numbers is: {sumEvenNumbers}");

int sumOddNumbers = oddNumbers.Sum();
Console.WriteLine($"\n The sum of the Odd numbers is: {sumOddNumbers}");


#endregion

Console.ReadKey();