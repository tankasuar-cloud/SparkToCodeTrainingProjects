

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
            public int Grade {  get; set; }
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
                    Console.WriteLine("2. Case 2 - Update Student Address");
                    Console.WriteLine("3. Case 3 - Make a Deposit");
                    Console.WriteLine("4. Case 4 - Make a Withdrawal");
                    Console.WriteLine("5. Case 5 - View Product Details");
                    Console.WriteLine("6. Case 6 - Register a Student");
                    Console.WriteLine("99. Exit");
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
                        case 1:
                        Console.WriteLine("==============================");
                        Console.Write("Enter 1 for Karim's account or 2 for Ali's account: ");
                            int choice2;
                            try
                            
                            {
                                choice2 = int.Parse(Console.ReadLine() ?? "");
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
                        ////////////////////
                        case 2:
                        Console.WriteLine("==============================");
                        Console.WriteLine("Select a student to edit the address for");
                        Console.Write("Enter 1 for Ali or 2 for Ahmed: ");
                        
                        try

                        {
                            choice2 = int.Parse(Console.ReadLine() ?? "");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                            continue;
                        }
                        Console.Write("Please enter the new address: ");
                        string addr = Console.ReadLine() ?? "";
                        if (choice2 == 1)
                        {
                            student1.Address = addr;
                            Console.WriteLine($"Address updated successfully! New address: {student1.Address}");
                        }
                        else if (choice2 == 2)
                        {
                            student2.Address = addr;
                            Console.WriteLine($"Address updated successfully! New address: {student2.Address}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        }
                        break;
                        //////////////////
                    case 3:
                        Console.WriteLine("==============================");
                        Console.Write("Enter 1 for Karim's account or 2 for Ali's account: ");
                        
                        try

                        {
                            choice2 = int.Parse(Console.ReadLine() ?? "");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                            continue;
                        }
                        double amount;
                        if (choice2 == 1)
                        {
                            Console.WriteLine($"Account Balance: {account1.Balance}");
                            Console.Write("Enter the amount: ");
                            
                            try

                            {
                                amount = double.Parse(Console.ReadLine() ?? "");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input. Please enter a Valid number");
                                continue;
                            }
                            account1.Deposit(amount);
                            Console.WriteLine("\n=========================");
                            Console.WriteLine($"Account name: {account1.HolderName}");
                            Console.WriteLine($"Account new Balance: {account1.Balance}");
                        }
                        else if (choice2 == 2)
                        {
                            Console.WriteLine($"Account Balance: {account2.Balance}");
                            Console.Write("Enter the amount: ");
                            try

                            {
                                amount = double.Parse(Console.ReadLine() ?? "");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input. Please enter a Valid number");
                                continue;
                            }
                            account2.Deposit(amount);
                            Console.WriteLine("\n=========================");
                            Console.WriteLine($"Account name: {account2.HolderName}");
                            Console.WriteLine($"Account new Balance: {account2.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        }
                        break;
                    ///////////////////

                    case 4:
                        Console.WriteLine("==============================");
                        Console.Write("Enter 1 for Karim's account or 2 for Ali's account: ");

                        try

                        {
                            choice2 = int.Parse(Console.ReadLine() ?? "");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                            continue;
                        }
                        if (choice2 == 1)
                        {
                            Console.WriteLine($"Account Balance: {account1.Balance}");
                            Console.Write("Enter the amount to Withdraw: ");

                            try

                            {
                                amount = double.Parse(Console.ReadLine() ?? "");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input. Please enter a Valid number");
                                continue;
                            }
                            account1.Withdraw(amount);
                            Console.WriteLine("\n=========================");
                            Console.WriteLine($"Account name: {account1.HolderName}");
                            Console.WriteLine($"Account new Balance: {account1.Balance}");
                        }
                        else if (choice2 == 2)
                        {
                            Console.WriteLine($"Account Balance: {account2.Balance}");
                            Console.Write("Enter the amount to Withdraw: ");
                            try

                            {
                                amount = double.Parse(Console.ReadLine() ?? "");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input. Please enter a Valid number");
                                continue;
                            }
                            account2.Withdraw(amount);
                            Console.WriteLine("\n=========================");
                            Console.WriteLine($"Account name: {account2.HolderName}");
                            Console.WriteLine($"Account new Balance: {account2.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        }
                        break;

                    ////////////////////

                    case 5:
                        Console.WriteLine("==============================");
                        Console.Write("Enter 1 for (Wireless Mouse) or 2 for (Mechanical Keyboard): ");

                        try

                        {
                            choice2 = int.Parse(Console.ReadLine() ?? "");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                            continue;
                        }
                        if (choice2 ==1 )
                        {
                            Console.WriteLine($"Inventory Value: {product1.GetInventoryValue()}");
                            Console.WriteLine("==============================");

                        }
                        else if (choice2 == 2)
                        {
                            Console.WriteLine($"Inventory Value: {product2.GetInventoryValue()}");
                            Console.WriteLine("==============================");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        }
                        break;

                    //////////////////////////////
                    case 6:
                    
                        Console.WriteLine("==============================");
                        Console.WriteLine("Select a student to register an email for.");
                        Console.Write("Enter 1 for Ali or 2 for Ahmed: ");

                        try

                        {
                            choice2 = int.Parse(Console.ReadLine() ?? "");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                            continue;
                        }
                        Console.WriteLine("Please enter an email: ");
                        string mail = Console.ReadLine() ?? "";
                        if (choice2 == 1)
                        {
                            
                            Console.WriteLine("==============================");

                            student1.Register(mail);
                            Console.WriteLine("Email updated successfully");

                        }
                        else if (choice2 == 2)
                        {
                            Console.WriteLine("==============================");

                            student2.Register(mail);
                            Console.WriteLine("Email updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        }
                        break;


                    //////////////////////////////


                    case 99:
                        is_running = false;
                        break;
                        
                    }
                }
            }
        }
    }
