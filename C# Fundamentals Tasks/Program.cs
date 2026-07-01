using System.Reflection.Metadata;

namespace C__Fundamentals_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1:

            //String name = "Haitham";
            //int Age = 26;
            //double Height = 1.75;
            //bool is_student = false;
            //Console.WriteLine("Name: "+ name+", Age: "+ Age+", Height: "+ Height+", Student: "+ is_student);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 2:

            //Console.WriteLine("Enter Rectangle length: ");
            //double length = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Rectangle width: ");
            //double width = double.Parse(Console.ReadLine());
            //double area = length * width;
            //double Perimeter = 2* (length + width);
            //Console.WriteLine("Area: " + area);
            //Console.WriteLine("Perimeter: " + Perimeter);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 2:

            //Console.WriteLine("Enter your Age: ");
            //int age = int.Parse(Console.ReadLine());
            //Console.WriteLine("Do you have a national ID? (yes/no): ");
            //string hasNationalID = Console.ReadLine().ToLower();
            //bool hasNational = false;


            //if (hasNationalID == "yes")
            //{
            //    hasNational = true;
            //}
            //else if (hasNationalID == "no")
            //{
            //    hasNational = false;
            //}

            //if (age >= 18 && hasNational == true)
            //{
            //    Console.WriteLine("You are eligible to vote.");

            //}
            //else
            //{
            //    Console.WriteLine("You are not eligible to vote.");
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 4: 

            Console.WriteLine("Enter a number: ");
            double number = double.Parse(Console.ReadLine());
            if (number % 2==0)
            {
                Console.WriteLine("The number "+number+" is even.");
            }
            else if (number % 2 == 1)
            {
                Console.WriteLine("The number " + number + " is odd.");
            }
}
}
}

