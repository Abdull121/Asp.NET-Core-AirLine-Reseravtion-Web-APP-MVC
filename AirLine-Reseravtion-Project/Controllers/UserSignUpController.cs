using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Module;
using BLL.Module;

namespace AirLine_Reseravtion_Project.Controllers
{
    public class UserSignUpController : Controller
    {
        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpformModel model)
        {
            if (ModelState.IsValid)
            {
                // Call BLL method to save sign-up information
                int result = await new SignUpBLL().SaveSignUp(model);
                if (result == 1)
                {
                    TempData["Message"] = "Sign up successful!";

                    // Redirect to BookingInfo action method in the Home controller
                    return RedirectToAction("BookingInfo", "Home");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");
                }
            }

            // If validation fails or an error occurs, redisplay the form
            return View(model);
        }




    }
}
