using System.Runtime.InteropServices;
using System.Xml;

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
            //string password = "Spark2026";
            //bool passwordCorrect = false;
            //while(passwordCorrect == false)
            //{
            //    Console.Write("Enter the password: ");
            //    string userInput = Console.ReadLine();
            //    if (userInput != password)
            //    {
            //        Console.WriteLine("wrong password");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Correct password");
            //        passwordCorrect = true;
            //    }


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 5:

            //int secretNumber = 42;
            //bool numberGuessed = false;
            //int gusses = 1;
            //do
            //{
            //    Console.WriteLine("Guess the secret number between 1 and 100: ");
            //    int userInput = int.Parse(Console.ReadLine());
            //    if (userInput < secretNumber)
            //    {
            //        Console.WriteLine("Too low! Try again.");
            //        gusses++;
            //    }
            //    else if (userInput > secretNumber)
            //    {
            //        Console.WriteLine("Too high! Try again.");
            //        gusses++;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Congratulations! You guessed the secret number in " + gusses + " guesses.");
            //        numberGuessed = true;
            //    }

            //} while (numberGuessed == false);


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 6:

            //try
            //{
            //    Console.Write("Enter the first number: ");
            //    int num1 = int.Parse(Console.ReadLine());
            //    Console.Write("Enter the second number: ");
            //    int num2 = int.Parse(Console.ReadLine());

            //    double result = (double)(num1 / num2);
            //    Console.WriteLine("The result of dividing " + num1 + " by " + num2 + " is: " + result);
            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("Error: Cannot divide by zero.");
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 7:

            //bool menu = true;
            //while (menu)
            //{
            //    try { 
            //        Console.WriteLine("***********************Menu***********************");
            //        Console.WriteLine("1.Say Hello");
            //        Console.WriteLine("2.Greeting ");
            //        Console.WriteLine("3.Quit");
            //        int option = int.Parse(Console.ReadLine());
            //        Console.WriteLine("******************************************");
            //        switch(option)
            //        { 
            //            case 1:
            //                Console.WriteLine("Hello");
            //                break;

            //            case 2:
            //                Console.WriteLine("good morning");
            //                break;

            //            case 3:
            //                menu = false;
            //                break;

            //        }
            //    }
            //    catch(FormatException)
            //    {
            //           Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            //    }
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 8:


            //Console.Write("Enter a positive whole number: ");
            //int num1 = int.Parse(Console.ReadLine());
            //int sum = 0;
            //for (int i = 1; i <= num1; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        sum += i;
            //    }

            //}
            //Console.WriteLine("The sum of even numbers from 1 to " + num1 + " is: " + sum);


            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 9:

            //bool is_running = true;
            //int sum = 0;
            //int num1 = 0;
            //do
            //{
            //    try
            //    {
            //        Console.WriteLine("please enter a positive whole number: ");
            //        num1 = int.Parse(Console.ReadLine());
            //        if (num1 <= 0)
            //        {
            //            Console.WriteLine("Invalid input, please enter a positive whole number: ");
            //        }
            //        else
            //        {
            //            is_running= false;
            //        }
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            //    }


            //} while (is_running);

            //for (int i = 1; i <= num1; i++)
            //{
            //    sum += i;
            //}
            //Console.WriteLine("The sum from 1 to " + num1 + " is: " + sum);



            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Problem 9:

            int pin = 1234;
            double startingBalance = 100.000;
            bool is_running = true;
            int gusses = 0;
            bool bank = false;
            while (is_running)
            {
                try
                {
                    Console.WriteLine("Please enter your pin: ");
                    int userPin = int.Parse(Console.ReadLine());
                    if (userPin != pin)
                    {
                        gusses++;
                        Console.WriteLine("Incorrect pin, please try again.");
                        if (gusses == 3)
                        {
                            Console.WriteLine("You have entered the wrong pin 3 times, Card blocked.");
                            is_running = false;

                        }
                    }else
                    {
                        bank = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }


                while (bank == true)
                {
                    try
                    {
                        Console.WriteLine("******************************************");
                        Console.WriteLine("welcome to Bank:");
                        Console.WriteLine("1.Withdraw");
                        Console.WriteLine("2.Deposite");
                        Console.WriteLine("3.Balance check");
                        Console.WriteLine("4.Quit");
                        Console.WriteLine("choose an option: ");
                        int option = int.Parse(Console.ReadLine());
                        Console.WriteLine("******************************************");
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("your balance = " + startingBalance);
                                Console.WriteLine("enter amount to withdraw: ");
                                double withdraw = double.Parse(Console.ReadLine());
                                if (withdraw > startingBalance)
                                {
                                    Console.WriteLine("Insufficient funds.");
                                }
                                else if(withdraw <= 0)
                                {
                                    Console.WriteLine("Invalid withdraw amount. Please enter a positive value.");
                                }
                                else
                                {
                                    startingBalance -= withdraw;
                                    Console.WriteLine("your new balance = " + startingBalance);
                                    Console.WriteLine("your withdrawed amount = " + withdraw);
                                }
                                break;

                             case 2:
                                Console.WriteLine("your balance =" + startingBalance);
                                Console.WriteLine("enter amount to deposite: ");
                                double deposite = double.Parse(Console.ReadLine());
                                if (deposite <= 0)
                                {
                                    Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                                }
                                else
                                {
                                    startingBalance += deposite;
                                    Console.WriteLine("your new balance = " + startingBalance);
                                }
                                
                                Console.WriteLine("your new balance = " + startingBalance);
                                break;

                            case 3:
                                Console.WriteLine("your balance = " + startingBalance);
                                break;

                            case 4:
                                bank = false;
                                is_running = false;
                                break;


                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                    }
                }

            }
        }
    }
}

                    
                





