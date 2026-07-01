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

            //Console.WriteLine("Enter a number: ");
            //double number = double.Parse(Console.ReadLine());
            //if (number % 2==0)
            //{
            //    Console.WriteLine("The number "+number+" is even.");
            //}
            //else if (number % 2 == 1)
            //{
            //    Console.WriteLine("The number " + number + " is odd.");
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 5: 

            //Console.WriteLine("Enter a Grade: ('A', 'B', 'C', 'D', or 'F') ");
            //char grade = char.Parse(Console.ReadLine().ToUpper());
            //switch(grade) 
            //{ 
            //    case 'A':
            //        Console.WriteLine("Excellent");
            //        break;

            //    case 'B':
            //        Console.WriteLine("Very Good");
            //        break;

            //    case 'C':
            //        Console.WriteLine("Good");
            //        break;

            //    case 'D':
            //        Console.WriteLine("Pass");
            //        break;

            //    case 'F':
            //        Console.WriteLine("Fail");
            //        break;

            //    default:
            //        Console.WriteLine("Invalid grade entered.");
            //        break;
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 6:

            //Console.WriteLine("Enter a temperature in Celsius= ");
            //double celsius = double.Parse(Console.ReadLine());
            //double fahrenheit = (celsius * 9 / 5) + 32;
            //if (fahrenheit < 10)
            //{
            //    Console.WriteLine("It is "+ fahrenheit+ " fahrenheit So It is Cold");
            //}
            //else if (fahrenheit >= 10 && fahrenheit < 30)
            //{
            //    Console.WriteLine("It is " + fahrenheit + " fahrenheit So It is Mild");
            //}
            //else
            //{
            //    Console.WriteLine("It is " + fahrenheit + " fahrenheit So It is Hot");
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 7:

            //Console.WriteLine("Enter your Age: ");
            //int age = int.Parse(Console.ReadLine());

            //if (age < 13 && age >0)
            //{
            //    Console.WriteLine("You are a child.");
            //    Console.WriteLine("Ticket cost 2.000 OMR");
            //}
            //else if (age >= 13 && age < 60)
            //{
            //    Console.WriteLine("You are a Adult.");
            //    Console.WriteLine("Ticket cost 5.000 OMR");
            //}
            //else if (age >=60)
            //{
            //    Console.WriteLine("You are an Seniors .");
            //    Console.WriteLine("Ticket cost 3.000 OMR");
            //}
            //else
            //{
            //    Console.WriteLine("You entered a invalid age.");
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 8:

            //Console.WriteLine("Enter The Bill Amount: ");
            //double billAmount = double.Parse(Console.ReadLine());
            //Console.WriteLine("Are you a Loyal Member? (yes/no): ");
            //string isLoyalMember = Console.ReadLine().ToLower();
            //double discount = 0;
            //double finalAmount = 0;
            //if (billAmount > 20 && isLoyalMember == "yes")
            //{
            //    finalAmount = billAmount - (billAmount * 0.15);
            //    Console.WriteLine("Original Bill Amount: " + billAmount + " OMR ");
            //    Console.WriteLine("discount: 15%");
            //    Console.WriteLine("final Bill: " + finalAmount + " OMR ");
            //}
            //else
            //{
            //    finalAmount = billAmount;
            //    Console.WriteLine("Original Bill Amount: " + billAmount + " OMR ");
            //    Console.WriteLine("discount: 0%");
            //    Console.WriteLine("final Bill: " + finalAmount + " OMR ");
            //}


            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // Task 9:

            Console.WriteLine("enter a number from 1 to 7");
            int dayNumber = int.Parse(Console.ReadLine());
            
            switch(dayNumber) 
            {
                case 1:
                    Console.WriteLine("Sunday");
                    break;

                case 2:
                    Console.WriteLine("Monday");
                    break;

                case 3:
                    Console.WriteLine("Tuesday");
                    break;

                case 4:
                    Console.WriteLine("Wednesday");
                    break;

                case 5:
                    Console.WriteLine("Thursday");
                    break;
                
                case 6:
                    Console.WriteLine("Friday");
                    break;

                case 7:
                    Console.WriteLine("Saturday");
                    break;

                default:
                    Console.WriteLine("nvalid day number");
                    break;
            }





    }
    }
}

