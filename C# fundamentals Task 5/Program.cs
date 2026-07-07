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

            //Queue<string>line = new Queue<string>();
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.Write($"Enter name for customer {i + 1}: ");
            //    string name = Console.ReadLine();
            //    line.Enqueue(name);
            //}
            //Console.WriteLine("\n--- Serving Customers ---");
            //string customer = line.Dequeue();
            //Console.WriteLine($"Now serving customer {customer}");


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 5:



            //bool is_running = true;
            //while (is_running)
            //{
            //    try
            //    {
            //        int[] grades = new int[5];
            //        for (int i = 0; i < grades.Length; i++)
            //        {
            //            Console.Write($"Please enter grade for {i + 1}: ");
            //            int grad = int.Parse(Console.ReadLine());
            //            grades[i] = grad;
            //        }
            //        int sum = 0;
            //        foreach (int grade in grades)
            //        {
            //            sum += grade;
            //        }
            //        Array.Sort(grades);
            //        double total = (double)sum / grades.Length;
            //        Console.WriteLine("\n--- Lowest/highest numbers ---");
            //        Console.WriteLine($"the lowest number is the array is: {grades[0]}");
            //        int max = grades.Length - 1;
            //        Console.WriteLine($"the highest number in the array is: {grades[max]}");
            //        Console.WriteLine("\n--- Average ---");
            //        Console.WriteLine($"the average grade is: {total}");
            //        is_running = false;
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //    }
            //}


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 6:

            //List<string> Shopping = new List<string>();
            //bool is_running = true;
            //int i = 0;
            //while (is_running)
            //{
            //    Console.Write($"Please enter item {i} to the shopping list (or type 'done'): ");
            //    string item = Console.ReadLine();
            //    if (item.ToLower() == "done")
            //    {
            //        is_running = false;
            //    }
            //    else
            //    {
            //        Shopping.Add(item);
            //        i++;
            //    }
            //}
            //is_running = true;
            //while (is_running)
            //{
            //    int option = 0;
            //    try
            //    {
            //        Console.WriteLine("1) Remove an item for the list\n2) Exit");
            //        option = int.Parse(Console.ReadLine());

            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //        continue;
            //    }
            //    switch (option)
            //    {
            //        case 1:
            //            Console.WriteLine("\n---- Shopping list ----");
            //            foreach (string item in Shopping)
            //            {
            //                Console.WriteLine(item);
            //            }
            //            Console.WriteLine("----------------------- ");
            //            Console.WriteLine("Enter Item name to remove it from the list");
            //            string name = Console.ReadLine();
            //            if (Shopping.Contains(name))
            //            {
            //                Shopping.Remove(name);
            //                Console.WriteLine($"{name} has been removed.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Item not found.");
            //            }
            //            Console.WriteLine("\n---- Updated Shopping list ----");
            //            foreach (string item in Shopping)
            //            {
            //                Console.WriteLine(item);
            //            }
            //            Console.WriteLine("-----------------------");
            //            break;

            //        case 2:
            //            is_running=false;
            //            break;

            //        default:
            //            Console.WriteLine("Please choose either 1 or 2.");
            //            break;

            //    }

            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 7:

            //List<int> scores = new List<int>();

            //for (int i = 0; i < 5; i++)
            //{
            //    try
            //    {
            //        Console.Write($"Enter score for game {i + 1}: ");
            //        int score = int.Parse(Console.ReadLine());
            //        scores.Add(score);
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //        i--; 
            //    }
            //}

            //scores.Sort();
            //scores.Reverse();

            //Console.WriteLine("\n--- Podium Standings ---");
            //Console.WriteLine($"1st place: {scores[0]}");
            //Console.WriteLine($"2nd place: {scores[1]}");
            //Console.WriteLine($"3rd place: {scores[2]}");


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // problem 8:
            Stack<string> actions = new Stack<string>();
            bool is_running = true;
            while (is_running)
            {
                Console.Write("please enter an action (to exit type 'stop') : ");
                string action = Console.ReadLine();
                if (action.ToLower() == "stop")
                {
                    is_running = false;
                }
                else
                {
                    actions.Push(action);
                }
            }
           
            if (actions.Count >= 2)
            {
                string poppedAction1 = actions.Pop();
                string poppedAction2 = actions.Pop();
                Console.WriteLine("\n--- Removing ---");
                Console.WriteLine($"The first undo removed: {poppedAction1}");
                Console.WriteLine($"The second undo removed: {poppedAction2}");
            }
            else
            {
                Console.WriteLine("Not enough actions in history to perform two undos.");
            }
            Console.WriteLine("\n--- Remaining Actions on Stack ---");
            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }
        }
    }
}



