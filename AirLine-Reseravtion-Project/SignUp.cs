using System;
using System.Collections.Generic;

#nullable disable

namespace AirLine_Reseravtion_Project
{
    public partial class SignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool TermsAccepted { get; set; }
    }
}
