namespace C__Fundamentals_Tasks_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // problem 1:
            //        bool is_running = true;
            //        while (is_running)
            //        {
            //            try
            //            {
            //                Console.WriteLine("Enter First Number: ");
            //                double FirstNumber = double.Parse(Console.ReadLine());
            //                Console.WriteLine("Enter Second Number: ");
            //                double SecondNumber = double.Parse(Console.ReadLine());
            //                double resault = SecondNumber - FirstNumber;
            //                double absoluteResault = Math.Abs(resault);
            //                Console.WriteLine("The absolute value of the difference is: " + absoluteResault);
            //                is_running = false;
            //            }
            //            catch(FormatException)
            //            {
            //                Console.WriteLine("Invalid input. Please enter a valid number.");
            //            }
            //}


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //problem 2:

            //bool is_running = true;
            //while (is_running)
            //{
            //    try
            //    {
            //        Console.WriteLine("Enter A Number: ");
            //        double Number = double.Parse(Console.ReadLine());
            //        double squareRoot = Math.Sqrt(Number);
            //        double pwr = Math.Pow(Number, 2);
            //        Console.WriteLine($"Square root = {squareRoot}, Square = {pwr}");
            //        is_running = false;
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //    }
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //problem 3:
            
                
                    Console.WriteLine("Please enter your full name: ");
                    string fullName = Console.ReadLine();
                    string nameUpperCase = fullName.ToUpper();
                    string nameLowerCase = fullName.ToLower();
                    int nameLength = fullName.Length;
                    Console.WriteLine($"Uppercase: {nameUpperCase}\nLowercase: {nameLowerCase}\nLength: {nameLength}");
                    
                
            }
        }
    }

