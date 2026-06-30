namespace FirstC_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.Write("Name: ");
            //string Name = Console.ReadLine();

            //Console.Write("Age: ");
            //int Age = int.Parse(Console.ReadLine());

            //Console.WriteLine("salary: ");
            //float Salary = float.Parse(Console.ReadLine());


            //Console.WriteLine("hello " + Name + " welcome to spark");
            //Console.WriteLine("You are:  " + Age + " years old");
            //Console.WriteLine("You make " + Salary + " OMR");


            /////////////////////////////////////////////////////////////////////////////////


            //Console.WriteLine("enter first number: ");
            //float A = float.Parse(Console.ReadLine());

            //Console.WriteLine("enter second number: ");
            //float B  = float.Parse(Console.ReadLine());


            //float R1 = A + B;
            //float R2 = A - B;
            //float R3 = A * B;
            //float R4 = A / B;
            //float R5 = A % B;

            //Console.WriteLine("Addition result: " + R1);
            //Console.WriteLine("Subtraction result: " + R2);
            //Console.WriteLine("multiplication result: " + R3);
            //Console.WriteLine("Division result: " + R4);
            //Console.WriteLine("Reminder result: " + R5);


            /////////////////////////////////////////////////////////////////////////////////


            //Console.WriteLine("mark 1: ");
            //double mark1 = double.Parse(Console.ReadLine());
            //Console.WriteLine("mark 2: ");
            //double mark2 = double.Parse(Console.ReadLine());
            //double result = (mark1 + mark2) / 2;
            //Console.WriteLine("result: " + result);
            //if (result < 50)
            //{
            //    Console.WriteLine("Fail");
            //}
            //else if (result < 65 && result > 50)
            //{
            //    Console.WriteLine("Pass");
            //}
            //else if (result < 80 && result > 65)
            //{
            //    Console.WriteLine("Good");
            //}
            //else if (result < 90 && result > 80)
            //{
            //    Console.WriteLine("Very Good");
            //}
            //else
            //{
            //    Console.WriteLine("Excellent");
            //}


            /////////////////////////////////////////////////////////////////////////////////
            bool is_running = true;
            while(is_running)
            {
            Console.WriteLine("******************************************");
            Console.WriteLine("welcome to Bank:");
            Console.WriteLine("1.Withdraw");
            Console.WriteLine("2.Deposite");
            Console.WriteLine("3.Balance check");
            Console.WriteLine("4.Quit");

            double balance = 1000;
            Console.WriteLine("choose an option: ");
                
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("******************************************");
            switch (option)
            {
                case 1:
                    Console.WriteLine("your balance = "+ balance);
                    Console.WriteLine("enter amount to withdraw: ");
                    double withdraw = double.Parse(Console.ReadLine());
                    double result = balance - withdraw;
                    Console.WriteLine("your new balance = " + result);
                    Console.WriteLine("your withdrawed amount = " + withdraw);
                    break;


                case 2:
                    Console.WriteLine("your balance =" + balance);
                    Console.WriteLine("enter amount to deposite: ");
                    double deposite = double.Parse(Console.ReadLine());
                    double result2 = balance + deposite;
                    Console.WriteLine("your new balance = " + result2);
                    break;


                case 3:
                    Console.WriteLine("your balance = " + balance);
                    break;

                case 4:
                        is_running = false;
                        break;  
                    default:
                    Console.WriteLine("please choose a correct option");
                    break;
            }

        }
    }
}
}
