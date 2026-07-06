
namespace C__fundamentals_Task_4
{
    internal class Program
    {
        //problem 1:
        //public static void PrintWelcome(string name)
        //{ 
        //    Console.WriteLine($"Welcome {name}");
        //}


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 2:

        //public static int Square(int number)
        //{
        //    int result = number * number;
        //    return result;

        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 3:
        //public static double CelsiusToFahrenheit(double Celsius)
        //{
        //    double Fahrenheit = (Celsius * 9 / 5) + 32;
        //    return Fahrenheit;
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 4:

        //public static void DisplayMenu()
        //{
        //    Console.WriteLine("Menu:");
        //    Console.WriteLine("1) Start");
        //    Console.WriteLine("2) Help");
        //    Console.WriteLine("3) Exit");
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 5:

        //public static bool IsEven(int number)
        //{
        //    return number % 2 == 0;
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 6:

        //public static double CalculateArea(double length, double width)
        //{ 
        //    double result = length * width;
        //    return result;
        //}
        //public static double CalculatePerimeter(double length, double width)
        //{
        //    double result = 2 * (length + width);
        //    return result;
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 7:

        //public static string GetGradeLetter(int score)
        //{
        //    string result;
        //    if (score >= 90)
        //    {
        //        result = "A";

        //    }
        //    else if (score >= 80)
        //    {
        //        result = "B";
        //    }
        //    else if (score >= 70)
        //    {
        //        result = "C";
        //    }
        //    else if (score >= 60)
        //    {
        //        result = "D";
        //    }
        //    else
        //    {
        //        result = "F";


        //    }
        //    return result;
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 8:
        //public static void Countdown(int number)
        //{
        //    for (int i = number; i >= 0; i--)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 9:

        //public static int Multiply(int a, int b)
        //{  return a * b; }
        //public static double Multiply(double a, double b)
        //{ return a * b; } 
        //public static int Multiply(int a, int b, int c)
        //{ return a * b * c; }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 10:


        //public static double CalculateArea(double A){  return A*A; }
        //public static double CalculateArea(double A, double B) {  return A*B; }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //problem 11:

        public static double AddNumbers(double a, double b) { return a + b; }

        public static double subNumbers(double a, double b) { return a - b; }

        public static double MultiplyNumbers(double a, double b) { return a * b; }

        public static double DivideNumbers(double a, double b) { if (b == 0) { return 0; } else { return a / b; } }

