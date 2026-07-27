using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_Commerce
{
    internal class Program
    {
        // Shared DbContext - created ONCE, here, so every function below reuses
        // the exact same instance instead of each function opening its own.
        static AppDbContext context = new AppDbContext();
        // Shared login state - 0 means "nobody is logged in".
        // Set by Login(), read by any function that requires a logged-in user,
        // reset back to 0 by Logout().
        static int loggedInUserId = 0;
        static void Main(string[] args)
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\n===== E-Commerce Console App =====");
                Console.WriteLine(" 1. Register New User");
                Console.WriteLine(" 2. Login");
                Console.WriteLine(" 3. Add New Category");
                Console.WriteLine(" 4. Add New Product");
                Console.WriteLine(" 5. View All Products");
                Console.WriteLine(" 6. Place an Order");
                Console.WriteLine(" 7. View My Orders");
                Console.WriteLine(" 8. View Order Details");
                Console.WriteLine(" 9. Add a Review for an Order");
                Console.WriteLine("10. View All Reviews for a Product");
                Console.WriteLine("11. Logout");
                Console.WriteLine(" 0. Exit");
                Console.Write("Enter your choice: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine()??"");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                switch (choice)
                {
                    case 1: RegisterUser(); break;
                    case 2: Login(); break;
                    case 3: AddCategory(); break;
                    case 4: AddProduct(); break;
                    case 5: ViewAllProducts(); break;
                    case 6: PlaceOrder(); break;
                    case 7: ViewMyOrders(); break;
                    case 8:ViewOrderDetails(); break;      
                    case 9: AddReview(); break;
                    case 10: ViewReviewsForProduct(); break;
                    case 11: Logout(); break;
                    case 0:
                        exitApp = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        // ===================== FUNCTIONS =====================
        // Every function below talks to the console itself AND uses the
        // shared "context" field declared above - never create a new
        // AppDbContext() inside any of these functions.
        static void RegisterUser()
        {
            Console.WriteLine("--- REGISTER NEW USER ---");
            Console.WriteLine("Please enter your full name: ");
            Console.Write("Full Name: ");
            string name = Console.ReadLine()??"";
            Console.WriteLine("Please enter your Email: ");
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter your Password: ");
            Console.Write("Password: ");
            string Pass = Console.ReadLine() ?? "";
            if(name == null || email == null || Pass == null)
            {
                Console.WriteLine("Name, Email or Password cannot be empty");
                return;
            }
            bool emailExists = context.Users.Any(u => u.Email.ToLower() == email.ToLower());
            if (emailExists)
            {
                Console.WriteLine("\nError: An account with this email already exists.");
                return;
            }
            User newUser = new User
            {
                FullName = name,
                Email = email,
                Password = Pass
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            Console.WriteLine($"Success! User '{newUser.FullName}' registered successfully with User ID: {newUser.UserId}");
        }
        static void Login()
        {
            Console.WriteLine("--- USER LOGIN ---");
            Console.WriteLine("Please enter your Email: ");
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter your Password: ");
            Console.Write("Password: ");
            string Pass = Console.ReadLine() ?? "";
            var loggedinUser = context.Users.FirstOrDefault(u=>u.Email.ToLower() == email.ToLower() && u.Password == Pass);
            if (loggedinUser != null)
            {
                loggedInUserId = loggedinUser.UserId; // Set active session
                Console.WriteLine($"Welcome back, {loggedinUser.FullName}! Logged in successfully.");
            }
            else
            {
                Console.WriteLine("Error: Invalid email or password.");
            }
        }
        static void AddCategory()
        {
            Console.WriteLine("--- ADD Category ---");
            Console.Write("Please enter the category name: ");
            string cname = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(cname))
            {
                Console.WriteLine("Error: Category name cannot be empty.");
                return;
            }
            bool exists = context.Categories.Any(c => c.CategoryName.ToLower() == cname.ToLower());
            if (exists)
            {
                Console.WriteLine($"Error: Category '{cname}' already exists.");
                return;
            }
            Category cat = new Category
            {
                CategoryName = cname
            };
            context.Categories.Add(cat);
            context.SaveChanges();
            Console.WriteLine($"Success! Category '{cat.CategoryName}' created with ID: {cat.CategoryId}");
        }
        static void AddProduct()
        {
            Console.WriteLine("--- ADD Product ---");
            var categories = context.Categories.ToList();
            if (!categories.Any())
            {
                Console.WriteLine("Error: No categories found. Please add a category first.");
                return;
            }
            Console.Write("Please enter the Product name: ");
            string Pname = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(Pname))
            {
                Console.WriteLine("Error: Category name cannot be empty.");
                return;
            }
            bool exists = context.Products.Any(c => c.ProductName.ToLower() == Pname.ToLower());
            if (exists)
            {
                Console.WriteLine($"Error: Category '{Pname}' already exists.");
                return;
            }
            Console.Write("Please Enter the price: ");
            decimal pri;
            try 
            { 
                pri = decimal.Parse(Console.ReadLine() ?? "");
                if (pri < 0)
                {
                    Console.WriteLine("Please enter a positive number.");
                    return;
                }
            } catch (FormatException) { Console.WriteLine("Invalid Number"); return; }
            Console.WriteLine("Available Categories:");
            foreach (var cat in categories)
            {
                Console.WriteLine($"ID: {cat.CategoryId} | Name: {cat.CategoryName}");
            }
            Console.Write("Enter Category ID for this product: ");
            int opion;
            try
            {
                opion = int.Parse(Console.ReadLine() ?? "");
                if ( !categories.Any(c => c.CategoryId == opion))
                {
                    Console.WriteLine("Error: Selected Category ID does not exist."); return;
                }
            }
            catch (FormatException) { Console.WriteLine("Invalid Number"); return; }
            Product pro = new Product
            {
                ProductName = Pname,
                Price = pri,
                CategoryId = opion
            };
            context.Products.Add(pro);
            context.SaveChanges();
            Console.WriteLine($"Success! Product '{pro.ProductName}' created with ID: {pro.ProductId}");

        }
        static void ViewAllProducts()
        {
            var categories = context.Categories.ToList();

            Console.WriteLine("Available Categories:");
            Console.WriteLine("ID: 0 | Name: All Categories");
            foreach (var cat in categories)
            {
                Console.WriteLine($"ID: {cat.CategoryId} | Name: {cat.CategoryName}");
            }

            Console.Write("Enter Category ID for this product (Or 0 for all Products) : ");
            int opion;
            try
            {
                opion = int.Parse(Console.ReadLine() ?? "");
                if (opion != 0 && !categories.Any(c => c.CategoryId == opion))
                {
                    Console.WriteLine("Error: Selected Category ID does not exist.");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
                return;
            }

            var query = context.Products.Include(p => p.Category).AsQueryable();

            if (opion != 0)
            {
                query = query.Where(p => p.CategoryId == opion);
            }

            var productList = query.ToList();

            if (!productList.Any())
            {
                Console.WriteLine("\nNo products found.");
                return;
            }

            Console.WriteLine("\nAvailable Products:");
            foreach (var pro in productList)
            {
                Console.WriteLine($"ID: {pro.ProductId} | Name: {pro.ProductName} | Price: {pro.Price:F2} OMR | Category: {pro.Category?.CategoryName}");
            }
        }
        static void PlaceOrder()
        {
            // TODO: implement - check loggedInUserId != 0 first
        }
        static void ViewMyOrders()
        {
            // TODO: implement - check loggedInUserId != 0 first
        }
        static void ViewOrderDetails()
        {
            // TODO: implement
        }
        static void AddReview()
        {
            // TODO: implement - check loggedInUserId != 0 first
        }
        static void ViewReviewsForProduct()

        {
            // TODO: implement
        }
        static void Logout()
        {
            // TODO: implement - reset loggedInUserId back to 0
        }
    }
}
