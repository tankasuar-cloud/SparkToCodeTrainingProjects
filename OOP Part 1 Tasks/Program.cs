

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
            Console.WriteLine("Hello, World!");
        }
    }
}
