using Microsoft.VisualBasic.FileIO;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
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

            Dictionary<string, string> Phonebook = new Dictionary<string, string>();
            Phonebook.Add("Ahmed", "99112288");
            Phonebook.Add("Ali", "93344214");
            Phonebook.Add("Khalid", "95674382");
            foreach (var phone in Phonebook)
            {
                Console.WriteLine($"Name: {phone.Key}");

            }
            Console.Write("Enter a name to search: ");
            string searchName = Console.ReadLine();

            if (Phonebook.ContainsKey(searchName))
            {
                Console.WriteLine($"Phone number: {Phonebook[searchName]}");
            }
            else
            {
                Console.WriteLine("Sorry, that name is not in the phonebook.");
            }

        }
    }
}
