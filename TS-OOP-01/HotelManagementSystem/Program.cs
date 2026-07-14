namespace HotelManagementSystem
{
    internal class Program
    {
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();
        static void Main(string[] args)
        {
            PreloadRooms();
            bool is_running = true;
            while (is_running)
            {
                Console.Clear();
                Console.WriteLine("=== HOTEL MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Register New Guest");
                Console.WriteLine("3. Book a Room for a Guest");
                Console.WriteLine("4. View All Rooms");
                Console.WriteLine("5. View All Guests");
                Console.WriteLine("6. Search & Filter Rooms");
                Console.WriteLine("7. Guest & Booking Statistics");
                Console.WriteLine("8. Update Room Price");
                Console.WriteLine("9. Guest Lookup by Name");
                Console.WriteLine("10. Room Type Breakdown Report");
                Console.WriteLine("11. Check Out a Guest");
                Console.WriteLine("12. Remove Unavailable Rooms");
                Console.WriteLine("13. Extend Guest Stay");
                Console.WriteLine("14. Highest Revenue Booking");
                Console.WriteLine("15. Guest Pagination Viewer");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice: ");
                int option;
                try { option = int.Parse(Console.ReadLine());}
                catch (FormatException) { Console.WriteLine("Invalid option.");continue; }
                switch (option)
                {
                    case 0: is_running = false; break;

                }
                Console.WriteLine("press any key.");
                Console.ReadKey();
                Console.Clear();


            }
        }
        static void PreloadRooms()
        {
            rooms.Add(new Room(101, "Single", 25.00));
            rooms.Add(new Room(102, "Single", 25.00));
            rooms.Add(new Room(201, "Double", 40.00));
            rooms.Add(new Room(202, "Double", 40.00));
            rooms.Add(new Room(301, "Suite", 75.00));
            rooms.Add(new Room(302, "Suite", 75.00));
        }
        
    }
}