        public static void DisplayResult(string name, double result)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"The result of the {name} operation is: {result}");
            Console.WriteLine("-----------------------------------------");
        }

        static void Main(string[] args)
        {

            //problem 1:

            //Console.Write("What is your name? ");
            //string name = Console.ReadLine();
            //PrintWelcome(name);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 2:

            //Console.Write("Please enter a number: ");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Square root of {number} is: {Square(number)}");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 3:

            //Console.Write("Please enter a Celsius degree: ");
            //double Celsius = double.Parse(Console.ReadLine());
            //Console.WriteLine($"{Celsius} Celsius is equal to {CelsiusToFahrenheit(Celsius)} Fahrenheit");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 4:

            //DisplayMenu();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 5:

            //Console.Write("Please enter a number: ");
            //int number = int.Parse(Console.ReadLine());
            //bool result = IsEven(number);
            //if (result)
            //{
            //    Console.WriteLine($"{number} is an even number.");
            //}
            //else
            //{
            //    Console.WriteLine($"{number} is an odd number.");

            //}

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 6:

            //Console.Write("Please enter the length of the rectangle: ");
            //double length = double.Parse(Console.ReadLine());
            //Console.Write("Please enter the width of the rectangle: ");
            //double width = double.Parse(Console.ReadLine());
            //Console.WriteLine($"Area of the rectangle is: {CalculateArea(length, width)}");
            //Console.WriteLine($"Perimeter of the rectangle is: {CalculatePerimeter(length, width)}");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 7:

            //Console.WriteLine("Please enter your score: ");
            //int score = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Your Grade is {GetGradeLetter(score)}");


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 8:

            //Console.Write("Please enter a number: ");
            //int number = int.Parse(Console.ReadLine());
            //Countdown(number);


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 9:

            //// First Overload: Two ints
            //Console.Write("Please enter a value for X: ");
            //int x = int.Parse(Console.ReadLine());
            //Console.Write("please enter value for Y: ");
            //int y = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Two integers (X * Y) = {Multiply(x, y)}"); ;
            //Console.WriteLine("*****************************************************");
            //// Second Overload: Two doubles
            //Console.Write("Please enter a value for Z: ");
            //double z = double.Parse(Console.ReadLine());
            //Console.Write("Please enter a value for F");
            //double F = double.Parse(Console.ReadLine());
            //Console.WriteLine($"Two doubles (Z * F) = {Multiply(z, F)}");
            //Console.WriteLine("*****************************************************");
            //// Third Overload: Three ints
            //Console.Write("Please enter a value for A: ");
            //int A = int.Parse(Console.ReadLine());
            //Console.Write("please enter value for B: ");
            //int B = int.Parse(Console.ReadLine());
            //Console.Write("please enter value for C: ");
            //int C = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Three integers (A * B * C) = {Multiply(A, B, C)}");


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 10:
            //Console.WriteLine("What shape do you want to calculate the area of? \n1)Square\n2)rectangle");
            //int option = int.Parse(Console.ReadLine());
            //switch (option)
            //{
            //    case 1:
            //        Console.Write("please enter the square length: ");
            //        double square = double.Parse(Console.ReadLine());
            //        Console.WriteLine($"The area of the square is {CalculateArea(square)}");
            //        break;

            //    case 2:
            //        Console.Write("please enter the rectangle length: ");
            //        double length = double.Parse(Console.ReadLine());
            //        Console.Write("please enter the rectangle width: ");
            //        double width = double.Parse(Console.ReadLine());
            //        Console.WriteLine($"The area of the rectangle is {CalculateArea(length, width)}");
            //            break;
            //}

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //problem 11:

            bool is_running = true;
            while (is_running)
            {
                try
                {
                    Console.Write("1)Add\n2)subtract\n3)multiply\n4)Divide\n5)Exit\nplease Select the operation: ");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("-----------------------------------------");
                            Console.Write("Please enter the first number: ");
                            double num1 = double.Parse(Console.ReadLine());
                            Console.Write("please enter the second number: ");
                            double num2 = double.Parse(Console.ReadLine());
                            double result = AddNumbers(num1, num2);
                            DisplayResult("Addition", result);
                            break;

                        case 2:
                            Console.WriteLine("-----------------------------------------");
                            Console.Write("Please enter the first number: ");
                            double num3 = double.Parse(Console.ReadLine());
                            Console.Write("please enter the second number: ");
                            double num4 = double.Parse(Console.ReadLine());
                            double result2 = subNumbers(num3, num4);
                            DisplayResult("Subtraction", result2);
                            break;

                        case 3:
                            Console.WriteLine("-----------------------------------------");
                            Console.Write("Please enter the first number: ");
                            double num5 = double.Parse(Console.ReadLine());
                            Console.Write("please enter the second number: ");
                            double num6 = double.Parse(Console.ReadLine());
                            double result3 = MultiplyNumbers (num5, num6);
                            DisplayResult("Multiply", result3);
                            break;

                        case 4:
                            Console.WriteLine("-----------------------------------------");
                            Console.Write("Please enter the first number: ");
                            double num7 = double.Parse(Console.ReadLine());
                            Console.Write("please enter the second number: ");
                            double num8 = double.Parse(Console.ReadLine());
                            double result4 = MultiplyNumbers(num7, num8);
                            DisplayResult("Division ", result4);
                            break;

                        case 5:
                            is_running = false;
                            break;
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

        }
    }
}




