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

            Console.WriteLine("Enter Rectangle length: ");
            double length = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Rectangle width: ");
            double width = double.Parse(Console.ReadLine());
            double area = length * width;
            double Perimeter = 2* (length + width);
            Console.WriteLine("Area: " + area);
            Console.WriteLine("Perimeter: " + Perimeter);
        }
    }
}
