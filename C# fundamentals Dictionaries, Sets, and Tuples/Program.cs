using Microsoft.VisualBasic.FileIO;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Xml;
using System.Xml.Linq;

namespace C__fundamentals_Dictionaries__Sets__and_Tuples
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task 1 - Phonebook Lookup
            //Create a Dictionary<string, string> to hold 3 contact names and their phone numbers. Ask the user to input a name, then look up and print that person's phone number.
            //Requirements:
            //Initialize the dictionary with 3 hardcoded entries.
            //Use ContainsKey to check if the name exists before printing. If it does not exist, print a friendly error message.

            //Dictionary<string, string> Phonebook = new Dictionary<string, string>();
            //Phonebook.Add("Ahmed", "99112288");
            //Phonebook.Add("Ali", "93344214");
            //Phonebook.Add("Khalid", "95674382");
            //foreach (var phone in Phonebook)
            //{
            //    Console.WriteLine($"Name: {phone.Key}");

            //}
            //Console.Write("Enter a name to search: ");
            //string searchName = Console.ReadLine();

            //if (Phonebook.ContainsKey(searchName))
            //{
            //    Console.WriteLine($"Phone number: {Phonebook[searchName]}");
            //}
            //else
            //{
            //    Console.WriteLine("Sorry, that name is not in the phonebook.");
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////////



            //Task 2 - Unique Guest List
            //Create a HashSet<string> to manage a guest list for a party.
            //Use a loop to ask the user to enter 5 guest names.Print the final count of unique guests and then list out all the names.
            // Requirements:
            // Use.Add to insert the names into the HashSet<string>.
            // Notice and verify how entering the same name twice does not increase the count.

            //HashSet<string> guestList = new HashSet<string>();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write($"Please enter quest {i + 1} Name: ");
            //    string name = Console.ReadLine();
            //    guestList.Add(name);

            //}
            //Console.WriteLine($"\nTotal unique guests: {guestList.Count}");
            //foreach (string guest in guestList)
            //{
            //    Console.WriteLine($"- {guest}");
            //}



            ////////////////////////////////////////////////////////////////////////////////////////////////////



            //Task 3 - Inventory Price Scanner
            //Create a Dictionary<string, double> to store item names and their prices.
            //Use a while loop to let a store manager keep entering items and prices until they type "stop".
            //Afterward, ask the user to type an item name to check its price.
            //Requirements:
            //Use a loop that saves items into the dictionary using user input.
            //Print the full inventory list with names and prices before asking the user to search.


            //Dictionary<string, double> inventory = new Dictionary<string, double>();
            //bool is_running = true;
            //while (is_running)
            //{

            //        Console.Write("Please enter item name (or type 'exit' to finish): ");
            //        string name = Console.ReadLine();
            //        if (name.ToLower() == "exit")
            //        {
            //            is_running = false;
            //            continue;
            //        }
            //    try
            //    {
            //        Console.Write($"Please enter a price for {name}: ");
            //        double price = double.Parse(Console.ReadLine());
            //        if (!inventory.ContainsKey(name))
            //        {
            //            inventory.Add(name, price);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Item already exists in inventory.");
            //        }
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Enter a valid Price");
            //    }
            //    }
            //is_running = true;
            //Console.WriteLine("\n--- Current Inventory ---");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine(item.Key);
            //}
            //Console.WriteLine("------------------------");
            //while (is_running)
            //{
            //    Console.Write("Enter an item name to check its price (or type 'exit' to quit): ");
            //    string searchName = Console.ReadLine();
            //    if (searchName.ToLower() == "exit")
            //    {
            //        is_running = false;
            //    }
            //    else if (inventory.ContainsKey(searchName))
            //    {
            //        Console.WriteLine($"Price: {inventory[searchName]}");
            //        Console.WriteLine("------------------------");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Item not found in inventory.\n");
            //        Console.WriteLine("------------------------");
            //    }
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////////

            //Task 4 - Min-Max Tuple Generator
            //Write a program that asks the user to enter 5 integers into an array.
            //Pass this array to a separate function that finds both the lowest and the highest numbers,
            //and returns them together as a named tuple.
            //Requirements:
            //The function must accept an int[] and return a (int Min, int Max) tuple.
            //Call the function from your Main method and print the results clearly.
            //int[] numbers = new int[5];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.Write($"Please enter a number {i + 1}) ");
            //    int num = int.Parse(Console.ReadLine());
            //    numbers[i] = num;
            //}
            //var result = minmax(numbers);
            //Console.WriteLine($"Lowest Number: {result.Min}");
            //Console.WriteLine($"Highest Number: {result.Max}");


            ////////////////////////////////////////////////////////////////////////////////////////////////////

            //Task 5 - Shared Interests Checker
            //Create two separate HashSet<string> collections representing the favorite hobbies of two different friends.
            //Ask the user to enter 3 hobbies for Friend A, and 3 hobbies for Friend B.
            //Write a function that takes both sets and returns a tuple containing two things:
            //a new set of hobbies they share in common,
            //and a boolean indicating if they have any common interests at all.
            //Requirements:
            //Use a loop to gather input for each friend.
            //Use a loop or a set operation to find common elements.
            //Return a (HashSet<string> Common, bool HasCommon) tuple from the function and display the common list to the console.

            HashSet<string> friend1 = new HashSet<string>();
            HashSet<string> friend2 = new HashSet<string>();
            Console.WriteLine("Friend A");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Please enter hobby {i + 1}");
                friend1.Add(Console.ReadLine().ToLower().Trim());
            }
            Console.WriteLine("Friend B");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Please enter hobby {i + 1}");
                friend2.Add(Console.ReadLine().ToLower().Trim());
            }
            var result = FindSharedInterests(friend1, friend2);

            if (result.HasCommon)
            {
                Console.WriteLine("\nThey share these common hobbies:");
                foreach (string hobby in result.Common)
                {
                    Console.WriteLine($"- {hobby}");
                }
            }
            else
            {
                Console.WriteLine("\nThey have no hobbies in common.");
            }

        }



        //public static (int Min, int Max) minmax(int[] nums)
        //{
        //    Array.Sort(nums);
        //    int min = nums[0];
        //    int max = nums[nums.Length-1];
        //    return (min , max);
        //}

        public static (HashSet<string> Common, bool HasCommon) FindSharedInterests(HashSet<string> setA, HashSet<string> setB)
        {
            HashSet<string> shared = new HashSet<string>();
            foreach (string hobby in setA)
            {
                if (setB.Contains(hobby))
                {
                    shared.Add(hobby);
                }
            }
            bool evaluation = shared.Count > 0;
            return (shared, evaluation);

        }


    }
}
