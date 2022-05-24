using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeeController:ControllerBase
    {
        private IEmployeeService _empService;
        public EmployeeController(IEmployeeService empservice)
        {
            _empService = empservice;
        }
        //[AllowAnonymous]

        //public IActionResult Login(string UserName, string Password)
        //{
        //   var user=_e
        //}

 

        //get all employees
        [HttpGet("getall")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_empService.getAll());

        }
        //get employee by id
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {

            return Ok(_empService.GetEmployeeById(id)) ; 
        }
        //add employee
        [HttpPost("add")]
        public IActionResult AddEmployeeRecord(EmployeeDTO empdto)
        {
           return Ok(_empService.AddEmployee(empdto));
        }
        //remove employee
        [HttpDelete("remove")]
        public IActionResult DeleteEmployee(int Id)
        {
            return Ok(_empService.RemoveEmployee(Id));
        }
        //update employee
        [HttpPut("update")]
        public IActionResult UpdateEmployee(EmployeeDTO empdto)
        {
            return Ok(_empService.UpdateEmployee(empdto));
        }
    }
}
