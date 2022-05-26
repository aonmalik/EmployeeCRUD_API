using Contracts;
using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public LoginController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("login")]
        //dfhfghdfgjfhjghg
        public IActionResult Login(string username,string password)
        {
           var user = _employeeService.GetEmployeeByIdandPassword(username, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.EmployeeId.ToString()),
                    new Claim(ClaimTypes.Name,user.EmployeeName),
                    new Claim(ClaimTypes.Email,user.EmployeeEmail),
                    new Claim(ClaimTypes.StreetAddress,user.EmployeeAddress),
                    new Claim(ClaimTypes.Role,user.UserTypeId.ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties { IsPersistent = true });
                return Ok("You are logged In!");

            }
            else
                return Unauthorized("Login Failed!");
        }
        [HttpGet("logout")]
        public  IActionResult Logout()
        {
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("You are logged out!");
            
        }

    }
}
