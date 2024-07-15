using System;
using System.Collections.Generic;

#nullable disable

namespace AirLine_Reseravtion_Project.Force
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? PassengerId { get; set; }
        public int? FlightId { get; set; }
        public DateTime ReservationDate { get; set; }

        public virtual BookingDetail Flight { get; set; }
        public virtual PassengersDetail Passenger { get; set; }
    }
}
