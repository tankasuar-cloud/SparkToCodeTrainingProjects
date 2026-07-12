

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
                }else
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
                    SendEmail();
                    Balance -= amount;
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
            public int Grade {  get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            private string email { get; set; }
            int age { get; set; }
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
                    LogTransaction();
                }
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
                Console.WriteLine($"Product name: {ProductName}");
                Console.WriteLine($"Product Price: {Price}");
                Console.WriteLine($"StockQuantity : {StockQuantity}");
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                BankAccount account1 = new BankAccount { AccountNumber = 1163, HolderName = "karim", Balance = 120 }; 
                BankAccount account2 = new BankAccount { AccountNumber = 15203, HolderName = "Ali", Balance = 63 };

                Student student1 = new Student { Name = "Ali", Address = "Muscat", Grade = 65 }; 
                Student student2 = new Student { Name = "Ahmed", Address = "Muscat", Grade = 70 };

                Product product1 = new Product { ProductName = "Wireless Mouse", Price = 5.500, StockQuantity = 50 };  
                Product product2 = new Product { ProductName = "Mechanical Keyboard", Price = 15.750, StockQuantity = 20 };

                bool is_running = true;
                while (is_running) 
                {
                    Console.WriteLine("\n===== Welcome to App =====");
                    Console.WriteLine("1. Case 1 - View Account Details");
                    Console.WriteLine("99. Exit");
                    Console.Write("Choose an option: ");
                    int choice;
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                        continue; 
                    }
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter 1 for Karim's account or 2 for Ali's account: ");
                            int choice2;
                            try
                            
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }catch (Exception)
                            {
                                Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                                continue;
                            }
                        if (choice2 == 1)
                        {
                            account1.CheckBalance();
                        }
                        else if (choice2 == 2)
                        {
                            account2.CheckBalance();
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        }
                        break;

                        case 2:



                        break;
                    }
                }
            }
        }
    }
