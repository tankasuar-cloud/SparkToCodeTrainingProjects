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



            //Task 3 - Inventory Price Scanner
            //Create a Dictionary<string, double> to store item names and their prices.
            //Use a while loop to let a store manager keep entering items and prices until they type "stop".
            //Afterward, ask the user to type an item name to check its price.
            //Requirements:
            //Use a loop that saves items into the dictionary using user input.
            //Print the full inventory list with names and prices before asking the user to search.


            Dictionary<string, double> inventory = new Dictionary<string, double>();
            bool is_running = true;
            while (is_running)
            {
                
                    Console.Write("Please enter item name (or type 'exit' to finish): ");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "exit")
                    {
                        is_running = false;
                        continue;
                    }
                try
                {
                    Console.Write($"Please enter a price for {name}: ");
                    double price = double.Parse(Console.ReadLine());
                    if (!inventory.ContainsKey(name))
                    {
                        inventory.Add(name, price);
                    }
                    else
                    {
                        Console.WriteLine("Item already exists in inventory.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid Price");
                }
                }
            is_running = true;
            Console.WriteLine("\n--- Current Inventory ---");
            foreach (var item in inventory)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine("------------------------");
            while (is_running)
            {
                Console.Write("Enter an item name to check its price (or type 'exit' to quit): ");
                string searchName = Console.ReadLine();
                if (searchName.ToLower() == "exit")
                {
                    is_running = false;
                }
                else if (inventory.ContainsKey(searchName))
                {
                    Console.WriteLine($"Price: {inventory[searchName]}");
                    Console.WriteLine("------------------------");
                }
                else
                {
                    Console.WriteLine("Item not found in inventory.\n");
                    Console.WriteLine("------------------------");
                }
            }
        }
    }
}
