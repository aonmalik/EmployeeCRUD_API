using Contracts;
using Domain;
using Domain.Repositories;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        //get all employees
        [HttpGet("getall")]
        
        public IActionResult GetAllEmployees()
        {
            if (User.Identity.IsAuthenticated)
                return Ok(_serviceManager.employeeService.getAll());
            else
                return Unauthorized("You are not Authorized!");

        }
        //get employee by id
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_serviceManager.employeeService.GetEmployeeById(id) ); 
        }
        //add employee
        [HttpPost("add")]
        public IActionResult AddEmployeeRecord(EmployeeDTO emp)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("1"))
                return Ok(_serviceManager.employeeService.AddEmployee(emp));
            return Unauthorized("You are not authorized to add employee!");
        }
        //remove employee
        [HttpDelete("remove")]
        public IActionResult DeleteEmployee(int Id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("1"))
                return Ok(_serviceManager.employeeService.RemoveEmployee(Id));
            return Unauthorized("You are not authorized to delete employee!");
        }
        //update employee
        [HttpPut("update")]
        public IActionResult UpdateEmployee(EmployeeDTO empdto)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("1"))
                return Ok(_serviceManager.employeeService.UpdateEmployee(empdto));
            return Unauthorized("You are not authorized to update employee!");
        }
    }
}
