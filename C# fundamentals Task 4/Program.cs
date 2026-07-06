
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

        public static double CalculateArea(double A){  return A*A; }
        public static double CalculateArea(double A, double B) {  return A*B; }
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
            Console.WriteLine("What shape do you want to calculate the area of? \n1)Square\n2)rectangle");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("please enter the square length: ");
                    double square = double.Parse(Console.ReadLine());
                    Console.WriteLine($"The area of the square is {CalculateArea(square)}");
                    break;

                case 2:
                    Console.Write("please enter the rectangle length: ");
                    double length = double.Parse(Console.ReadLine());
                    Console.Write("please enter the rectangle width: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.WriteLine($"The area of the rectangle is {CalculateArea(length, width)}");
                        break;
            }

    }
}
}


