namespace FirstC_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
      
            Console.Write("Name: ");
            string Name = Console.ReadLine();

            Console.Write("Age: ");
            int Age = int.Parse(Console.ReadLine());

            Console.WriteLine("salary: ");
            float Salary = float.Parse(Console.ReadLine());


            Console.WriteLine("hello " + Name + " welcome to spark");
            Console.WriteLine("You are:  " + Age + " years old");
            Console.WriteLine("You make " + Salary + " OMR");
            ///////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("enter first number: ");
            float A = float.Parse(Console.ReadLine());

            Console.WriteLine("enter second number: ");
            float B  = float.Parse(Console.ReadLine());


            float R1 = A + B;
            float R2 = A - B;
            float R3 = A * B;
            float R4 = A / B;
            float R5 = A % B;

            Console.WriteLine("Addition result: " + R1);
            Console.WriteLine("Subtraction result: " + R2);
            Console.WriteLine("multiplication result: " + R3);
            Console.WriteLine("Division result: " + R4);
            Console.WriteLine("Reminder result: " + R5);
            

        }
    }
}
