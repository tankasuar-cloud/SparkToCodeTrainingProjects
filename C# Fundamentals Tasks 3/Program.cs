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


            //Console.WriteLine("Please enter your full name: ");
            //string fullName = Console.ReadLine();
            //string nameUpperCase = fullName.ToUpper();
            //string nameLowerCase = fullName.ToLower();
            //int nameLength = fullName.Length;
            //Console.WriteLine($"Uppercase: {nameUpperCase}\nLowercase: {nameLowerCase}\nLength: {nameLength}");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //problem 4:
            //bool is_running = true;
            //while (is_running)
            //{
            //    try
            //    {
            //        Console.WriteLine("Enter the free trial duration in days: ");
            //        int days = int.Parse(Console.ReadLine());
            //        DateTime today = DateTime.Now;
            //        DateTime trial = today.AddDays(days);

            //        Console.WriteLine("Trial expiration date: " + trial.ToString("yyyy-MM-dd"));
            //        is_running = false;
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //    }
            //}
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //problem 5:
            //bool is_running = true;
            //while (is_running)
            //{
            //    try
            //    {
            //        Console.WriteLine("Enter the raw exam score: ");
            //        double score = double.Parse(Console.ReadLine());
            //        int roundedScore = (int)Math.Round(score);
            //        if (roundedScore >= 60)
            //        {
            //            Console.WriteLine($"Rounded score = {roundedScore}");
            //            Console.WriteLine("Pass.");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Rounded score = {roundedScore}");
            //            Console.WriteLine("Fail.");
            //        }

            //        is_running = false;
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //    }
            //}
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //problem 6:


            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();
            int passwordLength = password.Length;
            bool contain = password.ToLower().Contains("password");
            
            if (passwordLength < 8 || contain)
            {
                Console.WriteLine("Weak password!");
                if (passwordLength <8 )
            {
                Console.WriteLine("Password must be at least 8 characters long.");
            }
            
                if (contain)
            {
                Console.WriteLine("Password must not contain the word 'password'.");
            }
            }
            else
            {
                Console.WriteLine("Strong password!");
            }
        }
    }
    }

