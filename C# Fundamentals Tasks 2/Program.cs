using System.Runtime.InteropServices;

namespace C__Fundamentals_Tasks_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num1 = int.Parse(Console.ReadLine());
            for (int i = num1; i >= 1; i--) 
            { 
                Console.WriteLine(i);
            }
            Console.WriteLine("Liftoff!");
        }
    }
    }

