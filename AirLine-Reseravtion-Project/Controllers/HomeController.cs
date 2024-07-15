using AirLine_Reseravtion_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL.Db;
using BLL.Module;
using Microsoft.EntityFrameworkCore;
using System.Data;
using CommonModel.Module;
using AirLine_Reseravtion_Project.Db;

namespace AirLine_Reseravtion_Project.Controllers
{
    public class HomeController : Controller
    {
        airlinereservationDatabaseContext db = new airlinereservationDatabaseContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Destination()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

       




        // Action to display booking information
        //Read Booking DATA 

        [HttpGet]
        public async Task<IActionResult> BookingInfo()
        {
           
            List<BookingModel> data = await new BookingBLL().GetAllBooking();


            

            return View(data);
        }

        // Action to display the form for updating a booking
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int ID = 0)
        {
            BookingModel model = new BookingModel();
            if (ID == 0)
            {
                return View(model);
            }
            else
            {
                model = await new BookingBLL().GetBookingByID(ID);
                if (model == null)
                {
                    
                    return NotFound();
                }
                
                return View(model);
            }
        }



        


        [HttpGet]
        public IActionResult AddNewFlight()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Save Flight Booking  And Udate Flight Booking 
        // create and update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(BookingModel model)
        {


            try
            {

                    if (ModelState.IsValid)
                {



                    //set ticket prices

                    if (model.DepartureCity.ToLower() == "lahore" && model.Class.ToLower() == "economy")
                    {
                        model.Price = 250000;
                    }
                    else if (model.DepartureCity.ToLower() == "lahore" && model.Class.ToLower() == "premium Economy")
                    {
                        model.Price = 320000;
                    }
                    else if (model.DepartureCity.ToLower() == "lahore" && model.Class.ToLower() == "business")
                    {
                        model.Price = 499999;
                    }

                    //For Islamabad
                    else if (model.DepartureCity.ToLower() == "islamabad" && model.Class.ToLower() == "economy")
                    {
                        model.Price = 350000;
                    }

                    else if (model.DepartureCity.ToLower() == "islamabad" && model.Class.ToLower() == "premium Economy")
                    {
                        model.Price = 400000;
                    }
                    else if (model.DepartureCity.ToLower() == "islamabad" && model.Class.ToLower() == "business")
                    {
                        model.Price = 525000;
                    }
                    //For Karachi

                    else if (model.DepartureCity.ToLower() == "karachi" && model.Class.ToLower() == "economy")
                    {
                        model.Price = 150000;
                    }

                    else if (model.DepartureCity.ToLower() == "karachi" && model.Class.ToLower() == "business")
                    {
                        model.Price = 399999;
                    }

                    else
                    {
                        model.Price = 299999;
                    }


                    int res = await new BookingBLL().SaveBooking(model);
                    if (res == 3)
                    {
                        TempData["Message"] = "Failed to save booking. The booking already exists.";
                        TempData["MessageType"] = "error";
                        return View(model);
                    }

                    else if (res == 1)
                    {
                        TempData["Message"] = "Booking saved successfully.";
                        TempData["MessageType"] = "success";
                        return RedirectToAction("BookingInfo");
                    }
                    else if (res == 2)
                    {
                        TempData["Message"] = "Booking Updated successfully.";
                        TempData["MessageType"] = "success";
                        return RedirectToAction("BookingInfo");
                    }


                    else
                    {
                        TempData["Message"] = "Booking saved successfully.";
                        TempData["MessageType"] = "success";
                        return RedirectToAction("BookingInfo");
                    }


                }
            }
            
            catch (Exception exp)
            {
                TempData["Message"] = "An error occurred while saving the booking.";
                TempData["MessageType"] = "error";
                return NotFound();
            }


            return View(model);

        }


        // Delete Booking
        [HttpGet]
            public async Task<IActionResult> DeleteBooking(int ID)
        {
            if (ID != 0)
            {
                bool res = await new BookingBLL().DeleteBooking(ID);
                if (res)
                {

                    TempData["Message"] = "Booking deleted successfully.";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("BookingInfo");

                }
                else
                {
                    TempData["Message"] = "Failed to delete booking.";
                    TempData["MessageType"] = "error";
                    return NotFound();
                }


            }
            TempData["Message"] = "Invalid booking ID.";
            TempData["MessageType"] = "error";
            return NotFound();
        }


        //Add New Flight


       







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
