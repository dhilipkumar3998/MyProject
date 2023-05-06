using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking
{
    public class Flight
    {
        public int Cost{get;set;}
        private static int id=1;
        public int FlightId{get;set;}
        private static int bookId=1;
        public int BookingId{get;set;}
        public int SeatCount{get;set;}
        public int TotalCost{get;set;}
        public int AvailableSeats{get;set;}=50;
        public Flight(int cost)
        {
            FlightId=id++;
            Cost=cost;
        }

        public Flight(int id,int total,int seats)
        {
            FlightId=id;
            TotalCost=total;
            SeatCount=seats;
            BookingId=bookId++;
        }
    }
}