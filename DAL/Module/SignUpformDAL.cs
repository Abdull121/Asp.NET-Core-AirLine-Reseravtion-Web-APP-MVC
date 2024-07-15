using DAL.Db;
using DAL.Module;
using System;
using System.Linq;
using System.Threading.Tasks;
using AirLine_Reseravtion_Project.Db;
using CommonModel.Module;
namespace DAL.Module
{
   
    public class SignUpformDAL
    {
        private readonly airlinereservationDatabaseContext _context;

        // Constructor to initialize the database context
        public SignUpformDAL()
        {
            _context = new airlinereservationDatabaseContext();
        }

        #region SignUp

        // Method to save sign-up information
        public async Task<int> SaveSignUp(SignUpformModel signUpModel)
        {
            bool saveSuccessfully = false;

            // Create a new SignUp entity from the model
            var signUpEntity = new SignUp
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                Password = signUpModel.Password,
                ConfirmPassword = signUpModel.ConfirmPassword,
                TermsAccepted = signUpModel.TermsAccepted
            };

            // Add the new entity to the context
            _context.SignUps.Add(signUpEntity);
            await _context.SaveChangesAsync(); // Save changes to the database
            saveSuccessfully = true;

            if (saveSuccessfully)
            {
                return 1; // Indicate success
            }
            else
            {
                return 0; // Indicate failure
            }
        }

        #endregion
    }
}