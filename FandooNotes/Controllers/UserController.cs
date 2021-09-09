using System;
using Microsoft.AspNetCore.Mvc;
using FandooNotes.Managers.Interface;
using FandooNotes.Models;
using Models;
using StackExchange.Redis;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace FandooNotes.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        private readonly ILogger<UserController> logger;

        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                string SessionFirstName = "";
                string SessionEmail = "";
                bool result = this.manager.Register(userData);
                if (result == true)
                {
                    this.logger.LogInformation($" A New Register '{userData.Email}' is Successfull Added ");
                    HttpContext.Session.SetString(SessionFirstName, userData.FirstName);
                    HttpContext.Session.SetString(SessionEmail, userData.Email);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "New User Added Successfully !!" });
                }
                else
                {
                    this.logger.LogInformation($" Register API Fails for : {userData.Email}");
                    return this.Ok(new ResponseModel<string>() { Status = false, Message = "UnSuccessfully !!" });
                }
            }
            catch (Exception e)
            {
                this.logger.LogInformation($"Exception Rised for Register : {e.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = e.Message });
            }
        }

        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel loginData)
        {
            try
            {
                bool message = this.manager.Login(loginData);

                if (message == true)
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("FirstName");
                    string lastName = database.StringGet("LastName");
                    int userId = Convert.ToInt32(database.StringGet("UserId"));

                    this.logger.LogInformation($"{loginData.Email} login successfull");
                    string tokenString = this.manager.GenerateToken(loginData.Email);
                    return this.Ok(new { Status = true, Message = "Successfully logged for user " + loginData.Email, token = tokenString });
                }
                else
                {
                    this.logger.LogInformation($" Login API Fails for : {loginData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Login : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/forgetpassword")]

        public IActionResult ForgetPassword(string email)
        {
            try
            {
                bool result = this.manager.ForgetPassword(email);
                if (result == true)
                {
                    this.logger.LogInformation($" Forgot Password Mail send to {email}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration Successful" });
                }
                else
                {
                    this.logger.LogInformation($" Forgot Password API Fails for : {email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration UnSuccessful" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Forgot Password : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPasswordData)
        {
            try
            {
                bool result = this.manager.ResetPassword(resetPasswordData);
                if (result == true)
                {
                    this.logger.LogInformation($" Reset Password is done for : {resetPasswordData.Email}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reset Successfull !" });
                }
                else
                {
                    this.logger.LogInformation($" Reset Password API Fails for : {resetPasswordData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Unsuccessfull!.Invalid ConfirmNewPassword or Invalid Email!" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Reset Password : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
