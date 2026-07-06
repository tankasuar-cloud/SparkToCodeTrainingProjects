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

        public static int Square(int number)
        {
            int result = number * number;
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

            Console.Write("Please enter a number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Square root of {number} is: {Square(number)}");

        }
    }

}


