namespace HotelManagementSystem
{
    internal class Program
    {
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();
        static int guestCounter = 1;
        static void Main(string[] args)
        {
            PreloadRooms();
            bool is_running = true;
            while (is_running)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("=== GRAND VISTA HOTEL — MANAGEMENT SYSTEM ===");
                Console.WriteLine("================================================");
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
                Console.WriteLine("================================================");
                Console.Write("\nEnter your choice: ");
                int option;
                try { option = int.Parse(Console.ReadLine()??"");}
                catch (FormatException) { Console.WriteLine("Invalid option.");continue; }
                switch (option)
                {
                    case 0: is_running = false; break;
                    case 1: AddNewRoom(); break;
                    case 2: RegisterNewGuest(); break;
                    case 3: BookRoom(); break;


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
        static void AddNewRoom()
        {
            Console.WriteLine("================================================");
            Console.Write("Please enter Room number: ");
            int num;
            try { num = int.Parse(Console.ReadLine()??""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            if (rooms.Any(r => r.RoomNumber == num)) {Console.WriteLine("Room already exists.");return;}
            Console.WriteLine("================================================");
            Console.Write("Please enter room type (Single / Double / Suite): ");
            string roomType = Console.ReadLine() ?? "";
            if (roomType != "Single" && roomType != "Double" && roomType != "Suite")
            { Console.WriteLine("Wrong Room Type.");return; }

            Console.WriteLine("================================================");
            Console.Write("Please enter Room Price per night: ");
            double price;
            try { price = double.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            rooms.Add(new Room(num, roomType, price));
            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Room Added Successfully! ---");
            Console.WriteLine($"Room Number: {num}");
            Console.WriteLine($"Room Type:   {roomType}");
            Console.WriteLine($"Price/Night:  {price} OMR");
            Console.WriteLine($"Total Rooms: {rooms.Count}");
            Console.WriteLine("================================================");
        }
        static void RegisterNewGuest()
        {
            Console.WriteLine("================================================");
            Console.Write("Please enter guest name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Please enter guest check-in date (14/07/2026): ");
            string date = Console.ReadLine() ??"";
            Console.Write("Enter how many nights the guest will be staying at: ");
            int nights;
            try { nights = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            if (nights < 0) { Console.WriteLine("Number of nights must be positive integer ");return; }
            string guestID = "G" + guestCounter.ToString("D3");
            guestCounter++;
            guests.Add(new Guest(guestID, name, date, nights));
            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Guest Registered Successfully! ---");
            Console.WriteLine($"Guest ID:       {guestID}");
            Console.WriteLine($"Name:           {name}");
            Console.WriteLine($"Check-in Date:  {date}");
            Console.WriteLine($"Nights:         {nights}");
            Console.WriteLine($"Room Assigned:  Not Assigned");
            Console.WriteLine($"Total Guests:   {guests.Count}");
            Console.WriteLine("================================================");

        }
        static void BookRoom()
        {
            Console.WriteLine("================================================");
            Console.Write("Please enter guest ID: ");
            string guestid = (Console.ReadLine() ?? "").ToUpper();

            var foundGuest = guests.FirstOrDefault(g => g.GuestId == guestid);
            if (foundGuest != null)
            {
                Console.WriteLine(foundGuest.GuestId);
            }
            else
            {
                Console.WriteLine("guest not found.");
                return;
            }
            Console.WriteLine("================================================");
            Console.Write("Please enter Room ID: ");
            int roomNum;
            try { roomNum = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }

            var foundRoom = rooms.FirstOrDefault(r => r.RoomNumber == roomNum);
            if (foundRoom != null)
            {
                if (foundRoom.IsAvailable)
                {
                    Console.WriteLine("Room is found and available!"); 
                }
                else
                {
                    Console.WriteLine("Room is already booked.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Room not found.");
                return;
            }
            foundGuest.RoomNumber = foundRoom.RoomNumber.ToString();
            foundRoom.IsAvailable = false;
            double totalCost = foundGuest.CalculateTotalCost(foundRoom.PricePerNight);
            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Booking Confirmed Successfully! ---");
            Console.WriteLine($"Guest Name:     {foundGuest.GuestName}");
            Console.WriteLine($"Room Number:    {foundRoom.RoomNumber}");
            Console.WriteLine($"Room Type:      {foundRoom.RoomType}");
            Console.WriteLine($"Price Per Night: {foundRoom.PricePerNight} OMR");
            Console.WriteLine($"Total Nights:   {foundGuest.TotalNights}");
            Console.WriteLine($"Total Cost:     {totalCost} OMR");
            Console.WriteLine("================================================");
        }



    }
}
