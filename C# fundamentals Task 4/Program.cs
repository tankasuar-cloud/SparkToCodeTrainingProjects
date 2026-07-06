namespace C__fundamentals_Task_4
{
    internal class Program
    {
        public static void PrintWelcome(string name)
        { 
            Console.WriteLine($"Welcome {name}");
        }
        static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            PrintWelcome(name);
        }
        }
    }

