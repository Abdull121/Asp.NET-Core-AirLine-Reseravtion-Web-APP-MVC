using System;
using System.Collections.Generic;

#nullable disable

namespace AirLine_Reseravtion_Project.Force
{
    public partial class BookingDetail
    {
        public BookingDetail()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int FlightId { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
