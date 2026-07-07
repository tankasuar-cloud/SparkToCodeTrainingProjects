namespace C__fundamentals_Task_5
{
    internal class Program
    {
        static void Main(string[] args)
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
                Console.Write(grade+ " ");
            }
        }
    }
}
