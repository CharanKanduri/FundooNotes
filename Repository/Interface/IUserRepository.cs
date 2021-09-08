using FandooNotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FandooNotes.Repository.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        bool Login(LoginModel userData);
        bool ForgetPassword(string email);

        bool ResetPassword(ResetPasswordModel resetPasswordData);
        string GenerateToken(string email);
    }
}
