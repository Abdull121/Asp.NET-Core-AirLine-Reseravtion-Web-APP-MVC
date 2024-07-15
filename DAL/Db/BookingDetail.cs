using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Db
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
        public DateTime DepartureTime { get; set; } = DateTime.Now;
        public DateTime ArrivalTime { get; set; } = DateTime.Now;
        public string Class { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
