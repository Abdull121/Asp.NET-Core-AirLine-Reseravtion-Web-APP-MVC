using System;

// Use this namespace for data annotations
using System.ComponentModel.DataAnnotations;

namespace CommonModel.Module
{
    public class BookingModel
    {
        // This property is marked as the primary key of the Booking table.
        [Key]
        public int FlightId { get; set; }

        // This property is required and a custom error message is specified.
        [Required(ErrorMessage = "Departure city is required.")]
        public string DepartureCity { get; set; }

        // This property is required and a custom error message is specified.
        [Required(ErrorMessage = "Arrival city is required.")]
        public string ArrivalCity { get; set; }

        // This property is required, a custom error message is specified, and the data type is set to Date.
        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }

        // This property is required, a custom error message is specified, and the data type is set to Date.
        [Required(ErrorMessage = "Arrival date is required.")]
        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        // This property is required and a custom error message is specified.
        [Required(ErrorMessage = "Class is required.")]
        public string Class { get; set; }

        // This property represents the price of the booking.
        public decimal Price { get; set; }
    }
}
