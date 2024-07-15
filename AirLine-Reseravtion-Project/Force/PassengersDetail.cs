using System;
using System.Collections.Generic;

#nullable disable

namespace AirLine_Reseravtion_Project.Force
{
    public partial class PassengersDetail
    {
        public PassengersDetail()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PhoneNumber { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
