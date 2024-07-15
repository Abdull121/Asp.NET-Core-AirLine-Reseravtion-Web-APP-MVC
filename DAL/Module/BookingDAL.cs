using AirLine_Reseravtion_Project.Db;
using DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Module
{
    public class BookingDAL
    {
        // Database context for accessing the airline reservation database
        airlinereservationDatabaseContext db;

        // Constructor to initialize the database context
        public BookingDAL()
        {
            db = new airlinereservationDatabaseContext();
        }

        // Method to get all booking details
        public async Task<List<BookingDetail>> GetAllBooking()
        {
            // Use LINQ query to select all booking details from the database
            return (from c in db.BookingDetails
                    select c).ToList<BookingDetail>();
        }

        // Method to get booking details by flight ID
        public async Task<BookingDetail> GetBookingByID(int ID) 
        {
            // Use LINQ query to select the booking detail where the flight ID matches the given ID
            return (from c in db.BookingDetails
                    where c.FlightId == ID
                    select c).FirstOrDefault<BookingDetail>();
        }

        // Method to save a booking detail
        public async Task<int> SaveBooking(BookingDetail _BookingModel)
        {
            bool saveSuccessfully = false;
            int isSaved = 0;

            // Check if the booking model is new or an update
            if (_BookingModel.FlightId == 0)
            {
                // Add new booking detail to the database
                db.Add<BookingDetail>(_BookingModel);
                isSaved = 1; // Indicate a new record was added
            }
            else
            {
                // Update existing booking detail in the database
                db.Update<BookingDetail>(_BookingModel);
                isSaved = 2; // Indicate an existing record was updated
            }

            // Save changes to the database
            db.SaveChanges();
            saveSuccessfully = true;

            // Return the save status
            if (saveSuccessfully)
            {
                return isSaved;
            }
            else
            {
                return 0; // Indicate failure
            }
        }

        // Method to delete a booking detail by ID
        public async Task<bool> DeleteBooking(int _ID)
        {
            // Get the booking detail by ID
            BookingDetail bookingData = await GetBookingByID(_ID);
            bool res = false;

            // Check if the booking detail exists
            if (bookingData != null)
            {
                // Remove the booking detail from the database
                db.Remove<BookingDetail>(db.Find<BookingDetail>(_ID));
                db.SaveChanges();
                res = true; // Indicate success
            }
            else
            {
                res = false; // Indicate failure
            }

            return res; // Return the result of the delete operation
        }
    }
}
