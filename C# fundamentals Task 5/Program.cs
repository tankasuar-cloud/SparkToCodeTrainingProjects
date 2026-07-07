namespace C__fundamentals_Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // problem 1:


            //bool is_running = true;
            //while (is_running)
            //{
            //    try
            //    {
            //        int[] grades = new int[5];
            //        for (int i = 0; i < grades.Length; i++)
            //        {
            //            Console.Write($"please enter a grade for Index {i}: ");
            //            int num = int.Parse(Console.ReadLine());
            //            grades[i] = num;
            //        }
            //        foreach (int grade in grades)
            //        {
            //            Console.Write(grade + " ");
            //        }
            //        is_running = false;
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //    }
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 2:


            List<string> todo = new List<string>();
            
                
            for (int i = 0; i < 5; i++)
            { 
                Console.WriteLine("Add a task to to-do list: ");
                string task = Console.ReadLine();
                todo.Add(task);
            }
            int taskNumber = 1;
            Console.WriteLine("\n--- Your To-Do List ---");
            foreach (string task in todo)
            {
                Console.WriteLine($"{taskNumber}. {task}");
                taskNumber++;
            }
                    
                
                
            


        }
    }
}
