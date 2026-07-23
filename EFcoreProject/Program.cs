
using EFcoreProject.Models;

namespace EFcoreProject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
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
                    case 10: RoomTypeReport(); break;
                    case 11: CheckOut(); break;
                    case 12: RemoveUnavailableRooms(); break;
                    case 13: ExtendGuestStay(); break;
                    case 14: HighestRevenueBooking(); break;
                    case 15: GuestPaginationViewer(); break;


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
            using var context = new AppDbContext();
            Console.WriteLine("================================================");
            Console.Write("Please enter Room number: ");
            int num;
            try { num = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            if (context.Rooms.Any(r => r.RoomNumber == num)) { Console.WriteLine("Room already exists."); return; }
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
            context.Rooms.Add(new Room(num, roomType, price));
            context.SaveChanges();
            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Room Added Successfully! ---");
            Console.WriteLine($"Room Number: {num}");
            Console.WriteLine($"Room Type:   {roomType}");
            Console.WriteLine($"Price/Night:  {price} OMR");
            Console.WriteLine($"Total Rooms: {context.Rooms.Count()}");
            Console.WriteLine("================================================");
        }
        static void RegisterNewGuest()
        {
            using var context = new AppDbContext();

            Console.WriteLine("================================================");
            Console.Write("Please enter guest name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Please enter guest check-in date (14/07/2026): ");
            string date = Console.ReadLine() ?? "";

            Console.Write("Enter how many nights the guest will be staying at: ");
            int nights;
            try { nights = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid number."); return; }
            if (nights <= 0) { Console.WriteLine("Number of nights must be positive integer"); return; }

            var newGuest = new Guest(name, date, nights);
            context.Guests.Add(newGuest);

            context.SaveChanges();

            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Guest Registered Successfully! ---");
            Console.WriteLine($"Guest ID:       {newGuest.GuestId}");
            Console.WriteLine($"Name:           {name}");
            Console.WriteLine($"Check-in Date:  {date}");
            Console.WriteLine($"Nights:         {nights}");
            Console.WriteLine($"Room Assigned:  Not Assigned");
            Console.WriteLine($"Total Guests:   {context.Guests.Count()}");
            Console.WriteLine("================================================");
        }
        static void BookRoom()
        {
            using var context = new AppDbContext();
            Console.WriteLine("================================================");
            Console.Write("Please enter guest ID: ");
            int guestid;
            try { guestid = int.Parse(Console.ReadLine() ?? ""); }
            catch (FormatException) { Console.WriteLine("Invalid ID."); return; }

            var foundGuest = context.Guests.FirstOrDefault(g => g.GuestId == guestid);
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

            var foundRoom = context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNum);
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
            context.SaveChanges();

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
            using var context = new AppDbContext();
            int count = context.Rooms.Count();
            Console.WriteLine("\n================================================");
            Console.WriteLine($"Room count: {count}");
            Console.WriteLine("================================================\n");
            if (count <= 0) { Console.WriteLine("no rooms has been added yet"); }
            var sortedrooms = context.Rooms.OrderBy(r => r.RoomNumber).ToList();
            foreach (var room in sortedrooms)
            {
                room.DisplayRoom();
                Console.WriteLine("------------------------------------------------");
            }
        }
        static void ViewAllGuests()
        {
            using var context = new AppDbContext();
            int count = context.Guests.Count();
            Console.WriteLine("\n================================================");
            Console.WriteLine($"guests count: {count}");
            Console.WriteLine("================================================\n");
            if (count <= 0) { Console.WriteLine("No guests have been registered yet."); }
            var sortedguests = context.Guests.OrderBy(g => g.RoomNumber).ToList();
            foreach (var guest in sortedguests)
            {
                guest.DisplayGuest();
                Console.WriteLine("------------------------------------------------");
            }
        }
        static void SearchRoom()
        {
            using var context = new AppDbContext();
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
                        var found = context.Rooms.Where(r => r.IsAvailable).OrderBy(r => r.PricePerNight).ToList();
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
                        string type = Console.ReadLine() ?? "";
                        if (type != "Single" && type != "Double" && type != "Suite")
                        { Console.WriteLine("Wrong Room Type."); break; }

                        var found2 = context.Rooms.Where(r => r.RoomType == type).ToList();
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
                        try { price = double.Parse(Console.ReadLine() ?? ""); } catch (Exception) { Console.WriteLine("Wrong number"); break; }
                        var found3 = context.Rooms.Where(r => r.PricePerNight <= price).OrderBy(r => r.PricePerNight).ToList();
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
                        int totalRooms = context.Rooms.Count();
                        int availableRooms = context.Rooms.Count(r => r.IsAvailable);
                        if (totalRooms == 0) { Console.WriteLine("No rooms in the system to calculate statistics."); break; }
                        double averagePrice = context.Rooms.Average(r => r.PricePerNight);
                        double minPrice = context.Rooms.Min(r => r.PricePerNight);
                        double maxPrice = context.Rooms.Max(r => r.PricePerNight);

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
            using var context = new AppDbContext();
            int countGuests = context.Guests.Count();
            int assignedGuests = context.Guests.Count(g => g.RoomNumber != "Not Assigned");
            Console.WriteLine("\n================================================");
            Console.WriteLine($"Total Registered Guests:   {countGuests}");
            Console.WriteLine($"Guests with Rooms:         {assignedGuests}");
            Console.WriteLine("================================================");
            int totalRooms = context.Rooms.Count();
            int bookedRooms = context.Rooms.Count(r => !r.IsAvailable);

            Console.WriteLine("\n================================================");
            Console.WriteLine($"Total Rooms:     {totalRooms}");
            Console.WriteLine($"Booked Rooms:    {bookedRooms}");
            Console.WriteLine("================================================");

            var guestsWithBookings = context.Guests.Where(g => g.RoomNumber != "Not Assigned");
            if (guestsWithBookings.Any())
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
            var allRooms = context.Rooms.ToList();
            var activeGuests = context.Guests.Where(g => g.RoomNumber != "Not Assigned").ToList();


            var topguests = activeGuests.Where(g => g.RoomNumber != "Not Assigned").OrderByDescending(g =>
            {
                var room = allRooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
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
                int rank = 1;
                foreach (var guests in topguests)
                {
                    var room = context.Rooms.FirstOrDefault(r => r.RoomNumber.ToString() == guests.RoomNumber);
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

            var guestsWithBookings2 = activeGuests.Select(g =>
            {
                var room = allRooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
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
            using var context = new AppDbContext();
            Console.Write("Enter Room Number: ");
            int num; try { num = int.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Wrong Input."); return; }
            var roomm = context.Rooms.FirstOrDefault(r => r.RoomNumber == num);
            if (roomm == null) { Console.WriteLine("Room not Found."); return; }
            double oldPrice = roomm.PricePerNight;
            Console.WriteLine("Enter new Room/Night price: ");
            double newPrice; try { newPrice = double.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Wrong Input."); return; }
            if (newPrice <= 0) { Console.WriteLine("Room Price Must be positive number."); return; }
            roomm.PricePerNight = newPrice;
            context.SaveChanges();
            Console.WriteLine("\n================ PRICE UPDATE SUCCESS ================");
            Console.WriteLine($"Room Number: {roomm.RoomNumber}");
            Console.WriteLine($"Old Price/Night: OMR {oldPrice:F2}");
            Console.WriteLine($"New Price/Night: OMR {newPrice:F2}");
            Console.WriteLine("======================================================");
        }
        static void GuestLookup()
        {
            using var context = new AppDbContext();
            Console.Write("Enter guest name or partial name to search: ");
            string name = Console.ReadLine() ?? "";
            var lookup = context.Guests.Where(g => g.GuestName.ToLower().Contains(name.ToLower())).ToList();
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
        static void RoomTypeReport()
        {
            using var context = new AppDbContext();
            var single = context.Rooms.Where(r => r.RoomType == "Single");
            var singleCount = single.Count();
            var Doubleroom = context.Rooms.Where(r => r.RoomType == "Double");
            var doubleCount = Doubleroom.Count();
            var Suite = context.Rooms.Where(r => r.RoomType == "Suite");
            var SuiteCount = Suite.Count();
            string singleAvg = singleCount > 0
                ? $"OMR {single.Average(r => r.PricePerNight):F2}"
                : "N/A";

            string doubleAvg = doubleCount > 0
                ? $"OMR {Doubleroom.Average(r => r.PricePerNight):F2}"
                : "N/A";

            string suiteAvg = SuiteCount > 0
                ? $"OMR {Suite.Average(r => r.PricePerNight):F2}"
                : "N/A";
            double overallAverage = context.Rooms.Any() ? context.Rooms.Average(r => r.PricePerNight) : 0;

            Console.WriteLine("\n================ ROOM TYPE BREAKDOWN REPORT ================");
            Console.WriteLine($"Room Type | Count  | Average Price/Night");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Single    | {singleCount,-6} | {singleAvg}");
            Console.WriteLine($"Double    | {doubleCount,-6} | {doubleAvg}");
            Console.WriteLine($"Suite     | {SuiteCount,-6} | {suiteAvg}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Overall Average Room Price: OMR {overallAverage:F2}");
            Console.WriteLine("============================================================");


        }
        static void CheckOut()
        {
            using var context = new AppDbContext();
            Console.WriteLine("Please enter guest ID: ");
            int guestid;
            try { guestid = int.Parse(Console.ReadLine() ?? ""); }catch(FormatException) { Console.WriteLine("Invalid number");return; }
            var guestt = context.Guests.FirstOrDefault(g => g.GuestId == guestid);
            if (guestt == null)
            {
                Console.WriteLine("Guest not found");
                return;
            }
            if (guestt.RoomNumber == "Not Assigned")
            {
                Console.WriteLine("This guest has no active booking");
                return;
            }

            var roomnum = context.Rooms.FirstOrDefault(r => r.RoomNumber.ToString() == guestt.RoomNumber);
            double price = roomnum != null ? roomnum.PricePerNight : 0;
            string roomType = roomnum != null ? roomnum.RoomType : "Unknown";
            double totalCost = guestt.CalculateTotalCost(price);

            Console.WriteLine("\n=================== FINAL BILL / INVOICE ===================");
            Console.WriteLine($"Guest Name: {guestt.GuestName}");
            Console.WriteLine($"Room Number: {guestt.RoomNumber}");
            Console.WriteLine($"Room Type: {roomType}");
            Console.WriteLine($"Check-In Date: {guestt.CheckInDate:dd-MM-yyyy}");
            Console.WriteLine($"Total Nights: {guestt.TotalNights}");
            Console.WriteLine($"Price Per Night: OMR {price:F2}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"TOTAL COST DUE:  OMR {totalCost:F2}");
            Console.WriteLine("============================================================");

            Console.Write("Confirm checkout? (Y/N): ");
            string confirm = Console.ReadLine() ?? "";
            if (confirm.ToUpper() == "Y")
            {
                string guestName = guestt.GuestName;
                string assignedRoom = guestt.RoomNumber;
                if (roomnum != null)
                {
                    roomnum.IsAvailable = true;
                }
                context.Guests.Remove(guestt);
                context.SaveChanges();
                Console.WriteLine("\nCheckout confirmed. Room is now vacant, and guest has been removed.");
                Console.WriteLine("=================== CHECKOUT SUMMARY ======================");
                Console.WriteLine($"Checked out: {guestName} from Room {assignedRoom}");

                bool isRoomNowAvailable = roomnum != null ? roomnum.IsAvailable : true;
                Console.WriteLine($"Room {assignedRoom} Available:  {isRoomNowAvailable}");

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine($"Total Registered Guests: {context.Guests.Count()}");
                Console.WriteLine($"Total Registered Rooms:  {context.Rooms.Count()}");
                Console.WriteLine("============================================================");
            }
            else
            {
                Console.WriteLine("\nCheckout cancelled.");
            }
        }
        static void RemoveUnavailableRooms()
        {
            using var context = new AppDbContext();
            Console.WriteLine("\n================ REMOVE UNAVAILABLE ROOMS ================");

            var unavailableRooms = context.Rooms
                .Where(r => !r.IsAvailable && !context.Guests.Any(g => g.RoomNumber == r.RoomNumber.ToString()))
                .ToList();

            if (unavailableRooms.Count == 0)
            {
                Console.WriteLine("All unavailable rooms are currently occupied. No rooms can be decommissioned.");
                return;
            }

            Console.WriteLine($"Found {unavailableRooms.Count} removable room(s):");
            Console.WriteLine("================================================");

            var orderedRooms = unavailableRooms.OrderBy(r => r.RoomNumber);
            foreach (var room in orderedRooms)
            {
                Console.WriteLine($"- Room {room.RoomNumber} ({room.RoomType}), Price: {room.PricePerNight}");
                Console.WriteLine("---------------------------------------------");
            }

            Console.Write("\nConfirm removal? (Y/N): ");
            string confirm = Console.ReadLine() ?? "";
            if (confirm.ToUpper() == "Y")
            {
                context.Rooms.RemoveRange(unavailableRooms);
                context.SaveChanges();

                Console.WriteLine("================================================");
                Console.WriteLine("Selected rooms have been removed.");
                Console.WriteLine($"Total Rooms remaining: {context.Rooms.Count()}");
                Console.WriteLine("\n==================== REMAINING ROOMS ====================");

                var remainingRooms = context.Rooms.Select(r => new { r.RoomNumber, r.RoomType }).ToList();

                foreach (var room in remainingRooms)
                {
                    Console.WriteLine($"Room: {room.RoomNumber,-5} | Type: {room.RoomType}");
                }
            }
            else
            {
                Console.WriteLine("Cancelled. No rooms were removed.");
            }
        }
        static void ExtendGuestStay()
        {
            using var context = new AppDbContext();
            Console.Write("Please enter guest ID: ");
            int guestid;
            try { guestid = int.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Invalid number"); return; }
            var guestt = context.Guests.FirstOrDefault(g => g.GuestId == guestid);
            if (guestt == null)
            {
                Console.WriteLine("No guest were found");
                return;
            }
            if (guestt.RoomNumber == "Not Assigned")
            {
                Console.WriteLine("This guest has no active booking to extend.");
                return;
            }


            var roomnum = context.Rooms.FirstOrDefault(r => r.RoomNumber.ToString() == guestt.RoomNumber);
            if (roomnum == null)
            {
                Console.WriteLine("Error: Assigned room details could not be found.");
                return;
            }
            Console.Write("Please enter the number of Nights to Extend: ");
            int num;
            try { num = int.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Invalid Number"); return; }
            if (num <= 0) { Console.WriteLine("Number of Nights Must be positive integer (And more than 0"); return; }
            int oldNights = guestt.TotalNights;
            guestt.TotalNights += num;
            context.SaveChanges();
            double newTotalCost = guestt.CalculateTotalCost(roomnum.PricePerNight);
            Console.WriteLine("\n================ UPDATE STAY SUMMARY ================");
            Console.WriteLine($"Guest Name: {guestt.GuestName}");
            Console.WriteLine($"Room Number: {guestt.RoomNumber} ({roomnum.RoomType})");
            Console.WriteLine($"Price Per Night: OMR {roomnum.PricePerNight:F2}");
            Console.WriteLine($"Previous Nights: {oldNights}");
            Console.WriteLine($"Added Nights: +{num}");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"New Total Nights: {guestt.TotalNights}");
            Console.WriteLine($"New Total Cost Due: OMR {newTotalCost:F2}");
            Console.WriteLine("=====================================================");

        }
        static void HighestRevenueBooking()
        {
            var guestt = guests.Where
            (g => g.RoomNumber != "Not Assigned").Select(g =>
            {
                var room = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
                double price = room != null ? room.PricePerNight : 0;
                return new
                {
                    guestName = g.GuestName,
                    roomNumber = g.RoomNumber,
                    TotalCost = g.CalculateTotalCost(price)
                };

            }).OrderByDescending(b => b.TotalCost).Take(1).ToList();
            if (guestt.Count == 0)
            {
                Console.WriteLine("No active bookings recorded.");
                return;
            }
            var top = guestt[0];
            Console.WriteLine($"Top Earner Guest: {top.guestName}");
            Console.WriteLine($"Room Number:      {top.roomNumber}");
            Console.WriteLine($"Total Revenue:    OMR {top.TotalCost:F2}");
            Console.WriteLine("=======================================================");


        }
        static void GuestPaginationViewer()
        {
            int pagesize = 3;
            int totalguests = guests.Count();
            if (totalguests == 0)
            {
                Console.WriteLine("No guests registered in the system.");
                return;
            }
            int NumberPages = totalguests / pagesize;
            int num;
            Console.Write($"Enter page number (1 to {NumberPages}): ");
            try { num = int.Parse(Console.ReadLine() ?? ""); } catch (FormatException) { Console.WriteLine("Invalid Number"); return; }
            if (num <= 0 || num > NumberPages)
            {
                Console.WriteLine("That page does not exist.");
                return;
            }
            int skipCount = (num - 1) * pagesize;
            var paginatedGuests = guests
                .Skip(skipCount)
                .Take(pagesize)
                .ToList();
            Console.WriteLine($"\n==================== PAGE {num} OF {NumberPages} ====================");
            foreach (var guest in paginatedGuests)
            {
                guest.DisplayGuest();
                Console.WriteLine("------------------------------------------------------------");
            }
            Console.WriteLine($"Showing guests {skipCount + 1} - {Math.Min(skipCount + pagesize, totalguests)} of {totalguests}");
            Console.WriteLine("============================================================");
        }
    }
}



