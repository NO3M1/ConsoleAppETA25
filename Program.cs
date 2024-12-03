using System.Threading.Channels;
using ConsoleAppETA25;








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





            Console.ReadKey();
        
    






