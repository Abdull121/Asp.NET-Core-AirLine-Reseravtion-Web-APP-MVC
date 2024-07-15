using CommonModel.Module;
using Microsoft.AspNetCore.Mvc;

namespace AirLine_Reseravtion_Project.Controllers
{
    public class UserLogin : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginFormModel());
        }

        [HttpPost]
        public IActionResult Login(LoginFormModel model)
        {
            if (ModelState.IsValid)
            {

                return View(model);
            }

            return View(model);
        }
    }
}
