using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking
{
    /// <summary>
    /// Operation class is used to add all functionality
    /// </summary>
    public static class Operation
    {
        public static Flight CurrentUser;
        public static List<Flight> FlightList = new List<Flight>();
        
        public static List<Flight> BookingList=new List<Flight>();
        public static void Booking()
        {
            
            for(int i=0;i<2;i++)
            {
                Flight obj=new Flight(5000);
                FlightList.Add(obj);
            }

            
        }

        public static void Looping()
        {
            bool run=true;
            while(run)
            {
                Console.WriteLine("1. Book 2. Cancel 3. Available tickets 4. Booking History 5. Exit");
                Console.Write("Enter the choice : ");
                int choice=int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        CancelTicket();
                        break;
                    }
                    case 3:
                    {
                        FlightCost();
                        break;
                    }
                    case 4:
                    {
                        BookingHistory();
                        break;
                    }
                    case 5:
                    {
                        run=false;
                        break;
                    }
                }
            }
        }
        public static void Registration()
        {
            Console.Write("Enter the Flight ID : ");
            int id=int.Parse(Console.ReadLine());

            foreach(Flight flight in FlightList)
            {
                if(flight.FlightId==id)
                {
                    BookTicket(flight);
                }
                else if(flight.FlightId==id)
                {
                    BookTicket(flight);
                }
            }
        }
        public static void BookTicket(Flight flight)
        {
            Console.Write("Enter the ticket count : ");
            int count=int.Parse(Console.ReadLine());

            int totalPrice=0;
            if(flight.AvailableSeats>=count)
            {
                totalPrice+=count*flight.Cost;
                flight.Cost+=(count*200);
                flight.AvailableSeats-=count;
                Flight book=new Flight(flight.FlightId,totalPrice,count);
                BookingList.Add(book);
                Console.WriteLine("Ticket Booked Successfully...!");
            }
            else
            {
                Console.WriteLine("Sorry, ticket is not available for this flight..");
            }
        }

        public static void CancelTicket()
        {
            Console.Write("Enter the booking ID to cancel : ");
            int cancelID=int.Parse(Console.ReadLine());
            foreach(Flight booking in BookingList)
            {
                if(booking.BookingId==cancelID)
                {
                    Cancel(booking);
                    break;
                }
            }
            
        }
        private static void Cancel(Flight flight)
        {
            foreach(Flight flight1 in FlightList)
            {
                if(flight1.FlightId==flight.FlightId)
                {
                    flight1.Cost-=flight.SeatCount*200;
                    flight1.AvailableSeats+=flight.SeatCount;
                    BookingList.Remove(flight);
                    Console.WriteLine("Ticket cancelled successfully...");
                }
                else if(flight1.FlightId==flight.FlightId)
                {
                    flight1.Cost-=flight.SeatCount*200;
                    flight1.AvailableSeats+=flight.SeatCount;
                    BookingList.Remove(flight);
                    Console.WriteLine("Ticket cancelled successfully...");
                }
            }
            
        }
        private static void FlightCost()
        {
            foreach(Flight flight in FlightList)
            {
                Console.WriteLine($"Flight {flight.FlightId} cost is {flight.Cost}");
                Console.WriteLine($"Flight {flight.FlightId} available seats is {flight.AvailableSeats}");
                Console.WriteLine("\n");
            }
        }
        private static void BookingHistory()
        {
            foreach(Flight book in BookingList)
            {
                Console.WriteLine(book.BookingId+" "+book.FlightId+" "+book.SeatCount+" "+book.TotalCost);
            }
        }
    }
}