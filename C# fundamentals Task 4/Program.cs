
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
        public static string GetGradeLetter(int score)
        {
            string result;
            if (score >= 90)
            {
                result = "A";

            }
            else if (score >= 80)
            {
                result = "B";
            }
            else if (score >= 70)
            {
                result = "C";
            }
            else if (score >= 60)
            {
                result = "D";
            }
            else
            {
                result = "F";


            }
            return result;
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

            Console.WriteLine("Please enter your score: ");
            int score = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your Grade is {GetGradeLetter(score)}");

        }

    }
}


