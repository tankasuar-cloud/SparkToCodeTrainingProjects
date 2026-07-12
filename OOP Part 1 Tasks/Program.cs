

using System.Xml;

namespace OOP_Part_1_Tasks
{
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; set; }
        private void SendEmail()
        {
            Console.WriteLine("Email sent.");
        }
        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount.");
            }
            else
            {
                Balance += amount;
                SendEmail();
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds..");
            }
            else
            {

                Balance -= amount;
                SendEmail();
            }
        }
        public double CheckBalance()
        {
            PrintInformation();
            return Balance;
        }
        private void PrintInformation()
        {
            Console.WriteLine($"Name: {HolderName}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }
    public class Student
    {
        public int Grade { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        private string email;
        int age;
        public void Register(string Email)
        {
            email = Email;
            SendEmail();
        }
        private void SendEmail()
        {
            Console.WriteLine("Email sent.");
        }
    }
    public class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        private void LogTransaction()
        {
            Console.WriteLine("LogTransaction");
        }
        public void Sell(int quantity)
        {
            if (quantity > StockQuantity)
            {
                Console.WriteLine("not enough stock");
            }
            else
            {
                StockQuantity -= quantity;

            }
            LogTransaction();
        }
        public void Restock(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine("Invalid amount.");
            }
            else
            {
                StockQuantity += quantity;
                LogTransaction();
            }
        }
        public double GetInventoryValue()
        {
            PrintDetails();
            return Price * StockQuantity;
        }
        private void PrintDetails()
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"Product name: {ProductName}");
            Console.WriteLine($"Product Price: {Price}");
            Console.WriteLine($"StockQuantity : {StockQuantity}");
            Console.WriteLine("==============================");
        }
    }
    internal class Program
    {
        static BankAccount account1 = new BankAccount { AccountNumber = 1163, HolderName = "karim", Balance = 120 };
        static BankAccount account2 = new BankAccount { AccountNumber = 15203, HolderName = "Ali", Balance = 63 };

        static Student student1 = new Student { Name = "Ali", Address = "Muscat", Grade = 65 };
        static Student student2 = new Student { Name = "Ahmed", Address = "Muscat", Grade = 70 };

        static Product product1 = new Product { ProductName = "Wireless Mouse", Price = 5.500, StockQuantity = 50 };
        static Product product2 = new Product { ProductName = "Mechanical Keyboard", Price = 15.750, StockQuantity = 20 };
        static void Main(string[] args)
        {


            bool is_running = true;
            while (is_running)
            {
                Console.WriteLine("\n===== Welcome to App =====");
                Console.WriteLine("1. Case 1 - View Account Details");
                Console.WriteLine("2. Case 2 - Update Student Address");
                Console.WriteLine("3. Case 3 - Make a Deposit");
                Console.WriteLine("4. Case 4 - Make a Withdrawal");
                Console.WriteLine("5. Case 5 - View Product Details");
                Console.WriteLine("6. Case 6 - Register a Student");
                Console.WriteLine("7. Case 7 - Compare Two Account Balances");
                Console.WriteLine("8. Case 8 - Restock Product & Stock Level Check");
                Console.WriteLine("9. Case 9 - Transfer Between Accounts");
                Console.WriteLine("10. Case 10 - Update Student Grade");
                Console.WriteLine("11. Case 11 - Student Report Card");
                Console.WriteLine("20. Exit");
                Console.Write("Choose an option: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine() ?? "");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue;
                }
                switch (choice)
                {
                    case 1: ViewAccountDetails(); break;
                    case 2: UpdateStudentAddress(); break;
                    case 3: MakeDeposit(); break;
                    case 4: MakeWithdrawal(); break;
                    case 5: ViewProductDetails(); break;
                    case 6: RegisterStudent(); break;
                    case 7: CompareAccountBalance(); break;
                    case 8: RestockProduct(); break;
                    case 9: TransferBetweenAccounts(); break;
                    case 10: UpdateStudentGrade(); break;
                    case 11: StudentReportCard(); break;

                    case 20: is_running = false; break;

                }
                Console.WriteLine("press any key.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static BankAccount ChooseAccount()
        {
            Console.WriteLine("==============================");
            Console.Write("Enter 1 for Karim's account or 2 for Ali's account: ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                return null;
            }
            return (choice == 1) ? account1 : (choice == 2) ? account2 : null;
        }

        static Student ChooseStudent()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Select a student:");
            Console.Write("Enter 1 for Ali or 2 for Ahmed: ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                return null;
            }
            return (choice == 1) ? student1 : (choice == 2) ? student2 : null;
        }

        static Product ChooseProduct()
        {
            Console.WriteLine("==============================");
            Console.Write("Enter 1 for (Wireless Mouse) or 2 for (Mechanical Keyboard): ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                return null;
            }
            return (choice == 1) ? product1 : (choice == 2) ? product2 : null;
        }
        //////////////////////////////////////////////////////////////////////////////

        static void ViewAccountDetails()
        {
            BankAccount selectedA = ChooseAccount();
            if (selectedA != null)
            {
                selectedA.CheckBalance();
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void UpdateStudentAddress()
        {
            Student selected = ChooseStudent();
            if (selected != null)
            {
                Console.Write("Please enter the new address: ");
                string addr = Console.ReadLine() ?? "";
                selected.Address = addr;
                Console.WriteLine("Address updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void MakeDeposit()
        {
            BankAccount selected = ChooseAccount();
            if (selected == null)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine($"Account Balance: {selected.Balance}");
            Console.Write("Enter the amount: ");

            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a Valid number");
                return;
            }

            selected.Deposit(amount);
            Console.WriteLine("\n=========================");
            Console.WriteLine($"Account name: {selected.HolderName}");
            Console.WriteLine($"Account new Balance: {selected.Balance}");
        }

        static void MakeWithdrawal()
        {
            BankAccount selected = ChooseAccount();
            if (selected == null)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine($"Account Balance: {selected.Balance}");
            Console.Write("Enter the amount: ");

            double amount;
            try
            {
                amount = double.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a Valid number");
                return;
            }

            selected.Withdraw(amount);
            Console.WriteLine("\n=========================");
            Console.WriteLine($"Account name: {selected.HolderName}");
            Console.WriteLine($"Account new Balance: {selected.Balance}");
        }

        static void ViewProductDetails()
        {
            Product selected = ChooseProduct();
            if (selected != null)
            {
                Console.WriteLine($"Inventory Value: {selected.GetInventoryValue()}");
                Console.WriteLine("==============================");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
        //////////////////////////////////////////////////////////////////////////////

        static void RegisterStudent()
        {
            Student selected = ChooseStudent();
            if (selected != null)
            {
                Console.WriteLine("Please enter an email: ");
                string mail = Console.ReadLine() ?? "";
                selected.Register(mail);
                Console.WriteLine($"Email successfully registered!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
        static void CompareAccountBalance()
        {
            Console.WriteLine("--- Select the First Account ---");
            BankAccount Selected1 = ChooseAccount();

            Console.WriteLine("--- Select the Second Account ---");
            BankAccount Selected2 = ChooseAccount();

            if (Selected1 == null || Selected2 == null)
            {
                Console.WriteLine("Invalid selection made. Comparison cancelled.");
                return;
            }

            if (Selected1.Balance > Selected2.Balance)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"{Selected1.HolderName}'s account has more balance than {Selected2.HolderName}.");
            }
            else if (Selected2.Balance > Selected1.Balance)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"{Selected2.HolderName}'s account has more balance than {Selected1.HolderName}.");
            }
            else
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Both accounts have the same balance.");
            }
        }
        static void RestockProduct()
        {
            Product selected = ChooseProduct();
            if (selected != null)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Please enter the amount to restock: ");
                int restock;
                try
                {
                    restock = int.Parse(Console.ReadLine() ?? "");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a Valid number");
                    return;
                }
                if (restock <= 0)
                {
                    Console.WriteLine("Error: Restock amount must be greater than zero.");
                    return;
                }
                selected.Restock(restock);
                Console.WriteLine("==============================");
                if (selected.StockQuantity < 10)
                {
                    Console.WriteLine("Low Stock level");
                }
                else if (selected.StockQuantity >= 10 && selected.StockQuantity <= 49)
                {
                    Console.WriteLine("Moderate Stock level");
                }
                else
                {
                    Console.WriteLine("Well Stocked");
                }

            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
        //////////////////////////////////////////////////////////////////////////////
        static void TransferBetweenAccounts()
        {
            Console.WriteLine("--- Select Source Account ---");
            BankAccount selected1 = ChooseAccount();

            Console.WriteLine("--- Select Destination Account ---");
            BankAccount selected2 = ChooseAccount();

            if (selected1 == null || selected2 == null)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Transfer failed: One or both accounts do not exist.");
                return;
            }

            if (selected1 == selected2)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Source and destination accounts cannot be the same.");
                return;
            }

            Console.WriteLine("==============================");
            Console.Write("Enter the transfer amount: ");
            double transferAmount;
            try
            {
                transferAmount = double.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            if (transferAmount <= 0)
            {
                Console.WriteLine("Error: Transfer amount must be greater than zero.");
                return;
            }

            if (transferAmount > selected1.Balance)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Transfer failed: Insufficient funds in source account.");
            }
            else
            {
                selected1.Withdraw(transferAmount);
                selected2.Deposit(transferAmount);
                Console.WriteLine("==============================");
                Console.WriteLine("Transfer successful!");
                Console.WriteLine($"{selected1.HolderName}'s new balance: {selected1.Balance}");
                Console.WriteLine($"{selected2.HolderName}'s new balance: {selected2.Balance}");
                Console.WriteLine("==============================");
            }
        }
        static void UpdateStudentGrade()
        {
            Student selected = ChooseStudent();
            if (selected == null)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine("==============================");
            Console.Write("Please enter the new grade (0-100): ");
            int grade;
            try
            {
                grade = int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the grade.");
                return;
            }

            if (grade < 0)
            {
                Console.WriteLine("Invalid input, grade cannot be less than 0");
                return;
            }
            else if (grade > 100)
            {
                Console.WriteLine("Invalid input, grade cannot be more than 100");
                return;
            }
            selected.Grade = grade;
            Console.WriteLine($"Successfully updated grade to {selected.Grade} for {selected.Name}!");
        }
        static void StudentReportCard()
        {
            Student selected = ChooseStudent();
            if (selected != null)
            {
                Console.WriteLine($"Student Name: {selected.Name}\n" +
                    $"Student Grade: {selected.Grade}\n" +
                    $"Student Address: {selected.Address}");
                string pass = (selected.Grade >= 60) ? "Pass" : "Fail";
                Console.WriteLine(pass);
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
        }
    }
}
    

