using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Start");
            Console.WriteLine("2) Help");
            Console.WriteLine("3) Exit");
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
            DisplayMenu();

        }
    }

}


