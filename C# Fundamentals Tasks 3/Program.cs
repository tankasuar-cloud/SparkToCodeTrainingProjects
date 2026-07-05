namespace C__Fundamentals_Tasks_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1:
            bool is_running = true;
            while (is_running)
            {
                try
                {
                    Console.WriteLine("Enter First Number: ");
                    double FirstNumber = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Second Number: ");
                    double SecondNumber = double.Parse(Console.ReadLine());
                    double resault = SecondNumber - FirstNumber;
                    double absoluteResault = Math.Abs(resault);
                    Console.WriteLine("The absolute value of the difference is: " + absoluteResault);
                    is_running = false;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
    }
}
}
}
