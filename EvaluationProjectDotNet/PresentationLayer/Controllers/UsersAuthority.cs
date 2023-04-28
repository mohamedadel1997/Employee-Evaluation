using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using ServiceLayer.Services;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthority : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public UsersAuthority(IEmployeeServices employeeServices)
        {
            this._employeeServices = employeeServices;
        }

        [HttpGet(nameof(Login))]
        public IActionResult Login(string email, string password)
        {
            var employee = _employeeServices.FindEmployeeByEmail(email, password);
            if (employee == null)
                return BadRequest("user doesn't exist");
            else
                return Ok(employee);
        }

        [HttpPost(nameof(SignUp))]
        public IActionResult SignUp(EmployeeModel employee)
        {

            _employeeServices.CreateEmployee(employee);
            return Ok("user Created Successfully");
        }

    }
}

