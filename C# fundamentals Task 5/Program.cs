namespace C__fundamentals_Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool is_running = true;
            while (is_running)
            {
                try
                {
                    int[] grades = new int[5];
                    for (int i = 0; i < grades.Length; i++)
                    {
                        Console.Write($"please enter a grade for Index {i}: ");
                        int num = int.Parse(Console.ReadLine());
                        grades[i] = num;
                    }
                    foreach (int grade in grades)
                    {
                        Console.Write(grade + " ");
                    }
                    is_running = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
