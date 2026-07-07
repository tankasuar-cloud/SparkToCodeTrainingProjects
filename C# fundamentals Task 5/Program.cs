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


            //List<string> todo = new List<string>();


            //for (int i = 0; i < 5; i++)
            //{ 
            //    Console.WriteLine("Add a task to to-do list: ");
            //    string task = Console.ReadLine();
            //    todo.Add(task);
            //}
            //int taskNumber = 1;
            //Console.WriteLine("\n--- Your To-Do List ---");
            //foreach (string task in todo)
            //{
            //    Console.WriteLine($"{taskNumber}. {task}");
            //    taskNumber++;
            //}



            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 3:

            //Stack<string> PageHistor= new Stack<string>();
            //for (int i = 0; i < 3; i++) 
            //{
            //    Console.Write($"Enter website URL {i + 1}: ");
            //    PageHistor.Push(Console.ReadLine());
            //}
            //Console.WriteLine("\n--- pressing Back Button ---");
            //string removedPage = PageHistor.Pop();

            //var topItem = PageHistor.Peek();
            //Console.WriteLine($"Now landing on: {topItem}");


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 4:

            Queue<string>line = new Queue<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name for customer {i + 1}: ");
                string name = Console.ReadLine();
                line.Enqueue(name);
            }
            Console.WriteLine("\n--- Serving Customers ---");
            string customer = line.Dequeue();
            Console.WriteLine($"Now serving customer {customer}");

    }
    }
}

