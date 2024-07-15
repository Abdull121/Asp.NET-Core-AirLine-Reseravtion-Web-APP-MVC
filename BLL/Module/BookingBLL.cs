using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModel.Module;
using DAL.Module;
using DAL.Db;

namespace BLL.Module
{
    public class BookingBLL
    {
        #region Booking

        // Method to get all bookings
        public async Task<List<BookingModel>> GetAllBooking()
        {
            List<BookingModel> lmList = new List<BookingModel>();
            List<BookingDetail> lmTBLList = await new BookingDAL().GetAllBooking(); // Get all bookings from DAL
            if (lmTBLList.Count > 0)
            {
                BookingModel model = null;
                foreach (var item in lmTBLList)
                {
                    if (item != null)
                    {
                        model = new BookingModel();

                        // Map properties from BookingDetail to BookingModel
                        model.FlightId = item.FlightId;
                        model.DepartureCity = item.DepartureCity;
                        model.ArrivalCity = item.ArrivalCity;
                        model.DepartureTime = item.DepartureTime;
                        model.ArrivalTime = item.ArrivalTime;
                        model.Class = item.Class;
                        model.Price = item.Price;
                        lmList.Add(model);
                    }
                }
            }
            return lmList; // Return the list of booking models
        }

        // Method to get a booking by ID
        public async Task<BookingModel> GetBookingByID(int ID)
        {
            BookingModel model = new BookingModel();
            BookingDetail tblmodel = await new BookingDAL().GetBookingByID(ID); // Get booking by ID from DAL
            if (tblmodel != null)
            {
                // Map properties from BookingDetail to BookingModel
                model.FlightId = tblmodel.FlightId;
                model.DepartureCity = tblmodel.DepartureCity;
                model.ArrivalCity = tblmodel.ArrivalCity;
                model.DepartureTime = tblmodel.DepartureTime;
                model.ArrivalTime = tblmodel.ArrivalTime;
                model.Class = tblmodel.Class;
                model.Price = tblmodel.Price;
            }
            return model; // Return the booking model
        }

        // Method to save a booking
        public async Task<int> SaveBooking(BookingModel model)
        {
            int res = 0;
            BookingDetail lrData = new BookingDetail();

            // Map properties from BookingModel to BookingDetail
            lrData.FlightId = model.FlightId;
            lrData.DepartureCity = model.DepartureCity;
            lrData.ArrivalCity = model.ArrivalCity;
            lrData.DepartureTime = model.DepartureTime;
            lrData.ArrivalTime = model.ArrivalTime;
            lrData.Class = model.Class;
            lrData.Price = model.Price;

            // Save booking through DAL and get the result
            res = await new BookingDAL().SaveBooking(lrData);

            return res; // Return the result
        }

        // Method to delete a booking by ID
        public async Task<bool> DeleteBooking(int _ID)
        {
            return await new BookingDAL().DeleteBooking(_ID); // Delete booking through DAL
        }

        #endregion
    }
}
