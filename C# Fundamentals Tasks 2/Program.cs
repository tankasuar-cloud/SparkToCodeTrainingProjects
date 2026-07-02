using System.Runtime.InteropServices;

namespace C__Fundamentals_Tasks_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Problem 1: 

            //Console.Write("Enter a number: ");
            //int num1 = int.Parse(Console.ReadLine());
            //for (int i = num1; i >= 1; i--) 
            //{ 
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("Liftoff!");


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 2:

            //Console.Write("Enter a positive whole number: ");
            //int num1 = int.Parse(Console.ReadLine());
            //int sum = 0;
            //for (int i = 1; i <= num1; i++) 
            //{

            //    sum += i;

            //}
            //Console.WriteLine("The sum from 1 to " + num1 + " is: " + sum);


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 3:

            //Console.Write("Enter a number: ");
            //int num1 = int.Parse(Console.ReadLine());
            //int sum = 0;
            //int i = 0;
            //for ( i=0; i <= 10; i++)
            //{ 
            //    Console.WriteLine(num1 + "X" + i + "=" + (num1 * i));
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 4:
            string password = "Spark2026";
            bool passwordCorrect = false;
            while(passwordCorrect == false)
            {
                Console.Write("Enter the password: ");
                string userInput = Console.ReadLine();
                if (userInput != password)
                {
                    Console.WriteLine("wrong password");
                }
                else
                {
                    Console.WriteLine("Correct password");
                    passwordCorrect = true;
                }


    }
}
}
}



