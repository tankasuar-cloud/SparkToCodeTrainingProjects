using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
                    case 8: ViewOrderDetails(); break;      
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
                Console.WriteLine($"Error: Product '{Pname}' already exists.");
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
            if (loggedInUserId == 0)
            {
                Console.WriteLine("No User Logged In");
                return;
            }

            var productlist = context.Products.Include(p => p.Category).ToList();
            if (!productlist.Any())
            {
                Console.WriteLine("No products available to order.");
                return;
            }

            Console.WriteLine("--- Available Products ---");
            foreach (var pro in productlist)
            {
                Console.WriteLine($"ID: {pro.ProductId} | Name: {pro.ProductName} | Price: {pro.Price:F2} OMR | Category: {pro.Category?.CategoryName}");
            }

            List<OrderProduct> cart = new List<OrderProduct>();
            bool is_running = true;

            while (is_running)
            {
                Console.Write("\nPlease Enter the product ID (Or 0 to Exit): ");
                int option;
                try
                {
                    option = int.Parse(Console.ReadLine() ?? "");
                    if (option == 0)
                    {
                        is_running = false;
                        continue;
                    }

                    var product = productlist.FirstOrDefault(p => p.ProductId == option);
                    if (product == null)
                    {
                        Console.WriteLine("Please enter a valid product ID.");
                        continue;
                    }

                    Console.Write($"Enter quantity for '{product.ProductName}': ");
                    int quantity = int.Parse(Console.ReadLine() ?? "");

                    if (quantity <= 0)
                    {
                        Console.WriteLine("Error: Quantity must be at least 1.");
                        continue;
                    }

                    cart.Add(new OrderProduct
                    {
                        ProductId = option,
                        Quantity = quantity
                    });

                    Console.WriteLine($"-> Added {quantity}x '{product.ProductName}' to your cart!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number");
                    continue;
                }
            }

            if (!cart.Any())
            {
                Console.WriteLine("No items in cart. Order canceled.");
                return;
            }

            Order newOrder = new Order
            {
                UserId = loggedInUserId,
                OrderDate = DateTime.Now
            };

            context.Orders.Add(newOrder);
            context.SaveChanges(); 

            foreach (var item in cart)
            {
                item.OrderId = newOrder.OrderId;
                context.OrderProducts.Add(item);
            }

            context.SaveChanges();

            Console.WriteLine($"============================================");
            Console.WriteLine($"Success! Order #{newOrder.OrderId} placed successfully.");
            Console.WriteLine($"============================================");
        }
        static void ViewMyOrders()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("Error: You must be logged in to view your orders.");
                return;
            }

            var userOrders = context.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Where(o => o.UserId == loggedInUserId)
                .ToList();

            if (!userOrders.Any())
            {
                Console.WriteLine("You have not placed any orders yet.");
                return;
            }

            Console.WriteLine("\n--- My Orders ---");
            foreach (var order in userOrders)
            {
                Console.WriteLine($"\n========================================");
                Console.WriteLine($"Order ID   : #{order.OrderId}");
                Console.WriteLine($"Order Date : {order.OrderDate:yyyy-MM-dd HH:mm}");
                Console.WriteLine($"Items:");

                decimal totalAmount = 0;
                foreach (var item in order.OrderProducts)
                {
                    decimal itemTotal = (decimal)(item.Quantity * item.Product.Price);
                    totalAmount += itemTotal;

                    Console.WriteLine($"  - {item.Product.ProductName} | Qty: {item.Quantity} | Unit Price: {item.Product.Price:F2} OMR | Subtotal: {itemTotal:F2} OMR");
                }

                Console.WriteLine($"Total Order Amount: {totalAmount:F2} OMR");
                Console.WriteLine($"========================================");
            }
        }
        static void ViewOrderDetails()
        {
            Console.Write("Enter Order ID: ");
            int orderId;
            try { orderId = int.Parse(Console.ReadLine()??""); } catch (FormatException) { Console.WriteLine("Invalid number");return; }

            var order = context.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Include(o => o.Review)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                Console.WriteLine($"Error: Order #{orderId} was not found.");
                return;
            }

            Console.WriteLine($"\n========================================");
            Console.WriteLine($"ORDER DETAILS FOR #{order.OrderId}");
            Console.WriteLine($"Date: {order.OrderDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine("Products Ordered:");

            decimal grandTotal = 0;
            foreach (var item in order.OrderProducts)
            {
                decimal itemTotal = (decimal)(item.Quantity * item.Product.Price);
                grandTotal += itemTotal;

                Console.WriteLine($"  * {item.Product.ProductName}");
                Console.WriteLine($"    Qty: {item.Quantity} | Unit Price: {item.Product.Price:F2} OMR | Subtotal: {itemTotal:F2} OMR");
            }

            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"ORDER TOTAL: {grandTotal:F2} OMR");
            Console.WriteLine($"----------------------------------------");

            if (order.Review != null)
            {
                Console.WriteLine($"Review:");
                Console.WriteLine($"  Rating : {order.Review.Rating}");
                Console.WriteLine($"  Comment: {order.Review.Comment}");
            }
            else
            {
                Console.WriteLine("Review: No review submitted for this order.");
            }

            Console.WriteLine($"========================================");
        }
        static void AddReview()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("Error: You must be logged in to add a review.");
                return;
            }
            Console.Write("Enter the Order ID you want to review: ");
            int orderId;
            try { orderId = int.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Invalid number"); return; }


            var order = context.Orders.Include(o => o.Review).FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                Console.WriteLine($"Error: Order #{orderId} does not exist.");
                return;
            }

            if (order.UserId != loggedInUserId)
            {
                Console.WriteLine($"Error: You can only review your own orders.");
                return;
            }
            if (order.Review != null)
            {
                Console.WriteLine($"Error: Order #{orderId} has already been reviewed.");
                return;
            }
            Console.Write("Enter Rating (1 to 5 stars): ");
            int rating;
            try
            {
                rating = int.Parse(Console.ReadLine() ?? "");
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine("Rating must be between 1 and 5.");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.Write("Enter your review comment: ");
            string comment = Console.ReadLine() ?? "";

            Review newReview = new Review
            {
                OrderId = orderId,
                Rating = rating,
                Comment = comment
            };

            context.Reviews.Add(newReview);
            context.SaveChanges();

            Console.WriteLine($"Success! Your review for Order #{orderId} has been posted.");
        }
        static void ViewReviewsForProduct()

        {

            Console.Write("Enter Product ID to view reviews: ");
            int productId;
            try{productId = int.Parse(Console.ReadLine() ?? "");}catch (FormatException){Console.WriteLine("Invalid number.");return; }

            var product = context.Products
                .Include(p => p.OrderProducts)
                    .ThenInclude(op => op.Order)
                        .ThenInclude(o => o.Review)
                .FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                Console.WriteLine($"Error: Product ID {productId} does not exist.");
                return;
            }

            var reviews = product.OrderProducts
                .Select(op => op.Order?.Review)
                .Where(r => r != null)
                .ToList();

            Console.WriteLine($"========================================");
            Console.WriteLine($"REVIEWS FOR PRODUCT: {product.ProductName}");
            Console.WriteLine($"========================================");

            if (!reviews.Any())
            {
                Console.WriteLine("No reviews found for this product yet.");
                return;
            }

            foreach (var review in reviews)
            {
                Console.WriteLine($"[Order #{review!.OrderId}]");
                Console.WriteLine($"Rating : {review.Rating}/5 Stars");
                Console.WriteLine($"Comment: {review.Comment}");
                Console.WriteLine("----------------------------------------");
            }
        }
        static void Logout()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }
            loggedInUserId = 0;
            Console.WriteLine("Successfully logged out.");
        }
    }
}
