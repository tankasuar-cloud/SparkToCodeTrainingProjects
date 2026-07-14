using System.Numerics;

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
                try { option = int.Parse(Console.ReadLine() ?? ""); }
                catch (FormatException) { Console.WriteLine("Invalid option."); continue; }
                switch (option)
                {
                    case 0: is_running = false; break;
                    case 1: AddNewRoom(); break;
                    case 2: RegisterNewGuest(); break;
                    case 3: BookRoom(); break;
                    case 4: ViewAllRooms(); break;
                    case 5: ViewAllGuests(); break;
                    case 6: SearchRoom(); break;
                    case 7: GuestBookingStatistics(); break;
                    case 8: UpdateRoomPrice(); break;
                    case 9: GuestLookup(); break;


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
            try { num = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            if (rooms.Any(r => r.RoomNumber == num)) { Console.WriteLine("Room already exists."); return; }
            Console.WriteLine("================================================");
            Console.Write("Please enter room type (Single / Double / Suite): ");
            string roomType = Console.ReadLine() ?? "";
            if (roomType != "Single" && roomType != "Double" && roomType != "Suite")
            { Console.WriteLine("Wrong Room Type."); return; }

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
            string date = Console.ReadLine() ?? "";
            Console.Write("Enter how many nights the guest will be staying at: ");
            int nights;
            try { nights = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            if (nights < 0) { Console.WriteLine("Number of nights must be positive integer "); return; }
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
        static void ViewAllRooms()
        {
            int count = rooms.Count;
            Console.WriteLine("\n================================================");
            Console.WriteLine($"Room count: {count}");
            Console.WriteLine("================================================\n");
            if (count <= 0) { Console.WriteLine("no rooms has been added yet"); }
            var sortedrooms = rooms.OrderBy(g => g.RoomNumber).ToList();
            foreach (var room in sortedrooms)
            {
                room.DisplayRoom();
                Console.WriteLine("------------------------------------------------");
            }
        }
        static void ViewAllGuests()
        {
            int count = guests.Count;
            Console.WriteLine("\n================================================");
            Console.WriteLine($"guests count: {count}");
            Console.WriteLine("================================================\n");
            if (count <= 0) { Console.WriteLine("No guests have been registered yet."); }
            var sortedguests = guests.OrderBy(g => g.RoomNumber).ToList();
            foreach (var guest in sortedguests)
            {
                guest.DisplayGuest();
                Console.WriteLine("------------------------------------------------");
            }
        }
        static void SearchRoom()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=================== SEARCH ROOMS ===================");
                Console.WriteLine("(1) Show all available rooms");
                Console.WriteLine("(2) Filter by room type");
                Console.WriteLine("(3) Filter by max price");
                Console.WriteLine("(4) Room price statistics");
                Console.WriteLine("(0) Back");
                Console.WriteLine("====================================================");
                Console.Write("Enter your choice: ");

                int option;
                try { option = int.Parse(Console.ReadLine() ?? ""); }
                catch (FormatException) { Console.WriteLine("Invalid option."); Console.ReadKey(); continue; }

                switch (option)
                {
                    case 0: return;
                    case 1:
                        var found = rooms.Where(r => r.IsAvailable).OrderBy(r => r.PricePerNight).ToList();
                        Console.WriteLine("\n================================================");
                        Console.WriteLine($"Available Rooms Count: {found.Count}");
                        Console.WriteLine("================================================");

                        if (found.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        foreach (var room in found)
                        {
                            room.DisplayRoom();
                            Console.WriteLine("------------------------------------------------");
                        }

                        break;
                    case 2:
                        Console.Write("Please enter room type(Single / Double / Suite): ");
                        string type = Console.ReadLine()??"";
                        if (type != "Single" && type != "Double" && type != "Suite")
                        { Console.WriteLine("Wrong Room Type."); break; }
                        
                        var found2 = rooms.Where(r => r.RoomType == type).ToList();
                        Console.WriteLine("\n================================================");
                        Console.WriteLine($"Available Rooms Count: {found2.Count}");
                        Console.WriteLine("================================================");

                        if (found2.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        foreach (var room2 in found2)
                        {
                            room2.DisplayRoom();
                            Console.WriteLine("------------------------------------------------");
                        }
                        break;
                    case 3:
                        Console.Write("Please enter max price: ");
                        double price;
                        try { price = double.Parse(Console.ReadLine() ?? ""); } catch (Exception) {Console.WriteLine("Wrong number"); break; }
                        var found3 = rooms.Where(r => r.PricePerNight <= price ).OrderBy(r => r.PricePerNight).ToList();
                        Console.WriteLine("\n================================================");
                        Console.WriteLine($"Available Rooms Count: {found3.Count}");
                        Console.WriteLine("================================================");

                        if (found3.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        foreach (var room3 in found3)
                        {
                            room3.DisplayRoom();
                            Console.WriteLine("------------------------------------------------");
                        }
                        break;
                    case 4:
                        int totalRooms = rooms.Count();
                        int availableRooms = rooms.Count(r => r.IsAvailable);
                        if (totalRooms == 0) {Console.WriteLine("No rooms in the system to calculate statistics."); break;}
                        double averagePrice = rooms.Average(r => r.PricePerNight);
                        double minPrice = rooms.Min(r => r.PricePerNight);
                        double maxPrice = rooms.Max(r => r.PricePerNight);

                        Console.WriteLine("\n================ ROOM STATISTICS ================");
                        Console.WriteLine($"Total Rooms:       {totalRooms}");
                        Console.WriteLine($"Available Rooms:   {availableRooms}");
                        Console.WriteLine($"Average Price:     {averagePrice:F2} OMR");
                        Console.WriteLine($"Cheapest Price:    {minPrice:F2} OMR");
                        Console.WriteLine($"Most Expensive:    {maxPrice:F2} OMR");
                        Console.WriteLine("================================================");
                        break;

                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }
                Console.WriteLine("press any key.");
                Console.ReadKey();
                Console.Clear();
            }


        }
        static void GuestBookingStatistics()
        {
            int countGuests = guests.Count();
            int assignedGuests = guests.Count(g => g.RoomNumber != "Not Assigned");
            Console.WriteLine("\n================================================");
            Console.WriteLine($"Total Registered Guests:   {countGuests}");
            Console.WriteLine($"Guests with Rooms:         {assignedGuests}");
            Console.WriteLine("================================================");
            int totalRooms = rooms.Count();
            int bookedRooms = rooms.Count(r => !r.IsAvailable);

            Console.WriteLine("\n================================================");
            Console.WriteLine($"Total Rooms:     {totalRooms}");
            Console.WriteLine($"Booked Rooms:    {bookedRooms}");
            Console.WriteLine("================================================");

            var guestsWithBookings = guests.Where(g => g.RoomNumber != "Not Assigned");
            if(guestsWithBookings.Any())
            {
                double averageNights = guestsWithBookings.Average(g => g.TotalNights);
                Console.WriteLine("\n================ BOOKING STATISTICS ================");
                Console.WriteLine($"Average Nights: {averageNights:F2} nights");
                Console.WriteLine("====================================================");
            }
            else
            {
                Console.WriteLine("\n================ BOOKING STATISTICS ================");
                Console.WriteLine("Average Nights: 0.0 nights (No active bookings)");
                Console.WriteLine("====================================================");
            }



            var topguests = guests.Where(g => g.RoomNumber != "Not Assigned").OrderByDescending(g =>
            { var room = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
                double price = room != null ? room.PricePerNight : 0;
                return g.CalculateTotalCost(price);
            }).Take(3).ToList();

            Console.WriteLine("\n================ TOP 3 SPENDING GUESTS ================");
            if (topguests.Count == 0)
            {
                Console.WriteLine("No active bookings found to calculate spending.");
            }
            else
            {
                int rank =1;
                foreach (var guests in topguests)
                {
                    var room = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == guests.RoomNumber);
                    double price = room != null ? room.PricePerNight : 0;
                    double totalCost = guests.CalculateTotalCost(price);
                    Console.WriteLine($"{rank}. Guest:       {guests.GuestName}");
                    Console.WriteLine($"   Room Number: {guests.RoomNumber}");
                    Console.WriteLine($"   Total Cost:  {totalCost:F2} OMR");
                    Console.WriteLine("------------------------------------------------------");
                    rank++;
                }
            }
            Console.WriteLine("======================================================");

            var guestsWithBookings2 = guests.Where(g => g.RoomNumber != "Not Assigned")
                .Select(g =>
            {
                var room = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
                double price = room != null ? room.PricePerNight : 0;
                double totalCost = g.CalculateTotalCost(price);

                return $"{g.GuestName} — Room {g.RoomNumber} — {g.TotalNights} nights — OMR {totalCost:F2}";
            }).ToList();
            Console.WriteLine("\n================ ACTIVE BOOKINGS SUMMARY ================");
            if (guestsWithBookings2.Count == 0)
            {
                Console.WriteLine("No active bookings recorded.");
            }
            else
            {
                foreach (var guest in guestsWithBookings2)
                {
                    Console.WriteLine(guest);
                }
            }
            Console.WriteLine("=========================================================");

        }
        static void UpdateRoomPrice()
        {
            Console.Write("Enter Room Number: ");
            int num; try { num = int.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Wrong Input.");return; }
            var roomm = rooms.FirstOrDefault(r => r.RoomNumber == num);
            if (roomm == null) { Console.WriteLine("Room not Found.");return; }
            double oldPrice = roomm.PricePerNight;
            Console.WriteLine("Enter new Room/Night price: ");
            double newPrice; try { newPrice = double.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Wrong Input."); return; }
            if (newPrice <= 0) { Console.WriteLine("Room Price Must be positive number.");return; }
            roomm.PricePerNight = newPrice;
            Console.WriteLine("\n================ PRICE UPDATE SUCCESS ================");
            Console.WriteLine($"Room Number: {roomm.RoomNumber}");
            Console.WriteLine($"Old Price/Night: OMR {oldPrice:F2}");
            Console.WriteLine($"New Price/Night: OMR {newPrice:F2}");
            Console.WriteLine("======================================================");
        }
        static void GuestLookup()
        {
            Console.Write("Enter guest name or partial name to search: ");
            string name = Console.ReadLine()??"";
            var lookup = guests.Where(g => g.GuestName.ToLower().Contains(name.ToLower())).ToList();
            if (lookup.Count == 0)
            {
                Console.WriteLine("No guests matched that search.");
            }
            else
            {
                Console.WriteLine("\n==================================================");
                Console.WriteLine($"Matches Found: {lookup.Count}");
                

                foreach (var guest in lookup)
                {
                    Console.WriteLine($"ID: {guest.GuestId}");
                    Console.WriteLine($"Name: {guest.GuestName}");
                    Console.WriteLine($"Room Number: {guest.RoomNumber}");
                    Console.WriteLine("==================================================");
                }
            }

        }
    }
}
