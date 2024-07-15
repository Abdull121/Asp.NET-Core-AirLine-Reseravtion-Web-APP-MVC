using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModel.Module;
using DAL.Module;


namespace BLL.Module
{
    // Business Logic Layer for Sign-Up operations
    public class SignUpBLL
{
    // Method to save sign-up information
    public async Task<int> SaveSignUp(SignUpformModel signUpModel)
    {
        return await new SignUpformDAL().SaveSignUp(signUpModel);
    }
}
}
