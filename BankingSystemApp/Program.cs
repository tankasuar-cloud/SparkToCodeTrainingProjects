using System;
using System.Collections.Generic;
namespace BankingSystemApp
{
    internal class Program
    {
        // Shared data storage - declared at class level (static) so that
        // EVERY function below can read and modify the same three lists
        // without needing them passed in as parameters.
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();
        static void Main(string[] args)
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. Show All Accounts);
                Console.WriteLine("7. <your 2nd custom service - choose a name>");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; // skip the rest of this loop pass, show the menu again
                }
                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        // TODO: call your first custom service function here
                        AllAccounts();
                        break;
                    case 7:
                        // TODO: call your second custom service function here
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }
        // ===================== SERVICE FUNCTIONS =====================
        // Each function owns ONE service end-to-end: it asks the user for
        // whatever it needs, validates it, updates the shared lists, and
        // prints the outcome. Main never reads input or prints results
        // for these services - it only shows the menu and calls them.
        static void AddAccount()
        {
            // TODO: implement this service (see Section 3 requirements)
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter Customer name: ");
            string name = Console.ReadLine();
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter Customer Account number: ");
            string num = Console.ReadLine();
            if (accountNumbers.Contains(num))
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("account number already exist, Please enter a different account number.");
                return;
            }
            double depositt = 0;
            try
            {
                Console.WriteLine("-------------------------------------");
                Console.Write($"Please enter Customer {name} initial deposit amount: ");
                depositt = double.Parse(Console.ReadLine());
                if (depositt < 0)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"The initial deposit amount cannot be less than 0");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Please enter a valid number for the initial deposit amount");
                return;
            }

            customerNames.Add(name);
            accountNumbers.Add(num);
            balances.Add(depositt);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\nAccount created successfully");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Account name: {name}");
            Console.WriteLine($"Account number: {num}");
            Console.WriteLine($"balance: {depositt}");

        }

        static void DepositMoney()
        {
            // TODO: implement this service (see Section 3 requirements)
            int index = 0;
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter the Account number: ");
            string accountNumberr = Console.ReadLine();
            if (accountNumbers.Contains(accountNumberr))
            {
                index = accountNumbers.IndexOf(accountNumberr);
            }
            else
            {
                Console.WriteLine($"Account number {accountNumberr} does not exist.");
                return;
            }

            try
            {
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("Please enter the deposit amount: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Please enter a valid deposit (more than 0) ");
                    return;
                }
                balances[index] += amount;
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine($"New Balance for account {accountNumberr} is: {balances[index]} ");

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid deposit amount.");
                return;
            }
        }

        static void WithdrawMoney()
        {
            // TODO: implement this service (see Section 3 requirements)
            int index = 0;
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter the Account number: ");
            string accountNumberr = Console.ReadLine();
            if (accountNumbers.Contains(accountNumberr))
            {
                index = accountNumbers.IndexOf(accountNumberr);
            }
            else
            {
                Console.WriteLine($"Account number {accountNumberr} does not exist.");
                return;
            }
            try
            {
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("Please enter the Withdraw amount: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Please enter a valid Withdraw (more than 0) ");
                    return;
                }
                if (amount > balances[index])
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Insufficient funds");
                    return;

                }
                balances[index] -= amount;
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine($"New Balance for account {accountNumberr} is: {balances[index]} ");

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid Withdraw amount.");
                return;
            }

        }

        static void ShowBalance()
        {
            // TODO: implement this service (see Section 3 requirements)
            int index = 0;
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter the Account number: ");
            string accountNumberr = Console.ReadLine();
            if (accountNumbers.Contains(accountNumberr))
            {
                index = accountNumbers.IndexOf(accountNumberr);
            }
            else
            {
                Console.WriteLine($"Account number {accountNumberr} does not exist.");
                return;
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\nAccount Details ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Account name: {customerNames[index]}");
            Console.WriteLine($"Account number: {accountNumbers[index]}");
            Console.WriteLine($"balance: {balances[index]}");


        }

        static void TransferAmount()
        {
            // TODO: implement this service (see Section 3 requirements)
            int index1 = 0;
            int index2 = 0;
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter the Sender Account number: ");
            string accountNumberr = Console.ReadLine();
            if (accountNumbers.Contains(accountNumberr))
            {
                index1 = accountNumbers.IndexOf(accountNumberr);
            }
            else
            {
                Console.WriteLine($"Account number {accountNumberr} does not exist.");
                return;
            }

            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter the receiver Account number: ");
            string accountNumberr2 = Console.ReadLine();
            if (accountNumbers.Contains(accountNumberr2))
            {
                index2 = accountNumbers.IndexOf(accountNumberr2);
            }
            else
            {
                Console.WriteLine($"Account number {accountNumberr2} does not exist.");
                return;
            }
            Console.WriteLine("-------------------------------------");
            Console.Write("Please enter the transfer amount: ");
            double transfer = 0;
            try
            {


                transfer = double.Parse(Console.ReadLine());
                if (transfer <= 0)
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Invalid transfer amount (must be more than 0)");
                    return;
                }
                if (transfer > balances[index1])
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Insufficient funds");
                    return;

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid transfer amount number");
                return;
            }

            balances[index1] -= transfer;
            balances[index2] += transfer;
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("Transfer successful!");
            Console.WriteLine($"Sender ({accountNumberr}) updated balance: {balances[index1]}");
            Console.WriteLine($"Receiver ({accountNumberr2}) updated balance: {balances[index2]}");
            Console.WriteLine("-------------------------------------");

        }
        static void AllAccounts()
        {
            Console.WriteLine("\n-------------------------------------");
            if (accountNumbers.Count == 0)
            {
                Console.WriteLine("No accounts found in the system.");
                return;
            }
            for (int i = 0; i < accountNumbers.Count; i++)
            {
                Console.WriteLine("\n---- Account Details ----");
                Console.WriteLine(customerNames[i]);
                Console.WriteLine(accountNumbers[i]);
                Console.WriteLine(balances[i]);
                Console.WriteLine("\n-------------------------");
            }

        }

        // TODO: write two more void, no-parameter functions here for
        // your own custom services (option 6 and option 7)
    }
}